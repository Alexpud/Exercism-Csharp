using System;

  public static class TwoFer
  {
      public static string Name(string input = null)
      {
          string whoIsItFor = input ?? "you";
          return $"One for {whoIsItFor}, one for me.";
      }
  }
