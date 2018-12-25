using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

[Flags]
public enum Allergen
{
    None = 0,
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
    private int mask;
    private const int MaxAllergyPoints = 255;
    private List<Allergen> allergicToList = new List<Allergen>();

    public Allergies(int mask)
    {
        this.mask = mask;
        if ((int)Allergen.None == this.mask)
        {
            return;
        }

        if (this.mask > MaxAllergyPoints)
        {
            this.mask = (this.mask % MaxAllergyPoints) - 1;
            allergicToList.Add(Allergen.Eggs);
        }

        var allergens = (Allergen)this.mask;
        allergicToList = allergens.ToString().Split(", ")
            .Select(allergen => (Allergen)Enum.Parse(typeof(Allergen), allergen))
            .Distinct().ToList();
    }

    public Allergen[] List()
    {
        return allergicToList.ToArray();
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return (mask & (int)allergen) > 0;
    }
}