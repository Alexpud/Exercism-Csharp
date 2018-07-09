using System;

public static class Raindrops
{
	public static string Convert(int number)
	{
		string output = "";

		if (IsFactorOfNumber(number, 3))
		{
			output += "Pling";
		}

		if (IsFactorOfNumber(number, 5))
		{
			output += "Plang";
		}

		if (IsFactorOfNumber(number, 7))
		{
			output += "Plong";
		}

		return output == "" ? number.ToString() : output;
	}

	private static bool IsFactorOfNumber(int number, int factor)
	{
		if (factor <= number)
		{
			return number % factor == 0;
		}

		return false;
	}
}