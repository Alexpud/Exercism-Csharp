using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

[Flags]
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
        if (allergyPoints == 0) return new Allergen[] {};
        var allergens = (Allergen)allergyPoints;
        var allergensArray = allergens.ToString().Split(',');
        var allergenList = allergensArray
            .Select(allergen => 
                (Allergen)Enum.Parse(typeof(Allergen), allergen)).ToArray();
        
        allergicToList.AddRange(allergenList);
        return allergicToList.Distinct().ToArray();
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return allergyPoints >= (int)allergen;
    }
}