using System;
using System.Linq;
public class BinarySearch
{
    private int[] inputs { get; set; }
    public BinarySearch(int[] input)
    {
        inputs = input;
    }

    public int Find(int value)
    {
        if(!inputs.Any())
        {
            return -1;
        }
        return BinarySearchAlgo(0, inputs.Count() - 1, value);
    }

    private int BinarySearchAlgo(int lowerLimit, int upperLimit, int value)
    {
        int currentPosition = (lowerLimit + upperLimit) / 2;
        if(inputs[currentPosition] == value)
        {
            return currentPosition;
        }
        if(lowerLimit == upperLimit)
        {
            return - 1;
        }

        if (inputs[currentPosition] > value)
        {
            return BinarySearchAlgo(lowerLimit, currentPosition - 1, value);
        }
        else
        {
            return BinarySearchAlgo(currentPosition + 1, upperLimit, value);
        }
    }
}