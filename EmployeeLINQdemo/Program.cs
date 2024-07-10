using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeLINQdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice", Lastname = "Smith", Salary = 50000, Age = 30, SeniorityInTheCompany = 5 },
                new Employee { Id = 2, Name = "Bob", Lastname = "Johnson", Salary = 60000, Age = 35, SeniorityInTheCompany = 7 },
                new Employee { Id = 3, Name = "Charlie", Lastname = "Williams", Salary = 55000, Age = 28, SeniorityInTheCompany = 3 },
                new Employee { Id = 4, Name = "David", Lastname = "Brown", Salary = 70000, Age = 40, SeniorityInTheCompany = 10 },
                new Employee { Id = 5, Name = "Eve", Lastname = "Jones", Salary = 48000, Age = 25, SeniorityInTheCompany = 2 }
            };

            // CONSULTAS CON LINQ
            // sintaxis de consulta
            var seniorEmployees = from e in employees
                                  where e.SeniorityInTheCompany > 5
                                  select e;

            Console.WriteLine("Empleados con más de 5 años de antigüedad en la empresa:");
            foreach (var emp in seniorEmployees)
            {
                Console.WriteLine($"{emp.Name} {emp.Lastname} - {emp.SeniorityInTheCompany} años");
            }

            //Sintaxis de Métodos
            var highSalaryEmployees = employees.Where(e => e.Salary > 55000);

            Console.WriteLine("Empleados con salario mayor a 55000:");
            foreach (var emp in highSalaryEmployees)
            {
                Console.WriteLine($"{emp.Name} {emp.Lastname} - {emp.Salary}");
            }

            var orderedByAge = employees.OrderBy(e => e.Age);

            Console.WriteLine("Empleados ordenados por edad:");
            foreach (var emp in orderedByAge)
            {
                Console.WriteLine($"{emp.Name} {emp.Lastname} - {emp.Age} años");
            }

            var averageSalary = employees.Average(e => e.Salary);
            Console.WriteLine($"Salario promedio: {averageSalary}");


            var employeesWithJLastname = from e in employees
                                         where e.Lastname.StartsWith("J")
                                         select new { FullName = $"{e.Name} {e.Lastname[0]}." };
            Console.WriteLine("Empleados cuyos apellidos comienzan con 'J':");
            foreach (var emp in employeesWithJLastname)
            {
                Console.WriteLine(emp.FullName);
            }

        }
    }
}