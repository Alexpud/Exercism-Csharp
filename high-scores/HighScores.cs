using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private List<int> scoresList;
    public HighScores(List<int> list)
    {
        scoresList = list;
    }

    public List<int> Scores()
    {
        return scoresList;
    }

    public int Latest()
    {
        return scoresList.LastOrDefault();
    }

    public int PersonalBest()
    {
        return scoresList.OrderByDescending(score => score)
            .FirstOrDefault();
    }

    public List<int> PersonalTopThree()
    {
        return scoresList.OrderByDescending(score => score)
            .Take(3)
            .ToList();
    }
}