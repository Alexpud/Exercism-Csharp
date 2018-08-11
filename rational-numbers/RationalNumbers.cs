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
    public int Denominator;
    public int Numerator;
    
    public RationalNumber(int numerator, int denominator)
    {
        int gcd = Gcd(Math.Abs(numerator), Math.Abs(denominator));
        Denominator = denominator / gcd;
        Numerator = numerator / gcd;

        if(Denominator < 0 && (Numerator < 0 || Numerator > 0))
        {
            Denominator *= -1;
            Numerator *= -1;
        }
    }

    public RationalNumber Add(RationalNumber r)
    {
        return this + r;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        // int rest = Gcd(r1.GetValue(), r2.GetValue());
        int denominator = r1.Denominator * r2.Denominator;
        int numerator = (r1.Numerator * r2.Denominator) + (r2.Numerator * r1.Denominator);
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Sub(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        int denominator = r1.Denominator * r2.Denominator;
        int numerator = (r1.Numerator * r2.Denominator) - (r2.Numerator * r1.Denominator);
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Mul(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        int denominator = r1.Denominator * r2.Denominator;
        int numerator = r1.Numerator * r2.Numerator;
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Div(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        // int rest = Gcd(r1.GetValue(), r2.GetValue());
        int denominator = r1.Denominator * r2.Numerator;
        int numerator = r1.Numerator * r2.Denominator;
        return new RationalNumber(numerator, denominator);
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

    private void ReduceToLowestTerms(RationalNumber number)
    {
        int gcd = Gcd(number.Numerator, number.Denominator);
        number.Numerator /= gcd;
        number.Denominator /= gcd;
    }

    public static int Gcd(int a, int b)
    {
        if(a == 0)
        {
            return b;
        }
        if(b == 0)
        {
            return a;
        }
        while(a != b)
        {
            a = a > b ? a - b : a;
            b = b > a ? b - a : b;
        }
        return a;
    }

    public double GetValue()
    {
        return Math.Abs(Numerator) / Math.Abs(Denominator);
    }
}