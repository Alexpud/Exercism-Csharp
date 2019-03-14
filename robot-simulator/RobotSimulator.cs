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
        _direction = direction;
        _x = x;
        _y = y;
    }

    private Direction _direction;

    public Direction Direction
    {
        get
        {
            return _direction;
        }
    }

    private int _x;

    public int X
    {
        get
        {
            return _x;
        }
    }

    private int _y;

    public int Y
    {
        get
        {
            return _y;
        }
    }

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
            }
        }
    }

    private void MoveRight()
    {
        int value = (int)_direction + 1;
        bool clockWiseCircle = value >= Enum.GetValues(typeof(Direction)).Length;
        if (clockWiseCircle)
        {
            value = 0;
        }
        Enum.TryParse(value.ToString(), out _direction);
    }

    private void MoveLeft()
    {
        int value = (int)_direction - 1;
        bool counterClockWiseCircle = value < 0;
        if (counterClockWiseCircle)
        {
            value = Enum.GetValues(typeof(Direction)).Length - 1;
        }
        Enum.TryParse(value.ToString(), out _direction);
    }

    private void MoveForward()
    {
        if (_direction == Direction.South || _direction == Direction.North)
        {
            _y += _direction == Direction.South ? -1 :
                _direction == Direction.North ? 1 : 0;
            return;
        }
        
        _x += _direction == Direction.East ? 1 :
            _direction == Direction.West ? -1 : 0;
    }

}