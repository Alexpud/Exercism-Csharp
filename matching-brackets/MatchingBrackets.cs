using System;
using System.Linq;
using System.Collections.Generic;

public static class MatchingBrackets
{
    private static List<string> leftSideElements = new List<string>();
    private static List<string> rightSideElements = new List<string>();

    public static bool IsPaired(string input)
    {
    	foreach(var letter in input)
    	{
    		MatchLetterToABracket(letter.ToString());
    		switch(letter)
    		{
    			case ']':
    				if (leftSideElements.LastOrDefault() == "[")
    				{
    					RemoveRecentPairOfMatchingBrackets();
    				}
    				else 
    				{
    					return false;
    				}
    				break;
    			case '}':
    				if (leftSideElements.LastOrDefault() == "{")
    				{
    					RemoveRecentPairOfMatchingBrackets();
    				}
    				else 
    				{
    					return false;
    				}
    				break;

    			case ')':
    				if (leftSideElements.LastOrDefault() == "(")
    				{
    					RemoveRecentPairOfMatchingBrackets();
    				}
    				else 
    				{
    					return false;
    				}
    				break;
    		}
    	}
    	return leftSideElements.Count() == rightSideElements.Count();
    }

    private static void MatchLetterToABracket(string bracket)
    {
    	if (string.IsNullOrEmpty(bracket))
    	{
    		return;
    	}
    	string leftSideSymbols = "[({";
    	string rightSideSymbols = "])}";
    	if (leftSideSymbols.Contains(bracket))
    	{
    		leftSideElements.Add(bracket);
    	}
    	if (rightSideSymbols.Contains(bracket))
    	{
    		rightSideElements.Add(bracket);
    	}
    }

    private static void RemoveRecentPairOfMatchingBrackets()
    {
    	leftSideElements.RemoveAt(leftSideElements.Count() - 1);
    	rightSideElements.RemoveAt(rightSideElements.Count() - 1);
    }
}
