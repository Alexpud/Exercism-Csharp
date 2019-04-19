using System;
using System.Linq;
using System.Text;

public static class Acronym
{
  	private static readonly char [] wordDelimiters = { ' ', '-', '_'};
    public static string Abbreviate(string phrase)
    {
		var initials = phrase.Split(wordDelimiters)
				   	   		.Where(word => !string.IsNullOrEmpty(word))
				   			.Select(word => Char.ToUpper(word[0]))
				   			.ToArray();

		return new String(initials);
    }
}