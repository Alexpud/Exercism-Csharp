using System;
using System.Linq;
using System.Collections.Generic;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        var numbers = Enumerable.Range(0, max + 1);
        return (int)Math.Pow(numbers.Sum(), 2);
    }

    public static int CalculateSumOfSquares(int max)
    {
        var numbers = Enumerable.Range(0, max + 1);
        var numbersSquares = numbers.Select(x => Math.Pow(x, 2));
        return (int)numbersSquares.Sum();
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}