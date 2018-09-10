using System;
using System.Linq;
using System.Collections.Generic;

public class GradeSchool
{
    private List<Student> studentList = new List<Student>();

    public void Add(string student, int grade)
    {
        studentList.Add(new Student(student, grade));
    }

    public IEnumerable<string> Roster()
    {
        return StudentListOrderedByNameAndGrade()
            .Select(student => student.Name);
    }

    public IEnumerable<string> Grade(int grade)
    {
        return StudentListOrderedByNameAndGrade()
            .Where(student => student.Grade == grade)
            .Select(student => student.Name);
    }

    private IEnumerable<Student> StudentListOrderedByNameAndGrade()
    {
        return studentList.OrderBy(student => student.Grade)
            .ThenBy(student => student.Name);
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