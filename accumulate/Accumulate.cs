using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public static class AccumulateExtensions
{
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {
        List<U> newCollection = new List<U>();
        foreach(var element in collection)
        {
            yield return func.Invoke(element);
        }
    }
}