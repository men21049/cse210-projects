class Words
{
    private string _text;
    private bool _isHidden;

    public Words(string text)
    {
        _text = text;
    }

    public string GetDisplayText()
    {
        return _text;
    }
}