using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public static class TwelveDays
{
    private static readonly string[] _verseParts = new string[]
    {
        "a Partridge in a Pear Tree.",
        "two Turtle Doves",
        "three French Hens"
    };

    private static readonly Dictionary<int, string> _begginingOfVerse = new Dictionary<int, string>()
    {
        {1, "first"},
        {2, "second"},
        {3, "third"}
    };

    public static string Recite(int verseNumber)
    {
        var versesParts = AssembleVerseParts(verseNumber);
        return $"On the {_begginingOfVerse[verseNumber]} day of Christmas my true love gave to me: " + versesParts;
    }

    private static string AssembleVerseParts(int verseNumber)
    {
        StringBuilder sb = new StringBuilder();
        for(int i = verseNumber - 1; i >= 0; i--)
        {
            if (verseNumber > 1 && i == 0) sb.Append("and ");
            sb.Append(_verseParts[i]);
            if (i >= 1) sb.Append(", ");
        }
        return sb.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}