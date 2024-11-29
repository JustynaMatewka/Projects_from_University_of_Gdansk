using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry
{
    public class OfficeWorker : EmployeeBase
    {
        public int iq;
        public string officeEmployeeId = "";


        public string OfficeEmployeeId { get { return officeEmployeeId; } set { officeEmployeeId = value; } }
        public int IQ 
        { 
            get { return iq; }

            set
            {
                if (value >= 70 && value <= 150)
                {
                    iq = value;
                }
                else
                {
                    Console.WriteLine("IQ poza zakresem 70 - 150.");
                    iq = 70;
                }
            }
        }


        public OfficeWorker (string employeeId, string firstName, string lastName, int age, int experience, string street, string building, string place, string city, int iq, string officeEmployeeId)
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
            IQ = iq;
            OfficeEmployeeId = officeEmployeeId;
        }

        public double EmployeeValue()
        {
            return Experience * IQ;
        }
    }
}