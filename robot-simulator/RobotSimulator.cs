using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }

    public Direction Direction { get; private set;}

    public int X { get; private set; }
    public int Y { get; private set; } 

    public void Move(string instructions)
    {
        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case 'R':
                    MoveRight();
                    break;

                case 'L':
                    MoveLeft();
                    break;

                case 'A':
                    MoveForward();
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Unrecognized instruction");
            }
        }
    }

    private void MoveRight()
    {
        int directionValue = (int)Direction + 1;
        bool clockWiseCircle = directionValue  >= Enum.GetValues(typeof(Direction)).Length;
        if (clockWiseCircle)
        {
            directionValue = 0;
        }

        SetDirection(directionValue);
    }

    private void SetDirection(int directionValue)
    {
        Direction direction;
        Enum.TryParse(directionValue.ToString(), out direction);
        Direction = direction;
    }

    private void MoveLeft()
    {
        int value = (int)Direction - 1;
        bool counterClockWiseCircle = value < 0;
        if (counterClockWiseCircle)
        {
            value = Enum.GetValues(typeof(Direction)).Length - 1;
        }
        SetDirection(value);
    }

    private void MoveForward()
    {
        switch(Direction)
        {
            case Direction.South:
                Y += -1;
                break;

            case Direction.North:
                Y += 1;
                break;

            case Direction.West:
                X += -1;
                break;

            case Direction.East:
                X += 1;
                break;

            default:
                throw new ArgumentOutOfRangeException("Unrecognized direction");
        }
    }
}