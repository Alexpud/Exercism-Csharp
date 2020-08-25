using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        var inputList = input.Cast<object>();
        var flattenedList = new List<object>();
        if (!inputList.Any()) return flattenedList;
        var firstElement = inputList.First();
        if (IsCollection(firstElement))
        {
            var firstElementAsList = (IEnumerable<object>)firstElement;
            flattenedList = flattenedList.Concat(FlattenList(firstElementAsList)).ToList();
        }
        else if (firstElement != null)
        {
            flattenedList.Add(inputList.First());
        }

        flattenedList = flattenedList.Concat(FlattenList(inputList.Skip(1))).ToList();
        return flattenedList;
    }

    private static bool IsCollection(object firstElement)
    {
        return firstElement is Array;
    }

    private static IEnumerable<object> FlattenList(IEnumerable<object> inputListTail)
    {
        var flattenedInputListTail = (IEnumerable)Flatten(inputListTail);
        return flattenedInputListTail.Cast<object>();
    }
}