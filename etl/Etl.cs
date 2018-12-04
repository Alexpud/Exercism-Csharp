using System;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> returnDictionary = new Dictionary<string, int>();
        foreach (var key in old.Keys)
        {
            foreach(var letter in old[key])
            {
                returnDictionary.Add(letter.ToLower(), key);
            }
        }
        return returnDictionary;
    }
}