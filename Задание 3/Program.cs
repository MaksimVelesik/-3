using System;
using System.Linq;

public abstract class Person
{
    public string FullName { get; set; }
    public int Age { get; set; }

    protected Person(string fullName, int age)
    {
        FullName = fullName;
        Age = age;
    }
}

public sealed class Student : Person
{
    public double AverageScore { get; set; }

    public Student(string fullName, int age, double averageScore)
        : base(fullName, age)
    {
        AverageScore = averageScore;
    }
}

public sealed class Teacher : Person
{
    public string Subject { get; set; }

    public Teacher(string fullName, int age, string subject)
        : base(fullName, age)
    {
        Subject = subject;
    }
}

public class University
{
    private Person[] persons;

    public University(Person[] persons)
    {
        this.persons = persons;
    }

    public Student GetBestStudent()
    {
        return persons.OfType<Student>().OrderByDescending(s => s.AverageScore).FirstOrDefault();
    }

    public Teacher[] GetTeachersByAge(int age)
    {
        return persons.OfType<Teacher>().Where(t => t.Age > age).ToArray();
    }
}

class Program
{
    static void Main()
    {
        Person[] persons = new Person[]
        {
            new Student("Alice Smith", 20, 4.5),
            new Student("Bob Johnson", 22, 3.8),
            new Teacher("Dr. Brown", 45, "Mathematics"),
            new Teacher("Prof. Green", 50, "Physics"),
            new Student("Charlie Davis", 21, 4.9)
        };

        University university = new University(persons);

        Student bestStudent = university.GetBestStudent();
        if (bestStudent != null)
        {
            Console.WriteLine($"Лучший студент: {bestStudent.FullName} с средним баллом {bestStudent.AverageScore}");
        }

        Teacher[] experiencedTeachers = university.GetTeachersByAge(40);
        Console.WriteLine("\nПреподаватели старше 40 лет:");
        foreach (var teacher in experiencedTeachers)
        {
            Console.WriteLine($"{teacher.FullName}, предмет: {teacher.Subject}");
        }
    }
}