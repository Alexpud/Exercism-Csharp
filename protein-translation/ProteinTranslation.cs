using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class ProteinTranslation
{
    private static Dictionary<string, string> dict = new Dictionary<string, string>()
    {
        {"AUG", "Methionine"},
        {"UUU", "Phenylalanine"},
        {"UUC", "Phenylalanine"},
        {"UUA", "Leucine"},
        {"UUG", "Leucine"},
        {"UCU", "Serine"},
        {"UCA", "Serine"},
        {"UCC", "Serine"},
        {"UCG", "Serine"},
        {"UAU", "Tyrosine"},
        {"UAC", "Tyrosine"},
        {"UGU", "Cysteine"},
        {"UGC", "Cysteine"},
        {"UGG", "Tryptophan"},
        {"UAA", "Stop"},
        {"UAG", "Stop"},
        {"UGA", "Stop"}
    };

    public static string[] Proteins(string strand)
    {
        Regex reg = new Regex(@"(?<word>\w{3})");
        var proteinList = new List<string>();
        foreach(Match match in reg.Matches(strand))
        {
            GroupCollection groups = match.Groups;
            var dictEntry = dict[groups["word"].Value];
            if (dictEntry == "Stop")
            {
                return proteinList.ToArray();
            }
            proteinList.Add(dictEntry);
        }
        return proteinList.ToArray();
    }
}