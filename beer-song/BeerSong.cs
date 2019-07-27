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
    	return $"{GetBegginingOfFirstVerse(startBottles)} of beer on the wall, {GetBottlesForSecondPartOfVerse(startBottles)} of beer.\n";
    }

    private static string GetBegginingOfFirstVerse(int bottleQuantity)
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
		bottlesLeft = startBottles == 0 ? 99 : bottlesLeft;
    	return $"{GetBegginingOfSecondVerse(startBottles, bottlesLeft)}, {GetBottlesForSecondPartOfVerse(bottlesLeft)} of beer on the wall.";	
    }

    private static string GetBegginingOfSecondVerse(int startBottles, int bottlesLeft)
    {
    	if (startBottles == 0)
    	{
    		return "Go to the store and buy some more";
    	}

    	string bottlesQuantity = bottlesLeft != 0 ? "one" : "it";
    	return $"Take {bottlesQuantity} down and pass it around";
    }

    private static string GetBottlesForSecondPartOfVerse(int bottleQuantity)
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