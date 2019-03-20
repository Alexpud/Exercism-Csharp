using System;
using System.Linq;

public static class Isogram
{
    private const int letterAHexValue = 97; 
    private const int letterZHexValue = 122; 
    public static bool IsIsogram(string word)
    {
        if (String.IsNullOrEmpty(word))
        {
            return true;
        }

        word = word.ToLower();
        int[] dictionary = new int[26];
        for (int i = 0; i < word.Length; i++)
        {
            bool isLetterNotInAlphabet = word[i] >= letterAHexValue && word[i] <= letterZHexValue;
            if (isLetterNotInAlphabet)
            {
                dictionary[word[i] % letterAHexValue]++;
                bool isLetterRepeated = dictionary[word[i] % letterAHexValue] > 1;
                if (isLetterRepeated)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
