using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] parts = text.Split(' ');
        foreach (string word in parts)
        {
            _words.Add(new Word(word));
        }
    }
    public void Display()
    {
        Console.WriteLine(_reference.GetReference());
        Console.WriteLine();
        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine("\n");
    }
    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        int hiddenCount = 0;
        while (hiddenCount < count && !IsFullyHidden())
        {
            int index = rand.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }
    public bool IsFullyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
    public string GetReferenceText()
    {
        return _reference.GetReference();
    }
}