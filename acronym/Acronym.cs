using System;
using System.Text;

public static class Acronym
{
  	private static readonly char [] wordDelimiters = { ' ', '-', '_'};
    public static string Abbreviate(string phrase)
    {
    	var words = phrase.Split(wordDelimiters);
    	StringBuilder acronym = new StringBuilder();
    	foreach(var word in words)
    	{
    		if (!string.IsNullOrEmpty(word))
    		{
    			acronym.Append(Char.ToUpper(word[0]));
    		}
    	}
    	return acronym.ToString();
    }
}