using System;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly DateTime previousMeetupDate;
    public Meetup(int month, int year)
    {
        previousMeetupDate = new DateTime(year, month, 1);
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        DateTime baseDateForNextMeetup = CalculateBaseDateForNextMeetup(previousMeetupDate, schedule);
        int requiredOcurrences = RequiredOcurrences(schedule);
        return CalculateNextMeetupDate(baseDateForNextMeetup, requiredOcurrences, dayOfWeek);
    }

    private DateTime CalculateBaseDateForNextMeetup(DateTime previousMeetupDate, Schedule schedule)
    {
        if (schedule == Schedule.Teenth)
        {
            return previousMeetupDate.AddDays(12);
        }

        if (schedule == Schedule.Last)
        {
            var daysInMonth = DateTime.DaysInMonth(previousMeetupDate.Year, previousMeetupDate.Month);
            return previousMeetupDate.AddDays(daysInMonth - 7);
        }

        return previousMeetupDate; 
    }

    private int RequiredOcurrences(Schedule schedule)
    {
        switch (schedule)
        {
            case Schedule.Second:
                return 2;
            case Schedule.Third:
                return 3;
            case Schedule.Fourth:
                return 4;
            default:
                return 1;
        }
    }

    private DateTime CalculateNextMeetupDate(DateTime baseDateForNextMeetup, int requiredOcurrences,
        DayOfWeek dayOfWeek)
    {
        DateTime nextMeetupDate = baseDateForNextMeetup;
        while (true)
        {
            if (nextMeetupDate.DayOfWeek == dayOfWeek)
            {
                requiredOcurrences--;
            }
            if (requiredOcurrences == 0)
            {
                break;
            }
            nextMeetupDate = nextMeetupDate.AddDays(1);
        }
        return nextMeetupDate;
    }
}