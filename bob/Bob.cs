using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Bob
{
    public static string Response(string statement)
    {
        string letters          = new String(statement.Where(x => Char.IsLetter(x)).ToArray());
        bool isShouting         = letters == letters.ToUpper() && !string.IsNullOrEmpty(letters);
        bool isAskingQuestion   = statement.Trim().EndsWith("?") && !string.IsNullOrEmpty(statement);
        bool emptyStatement     = statement.Trim().Where(x => Char.IsLetterOrDigit(x)).ToArray().Count() == 0;

        if(isShouting)
        {
            if(isAskingQuestion)
                return "Calm down, I know what I'm doing!";
            
            return "Whoa, chill out!";
        }

        if(isAskingQuestion)
            return "Sure.";

        if(emptyStatement)
            return "Fine. Be that way!";

        return "Whatever.";
    }
}