using System;
using System.Linq;
using System.Collections.Generic;

public static class MatchingBrackets
{
    private const string rightSideSymbols = "])}";
    private const string leftSideSymbols = "[({";
    public static bool IsPaired(string input)
    {
        Stack<string> rightSideElements = new Stack<string>();
        Stack<string> leftSideElements = new Stack<string>();
    	foreach(var letter in input)
    	{
            if (Char.IsWhiteSpace(letter))
            {
                continue;
            }

            if (leftSideSymbols.Contains(letter.ToString()))
            {
                leftSideElements.Push(letter.ToString());
            }
            if (rightSideSymbols.Contains(letter.ToString()))
            {
                rightSideElements.Push(letter.ToString());
            }
    		
            switch(letter)
    		{
    			case ']':
    				if (leftSideElements.Count > 0 && leftSideElements.Peek() == "[")
    				{
    					RemoveRecentPairOfMatchingBrackets(leftSideElements, rightSideElements);
    				}
    				else 
    				{
    					return false;
    				}
    				break;
    			case '}':
    				if (leftSideElements.Count > 0 && leftSideElements.Peek() == "{")
    				{
    					RemoveRecentPairOfMatchingBrackets(leftSideElements, rightSideElements);
    				}
    				else 
    				{
    					return false;
    				}
    				break;

    			case ')':
    				if (leftSideElements.Peek() == "(")
    				{
    					RemoveRecentPairOfMatchingBrackets(leftSideElements, rightSideElements);
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

    private static void RemoveRecentPairOfMatchingBrackets(Stack<string> leftSideElements,
        Stack<string> rightSideElements)
    {
        leftSideElements.Pop();
        rightSideElements.Pop();
    }
}
