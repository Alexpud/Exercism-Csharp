using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class ProteinTranslation
{
    private static Dictionary<string, string> codonProteinDictionary = new Dictionary<string, string>()
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

    private const int CODON_SIZE = 3;

    public static string[] Proteins(string strand)
    {
        return GetProteinList(strand).ToArray();
    }

    private static List<string> GetProteinList(string strand)
    {
        List<string> proteinList = new List<string>();
        foreach(Match match in GetCodonMatches(strand))
        {
            GroupCollection groups = match.Groups;
            var dictEntry = codonProteinDictionary[groups["word"].Value];
            if (dictEntry == "Stop")
            {
                return proteinList;
            }
            proteinList.Add(dictEntry);
        }
        return proteinList;
    }

    private static MatchCollection GetCodonMatches(string strand)
    {
        Regex reg = new Regex(@"(?<word>\w{" + CODON_SIZE + "})");
        return reg.Matches(strand);
    }
}