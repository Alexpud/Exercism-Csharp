using System;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        ValidateSeriesSlicing(numbers, sliceLength);
        List<string> slicesList = new List<string>();
        for (int j = 0; j <= numbers.Length - sliceLength; j++)
        {
            slicesList.Add(numbers.Substring(j, sliceLength));
        }
        return slicesList.ToArray();
    }

    private static void ValidateSeriesSlicing(string series, int sliceLength)
    {
        if (!IsSliceValid(sliceLength, series.Length ) || string.IsNullOrEmpty(series))
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
}