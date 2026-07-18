using System;


public class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _verse;
    private readonly int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

      public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        if (endVerse < startVerse)
        {
            throw new ArgumentException("endVerse cannot be smaller than startVerse.");
        }

        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }


    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }

        return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}