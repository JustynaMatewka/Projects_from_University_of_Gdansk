using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry
{
    public class ManualWorker : EmployeeBase
    {
        public int physicalStrength;


        public int PhysicalStrength 
        { 
            get { return physicalStrength; } 
            set 
            {
                if (value >= 1 && value <= 100)
                {
                    physicalStrength = value;
                }
                else
                {
                    Console.WriteLine("IQ poza zakresem 70 - 150.");
                    physicalStrength = 1;
                }
                 
            } 
        }

        public ManualWorker(string employeeId, string firstName, string lastName, int age, int experience, string street, string building, string place, string city, int physicalStrength)
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
            PhysicalStrength = physicalStrength;
        }

        public double EmployeeValue() 
        { 
            return Experience * PhysicalStrength / Age; 
        }
    }
}