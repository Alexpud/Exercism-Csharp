using System;
using System.Collections.Generic;
using System.Linq;
public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
    	List<string> phrases = new List<string>();
    	if (!subjects.Any())
    	{
    		return phrases.ToArray();
    	}

    	for(int i = 0; i < subjects.Length - 1; i++)
    	{
    		phrases.Add($"For want of a {subjects[i]} the {subjects[i+1]} was lost.");
    	}

    	phrases.Add($"And all for the want of a {subjects.First()}.");
        return phrases.ToArray();
    }
}