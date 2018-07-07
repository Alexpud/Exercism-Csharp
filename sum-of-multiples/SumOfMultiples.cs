using System;
using System.Linq;
using System.Collections.Generic;


public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        var multipleNumbers = MultiplesBetween(0, max, multiples);
        if(!multipleNumbers.Any())
        {    
            return 0;
        }

        return multipleNumbers.Sum();
    }

    public static IEnumerable<int> MultiplesBetween(int lowerLimit, int upperLimit, IEnumerable<int> multiples)
    {
        var numbersBetween = NumbersBetween(lowerLimit, upperLimit);
        return (from number in numbersBetween
                
                let isMultiple = (from multiple in multiples
                                  where number % multiple == 0
                                  select multiple)
                
                where isMultiple.Any() == true
                
                select number);
    }

    public static List<int> NumbersBetween(int lowerLimit, int upperLimit)
    {
        List<int> list = new List<int>();
        
        while(lowerLimit < upperLimit)
        {
            list.Add(lowerLimit);
            lowerLimit++;
        }
        return list;
    }
}