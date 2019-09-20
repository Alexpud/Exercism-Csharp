using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public static class TwelveDays
{
    private class Verse
    {
        public string Content {get; set;}
        public string Position { get; set; }
        public Verse(string position, string content)
        {
            Content = content;
            Position = position;
        }
    }

    private static Dictionary<int, Verse> VerseNumberToVerse = new Dictionary<int, Verse>()
    {
        [1] = new Verse("first", "a Partridge in a Pear Tree."),
        [2] = new Verse("second", "two Turtle Doves"),
        [3] = new Verse("third", "three French Hens"),
        [4] = new Verse("fourth", "four Calling Birds"),
        [5] = new Verse("fifth", "five Gold Rings"),
        [6] = new Verse("sixth", "six Geese-a-Laying"),
        [7] = new Verse("seventh", "seven Swans-a-Swimming"),
        [8] = new Verse("eighth", "eight Maids-a-Milking"),
        [9] = new Verse("ninth", "nine Ladies Dancing"),
        [10] = new Verse("tenth", "ten Lords-a-Leaping"),
        [11] = new Verse("eleventh", "eleven Pipers Piping"),
        [12] = new Verse("twelfth", "twelve Drummers Drumming"),
    };

    public static string Recite(int verseNumber)
    {
        var versesParts = AssembleContents(verseNumber);
        return $"On the {VerseNumberToVerse[verseNumber].Position} day of Christmas my true love gave to me: " + versesParts;
    }

    private static string AssembleContents(int verseNumber)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for(int i = verseNumber; i >= 1; i--)
        {
            bool isPenultimateVerse = verseNumber > 1 && i == 1; 
            if (isPenultimateVerse) 
            {
                stringBuilder.Append("and ");
            }

            stringBuilder.Append(VerseNumberToVerse[i].Content);
            bool hasMoreLines = i >= 2;
            if (!isPenultimateVerse && hasMoreLines) stringBuilder.Append(", ");
        }
        return stringBuilder.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = startVerse; i <= endVerse; i++)
        {
            stringBuilder.Append(Recite(i));
            if (i != endVerse) stringBuilder.Append("\n");
        }
        return stringBuilder.ToString();
    }
}