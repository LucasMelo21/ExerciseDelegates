using System;
using System.Linq;
using ExerciseDelegates.Entities;

namespace ExerciseDelegates {
    class Program {
        static void Main(string[] args) {
            List<Employee> emp = new List<Employee>();
            emp.Add(new Employee("João", 5000.0));
            emp.Add(new Employee("Maria", 4000.0));
            emp.Add(new Employee("Jamil", 3000.0));
            emp.Add(new Employee("Peter", 2500.0));

            Console.WriteLine("Name.ToUpper(): ");
            Func<Employee, string> func = p => p.Name.ToUpper() + " - " + p.Salary;
            List<string> result = emp.Select(func).ToList();
            foreach(string employee in result) {
                Console.WriteLine(employee);
            }
            Console.WriteLine("-------------------------");
            emp.RemoveAll(RemoveEmp);
            Console.WriteLine("After removing: ");
            foreach(Employee employee in emp) {
                Console.WriteLine(employee);
            }
            Console.WriteLine("-------------------------");
            Action<Employee> action = Increase;
            Action<Employee> action1 = p => p.Salary *= 1.15;
            emp.ForEach(action);
            emp.ForEach(action1);
            emp.ForEach(p => p.Salary *= 1.15);
            Console.WriteLine("After increasing:");
            foreach(Employee employee in emp) {
                Console.WriteLine(employee);
            }

        }
        static bool RemoveEmp(Employee emp) {
            return emp.Salary <= 3000.0;
        }
        static void Increase(Employee emp) {
            emp.Salary *= 1.15;
        }
    }
}