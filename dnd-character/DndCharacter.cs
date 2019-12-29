using System;
using System.Collections.Generic;
using System.Linq;
public class DndCharacter
{
    public int Strength { get; }
    public int Dexterity { get;}
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }
    private const int InitialHitpoints = 10;

    private DndCharacter(int strength, int dextrety, int constitution, int intelligence, int wisdom, 
        int charisma,
        int hitpoints)
    {
        Strength = strength;
        Dexterity = dextrety;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
        Hitpoints = hitpoints;
    }

    public static int Modifier(int score)
    {
        var constitutionModifier = (score - InitialHitpoints) / 2.0;
        return constitutionModifier < 0 ? (int)Math.Ceiling(Math.Abs(constitutionModifier)) * -1 : (int)Math.Floor(constitutionModifier);
    }

    public static int Ability()
    {
        List<int> dices = RowDice(4);

        var orderedDices = dices.OrderByDescending(x => x)
            .ToList();

        return Enumerable.Range(0, 3).Select(position => orderedDices[position]).Sum();
    }

    private static List<int> RowDice(int timesDiceThrown)
    {
        List<int> dices = new List<int>();
        for (int i = 0; i < timesDiceThrown; i++)
        {
            var randomNumber = new Random().Next(1, 6);
            dices.Add(randomNumber);
        }
        return dices;
    }

    public static DndCharacter Generate()
    {
        var constitution = Ability();
        return new DndCharacter(strength: Ability(), dextrety: Ability(), constitution: constitution,
            intelligence: Ability(),
            wisdom: Ability(),
            charisma: Ability(),
            hitpoints: InitialHitpoints + Modifier(constitution));
    }
}
