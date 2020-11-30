using System;

public static class ResistorColorDuo
{ 
    private enum _resistorColor 
    {
        black =  0,
        brown = 1,
        red = 2,
        orange = 3,
        yellow = 4,
        green = 5,
        blue = 6,
        violet = 7,
        grey = 8,
        white = 9
    };

    public static int Value(string[] colors)
    {
        var firstBandColor = Enum.Parse<_resistorColor>(colors[0]);
        var secondBandColor = Enum.Parse<_resistorColor>(colors[1]);

        var resultingBands = $"{(int)firstBandColor}{(int)secondBandColor}";
        return Convert.ToInt32(resultingBands);
    }
}
