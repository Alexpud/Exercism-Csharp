using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        bool divisibleBy4 = year % 4 == 0;
        bool divisibleBy100 = year % 100 == 0;
        bool divisibleBy400 = year % 400 == 0;

        if(divisibleBy4)
        {
            if(divisibleBy100 && !divisibleBy400)
            {    
                return false;
            }
            return true;
        }  
            
        return false;
    }
}