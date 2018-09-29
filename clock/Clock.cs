using System;

public class Clock
{
    public Clock(int hours, int minutes)
    {     
        Minutes = minutes;
        Hours += hours;
        AjdustClockMinutes();
        AdjustClockHour();
    }

    private void AjdustClockMinutes()
    {
        if(Minutes >= 60)
        {
            Hours += Minutes / 60;
            Minutes = Minutes % 60;
        }
        else if(Minutes < 0)
        {
            int positiveMinutes = Minutes * -1;
            Hours -= 1 + (positiveMinutes / 60);
            Minutes = 60 - (positiveMinutes % 60);
        }
    }

    private void AdjustClockHour()
    {
        if(Hours >= 24)
        {
            Hours = Hours % 24;
        }
        else if(Hours < 0)
        {
            int positiveHours = Hours * -1;
            if(positiveHours > 24)
            {
                Hours = 24 - (positiveHours % 24);
            }
            else
            {
                Hours  = 24 - positiveHours;
            }
            Hours = Hours == 24 ? 0 : Hours;
        }
    }


    public int Hours { get; private set;}

    public int Minutes { get; private set; }

    public Clock Add(int minutesToAdd)
    {
        Minutes += minutesToAdd;
        AjdustClockMinutes();
        AdjustClockHour();
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        Add(minutesToSubtract * -1);
        return this;
    }

    public override string ToString()
    {
        return $"{Hours:00}:{Minutes:00}";
    }

    public override bool Equals(Object obj)
    {
        if(ReferenceEquals(this, null) || ReferenceEquals(obj, null))
        {
            return false;
        }
        
        if(ReferenceEquals(obj, this))
        {
            return false;
        }

        return Equals((Clock) obj);
    }

    private bool Equals(Clock clock)
    {
        if(clock.Hours != this.Hours || clock.Minutes != this.Minutes)
        {
            return false;
        }
        return true;
    }

    public override int GetHashCode()
    {
        return (Hours * 397) ^ Minutes;
    }
}