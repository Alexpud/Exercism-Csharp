using System;
using System.Collections.Generic;
using System.Linq;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4 ,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private int allergyPoints;
    public Allergies(int mask)
    {
        allergyPoints = mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        int allergenAllergyPoints = (int)allergen;
        if (allergyPoints >= allergenAllergyPoints) return true;
        return false;
    }

    public Allergen[] List()
    {
        List<Allergen> listOfAllergies = new List<Allergen>();
        if (allergyPoints > 255)
        {
            AdjustAllergyScore();
            listOfAllergies.Add(Allergen.Eggs);
        }
        var allergenList = Enum.GetValues(typeof(Allergen)).Cast<Allergen>();
        foreach(var allergen in allergenList.Reverse())
        {
            int allergenAllergyPoints = (int)allergen;
            if (IsAllergicTo(allergen))
            {
                allergyPoints -= allergenAllergyPoints;
                listOfAllergies.Add(allergen);
            }
        }
        listOfAllergies.Reverse();
        return listOfAllergies.Distinct().ToArray();
    }

    private void AdjustAllergyScore()
    {
        while(allergyPoints > 255)
        {
            if (allergyPoints > 255)
            {
                allergyPoints %= 255;
            }
        }
        allergyPoints -= (int)Allergen.Eggs;
    }
}