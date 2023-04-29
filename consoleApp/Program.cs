using static System.Console;
using TranslateLiblary;
internal class Program
{
    private static void Main()
    {
        Translate tutor = new();
        tutor.AddWords("dog", "собака");
        tutor.AddWords("cat", "кошка");
        tutor.AddWords("door", "дверь");

        while (true)
        {
            var checkWord = tutor.GetRandomEngWord();
            Write("Как переводится слово {0}?: ", checkWord);
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

            Clear();
        }
    }
}