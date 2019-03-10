using System;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        ValidateNumberToBeClassified(number);
        int sum = 0;
        for (int i = 1; i <= number / 2; i++)
        {
            if (sum >= number)
            {
                break;
            }

            if (number % i == 0)
            {
                sum += i;
            }
        }
        return ClassifySum(sum, number);
    }

    private static void ValidateNumberToBeClassified(int number)
    {
        if (number == 0)
        {
            throw new ArgumentOutOfRangeException("Can't classify the number 0");
        }

        if (number < 0)
        {
            throw new ArgumentOutOfRangeException("Can't classify negative numbers");
        }
    }

    private static Classification ClassifySum(int sum, int number)
    {
        if (sum == number)
        {
            return Classification.Perfect;
        }

        if (sum > number)
        {
            return Classification.Abundant;
        }
        return Classification.Deficient;
    }
}
