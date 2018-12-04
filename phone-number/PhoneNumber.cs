using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{

    public static string Clean(string phoneNumber)
    {
        ValidatePhoneNumber(phoneNumber);
        Regex rx = new Regex(@"\d+",  RegexOptions.Compiled);
        MatchCollection matches = rx.Matches(phoneNumber);
        
        string digits = "";
        if (matches.Count == 1)
        {
            digits = matches[0].ToString();
        }
        else
        {
            int j = matches.Count == 4 ? 1 : 0;
            for (int i = j; i < matches.Count; i++)
            {
                string matchedDigits = matches[i].ToString();
                bool areAreaCodeDigits = (j == 0 && i == 0) || (j == 1 && i == 1);
                bool areExchangeCodeDigits = (j == 0 && i == 1) || (j == 1 && i == 2);
                if (areAreaCodeDigits) ValidateAreaCode(matchedDigits);
                if (areExchangeCodeDigits) ValidateExchangeCode(matchedDigits);
                digits += matchedDigits;
            }
        }

        ValidateCleanDigits(digits);
        return digits.Length == 11 ? digits.Substring(1) : digits;
    }

    private static void ValidatePhoneNumber(string phoneNumber)
    {
        PhoneNumberPossessLetters(phoneNumber);
        PhoneNumberPossessSymbols(phoneNumber);
    }

    private static void PhoneNumberPossessLetters(string phoneNumber)
    {
        Regex rx = new Regex(@"[a-z]",  RegexOptions.Compiled);
        MatchCollection matches = rx.Matches(phoneNumber);
        if (matches.Count != 0)
        {
            throw new ArgumentException("Phone number possess letters");
        }
    }

    private static void PhoneNumberPossessSymbols(string phoneNumber)
    {
        Regex rx = new Regex(@"(@|:|!)",  RegexOptions.Compiled);
        MatchCollection matches = rx.Matches(phoneNumber);
        if (matches.Count != 0)
        {
            throw new ArgumentException("Phone number possess symbols");
        }
    }

   private static void ValidateAreaCode(string phoneAreaCode)
    {
        if (phoneAreaCode[0] == '1' || phoneAreaCode[0] == '0')
        {
            throw new ArgumentException();
        }
    }

    private static void ValidateExchangeCode(string phoneExchangeCode)
    {
        if (phoneExchangeCode[0] == '0' || phoneExchangeCode[0] == '1')
        {
            throw new ArgumentException();
        }
    }

    private static void ValidateCleanDigits(string digits)
    {
        if (digits[0] == '0')
        {
            throw new ArgumentException("Phone number can't start with 0");
        }

        if (digits.Length == 11 && digits[0] != '1')
        {
            throw new ArgumentException("11 digits number not starting with 1");
        }

        if (digits.Length > 11 || digits.Length == 9)
        {
            throw new ArgumentException();
        }
    }
}