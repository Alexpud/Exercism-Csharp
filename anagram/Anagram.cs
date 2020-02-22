using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
	private readonly Dictionary<char, int> _baseWordLettersByFrequency;
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
    		if (potentialMatch.ToLower() == _baseWord.ToLower()) 
    			continue;

    		var potentialMatchFrequency = GetLetterByFrequency(potentialMatch);
    		if (IsAnagramToBaseWord(potentialMatchFrequency))
    			result.Add(potentialMatch);
    	}
    	return result.ToArray();
    }

    private Dictionary<char, int> GetLetterByFrequency(string word) 
    {
    	return word.ToLower().GroupBy(letter => letter)
    		.ToDictionary(x => x.Key, y => y.Count());;
    }

    private bool IsAnagramToBaseWord(Dictionary<char, int> letterByFrequency)
    {
    	bool differentLettersInWords = letterByFrequency.Count() != _baseWordLettersByFrequency.Count();
    	if (differentLettersInWords)
    		return false;
    	
    	foreach(var key in _baseWordLettersByFrequency.Keys)
    	{
    		bool letterIsNotPresent = !letterByFrequency.TryGetValue(key, out var frequency);
	    	if (letterIsNotPresent)
	    		return false;
	
    		bool letterFrequencyIsDifferent = letterByFrequency[key] != _baseWordLettersByFrequency[key];
    		if (letterFrequencyIsDifferent)
    			return false;
    	}
    	return true;
    }
}