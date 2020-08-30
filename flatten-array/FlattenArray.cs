using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        var inputList = input.Cast<object>();
        var flattenedInput = Enumerable.Empty<object>();
        if (!inputList.Any()) return flattenedInput;
        var firstElement = inputList.First();
        if (IsCollection(firstElement))
        {
            var firstElementAsList = (IEnumerable<object>)firstElement;
            flattenedInput = flattenedInput.Concat(FlattenList(firstElementAsList));
        }
        else if (firstElement != null)
        {
            flattenedInput = flattenedInput.Append(firstElement);
        }

        flattenedInput = flattenedInput.Concat(FlattenList(inputList.Skip(1)));
        return flattenedInput;
    }

    private static bool IsCollection(object firstElement)
    {
        return firstElement is Array;
    }

    private static IEnumerable<object> FlattenList(IEnumerable inputListTail)
    {
        var flattenedInputListTail = Flatten(inputListTail);
        return flattenedInputListTail.Cast<object>();
    }
}