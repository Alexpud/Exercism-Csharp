using System;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        ValidateSeriesSlicing(numbers, sliceLength);
        List<string> result = new List<string>();
        for (int j = 0; j < numbers.Length; j++)
        {
            if (j + sliceLength > numbers.Length)
            {
                break;
            }
            result.Add(numbers.Substring(j, sliceLength));
        }
        return result.ToArray();
    }

    private static void ValidateSeriesSlicing(string series, int sliceLength)
    {
        if (!IsSliceValid(sliceLength, series.Length ) || !IsSeriesValid(series))
        {
            throw new ArgumentException();
        }
    }
    
    private static bool IsSliceValid(int sliceLength, int seriesLength)
    {
        bool sliceLengthSmallerThanSeriesLength = sliceLength <= seriesLength;
        bool nonNegativeSliceLength = sliceLength > 0;
        return sliceLengthSmallerThanSeriesLength && nonNegativeSliceLength;
    }

    private static bool IsSeriesValid(string series)
    {
        bool seriesNotEmpty = !string.IsNullOrEmpty(series);
        return seriesNotEmpty;
    }
}