using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        var inputList = input.Cast<object>().ToList();
        var flattenedList = new List<object>();
        if (!inputList.Any()) return flattenedList;
        var firstElement = inputList.First();
        if (IsCollection(firstElement))
        {
            flattenedList = FlattenNestedList(inputList, flattenedList);
        }
        else if (firstElement != null)
        {
            flattenedList.Add(inputList.First());
        }

        var inputListTail = inputList.Skip(1);
        var flattenedInputListTail = (IEnumerable<object>)Flatten(inputListTail);
        flattenedList = flattenedList.Concat(flattenedInputListTail).ToList();

        return flattenedList;
    }

    private static bool IsCollection(object firstElement)
    {
        return firstElement is Array;
    }

    private static List<object> FlattenNestedList(List<object> inputList, List<object> flattenedList)
    {
        var flattennedSubList = Flatten((IEnumerable)inputList.First());
        return flattenedList.Concat(Flatten(flattennedSubList).Cast<object>()).ToList();
    }
}