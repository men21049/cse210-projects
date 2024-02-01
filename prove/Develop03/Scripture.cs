class Scripture
{
    private string _text;
    Reference _reference;
    private List<Words> _words = new List<Words>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _text = text;
        string[] textSplit = _text.Split(' ');
        foreach (string word in textSplit)
        {
            Words newW = new Words(word);
            _words.Add(newW);
        }
    }

    public void SetText(string text)
    {
        _text = text;
    }

    public string GetText()
    {
        return _text;
    }

    public string GetDisplayText()
    {
        List<string> _fullText = new List<string>();
        foreach (Words wor in _words)
        {
            _fullText.Add(wor.GetDisplayText());
        }
        return _reference.GetDisplayText() + string.Join(" ", _fullText);
    }
}