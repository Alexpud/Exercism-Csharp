using System;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (span == 0)
        {
            return 1;
        }

        ThrowIfInvalidInputs(digits, span);

        long largestProduct = 0;
        long currentSpanProduct = 1;
        for (int i = 0; i <= digits.Length - span; i++)
        {
            currentSpanProduct = 1;
            for (int j = i; j <= i + (span - 1); j++)
            {
                var digit = (long)char.GetNumericValue(digits[j]);
                if (digit < 0)
                {
                    throw new ArgumentException("Can't have non digit characters");
                }
                currentSpanProduct *= digit;
            }
            largestProduct = currentSpanProduct > largestProduct ? currentSpanProduct : largestProduct;
        }
        return largestProduct;
    }

    private static void ThrowIfInvalidInputs(string digits, int span)
    {
        if (string.IsNullOrWhiteSpace(digits))
        {
            throw new ArgumentException("Digits can't be null or empty");
        }

        if (span < 0)
        {
            throw new ArgumentException("Span can't be negative");
        }

        if (digits.Length < span)
        {
            throw new ArgumentException("Span can't be larger than the digits");
        }
    }
}