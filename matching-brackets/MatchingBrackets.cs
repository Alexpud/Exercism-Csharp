using System;
using System.Linq;
using System.Collections.Generic;

public static class MatchingBrackets
{
    private static readonly Dictionary<char, char> leftRightBracketsDict = 
            new Dictionary<char, char>()
            {
                {'[', ']'},
                {'(', ')'}, 
                {'{', '}'},
            };
    public static bool IsPaired(string input)
    {
        Stack<char> bracketStack = new Stack<char>();
    	foreach(var letter in input)
    	{
            foreach(var leftBracket in leftRightBracketsDict.Keys)
            {
                bool isLeftBracket = leftBracket == letter;
                bool isRightBracket = leftRightBracketsDict[leftBracket] == letter;
                if (isLeftBracket)
                {
                    bracketStack.Push(letter);
                    break;
                }

                if (isRightBracket)
                {
                    if (bracketStack.Count > 0 && bracketStack.Peek() == leftBracket)
                    {
                        bracketStack.Pop();
                        break;
                    }
                    else 
                    {
                        return false;
                    }
                }
            
            }
    	}
    	return bracketStack.Count == 0;
    }
}
