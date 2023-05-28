using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var botClient = new TelegramBotClient("6162904953:AAHGUmaayfABF48j1V8VFGbPGVTnjRGBEZs");

        using CancellationTokenSource cts = new();

        // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
        ReceiverOptions receiverOptions = new()
        {
            AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
        };

        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        var me = await botClient.GetMeAsync();

        Console.WriteLine($"Начал прослушку бота @{me.Username}");
        Console.ReadLine();

        // Send cancellation request to stop bot
        cts.Cancel();
    }
    private async static Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
    CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message && update?.Message?.Text != null)
        {
            await HandleMessage(botClient, update.Message);
            return;
        }
    }

    private async static Task HandleMessage(ITelegramBotClient botClient, Message message)
    {
        var nameUser = message.Chat.Username;
        ReplyKeyboardMarkup keyboard = new(new[]
        {
            new KeyboardButton[] {"Проверить", "Добавить слово"},
        })
        {
            ResizeKeyboard = true
        };

        if (message.Text == "/start")
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, $"Привет {nameUser}", replyMarkup: keyboard);
            return;
        }
        if (message.Text == "Проверить")
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, $"Проверка перевода не готова", replyMarkup: keyboard);
            return;
        }
        if (message.Text == "Добавить слово")
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, $"Добавление слов не готово", replyMarkup: keyboard);
            return;
        }

    }


    static Task HandlePollingErrorAsync(ITelegramBotClient botClient,
    Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}