using System;
using System.Text;

public static class BeerSong
{
	private const string LINE_BREAK = "\n\n";
    public static string Recite(int startBottles, int takeDown)
    {
    	StringBuilder stringBuilder = new StringBuilder();
    	for (int i = takeDown; i > 0; i --)
    	{
    		int bottlesLeft = startBottles - 1;
    		stringBuilder.Append(FirstVerse(startBottles));
    		stringBuilder.Append(SecondVerse(startBottles, bottlesLeft));
    		if (i - 1 > 0) stringBuilder.Append(LINE_BREAK);
    		startBottles -= 1;
    	}
    	return stringBuilder.ToString();
    }

    private static string FirstVerse(int startBottles)
    {
    	return $"{GetBottlesAtBegginingFirstVerse(startBottles)} of beer on the wall, {GetBottles(startBottles)} of beer.\n";
    }

    private static string GetBottlesAtBegginingFirstVerse(int bottleQuantity)
    {
    	if (bottleQuantity == 1)
    	{
    		return "1 bottle";
    	}
    	if (bottleQuantity == 0)
    	{
    		return "No more bottles";
    	}
    	return bottleQuantity.ToString() + " bottles";
    }

    private static string SecondVerse(int startBottles, int bottlesLeft)
    {
    	string firstPhrase = GetSecondVerseFirstPhrase(startBottles, bottlesLeft);

    	string secondPhrase = "";
    	int bottles = bottlesLeft;
    	if (startBottles == 0)
    	{
    		bottles = 99;
    	}
    	return $"{firstPhrase}, {GetBottles(bottles)} of beer on the wall.";	
    }

    private static string GetSecondVerseFirstPhrase(int startBottles, int bottlesLeft)
    {
    	if (startBottles == 0)
    	{
    		return "Go to the store and buy some more";
    	}

    	string quantity = bottlesLeft != 0 ? "one" : "it";
    	return $"Take {quantity} down and pass it around";
    }

    private static string GetBottles(int bottleQuantity)
    {
    	if (bottleQuantity == 1)
    	{
    		return "1 bottle";
    	}
    	
    	if (bottleQuantity == 0)
    	{
    		return "no more bottles";
    	}

    	if (bottleQuantity < 0)
    	{
    		 return "99 bottles";
    	}

    	return bottleQuantity.ToString() + " bottles";
    }
}