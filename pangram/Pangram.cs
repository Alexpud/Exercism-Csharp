using System;

public static class Pangram
{
    private const int LowerCaseLetterAsciiMaxValue = 97;
    public static bool IsPangram(string input)
    {
        if (String.IsNullOrEmpty(input))
        {
            return false;
        }

        // From a to z
        var lettersFrequency = CountFrequencyOfLetters(input);
        for(int i = 0; i < lettersFrequency.Length; i ++)
        {
            if (lettersFrequency[i] == 0)
            {
                return false;
            }
        }
        return true;
    }

    private static int[] CountFrequencyOfLetters(string input)
    {
        int [] lettersFrequency = new int[26];
        foreach(var letter in input)
        {
            if (!Char.IsDigit(letter) && Char.IsLetter(letter))
            {
                int position = LetterPositionInFrequencyArray(letter);
                lettersFrequency[position]++;
            }
        }
        return lettersFrequency;
    }

    private static int LetterPositionInFrequencyArray(char letter)
    {
        var lowerCaseLetter = letter.ToString().ToLower();
        int letterAsciiValue = (int)lowerCaseLetter[0];
        // Mapping it to frequency array of 27 positions
        return letterAsciiValue - LowerCaseLetterAsciiMaxValue;
    }
}
