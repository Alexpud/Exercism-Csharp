using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this extension method.");
    }
}

public struct RationalNumber
{
    public RationalNumber(int numerator, int denominator)
    {
        int rest = Gdc(numerator, denominator);
    }

    public RationalNumber Add(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        throw new NotImplementedException("You need to implement this operator.");
    }

    public RationalNumber Sub(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        throw new NotImplementedException("You need to implement this operator.");
    }

    public RationalNumber Mul(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        throw new NotImplementedException("You need to implement this operator.");
    }

    public RationalNumber Div(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        System.Console.WriteLine("Here");
        throw new NotImplementedException("You need to implement this operator.");
    }

    public RationalNumber Abs()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public RationalNumber Reduce()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public RationalNumber Exprational(int power)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public int Gdc(int a, int b)
    {
        int smallerNumber = a < b ? a : b;
        int biggerNumber = a < b ? b : a;

        while(true)
        {
            int quocient = biggerNumber / smallerNumber;
            int rest = biggerNumber % smallerNumber;
            if(rest == 0)
            {
                return rest;
            }

            biggerNumber = quocient;
            smallerNumber = rest;
        }
    }
}