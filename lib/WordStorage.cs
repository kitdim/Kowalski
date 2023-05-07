namespace TranslateLiblary;

public class WordStorage
{
    private const string _path = "wordstorage.txt";
    public Dictionary<string, string> GetAllWords()
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
    public void AddWords(string eng, string rus)
    {
        using (var writer = new StreamWriter(_path, true))
            writer.WriteLine($"{eng}|{rus}");
    }
}
