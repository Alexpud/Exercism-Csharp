using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    private static bool[] primes;

    public static int[] Primes(int limit)
    {
        if (limit < 2)
        {
            throw new ArgumentOutOfRangeException("No primes smaller than 2");
        }

        return GetPrimeNumbersArray(limit);
    }

    private static int[] GetPrimeNumbersArray(int limit)
    {
        int currentPrime = 2;
        List<int> numbers = Enumerable.Range(currentPrime, limit - 1).ToList();
        List<int> potentialPrimesList = new List<int>()
        {
            currentPrime
        };
        List<int> finalPrimeList = new List<int>();

        while (currentPrime != numbers.LastOrDefault())
        {
            potentialPrimesList = GetNotMultiplesOf(numbers, currentPrime);
            numbers = potentialPrimesList;
            finalPrimeList.Add(currentPrime);
            currentPrime = numbers.FirstOrDefault();
        }

        finalPrimeList.Add(currentPrime);
        return finalPrimeList.ToArray();
    }

    private static List<int> GetNotMultiplesOf(List<int> possibleMultiplesList, int number)
    {
        List<int> potentialPrimesList = new List<int>();
        foreach(var possibleMultiple in possibleMultiplesList)
        {
            if (possibleMultiple % number != 0)
            {
                potentialPrimesList.Add(possibleMultiple);
            }
        }
        return potentialPrimesList;
    }
}