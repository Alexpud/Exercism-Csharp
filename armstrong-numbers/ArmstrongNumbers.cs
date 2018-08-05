using System;
using System.Linq;
using System.Collections.Generic;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string numberString = number.ToString();
        int numberSize = numberString.Length;
        var digitsPows = numberString.Select(x => 
        {
            return Math.Pow(Char.GetNumericValue(x), numberSize);
        });
        
        return digitsPows.Sum() == number;
    }
}