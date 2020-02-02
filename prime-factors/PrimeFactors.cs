using System.Collections.Generic;

public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        long currentPossiblePrime = 2;
        List<long> result  = new List<long>();
        while(currentPossiblePrime <= number)
        {
            if (IsPrimeFactor(number, currentPossiblePrime))
            {
                number /= currentPossiblePrime;
                result.Add(currentPossiblePrime);
            }
            else
            {
                currentPossiblePrime++;
            }
        }
        return result.ToArray();
    }

    private static bool IsPrimeFactor(long number, long possiblePrimeFactor)
    {
        return number % possiblePrimeFactor == 0;
    }
}