using System;
using System.Collections.Generic;

public class NucleotideCount
{
    private string Sequence { get; set; }
    public NucleotideCount(string sequence)
    {
        if(!IsValidDNA(sequence))
        {
            throw new ArgumentException("DNA contains invalid nucleotides");
        }
        Sequence = sequence;
    }

    public IDictionary<char, int> NucleotideCounts
    {
        get
        {
            return CountNucleotides(Sequence);
        }
    }
    

    private Dictionary<char, int> CountNucleotides(string dnaSequence)
    {
        var dictionary = BuildNucleotideDictionary();
        foreach(var nucleotide in dnaSequence)
        {
            int currentNucleotideCount = dictionary[nucleotide];
            dictionary[nucleotide] = ++currentNucleotideCount;
        }
        return dictionary;
    }
    
    private Dictionary<char, int> BuildNucleotideDictionary()
    {
        Dictionary<char, int> dic = new Dictionary<char, int>();
        dic.Add('A', 0);
        dic.Add('C', 0);
        dic.Add('G', 0);
        dic.Add('T', 0);

        return dic;
    }

    public static bool IsValidDNA(string dnaSequence)
    {
        string validNucleotides = "ACGT";
        foreach(var nucleotide in dnaSequence)
        {
            if(!validNucleotides.Contains(nucleotide.ToString()))
            {
                return false;
            }
        }

        return true;
    }
}