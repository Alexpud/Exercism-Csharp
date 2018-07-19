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
        switch(dna)
        {
            case 'G':
                return 'C';
            
            case 'C':
                return 'G';
            
            case 'T':
                return 'A';

            case 'A':
                return 'U';

            default:
                throw new ArgumentException();
        }
    }
}