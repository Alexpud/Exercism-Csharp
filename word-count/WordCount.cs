using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
    	var matches = Regex.Matches(phrase.ToLower(), @"(\w+('\w)?)+");
		Dictionary<string, int> wordByFrequency = new Dictionary<string, int>();
		foreach(Match match in matches)
		{
			if (wordByFrequency.TryGetValue(match.Value, out var frequency))
			{
				wordByFrequency[match.Value]++;
			}
			else
			{
				wordByFrequency[match.Value] = 1;
			}
		}
    	return wordByFrequency; 
    }
}