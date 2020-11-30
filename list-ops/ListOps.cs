using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        int count = 0;
        foreach(var el in input) count++;
        return count;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        var inputLength = Length(input);
        var invertedArray = new T[inputLength];
        var pos = 0;
        for (int i = inputLength - 1; i >= 0; i--)
        {
            invertedArray[pos++] = input[i];
        }
        return invertedArray.ToList();
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        var inputLength = Length(input);
        var mappedInputArray = new TOut[inputLength];
        for(int i = 0; i < inputLength; i++)
        {
            mappedInputArray[i] = map(input[i]);
        }
        return mappedInputArray.ToList();
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        var pos = 0;
        var nElementsFiltered = 0;
        foreach(var element in input)
        {
            if (predicate(element))
                nElementsFiltered++;
        }
        var resultingArray = new T[nElementsFiltered];
        foreach(var element in input)
        {
            if (predicate(element))
                resultingArray[pos++] = element;
        }
        return resultingArray.ToList();
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        var secondParameter = start;
        foreach(var element in input)
        {
            secondParameter = func(secondParameter, element);
        }
        return secondParameter;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        var secondParameter = start;
        foreach(var element in Reverse(input))
        {
            secondParameter = func(element, secondParameter);
        }
        return secondParameter;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        var resultingList = new List<T>();
        foreach(var list in input) 
        {
            resultingList = Append(resultingList, list);
        }
        return resultingList;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        var leftSideArray = left.ToArray();
        var leftListLength = Length(left);
        var rightListLength = Length(right);
        Array.Resize(ref leftSideArray, leftListLength + rightListLength);
        var leftAndRightArrays = new T[leftListLength + rightListLength];
        int i = 0;
        for (i = 0; i < leftListLength; i++) 
        {
            leftAndRightArrays[i] = left[i];
        }

        for (int j = 0; j < rightListLength; j ++)
        {
            leftAndRightArrays[i++] = right[j];
        }

        return leftAndRightArrays.ToList();
    }
}