using System.Text.RegularExpressions;

public class Word 
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool isHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        string result;

        if (_isHidden)
        {
            Regex reg = new Regex(".");
            result = reg.Replace(_text, "_");
        }
        else
        {
            result = _text;
        }
        
        return result;
    }

}