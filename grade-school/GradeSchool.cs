using System;
using System.Linq;
using System.Collections.Generic;

public class GradeSchool
{
    private List<Student> StudentList;

    public GradeSchool()
    {
        StudentList = new List<Student>();
    }

    public void Add(string student, int grade)
    {
        StudentList.Add(NewStudent(student, grade));
    }

    public IEnumerable<string> Roster()
    {
        return StudentListOrderedByNameAndGrade()
            .Select(x => x.Name)
            .ToList();
    }

    public IEnumerable<string> Grade(int grade)
    {
        return StudentListOrderedByNameAndGrade()
            .Where(student => student.Grade == grade)
            .Select(student => student.Name);
    }

    private IEnumerable<Student> StudentListOrderedByNameAndGrade()
    {
        return StudentList.OrderBy(student => student.Grade)
            .ThenBy(student => student.Name);
    }

    private Student NewStudent(string name, int grade)
    {
        return new Student(name, grade);
    }

    private class Student
    {
        public string Name { get; set; }   
        public int Grade { get; set; }

        public Student(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
    }
}