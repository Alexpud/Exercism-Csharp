using System;

public static class RotationalCipher
{
    private const int LetteraASCIIValue = 97;
    private const int LetterzASCIIValue = 122;
    private const int LetterAASCIIValue = 65;
    private const int LetterZASCIIValue = 90;
    
    public static string Rotate(string text, int shiftKey)
    {
        string rotatedText = "";
        foreach (var letter in text)
        {
            if (char.IsLetter(letter))
            {
                rotatedText += RotateLetter(letter, shiftKey);
            }
            else
            {
                rotatedText += letter;
            }
        }
        return rotatedText;
    }

    private static char RotateLetter(char letter, int shiftKey)
    {
        if (char.IsLower(letter))
        {
            return RotateLowerCaseLetter(letter, shiftKey);
        }

        return RotateUpperCaseLetter(letter, shiftKey);
    }

    private static char RotateLowerCaseLetter(char letter, int shiftKey)
    {
        int letterInt = ((int)letter + shiftKey);
        if (letterInt > LetterzASCIIValue)
        {
            letterInt = LetteraASCIIValue + (letterInt - (LetterzASCIIValue + 1));
        }
        return Convert.ToChar(letterInt);
    }

    private static char RotateUpperCaseLetter(char letter, int shiftKey)
    {
        int letterInt = ((int)letter + shiftKey);
        if (letterInt > LetterZASCIIValue)
        {
            letterInt = LetterAASCIIValue + (letterInt - (LetterZASCIIValue + 1));
        }

        return Convert.ToChar(letterInt);
    }
}