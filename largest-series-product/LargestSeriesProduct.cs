using System;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        long largestProduct = 0;
        long product = 1;
        for(int i = 0; i <= digits.Length - span; i++)
        {
            product = 1;
            for (int j = i; j <= i + (span - 1); j++)
            {
                product *= (long)char.GetNumericValue(digits[j]);
            }
            largestProduct = product > largestProduct ? product : largestProduct;
        }
        return largestProduct;
    }
}