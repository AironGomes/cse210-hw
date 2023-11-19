public class Scripture 
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string scriptureText)
    {
        _reference = reference;
        string[] textArray = scriptureText.Split(' ');
        foreach (var text in textArray) {
            Word word = new Word(text);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int loop = 0;

        while (loop < numberToHide) {
            List<Word> visibleWords = _words.Where(word => !word.isHidden()).ToList();
            if (visibleWords.Count == 0)
            {
                break;
            }

            Random randomGenerator = new Random();
            int position = randomGenerator.Next(0, visibleWords.Count()-1);
            Word selectedWord = visibleWords[position];

            _words[_words.IndexOf(selectedWord)].Hide();
            loop++;
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = "";

        foreach (var word in _words)
        {
            if (_words.IndexOf(word) > 0)
            {
                scriptureText += $" {word.GetDisplayText()}";
            }
            else
            {
                scriptureText += word.GetDisplayText();
            }
        }
        
        return $"{_reference.GetDisplayText()} {scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.isHidden());
    }

}