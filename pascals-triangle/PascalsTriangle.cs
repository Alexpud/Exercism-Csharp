using System.Collections.Generic;
using System.Linq;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var previousTriangleLvlElements = new List<int>(){1};
        var pascalTriangle = new List<List<int>>();
        if (rows == 0)
        {
            return Enumerable.Empty<IEnumerable<int>>();
        }
        
        pascalTriangle.Add(previousTriangleLvlElements);
        for(var currentTriangleLvl = 1; currentTriangleLvl < rows; currentTriangleLvl++)
        {
            var newTriangleLvl = GetNewTriangleLvl(previousTriangleLvlElements, currentTriangleLvl);
            pascalTriangle.Add(newTriangleLvl);
            previousTriangleLvlElements = newTriangleLvl;
        }
        return pascalTriangle;
    }

    private static List<int> GetNewTriangleLvl(List<int> previousTriangleLvlElements,  int currentTriangleLvl)
    {
        var newTriangleLvlElements = new List<int>();
        for (int newTriangleColumn = 0; newTriangleColumn <= currentTriangleLvl; newTriangleColumn++)
        {
            newTriangleLvlElements.Add(GetCurrentTriangleColumnValue(newTriangleColumn, previousTriangleLvlElements));
        }
        return newTriangleLvlElements;
    }

    private static int GetCurrentTriangleColumnValue(int newLineColumn, List<int> previousTriangleLvlElements)
    {
        var valueInPreviousColumnInLvlAbove = newLineColumn == 0 ? 0 : previousTriangleLvlElements[newLineColumn - 1];
        var valueInCurrentColumnLvlAbove = newLineColumn >= previousTriangleLvlElements.Count() ? 0  : previousTriangleLvlElements[newLineColumn];
        return valueInPreviousColumnInLvlAbove + valueInCurrentColumnLvlAbove;
    }
}