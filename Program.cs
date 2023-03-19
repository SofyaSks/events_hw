
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace events_hw
{
    public delegate void workAccessDelegate(string str);
    class Employee
    {      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int salary { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {salary} {BirthDate.ToShortDateString()}";
        }

        public void workAccess(string str)
        {
            WriteLine($"{FirstName} {LastName}  {str} ");
        }
    }

    class Director
    {
        public event workAccessDelegate workAccessEvent;

        public void workAccess(string str)
        {
            if (workAccessEvent!= null)
            {
               workAccessEvent(str);
            }
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee {
                    FirstName = "John",
                    LastName = "Black",
                    BirthDate = new DateTime(1998, 03, 22),
                    salary = 200000 },
                new Employee
                {
                    FirstName = "Amanda",
                    LastName = "Grey",
                    BirthDate = new DateTime(2002, 11, 13),
                    salary = 300500
                },
                 new Employee
                {
                    FirstName = "Kith",
                    LastName = "White",
                    BirthDate = new DateTime(2008, 07, 07),
                    salary = 100345
                },
                  new Employee
                {
                    FirstName = "Marline",
                    LastName = "Blue",
                    BirthDate = new DateTime(2006, 10, 26),
                    salary = 50000
                },
                   new Employee
                {
                    FirstName = "Cassy",
                    LastName = "Red",
                    BirthDate = new DateTime(1999, 09, 12),
                    salary = 90500
                }
            };


            Director d = new Director();

            foreach (Employee item in employees)
            {
                if (DateTime.Now.Year - item.BirthDate.Year >= 18)
                {
                    d.workAccessEvent += item.workAccess;
                }
            }
            d.workAccess("has appropriate age");
        }
    }
}
