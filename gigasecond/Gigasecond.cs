using System;

public static class Gigasecond
{
    private const double GigaSecond = 1000000000;
    public static DateTime Add(DateTime birthDate)
    {
        return birthDate.AddSeconds(GigaSecond);
    }
}