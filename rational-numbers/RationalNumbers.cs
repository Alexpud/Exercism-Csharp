using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return Math.Pow(realNumber, r.GetValue());
    }
}

public struct RationalNumber
{
    public double Denominator { get; private set;}
    public double Numerator { get; private set; }
    
    public RationalNumber(double numerator, double denominator)
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
        double denominator = r1.Denominator * r2.Denominator;
        double numerator = (r1.Numerator * r2.Denominator) + (r2.Numerator * r1.Denominator);
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Sub(RationalNumber r)
    {
        return this - r;
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        double denominator = r1.Denominator * r2.Denominator;
        double numerator = (r1.Numerator * r2.Denominator) - (r2.Numerator * r1.Denominator);
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Mul(RationalNumber r)
    {
        return this * r;
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        double denominator = r1.Denominator * r2.Denominator;
        double numerator = r1.Numerator * r2.Numerator;
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Div(RationalNumber r)
    {
        return this / r;
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        double denominator = r1.Denominator * r2.Numerator;
        double numerator = r1.Numerator * r2.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator));
    }

    public RationalNumber Reduce()
    {
        return this;
    }

    public RationalNumber Exprational(int power)
    {
        RationalNumber reducedRational = this.Reduce();
        double denominator = power < 0 ? Math.Pow(reducedRational.Numerator, power) : 
                                         Math.Pow(reducedRational.Denominator, power);

        double numerator   = power < 0 ? Math.Pow(reducedRational.Denominator, power) : 
                                         Math.Pow(reducedRational.Numerator, power);

        return new RationalNumber((int)numerator, (int)denominator);
    }

    public double Expreal(int baseNumber)
    {
        return baseNumber.Expreal(this);
    }

    private void ReduceToLowestTerms(RationalNumber number)
    {
        int gcd = Gcd(number.Numerator, number.Denominator);
        number.Numerator /= gcd;
        number.Denominator /= gcd;
    }

    public static int Gcd(double a, double b)
    {
        if(a == 0)
        {
            return (int)b;
        }
        if(b == 0)
        {
            return (int)a;
        }
        while(a != b)
        {
            a = a > b ? a - b : a;
            b = b > a ? b - a : b;
        }
        return (int)a;
    }

    public double GetValue()
    {
        return Numerator / Denominator;
    }
}