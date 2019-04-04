using System;

public static class RotationalCipher
{
    private enum ASCIILetterValue
    {
        a = 97,
        z = 122,
        A = 65,
        Z = 90
    }
    
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
        int shiftedLetterASCIIValue = ((int)letter + shiftKey);
        if (shiftedLetterASCIIValue > (int)ASCIILetterValue.z)
        {
            shiftedLetterASCIIValue = (int)ASCIILetterValue.a + 
                (shiftedLetterASCIIValue - ((int)ASCIILetterValue.z + 1));
        }
        return Convert.ToChar(shiftedLetterASCIIValue);
    }

    private static char RotateUpperCaseLetter(char letter, int shiftKey)
    {
        int shiftedLetterASCIIValue = ((int)letter + shiftKey);
        if (shiftedLetterASCIIValue > (int)ASCIILetterValue.Z)
        {
            shiftedLetterASCIIValue = (int)ASCIILetterValue.A + 
                (shiftedLetterASCIIValue - ((int)ASCIILetterValue.Z + 1));
        }

        return Convert.ToChar(shiftedLetterASCIIValue);
    }
}