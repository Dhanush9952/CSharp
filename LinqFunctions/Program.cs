using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFunctions
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Salary { get; set; }
        public string Dept { get; set; }
        public string Gender { get; set; }

        // internal static object GetAllEmployees()
        // {
        //     throw new NotImplementedException();
        // }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> listStudents = new List<Employee>()
            {
                new Employee{ID= 101,Name = "Preety", Salary = 16000, Dept = "IT", Gender = "Female"},
                new Employee{ID= 102,Name = "Priyanka", Salary = 15000, Dept = "Sales",  Gender = "Female"},
                new Employee{ID= 103,Name = "James", Salary = 50000, Dept = "Sales",  Gender = "Male"},
                new Employee{ID= 104,Name = "Hina", Salary = 23000, Dept = "IT", Gender = "Female"},
                new Employee{ID= 105,Name = "Anurag", Salary = 46000, Dept = "IT",  Gender = "Male"},
                new Employee{ID= 106,Name = "Sara", Salary = 25000, Dept = "IT", Gender = "Female"},
                new Employee{ID= 107,Name = "Pranaya", Salary = 35000, Dept = "IT", Gender = "Female"},
                new Employee{ID= 108,Name = "Manoj", Salary = 11000, Dept = "Sales",  Gender = "Male"},
                new Employee{ID= 109,Name = "Sam", Salary = 45000, Dept = "Sales",  Gender = "Male"},
                new Employee{ID= 110,Name = "Saurav", Salary = 25000, Dept = "Sales",  Gender = "Male"}
            };
            return listStudents;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tableData = from TD in Employee.GetAllEmployees()
                            where TD.ID > 0
                            select (TD.ID, TD.Name, TD.Salary, TD.Dept);
            foreach (var t in tableData)
            {
                System.Console.WriteLine(t);
            }
            // To show Aggregate function 
            // int[] intNumbers = { 3, 5, 7, 9 };
            // int result = intNumbers.Aggregate((n1, n2) => n1 * n2);
            // System.Console.WriteLine(result);
            // output:945 
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Choose the Department:");
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("1.IT");
            System.Console.WriteLine("2.Sales");
            System.Console.Write("Option: ");
            string ch = Console.ReadLine();
            int choice = Convert.ToInt32(ch);
            if (choice == 1)
            {
                var total = (from T in Employee.GetAllEmployees()
                             where T.Dept == "IT"
                             select T).Sum(T => T.Salary);
                System.Console.WriteLine("-------------------------------------");
                System.Console.WriteLine("Sum of all salary for IT : {0}", total);
                var large = (from L in Employee.GetAllEmployees()
                             where L.Dept == "IT"
                             select (L.Name, L.Salary)).Max(L => (L.Salary, L.Name));
                System.Console.WriteLine("Largest Salary: {0}", large);
                var minimum = (from M in Employee.GetAllEmployees()
                             where M.Dept == "IT"
                             select (M.Name, M.Salary)).Min(M => (M.Salary, M.Name));
                System.Console.WriteLine("Minimum Salary: {0}", minimum);
                var average = (from A in Employee.GetAllEmployees()
                             where A.Dept == "IT"
                             select (A.Name, A.Salary)).Average(A => A.Salary);
                System.Console.WriteLine("Average Salary: {0}", average);
                var number = (from N in Employee.GetAllEmployees()
                             where N.Dept == "IT"
                             select (N.Name, N.Salary)).Count();
                System.Console.WriteLine("No.of.Employees: {0}", number);
                var consist = (from C in Employee.GetAllEmployees()
                               where C.Dept == "IT"
                              select C.ID).Contains(105);
                System.Console.WriteLine("Contains ID-105: {0}",consist);
                System.Console.WriteLine("Using GroupBy, OrderBy & Key: ");
                var groupByGenderQuery = from  G in Employee.GetAllEmployees()
                                         group G by G.Gender into newGroup
                                         orderby newGroup.Key
                                         select newGroup;
                foreach (var Emp in groupByGenderQuery)
                {
                    System.Console.WriteLine($"Key: {Emp.Key}");
                    foreach (var Groups in Emp)
                    {
                        System.Console.WriteLine($"\t{Groups.Name},{Groups.Dept}");
                    }
                }
                System.Console.WriteLine("-------------------------------------");
            }
            else
            {
                var total = (from T in Employee.GetAllEmployees()
                             where T.Dept == "Sales"
                             select T).Sum(T => T.Salary);
                System.Console.WriteLine("-------------------------------------");
                System.Console.WriteLine("Sum of all salary for Sales : {0}", total);
                var large = (from L in Employee.GetAllEmployees()
                             where L.Dept == "Sales"
                             select (L.Name, L.Salary)).Max(L => (L.Salary, L.Name));
                System.Console.WriteLine("Largest Salary: {0}", large);
                                var minimum = (from M in Employee.GetAllEmployees()
                             where M.Dept == "Sales"
                             select (M.Name, M.Salary)).Min(M => (M.Salary, M.Name));
                System.Console.WriteLine("Minimum Salary: {0}", minimum);
                var average = (from A in Employee.GetAllEmployees()
                             where A.Dept == "Sales"
                             select (A.Name, A.Salary)).Average(A => A.Salary);
                System.Console.WriteLine("Average Salary: {0}", average);
                var number = (from N in Employee.GetAllEmployees()
                             where N.Dept == "Sales"
                             select (N.Name, N.Salary)).Count();
                System.Console.WriteLine("No.of.Employees: {0}", number);
                var consist = (from C in Employee.GetAllEmployees()
                              where C.Dept == "Sales"
                              select C.ID).Contains(105);
                System.Console.WriteLine("Contains ID-105: {0}",consist);
                                System.Console.WriteLine("Using GroupBy, OrderBy & Key: ");
                var groupByGenderQuery = from  G in Employee.GetAllEmployees()
                                         group G by G.Gender into newGroup
                                         orderby newGroup.Key
                                         select newGroup;
                foreach (var Emp in groupByGenderQuery)
                {
                    System.Console.WriteLine($"Key: {Emp.Key}");
                    foreach (var Groups in Emp)
                    {
                        System.Console.WriteLine($"\t{Groups.Name},{Groups.Dept}");
                    }
                }
                System.Console.WriteLine("-------------------------------------");
            }

        }
    }
}
