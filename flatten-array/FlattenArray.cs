
using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach(var element in input)
        {
            if (element is IEnumerable enumerable)
            {
                foreach(var el in Flatten(enumerable))
                {
                    yield return el;
                }
            }
            else if (!(element is null))
            {
                yield return element;
            }
        }
    }
}