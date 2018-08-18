using System;

public class Robot
{
    public string Name { get; private set; }
    private readonly Random _random;

    public Robot()
    {
        _random = new Random();
        Name = ThreeRandomLetters() + ThreeRandomNumbers();
    }

    public void Reset()
    {
        Name = ThreeRandomLetters() + ThreeRandomNumbers();
    }

    public string ThreeRandomLetters()
    {
        string result = "";
        result += RandomAlphabetCharacter();
        result += RandomAlphabetCharacter();
        result += RandomAlphabetCharacter();

        return result;
    }

    public string ThreeRandomNumbers()
    {
        string result = "";
        result += RandomZeroToNineNumber();
        result += RandomZeroToNineNumber();
        result += RandomZeroToNineNumber();

        return result;
    }

    private char RandomAlphabetCharacter()
    {
        return (char)_random.Next(65, 90);
    }

    public int RandomZeroToNineNumber()
    {
        return _random.Next(0, 9);
    }
}