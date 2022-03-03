using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqJoins
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
            List<Employee> listEmployee = new List<Employee>()
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
            return listEmployee;
        }
    }

    public class People
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public static List<People> GetAllPeople()
        {
            List<People> listPeople = new List<People>()
            {
                new People { ID = 101, Name = "Preety", AddressId = 1 },
                new People { ID = 102, Name = "Priyanka", AddressId = 2 },
                new People { ID = 103, Name = "Anurag", AddressId = 3 },
                new People { ID = 104, Name = "Pranaya", AddressId = 4 },
                new People { ID = 105, Name = "Hina", AddressId = 5 },
                new People { ID = 106, Name = "Sambit", AddressId = 6 },
                new People { ID = 107, Name = "Happy", AddressId = 7},
                new People { ID = 108, Name = "Tarun", AddressId = 8 },
                new People { ID = 109, Name = "Santosh", AddressId = 9 },
                new People { ID = 110, Name = "Raja", AddressId = 10},
                new People { ID = 111, Name = "Sudhanshu", AddressId = 11}
            };
            return listPeople;
        }
    }
    public class Address
    {
        public int ID { get; set; }
        public string AddressLine { get; set; }
        public static List<Address> GetAllAddresses()
        {
            List<Address> listAddress = new List<Address>()
            {
                new Address { ID = 101, AddressLine = "AddressLine1"},
                new Address { ID = 102, AddressLine = "AddressLine2"},
                new Address { ID = 103, AddressLine = "AddressLine3"},
                new Address { ID = 104, AddressLine = "AddressLine4"},
                new Address { ID = 105, AddressLine = "AddressLine5"},
                new Address { ID = 109, AddressLine = "AddressLine9"},
                new Address { ID = 110, AddressLine = "AddressLine10"},
                new Address { ID = 111, AddressLine = "AddressLine11"},
            };
            return listAddress;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var firstTableData = from FTD in Employee.GetAllEmployees()
                                 select (FTD.ID, FTD.Name, FTD.Salary, FTD.Dept);
            System.Console.WriteLine("-------------");
            System.Console.WriteLine("First Table");
            System.Console.WriteLine("-------------");
            foreach (var ft in firstTableData)
            {
                System.Console.WriteLine(ft);
            }
            var secondTableData = from STD in People.GetAllPeople()
                                  select (STD.ID, STD.Name);
            System.Console.WriteLine("-------------");
            System.Console.WriteLine("Second Table");
            System.Console.WriteLine("-------------");
            foreach (var st in secondTableData)
            {
                System.Console.WriteLine(st);
            }
            var thirdTableData = from TTD in Address.GetAllAddresses()
                                 select (TTD.ID, TTD.AddressLine);
            System.Console.WriteLine("-------------");
            System.Console.WriteLine("Third Table");
            System.Console.WriteLine("-------------");
            foreach (var tt in thirdTableData)
            {
                System.Console.WriteLine(tt);
            }

            System.Console.WriteLine("------------------------------------------------");
            System.Console.WriteLine(" ============ SIMPLE JOIN IN LINQ ============= ");
            System.Console.WriteLine("------------------------------------------------");
            System.Console.WriteLine($"Table-1(Name) |  Table-1(ID) |  Table-2(People)| Table-3(ID) |  Table-3(Line)");

            var SimpleJoin = from E in Employee.GetAllEmployees()
                             join P in People.GetAllPeople()
                             on E.ID equals P.ID
                             join A in Address.GetAllAddresses()
                             on E.ID equals A.ID
                             select new
                             {
                                 EmployeeName = E.Name,
                                 EmployeeID = E.ID,
                                 PeopleName = P.Name,
                                 AddressID = A.ID,
                                 addressline = A.AddressLine
                             };
            foreach (var simple in SimpleJoin)
            {
                System.Console.WriteLine("---------------------------------------------------------------------");
                System.Console.WriteLine($"Name: {simple.EmployeeName} | ID: {simple.EmployeeID} | People: {simple.PeopleName} | ID: {simple.AddressID} | Line: {simple.addressline}");
            }
        }
    }
}
