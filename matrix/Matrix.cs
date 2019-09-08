﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

static class StringExtensions
{
    public static string[] SplitByLineBreak(this string input)
    {
        return input.Split("\n");
    }

    public static string[] SplitByEmptySpace(this string input)
    {
        return input.Split(" ");
    }
}

public class Matrix
{
    private int[][] _matrix;
    public Matrix(string input)
    {
        var matrixLine = input.SplitByLineBreak();
        var size = matrixLine.Count();
        _matrix = new int[size][];
        for(int i = 0; i < size; i++)
        {
            var row = ConvtertToMatrixRow(matrixLine[i]);
            _matrix[i] = row;
        }
    }

    private int[] ConvtertToMatrixRow(string line)
    {
        return line.SplitByEmptySpace()
            .Select(number => Convert.ToInt32(number))
            .ToArray();
    }

    public int Rows
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public int Cols
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public int[] Row(int row)
    {
        return _matrix[row - 1];
    }

    public int[] Column(int col)
    {
        var column = new int[_matrix.Length];
        for(int i = 0; i < _matrix.Length; i++)
        {
            column[i] = _matrix[i][col - 1];
        }
        return column;
    }
}