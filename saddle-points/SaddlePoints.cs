using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        int dimensions = matrix.Rank;
        Enumerable.Range(0, dimensions);
        throw new NotImplementedException("You need to implement this function.");
    }
}
