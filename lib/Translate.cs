namespace TranslateLiblary;
public class Translate
{
    /// <summary>
    /// Словарь английских слов с переводом на русский
    /// </summary>

    private WordStorage _storage = new();
    private Dictionary<string, string>? _dict;

    public Translate()
    {
        _dict = _storage.GetAllWords();
    }

    /// <summary>
    /// Случайное число
    /// </summary>
    private Random _rnb = new();

    /// <summary>
    /// Добавить английское слово и его перевод
    /// </summary>
    /// <param name="eng">английское слово</param>
    /// <param name="rus">русское слово</param>
    public void AddWords(string eng, string rus)
    {
        if (!_dict.ContainsKey(eng))
        {
            _dict?.Add(eng, rus);
            _storage.AddWords(eng, rus);
        }
    }

    /// <summary>
    /// Проверка перевода английского слова
    /// </summary>
    /// <param name="eng">английское слово</param>
    /// <param name="rus">русское слово</param>
    /// <returns>Проверку перевода</returns>
    public bool CheckWord(string eng, string rus)
    {
        var answer = _dict?[eng];
        return answer?.ToLower() == rus.ToLower();
    }

    /// <summary>
    /// Перевод англиского слова на русский язык
    /// </summary>
    /// <param name="eng">английское слово</param>
    /// <returns>Перевод слова</returns>
    public string? Translating(string eng)
    {
        return _dict.ContainsKey(eng) ? _dict[eng] : null;
    }

    /// <summary>
    /// Получение случайного английского слова из словаря
    /// </summary>
    /// <returns>английское слово</returns>
    public string? GetRandomEngWord()
    {
        var randomWord = _rnb.Next(0, _dict.Count());
        var keys = new List<string>(_dict.Keys);

        return keys[randomWord];
    }
}
