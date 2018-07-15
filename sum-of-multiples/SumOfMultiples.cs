using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
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

    private static IEnumerable<int> MultiplesBetween(int lowerLimit, int upperLimit, IEnumerable<int> multiples)
    {
        var numbersBetween = Enumerable.Range(lowerLimit, upperLimit);
        return (from number in numbersBetween
                
                let isMultiple = (from multiple in multiples
                                  where number % multiple == 0
                                  select multiple)
                
                where isMultiple.Any() == true
                
                select number);
    }
}