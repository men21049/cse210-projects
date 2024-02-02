class Scripture
{
    private string _text;
    private int _wordsHiddenCounter;
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
            newW.Show();
            _words.Add(newW);

        }
    }

    public void SetHiddenWordCounter()
    {
        _wordsHiddenCounter += 1;
    }

    public int GetHiddenWordCounter()
    {
        return _wordsHiddenCounter;
    }

    public void SetText(string text)
    {
        _text = text;
    }

    public string GetText()
    {
        return _text;
    }

    public void HideRandomWords(int numberToHide)
    {
        if (!_words[numberToHide].IsHidden())
        {
            _words[numberToHide].Hide();
            SetHiddenWordCounter();
        }

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

    public int NumberWords()
    {
        return _words.Count;
    }

    public bool IsWordHidden(int idx)
    {
        return _words[idx].IsHidden();
    }
    public bool IscompletelyHidden()
    {
        if (NumberWords() == GetHiddenWordCounter())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}