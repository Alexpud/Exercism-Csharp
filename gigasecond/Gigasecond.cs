using System;

public static class Gigasecond
{
    public static DateTime Add(DateTime birthDate)
    {
        double gigaSecond = 1000000000;
        return birthDate.AddSeconds(gigaSecond);
    }
}