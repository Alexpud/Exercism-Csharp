using System;
using System.Linq;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        return new string(Enumerable.Reverse(input).ToArray());
    }
}