using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
	private Dictionary<char, int> _baseWordLettersByFrequency;
	private readonly string _baseWord;
    public Anagram(string baseWord)
    {
    	_baseWord = baseWord;
    	_baseWordLettersByFrequency = GetLetterByFrequency(baseWord);
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
    	var result = new List<string>();
    	foreach(var potentialMatch in potentialMatches)
    	{
    		if (potentialMatch.ToLower() == _baseWord.ToLower()) continue;
    		var potentialMatchFrequency = GetLetterByFrequency(potentialMatch);

			bool shouldAdd = true;
    		foreach(var key in _baseWordLettersByFrequency.Keys)
    		{
    			bool differentCharactersInWords = potentialMatchFrequency.Count() != _baseWordLettersByFrequency.Count();
    			if (differentCharactersInWords)
    			{
    				shouldAdd = false;
    				break;
    			}

    			bool characterIsNotPresent = !potentialMatchFrequency.TryGetValue(key, out var frequency);
    			if (characterIsNotPresent)
    			{
    				shouldAdd = false;
    				break;
    			}

    			bool characterFrequencyIsDifferent = potentialMatchFrequency[key] != _baseWordLettersByFrequency[key];
    			if (characterFrequencyIsDifferent)
    			{
    				shouldAdd = false;
    				break;
    			}
    		}
    		if (shouldAdd)
    			result.Add(potentialMatch);
    	}
    	return result.ToArray();
    }

    private Dictionary<char, int> GetLetterByFrequency(string word) 
    {
    	return word.ToLower().GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());;
    }
}