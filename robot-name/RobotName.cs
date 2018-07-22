using System;

public class Robot
{
    public string Name
    {
        get
        {
            return _AuxiliaryRobotName;
        }
    }

    private string _AuxiliaryRobotName { get; set;}
    
    public Robot()
    {
      _AuxiliaryRobotName = ThreeRandomLetters() + ThreeRandomNumbers();
    }

    public void Reset()
    {
        _AuxiliaryRobotName = ThreeRandomLetters() + ThreeRandomNumbers();
    }

    public string ThreeRandomLetters()
    {
        Random random = new Random();
        string result = "";

        int seed = random.Next(65, 90);
        result += (char)seed;

        seed = random.Next(65, 90);
        result += (char)seed;

        seed = random.Next(65, 90);
        result += (char)seed;

        return result;
    }

    public string ThreeRandomNumbers()
    {
        Random random = new Random();
        string result = "";

        int seed = random.Next(0, 9);
        result += seed;

        seed = random.Next(0, 9);
        result += seed;

        seed = random.Next(0, 9);
        result += seed;

        return result;
    }
}