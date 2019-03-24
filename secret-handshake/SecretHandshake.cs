using System;
using System.Collections.Generic;

public static class SecretHandshake
{
    private enum handshakes 
    {
        Wink = 1,
        DoubleWink = 2,
        CloseYourEyes = 4,
        Jump = 8,
        Reverse = 16
    }

    public static string[] Commands(int commandValue)
    {
        int result = commandValue;
        List<string> commands = new List<string>();
        foreach(var handshake in Enum.GetValues(typeof(handshakes)))
        {
            bool isHandshake = (result & (int)handshake) == (int)handshake;
            if (isHandshake)
            {
                if ((handshakes)handshake == handshakes.Reverse)
                {
                    commands.Reverse();
                    continue;
                }
                commands.Add(ParseHandshake((handshakes)handshake));
            }
        }
        return commands.ToArray();
    }

    private static string ParseHandshake(handshakes handshake)
    {
        var name = Enum.GetName(typeof(handshakes), handshake);
        switch(handshake)
        {
            case handshakes.Wink:
                return "wink";

            case handshakes.DoubleWink:
                return "double blink";

            case handshakes.CloseYourEyes:
                return "close your eyes";
            
            case handshakes.Jump:
                return "jump";

            default:
                throw new ArgumentOutOfRangeException("Unknown handshake");
        }
    }
}
