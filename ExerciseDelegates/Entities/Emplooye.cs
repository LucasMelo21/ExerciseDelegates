using System;

namespace ExerciseDelegates.Entities {
    internal class Employee {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee() { }
        public Employee(string name, double salary) {
            Name = name;
            Salary = salary;
        }

        public override string ToString() {
            return Name + " - " + Salary.ToString("F2");
        }
    }

}
