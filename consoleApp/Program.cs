using static System.Console;
using TranslateLiblary;
internal class Program
{
    private static void Main()
    {
        Translate tutor = new();

        while (true)
        {
            CursorVisible = true;
            var checkWord = tutor.GetRandomEngWord() ?? default;
            Write("Как переводится слово {0} ?: ", checkWord);
            var answer = ReadLine() ?? "пустая строка";

            if (tutor.CheckWord(checkWord, answer))
            {
                WriteLine("Правильно");
            }
            else
            {
                var currectAnswer = tutor.Translating(checkWord);
                WriteLine("Неверно, слово {0} переводится как {1}.", checkWord, currectAnswer);
            }
            CursorVisible = false;
            ReadKey();
            Clear();
        }
    }
}