using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
    	return ApplyPredicate(collection, predicate);
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        return ApplyPredicate(collection, x => !predicate(x));
    }

    public static IEnumerable<T> ApplyPredicate<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach(var item in collection)
        {
            if (predicate(item))
            {
                 yield return item;
            }
        }
    }
}