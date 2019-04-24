using System;
using System.Linq;
using System.Collections.Generic;

public static class MatchingBrackets
{
    private static readonly Dictionary<char, char> leftRightBracketDict = 
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
            foreach(var leftBracket in leftRightBracketDict.Keys)
            {
                bool isLeftBracket = leftBracket == letter;
                if (isLeftBracket)
                {
                    bracketStack.Push(letter);
                    break;
                }

                bool isRightBracket = leftRightBracketDict[leftBracket] == letter;
                if (isRightBracket)
                {
                    if (TryPop(bracketStack, leftBracket))
                    {
                        continue;
                    }
                    return false;
                }
            }
    	}
    	return bracketStack.Count == 0;
    }

    private static bool TryPop(Stack<char> bracketStack, char bracket)
    {
        if (bracketStack.Count > 0 && bracketStack.Peek() == bracket)
        {
            bracketStack.Pop();
            return true;
        }
        return false;
    }
}
