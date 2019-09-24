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
        var versesParts = BuildVerseParts(verseNumber);
        return $"On the {VerseNumberToVerse[verseNumber].Position} day of Christmas my true love gave to me: " + versesParts;
    }

    private static string BuildVerseParts(int verseNumber)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for(int currentVerse = verseNumber; currentVerse >= 1; currentVerse--)
        {
            bool isLastVersePart = currentVerse == 1;
            bool noNextVerses = isLastVersePart && verseNumber > 1;
            if (noNextVerses)
            {
                AddLastVerseConjunction(stringBuilder);
            }

            stringBuilder.Append(VerseNumberToVerse[currentVerse].Content);
            
            if (!isLastVersePart)
            {
                AddVerseConjunction(stringBuilder);
            }
        }
        return stringBuilder.ToString();
    }

    private static void AddLastVerseConjunction(StringBuilder stringBuilder)
    {
        stringBuilder.Append("and ");
    }

    private static void AddVerseConjunction(StringBuilder stringBuilder)
    {
        stringBuilder.Append(", ");
    }

    public static string Recite(int startVerse, int endVerse)
    {
        StringBuilder stringBuilder = new StringBuilder();
        bool isLastVersePart = false;
        for (int currentVerse = startVerse; currentVerse <= endVerse; currentVerse++)
        {
            stringBuilder.Append(Recite(currentVerse));
            isLastVersePart  = currentVerse == endVerse;
            if (!isLastVersePart ) 
            {
                stringBuilder.Append("\n");  
            } 
        }
        return stringBuilder.ToString();
    }
}