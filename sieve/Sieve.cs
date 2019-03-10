using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2)
        {
            throw new ArgumentOutOfRangeException("No primes smaller than 2");
        }

        return GetPrimeNumbersArray(GetPossiblePrimeNumbersArray(limit));
    }

    private static bool[] GetPossiblePrimeNumbersArray(int limit)
    {
        int currentPrime = 2;
        bool[] possiblePrimeNumbersArray = new bool[limit + 1];
        while (currentPrime > 0 && limit > 2)
        {
            for (int i = currentPrime + 1; i < possiblePrimeNumbersArray.Length; i ++)
            {
                if (i % currentPrime == 0)
                {
                    possiblePrimeNumbersArray[i] = true;
                }
            }
            currentPrime = GetNextPrimeNumber(possiblePrimeNumbersArray, currentPrime);
        }
        return possiblePrimeNumbersArray;
    }

    private static int GetNextPrimeNumber(bool[] possiblePrimeNumbersArray, int currentPrime)
    {
        for (int i = currentPrime + 1; i < possiblePrimeNumbersArray.Length; i++)
        {
            if (possiblePrimeNumbersArray[i] == false)
            {
                return i;
            }
        }
        return -1;
    }

    private static int[] GetPrimeNumbersArray(bool[] possiblePrimeNumbersArray)
    {
        List<int> primeNumberList = new List<int>();
        for (int i = 2; i < possiblePrimeNumbersArray.Length; i++)
        {
            if (!possiblePrimeNumbersArray[i])
            {
                primeNumberList.Add(i);
            }
        }
        return primeNumberList.ToArray();
    }
}