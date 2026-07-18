using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a full scripture: a reference plus the words of its text.
/// Knows how to hide random words and how to display itself.
/// </summary>
public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private static readonly Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(w => new Word(w))
            .ToList();
    }

    /// <summary>
    /// Hides up to <paramref name="numberToHide"/> words that are not already hidden,
    /// chosen at random. If fewer than that many words remain visible, all of them are hidden.
    /// </summary>
    public void HideRandomWords(int numberToHide)
    {
        List<Word> hidableWords = _words.Where(w => !w.IsHidden()).ToList();

        if (hidableWords.Count == 0)
        {
            return;
        }

        int amountToHide = Math.Min(numberToHide, hidableWords.Count);

        for (int i = 0; i < amountToHide; i++)
        {
            int index = _random.Next(hidableWords.Count);
            hidableWords[index].Hide();
            hidableWords.RemoveAt(index);
        }
    }

    /// <summary>
    /// Returns the reference and the text (with any hidden words shown as underscores)
    /// formatted for display in the console.
    /// </summary>
    public string GetDisplayText()
    {
        string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}{Environment.NewLine}{wordsText}";
    }

    /// <summary>
    /// True once every word in the scripture has been hidden.
    /// </summary>
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}