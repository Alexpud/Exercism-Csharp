using System;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        long largestProduct = 0;
        long currentSpanProduct = 1;
        for(int i = 0; i <= digits.Length - span; i++)
        {
            currentSpanProduct = 1;
            for (int j = i; j <= i + (span - 1); j++)
            {
                currentSpanProduct *= (long)char.GetNumericValue(digits[j]);
            }
            largestProduct = currentSpanProduct > largestProduct ? currentSpanProduct : largestProduct;
        }
        return largestProduct;
    }
}