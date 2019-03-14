using System;

public class Queen
{
    public Queen(int row, int column)
    {
        if (row < 0 || column < 0)
        {
            throw new ArgumentOutOfRangeException("Queen position can not be negative");
        }

        if (row >= 8 || column >= 8)
        {
            throw new ArgumentOutOfRangeException("Queen position must not be outside the board");
        }

        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        bool sameDiagonal = Math.Abs(white.Row - black.Row) == Math.Abs(white.Column - black.Column);
        bool sameLine = (white.Row == black.Row);
        bool sameColumn = (white.Column == black.Column);
        return sameDiagonal || sameLine || sameColumn;
    }

    public static Queen Create(int row, int column)
    {
        return new Queen(row, column);
    }
}