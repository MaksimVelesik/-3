using System;
using System.Linq;

public class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }

    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }
}

public static class ArrayOperations
{
    public static double CalculateAverageSalary(Employee[] employees)
    {
        return employees.Length == 0 ? 0 : employees.Average(e => e.Salary);
    }

    public static Employee[] SortBySalary(Employee[] employees)
    {
        return employees.OrderBy(e => e.Salary).ToArray();
    }

    public static Employee[] FilterBySalary(Employee[] employees, double minSalary)
    {
        return employees.Where(e => e.Salary > minSalary).ToArray();
    }

    public static Employee[] GenerateRandomEmployees(int count)
    {
        Random random = new Random();
        return Enumerable.Range(1, count).Select(i => new Employee($"Employee {i}", random.Next(30000, 100000))).ToArray();
    }
}

class Program
{
    static void Main()
    {
        Employee[] employees = ArrayOperations.GenerateRandomEmployees(10);

        Console.WriteLine("Сгенерированные сотрудники:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.Name}: {employee.Salary}");
        }

        Console.WriteLine($"\nСредняя зарплата: {ArrayOperations.CalculateAverageSalary(employees):F2}");

        Console.WriteLine("\nСотрудники, отсортированные по зарплате:");
        foreach (var employee in ArrayOperations.SortBySalary(employees))
        {
            Console.WriteLine($"{employee.Name}: {employee.Salary}");
        }

        Console.WriteLine("\nСотрудники с зарплатой выше 50000:");
        foreach (var employee in ArrayOperations.FilterBySalary(employees, 50000))
        {
            Console.WriteLine($"{employee.Name}: {employee.Salary}");
        }
    }
}