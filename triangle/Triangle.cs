using System;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        return IsValidTriangle(side1, side2, side3) && !IsIsosceles(side1, side2, side3);
    }

    public static bool IsIsosceles(double side1, double side2, double side3)
    {
        if (!IsValidTriangle(side1, side2, side3))
        {
            return false;
        }

        bool isEquilateral = IsEquilateral(side1, side2, side3);
        bool hasTwoEqualSides = (side1 == side3) || (side1 == side2) || (side2 == side3);
        return (isEquilateral || hasTwoEqualSides);
    }

    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        if (!IsValidTriangle(side1, side2, side3))
        {
            return false;
        }
        return (side1 == side2) && (side1 == side3);
    }

    private static bool IsValidTriangle(double side1, double side2, double side3)
    {
        return !HasTriangleInequality(side1, side2, side3);
    }

    private static bool HasTriangleInequality(double side1, double side2, double side3)
    {
        bool triangleHasSideWithZeroLength = side1 == 0 || side2 == 0 || side3 == 0;
        bool isDegenerateTriangle = (side1 + side2 < side3) ||
            (side1 + side3 < side2) ||
            (side2 + side3 < side1);

        if (triangleHasSideWithZeroLength || isDegenerateTriangle)
        {
            return true;
        }

        return false;
    }
}