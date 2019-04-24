using System;
using System.Linq;
using System.Collections.Generic;

public static class MatchingBrackets
{
    private const string rightSideSymbols = "])}";
    private const string leftSideSymbols = "[({";
    public static bool IsPaired(string input)
    {
        Stack<char> singleStack = new Stack<char>();
    	foreach(var letter in input)
    	{
            if (leftSideSymbols.Contains(letter))
            {
                singleStack.Push(letter);
                continue;
            }

            if (rightSideSymbols.Contains(letter))
            {
                int nStackElements = singleStack.Count;
                switch(letter)
                {
                    case ']':
                        if (nStackElements > 0 && singleStack.Peek() == '[')
                        {
                            singleStack.Pop();
                        }
                        else 
                        {
                            return false;
                        }
                        break;
                    case '}':
                        if (nStackElements > 0 && singleStack.Peek() == '{')
                        {
                            singleStack.Pop();
                        }
                        else 
                        {
                            return false;
                        }
                        break;
    
                    case ')':
                        if (singleStack.Peek() == '(')
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
    	return singleStack.Count == 0;
    }
}
