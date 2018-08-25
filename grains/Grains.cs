using System;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n > 64 || n <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        ulong square = 1;
        for (int i = 1; i < n; i++)
        {
            square *= 2UL;
        }

        return square;
    }

    public static ulong Total()
    {
        /*
            Since it is the sum of a Geometric Progression of order 2, and the last element 
            value cannot be held inside a ulong variable, this is the equivalent operation
        */
        var lastElementSquare = Square(64);
        return lastElementSquare + lastElementSquare - 1;
    }
}