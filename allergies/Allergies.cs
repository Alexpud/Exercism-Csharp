using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

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
    private const int MaxAllergyPoints = 255;
    private List<Allergen> allergicToList;

    public Allergies(int mask)
    {
        allergicToList = mask > MaxAllergyPoints ? 
            new List<Allergen>() { Allergen.Eggs} :
            new List<Allergen>();

        allergyPoints = mask > MaxAllergyPoints ? 
            (mask & MaxAllergyPoints)  : mask;
    }

    public Allergen[] List()
    {
        var allergens = GetAllergenList();
        allergens.Reverse();
        foreach(var allergen in allergens)
        {
            if (IsAllergicTo(allergen))
            {
                allergyPoints -= (int)allergen;
                allergicToList.Add(allergen);
            }
        }
        allergicToList = allergicToList.OrderBy(allergen => (int)allergen)
            .Distinct().ToList();
        return allergicToList.ToArray();
    }

    private List<Allergen> GetAllergenList()
    {
        return Enum.GetValues(typeof(Allergen))
            .Cast<Allergen>()
            .ToList();
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return allergyPoints >= (int)allergen;
    }
}