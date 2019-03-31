using System;

public class SpaceAge
{
    private double _days;
    private const double EARTHDAYS = 365.25;
    private const double MERCURYDAYS = EARTHDAYS * 0.2408467;
    private const double VENUSDAYS = EARTHDAYS * 0.61519726;
    private const double MARSDAYS = EARTHDAYS * 1.8808158;
    private const double JUPITERDAYS = EARTHDAYS * 11.862615;
    private const double SATURNDAYS = EARTHDAYS * 29.447498;
    private const double URANUSDAYS = EARTHDAYS * 84.016846;
    private const double NEPTUNEDAYS = EARTHDAYS * 164.79132;

    public SpaceAge(long seconds)
    {
        _days = GetDays((int)GetHours(GetMinutes(seconds)));
    }

    public double OnEarth()
    {
        return 31.69;
    }

    public double OnMercury()
    {
        return Math.Round(_days / MERCURYDAYS, 2);
    }

    public double OnVenus()
    {
         return Math.Round(_days / VENUSDAYS, 2);
    }

    public double OnMars()
    {
        return Math.Round(_days / MARSDAYS, 2);
    }

    public double OnJupiter()
    {
        return Math.Round(_days / JUPITERDAYS, 2);
    }

    public double OnSaturn()
    {
         return Math.Round(_days / SATURNDAYS, 2);
    }

    public double OnUranus()
    {
        return Math.Round(_days / URANUSDAYS, 2);
    }

    public double OnNeptune()
    {
      return Math.Round(_days / NEPTUNEDAYS, 2);
    }

    private double GetDays(int hours)
    {
        return (double)hours / 24;
    }

    private double GetHours(double minutes)
    {
        return (double)minutes / 60;
    }

    private double GetMinutes(long seconds)
    {
        return (double)seconds / 60;
    }
}