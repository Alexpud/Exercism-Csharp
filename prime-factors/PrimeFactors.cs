using System;
using System.Collections.Generic;
using System.Linq;

public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        var possiblePrimeNumbers = Enumerable.Range(2, (int)number - 1).ToArray();
        int i = 0;
        List<long> result  = new List<long>();
        while(i < possiblePrimeNumbers.Length)
        {
            if (IsPrimeFactor(number, possiblePrimeNumbers[i]))
            {
                number /= possiblePrimeNumbers[i];
                result.Add(possiblePrimeNumbers[i]);
            }
            else
            {
                i++;
            }
        }
        return result.ToArray();
    }

    private static bool IsPrimeFactor(long number, long possiblePrimeFactor)
    {
        return number % possiblePrimeFactor == 0;
    }
}