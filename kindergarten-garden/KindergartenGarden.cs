using System;
using System.Linq;
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

    private Dictionary<students, string> studentsPlants;
    private const int StudentsCupsPerRow = 2;

    public KindergartenGarden(string diagram)
    {
        studentsPlants = new Dictionary<students, string>();
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
            GetStudentPlantsInRow(rowOfPlantCups, i, currentStudent);
        }
    }
    
    private students GetOwnerOfNextTwoPlants(int diagramRowIndex)
    {
        return (students)Enum.Parse(typeof(students), diagramRowIndex.ToString());
    }

    private void GetStudentPlantsInRow(string rowOfPlantCups, int positionOfCupOnRow, students ownerOfCups)
    {
        bool outOfBounds = positionOfCupOnRow + StudentsCupsPerRow > rowOfPlantCups.Length - 1;
        string plantsList = "";
        if (studentsPlants.ContainsKey(ownerOfCups))
        {
            if(outOfBounds)
            {
                plantsList = GetListOfPlantsOnStudentCups(rowOfPlantCups.Substring(positionOfCupOnRow));
            }
            else
            {
                plantsList = GetListOfPlantsOnStudentCups(rowOfPlantCups.Substring(positionOfCupOnRow, StudentsCupsPerRow));
            }
            studentsPlants[ownerOfCups] += plantsList;
        }
        else
        {
            if(outOfBounds)
            {
                plantsList = GetListOfPlantsOnStudentCups(rowOfPlantCups.Substring(positionOfCupOnRow));
            }
            else
            {
                plantsList = GetListOfPlantsOnStudentCups(rowOfPlantCups.Substring(positionOfCupOnRow, StudentsCupsPerRow));
            }
            studentsPlants.Add(ownerOfCups, plantsList);
        }
    }

    private string GetListOfPlantsOnStudentCups(string studentCups)
    {
        string plants = "";
        foreach(var plant in studentCups)
        {
            plants += plant;
        }
        return plants;
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var studentEnum = (students)Enum.Parse(typeof(students), student);
        return GetStudentPlantsAsEnum(studentsPlants[studentEnum]);
    }

    private IEnumerable<Plant> GetStudentPlantsAsEnum(string studentPlants)
    {
        return studentPlants.Select(plant => PlantEnumName(plant));
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
}