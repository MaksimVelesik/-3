using System;
using System.Collections.Generic;
using System.Linq;

public partial class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public Employee(string name, string position, double salary)
    {
        Name = name;
        Position = position;
        Salary = salary;
    }
}

public partial class Employee
{

    public static Employee[] GetHighestPaidEmployees(Employee[] employees)
    {
        double highestSalary = employees.Max(e => e.Salary);
        return employees.Where(e => e.Salary == highestSalary).ToArray();
    }

    public static Employee[] GetEmployeesByPosition(Employee[] employees, string position)
    {
        return employees.Where(e => e.Position.Equals(position, StringComparison.OrdinalIgnoreCase)).ToArray();
    }
}

public class Company
{
    private Employee[] employees;

    public Company(Employee[] employees)
    {
        this.employees = employees;
    }

    public Employee[] GetHighestPaidEmployees()
    {
        return Employee.GetHighestPaidEmployees(employees);
    }

    public Employee[] GetEmployeesByPosition(string position)
    {
        return Employee.GetEmployeesByPosition(employees, position);
    }
}

class Program
{
    static void Main()
    {
        Employee[] employees = new Employee[]
        {
            new Employee("Alice Smith", "Developer", 80000),
            new Employee("Bob Johnson", "Designer", 60000),
            new Employee("Charlie Davis", "Developer", 80000),
            new Employee("Diana Prince", "Manager", 90000),
            new Employee("Ethan Hunt", "Designer", 60000)
        };

        Company company = new Company(employees);

        Employee[] highestPaid = company.GetHighestPaidEmployees();
        Console.WriteLine("Сотрудники с самой высокой зарплатой:");
        foreach (var employee in highestPaid)
        {
            Console.WriteLine($"{employee.Name} - {employee.Position}: {employee.Salary}");
        }

        string positionToSearch = "Developer";
        Employee[] developers = company.GetEmployeesByPosition(positionToSearch);
        Console.WriteLine($"\nСотрудники на должности {positionToSearch}:");
        foreach (var employee in developers)
        {
            Console.WriteLine($"{employee.Name} - {employee.Position}: {employee.Salary}");
        }
    }
}