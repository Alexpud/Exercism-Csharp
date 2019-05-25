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
        DateTime nextMeetupDate = CalculateBaseDateForNextMeetup(previousMeetupDate, schedule);
        while (nextMeetupDate.DayOfWeek != dayOfWeek)
        {
            nextMeetupDate = nextMeetupDate.AddDays(1);
        }
        return nextMeetupDate;
    }

    private DateTime CalculateBaseDateForNextMeetup(DateTime previousMeetupDate, Schedule schedule)
    {
        int days = 0;
        switch (schedule)
        {
            case Schedule.Teenth:
                days = 12;
                break;
            case Schedule.Second:
                days = 7;
                break;
            case Schedule.Third:
                days = 14;
                break;
            case Schedule.Fourth:
                days = 21;
                break;
            case Schedule.Last:
                days = previousMeetupDate.AddMonths(1).AddDays(-8).Day;
                break;
        }
        return previousMeetupDate.AddDays(days);
    }
}