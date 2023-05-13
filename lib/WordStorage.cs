using static System.Console;
namespace TranslateLiblary;

public class WordStorage
{
    private const string _path = "wordstorage.txt";
    public Dictionary<string, string> GetAllWords()
    {
        try
        {
            Dictionary<string, string> dict = new();
            if (File.Exists(_path))
            {

                foreach (var line in File.ReadAllLines(_path))
                {
                    var words = line.Split('|');

                    if (words.Length == 2)
                        dict.Add(words[0], words[1]);
                }
            }
            return dict;
        }
        catch (Exception ex)
        {
            WriteLine($"Не удалось считать файл со словарем.");
            WriteLine(ex);
            return new Dictionary<string, string>();
        }
    }
    public void AddWords(string eng, string rus)
    {
        try
        {
            using (var writer = new StreamWriter(_path, true))
                writer.WriteLine($"{eng}|{rus}");
        }
        catch (Exception ex)
        {
            WriteLine($"Не удалось добавить слово {eng} в словарь.");
            WriteLine(ex);
        }
    }
}
