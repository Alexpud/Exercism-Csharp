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
        if (firstElement is Array)
        {
            var flattennedSubList = Flatten((IEnumerable)inputList.First());
            flattenedList = flattenedList.Concat(Flatten(flattennedSubList).Cast<object>()).ToList();
        }     
        else if (firstElement != null)
        {
            flattenedList.Add(inputList.First());
        }
        
        var inputListTail = inputList.Skip(1);
        flattenedList = flattenedList.Concat((IEnumerable<object>)Flatten(inputListTail)).ToList();

        return flattenedList;
    }
}