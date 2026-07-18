/// <summary>
/// Represents a single word inside a scripture, and whether it is currently hidden.
/// </summary>
public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    /// <summary>
    /// Hides this word so that it is displayed as underscores.
    /// </summary>
    public void Hide()
    {
        _isHidden = true;
    }

    /// <summary>
    /// Reveals this word again.
    /// </summary>
    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    /// <summary>
    /// Returns the word as it should be displayed: the real text if visible,
    /// or a run of underscores (one per letter) if hidden.
    /// </summary>
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }

        return _text;
    }
}