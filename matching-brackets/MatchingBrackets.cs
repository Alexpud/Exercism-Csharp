using System;
using System.Linq;
using System.Collections.Generic;

public static class MatchingBrackets
{
    private const string rightSideSymbols = "])}";
    private const string leftSideSymbols = "[({";
    public static bool IsPaired(string input)
    {
        Stack<string> singleStack = new Stack<string>();
    	foreach(var letter in input)
    	{
            if (Char.IsWhiteSpace(letter))
            {
                continue;
            }

            if (leftSideSymbols.Contains(letter.ToString()))
            {
                singleStack.Push(letter.ToString());
                continue;
            }

            if (rightSideSymbols.Contains(letter.ToString()))
            {
                switch(letter)
                {
                    case ']':
                        if (singleStack.Count > 0 && singleStack.Peek() == "[")
                        {
                            singleStack.Pop();
                        }
                        else 
                        {
                            return false;
                        }
                        break;
                    case '}':
                        if (singleStack.Count > 0 && singleStack.Peek() == "{")
                        {
                            singleStack.Pop();
                        }
                        else 
                        {
                            return false;
                        }
                        break;
    
                    case ')':
                        if (singleStack.Peek() == "(")
                        {
                            singleStack.Pop();
                        }
                        else 
                        {
                            return false;
                        }
                        break;
                }
            }
    	}
    	return singleStack.Count() == 0;
    }
}
