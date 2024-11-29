using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry
{
    public class Salesman : EmployeeBase
    {

        public string effectiveness = "";
        public double commission;
        
        public string Effectiveness 
        { 
            get { return effectiveness; } 
            set 
            {
                if (value == "NISKA" || value == "ŒREDNIA" || value == "WYSOKA")
                {
                    effectiveness = value;
                }
                else
                {
                    Console.WriteLine("Skutecznoœæ inna ni¿ oczekiwana");
                    effectiveness = null;
                }
            } 
        }
        public double Commission 
        { 
            get { return commission; } 
            set 
            { 
                if ( value >= 1.0 && value <= 100.0)
                {
                    commission = value;
                }
                else
                {
                    Console.WriteLine("Wysokoœæ prowizji poza zakresem procentowym");
                    commission = 0.0;
                }
            } 
        }


        public Salesman(string employeeId, string firstName, string lastName, int age, int experience, string street, string building, string place, string city, double commission, string effectiveness)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Experience = experience;
            Street = street;
            Building = building;
            Place = place;
            City = city;
            Effectiveness = effectiveness;
            Commission = commission;
        }

        public double EmployeeValue()
        {
            int e = 1;

            if (Effectiveness == "NISKA")
            {
                e = 60;
            }
            else if (Effectiveness == "ŒREDNIA")
            {
                e = 90;
            }
            else if (Effectiveness == "WYSOKA")
            {
                e = 120;
            }
            return Experience * e;
        }
    }
}
