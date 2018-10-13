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
    private int allergyScore;
    private int allergyPoints;
    public Allergies(int mask)
    {
        allergyScore = mask;
        allergyPoints = allergyScore;
    }


    public bool IsAllergicTo(Allergen allergen)
    {
        int allergenScore = (int)allergen;
        if (allergyPoints < allergenScore) return false;
        return true;
    }

    private bool IsAllergicTo2(Allergen allergen)
    {
        int allergenPoints = (int)allergen;
        if ( allergyPoints >= allergenPoints)
        {
            if (allergyPoints == allergenPoints)
            {
                allergyPoints -= allergenPoints;
                return true;
            }
            else
            {
                allergyPoints -= allergenPoints;
                return true;
            }
        }
        return false;
    }

    public Allergen[] List()
    {
        List<Allergen> listOfAllergies = new List<Allergen>();
        if (allergyScore > 255)
        {
            allergyPoints = AdjustAllergyScore() - 1;
            listOfAllergies.Add(Allergen.Eggs);
        }
        foreach(var allergen in Enum.GetValues(typeof(Allergen)).Cast<Allergen>().Reverse())
        {
            int allergenAllergyPoints = (int)allergen;
            if ( allergyPoints >= allergenAllergyPoints)
            {
                if (allergyPoints == allergenAllergyPoints)
                {
                    allergyPoints -= allergenAllergyPoints;
                    listOfAllergies.Add(allergen);
                }
                else
                {
                    if (IsAllergicTo(allergen))
                    {
                        allergyPoints -= allergenAllergyPoints;
                        listOfAllergies.Add(allergen);
                    }
                }
            }
        }
        listOfAllergies.Reverse();
        return listOfAllergies.Distinct().ToArray();
    }

    private int AdjustAllergyScore()
    {
        int adjustedAllergyScore = allergyScore;
        while(adjustedAllergyScore > 255)
        {
            if(adjustedAllergyScore > 255)
            {
                adjustedAllergyScore %= 255;
            }
        }
        return adjustedAllergyScore;
    }
}