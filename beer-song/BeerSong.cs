using System.Text;

public static class BeerSong
{
	private const string LINE_BREAK = "\n\n";
    public static string Recite(int startBottles, int takeDown)
    {
    	StringBuilder stringBuilder = new StringBuilder();
		for (int i = 1; i <= takeDown; i++)
		{
			int bottlesLeft = startBottles - i;
    		stringBuilder.Append(FirstVerse(bottlesLeft + 1));
    		stringBuilder.Append(SecondVerse(bottlesLeft + 1, bottlesLeft));
			bool hasMoreThanOneLineToFinish = i < takeDown;
			if (hasMoreThanOneLineToFinish) stringBuilder.Append(LINE_BREAK);
		}
    	return stringBuilder.ToString();
    }

    private static string FirstVerse(int bottles)
    {
    	return $"{GetBegginingOfFirstVerse(bottles)} of beer on the wall, {GetBottlesForSecondPartOfVerse(bottles)} of beer.\n";
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

    private static string SecondVerse(int bottlesLeftBeforeRecitingLine, int bottlesLeft)
    {
		bottlesLeft = bottlesLeftBeforeRecitingLine == 0 ? 99 : bottlesLeft;
    	return $"{GetBegginingOfSecondVerse(bottlesLeftBeforeRecitingLine, bottlesLeft)}, {GetBottlesForSecondPartOfVerse(bottlesLeft)} of beer on the wall.";	
    }

    private static string GetBegginingOfSecondVerse(int bottlesLeftBeforereciteLine, int bottlesLeft)
    {
    	if (bottlesLeftBeforereciteLine == 0)
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