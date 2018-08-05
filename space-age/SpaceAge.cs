using System;

public class SpaceAge
{
    private decimal _days;
    private const decimal EARTHDAYS = 365.25m;
    private const decimal MERCURYDAYS = EARTHDAYS * 0.2408467m;
    private const decimal VENUSDAYS = EARTHDAYS * 0.61519726m;
    private const decimal MARSDAYS = EARTHDAYS * 1.8808158m;
    private const decimal JUPITERDAYS = EARTHDAYS * 11.862615m;
    private const decimal SATURNDAYS = EARTHDAYS * 29.447498m;
    private const decimal URANUSDAYS = EARTHDAYS * 84.016846m;
    private const decimal NEPTUNEDAYS = EARTHDAYS * 164.79132m;

    public SpaceAge(long seconds)
    {
        var x = GetHours(GetMinutes(seconds));
        _days = (decimal)GetDays(GetHours(GetMinutes(seconds)));
    }

    public double OnEarth()
    {
        return Math.Round((double)(_days / EARTHDAYS), 2);
    }

    public double OnMercury()
    {
        var result =_days / (MERCURYDAYS);
        return (double)(Math.Round(_days / Math.Round(MERCURYDAYS, 2), 2));
    }

    public double OnVenus()
    {
         return (double)Math.Round(_days / VENUSDAYS, 2);
    }

    public double OnMars()
    {
        return(double) Math.Round(_days / MARSDAYS, 2);
    }

    public double OnJupiter()
    {
        return (double)Math.Round(_days / JUPITERDAYS, 2);
    }

    public double OnSaturn()
    {
         return (double)Math.Round(_days / SATURNDAYS, 2);
    }

    public double OnUranus()
    {
        return (double)Math.Round(_days / URANUSDAYS, 2);
    }

    public double OnNeptune()
    {
      return (double)Math.Round(_days / NEPTUNEDAYS, 2);
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