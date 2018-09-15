using System;
using System.Collections.Generic;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private enum students
    {
        Alice = 0,
        Bob = 2,
        Charlie = 4,
        David = 6,
        Eve = 8,
        Fred = 10,
        Ginny = 12,
        Harriet = 14,
        Ileana = 16,
        Joseph = 18,
        Kincaid = 20,
        Larry = 22
    }  

    private Dictionary<students, List<Plant>> studentsPlants;

    public KindergartenGarden(string diagram)
    {
        studentsPlants = new Dictionary<students, List<Plant>>()
        {
            { students.Alice, new List<Plant>() },
            { students.Bob, new List<Plant>()},
            { students.Charlie, new List<Plant>() },
            { students.David, new List<Plant>() },
            { students.Eve, new List<Plant>() },
            { students.Fred, new List<Plant>() },
            { students.Ginny, new List<Plant>() },
            { students.Harriet, new List<Plant>() },
            { students.Ileana, new List<Plant>() },
            { students.Joseph, new List<Plant>() },
            { students.Kincaid, new List<Plant>() },
            { students.Larry, new List<Plant>() },
        };

        SeparatePlantsPerStudent(diagram);
    }

    private void SeparatePlantsPerStudent(string diagram)
    {
        int endOfRow = diagram.IndexOf('\n');
        PlantsPerRowByStudent(diagram.Substring(0, endOfRow));
        PlantsPerRowByStudent(diagram.Substring(endOfRow + 1));  
    }

    private void PlantsPerRowByStudent(string rowOfPlantCups)
    {
        for(int i = 0; i < rowOfPlantCups.Length; i+= 2)
        {
            var student = OwnerOfNextTwoPlants(i);
            bool outOfBounds = i + 2 > rowOfPlantCups.Length - 1;
            if(outOfBounds)
            {
                studentsPlants[student]
                    .AddRange(PlantsOnStudentCups(rowOfPlantCups.Substring(i)));
            }
            else
            {
                studentsPlants[student]
                    .AddRange(PlantsOnStudentCups(rowOfPlantCups.Substring(i, 2)));
            }
        }
    }

    private students OwnerOfNextTwoPlants(int diagramRowIndex)
    {
        switch(diagramRowIndex)
        {
            case 0:
                return students.Alice;
            case 2:
                return students.Bob;
            case 4:
                return students.Charlie;
            case 6:
                return students.David;
            case 8:
                return students.Eve;
            case 10:
                return students.Fred;
            case 12:
                return students.Ginny;
            case 14:
                return students.Harriet;
            case 16:
                return students.Ileana;
            case 18:
                return students.Joseph;
            case 20:
                return students.Kincaid;
            case 22:
                return students.Larry;
            default:
                throw new ArgumentException();
        }
    }

    private List<Plant> PlantsOnStudentCups(string studentCups)
    {
        List<Plant> plants = new List<Plant>();
        foreach(var plant in studentCups)
        {
            plants.Add(PlantEnumName(plant));
        }
        return plants;
    }

    private Plant PlantEnumName(char plant)
    {
        switch(plant)
        {
            case 'V':
                return Plant.Violets;
            case 'G':
                return Plant.Grass;
            case 'R':
                return Plant.Radishes;
            case 'C':
                return Plant.Clover;
            default:
                throw new ArgumentException();
        }
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var studentEnum = (students)Enum.Parse(typeof(students), student);
        return studentsPlants[studentEnum];
    }
}