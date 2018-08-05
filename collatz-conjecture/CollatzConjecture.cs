using System;

public static class CollatzConjecture 
{
    public static int Steps(int number) 
    {
        if (number <= 0)
        {
            throw new ArgumentException();
        }

        if (number == 1) 
        {
            return 0;
        }

        if (number % 2 == 0) 
        {
            return Steps(number / 2) + 1;
        } 
        
        else 
        {
            return Steps((number * 3) + 1) + 1;
        }
    }
}