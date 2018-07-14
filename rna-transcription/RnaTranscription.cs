using System;
using System.Linq;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        var rnaArray = nucleotide.ToCharArray();

        string result = "";
        foreach(var rna in rnaArray)
        {
            result += RnaComplement(rna);
        }

        return result;
    }

    private static char RnaComplement(char dna)
    {
        char rnaEquivalent = '0';
        switch(dna)
        {
            case 'G':
                rnaEquivalent = 'C';
                break;
            
            case 'C':
                rnaEquivalent = 'G';
                break;
            
            case 'T':
                rnaEquivalent = 'A';
                break;

            case 'A':
                rnaEquivalent = 'U';
                break;
        }
        return rnaEquivalent;
    }
}