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
        Alice,
        Bob,
        Charlie,
        David,
        Eve,
        Fred,
        Ginny,
        Harriet,
        Ileana,
        Joseph,
        Kincaid,
        Larry
    }  

    private Dictionary<students, List<Plant>> studentsPlants;
    private const int StudentsCupsPerRow = 2;

    public KindergartenGarden(string diagram)
    {
        studentsPlants = new Dictionary<students, List<Plant>>();
        SeparatePlantsPerStudent(diagram);
    }

    private void SeparatePlantsPerStudent(string diagram)
    {
        var rows =  diagram.Split('\n');
        foreach(var diagramRow in rows)
        {
            GetPlantsPerRowByStudent(diagramRow);
        }
    }

    private void GetPlantsPerRowByStudent(string rowOfPlantCups)
    {
        var studentEnumList = Enum.GetValues(typeof(students));
        int currentStudentIndex = 0;
        for(int i = 0; i < rowOfPlantCups.Length; i+= StudentsCupsPerRow)
        {
            var student = GetOwnerOfNextTwoPlants(i);
            bool outOfBounds = i + StudentsCupsPerRow > rowOfPlantCups.Length - 1;
            students currentStudent = (students)studentEnumList.GetValue(currentStudentIndex++); 
            if (outOfBounds)
            {
                PlantsInEndOfTheRow(rowOfPlantCups, i, currentStudent);
            }
            else
            {
                PlantsInBegginingOfTheRow(rowOfPlantCups, i, currentStudent);
            }
        }
    }

    private students GetOwnerOfNextTwoPlants(int diagramRowIndex)
    {
        return (students)Enum.Parse(typeof(students), diagramRowIndex.ToString());
    }

    private void PlantsInEndOfTheRow(string rowOfPlantCups, int positionOfCupOnRow, students ownerOfCups)
    {
        if (studentsPlants.ContainsKey(ownerOfCups))
        {
            var plantsList = GetListOfPlantsOnStudentCups(rowOfPlantCups.Substring(positionOfCupOnRow));
            studentsPlants[ownerOfCups].AddRange(plantsList);
        }
        else
        {
            var plantsList = GetListOfPlantsOnStudentCups(rowOfPlantCups.Substring(positionOfCupOnRow));
            studentsPlants.Add(ownerOfCups, plantsList);
        }
    }

    private void PlantsInBegginingOfTheRow(string rowOfPlantCups, int positionOfCupOnRow, students ownerOfCups)
    {
        if (studentsPlants.ContainsKey(ownerOfCups))
        {
            var plantsList = GetListOfPlantsOnStudentCups(rowOfPlantCups.Substring(positionOfCupOnRow, StudentsCupsPerRow)); 
            studentsPlants[ownerOfCups].AddRange(plantsList);   
        }
        else
        {
            var plantsList = GetListOfPlantsOnStudentCups(rowOfPlantCups.Substring(positionOfCupOnRow, StudentsCupsPerRow));
            studentsPlants.Add(ownerOfCups, plantsList);
        }
    }

    private List<Plant> GetListOfPlantsOnStudentCups(string studentCups)
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