using System;

public static class RotationalCipher
{
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
        (char minChar, char maxChar) = GetMinMaxLetters(char.IsUpper(letter));
        int shiftedLetterASCIIValue = ((int)letter + shiftKey);
        if (shiftedLetterASCIIValue > maxChar)
        {
            shiftedLetterASCIIValue = minChar + (shiftedLetterASCIIValue - (maxChar + 1));
        }
        
        return Convert.ToChar(shiftedLetterASCIIValue);
    }

    private static (char, char) GetMinMaxLetters(bool areUpperCase)
    {
        return areUpperCase ? ('A', 'Z') : ('a', 'z');
    }
}