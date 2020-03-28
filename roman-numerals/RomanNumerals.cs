using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public static class RomanNumeralExtension
{
    private static Dictionary<int, string> arabicByRomanAlgarisms = new Dictionary<int, string>()
    {
        { 1000, "M" },
        { 900, "CM" },
        { 500, "D" },
        { 400, "CD" },
        { 100, "C" },
        { 90, "XC" },
        { 50, "L" },
        { 40, "XL" },
        { 20, "XX"},
        { 10, "X"},
        { 9, "IX" },
        { 5, "V" },
        { 4, "IV" },
        { 1, "I" }
    };

    public static string ToRoman(this int value)
    {
        StringBuilder sb = new StringBuilder();
        foreach(var arabicAlgarism in arabicByRomanAlgarisms.Keys)
        {
            if (arabicAlgarism <= value)
            {
                var romanAlgarism = Enumerable.Repeat(arabicByRomanAlgarisms[arabicAlgarism], value / arabicAlgarism);
                value -= romanAlgarism.Count() * arabicAlgarism;
                sb.Append(string.Concat(romanAlgarism));
            }
        }
        return sb.ToString();
    }
}