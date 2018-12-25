using System;
using System.Collections.Generic;

public static class ScrabbleScore
{
    private static readonly Dictionary<string, int> dict = new Dictionary<string, int>()
    {
        {"A",  1},
        {"B",  3},
        {"C",  3},
        {"D",  2},
        {"E",  1},
        {"F",  4},
        {"G",  2},
        {"H",  4},
        {"I",  1},
        {"J",  8},
        {"K",  5},
        {"L",  1},
        {"M",  3},
        {"N",  1},
        {"O",  1},
        {"P",  3},
        {"Q",  10},
        {"R",  1},
        {"S",  1},
        {"T",  1},
        {"U",  1},
        {"V",  4},
        {"W",  4},
        {"Y",  4},
        {"X",  8},
        {"Z",  10}
    };

    public static int Score(string input)
    {
        int sum = 0;
        foreach(var letter in input.ToUpper())
        {
            sum += dict[letter.ToString()];
        }
        return sum;
    }
}