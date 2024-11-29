using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry
{
    internal class ViewEmployeeByCity
    {
        public List<EmployeeInterface> FindEmployeeByCity(string findCity)
        {
            int check = 0;

            List<EmployeeInterface> employees = Registry.Instance.Employees;
            List<EmployeeInterface> foundCities = new List<EmployeeInterface>();


            if (employees == null)
            {
                Console.WriteLine("Lista jest pusta");
            }
            else
            {
                foreach (EmployeeInterface employee in employees)
                {
                    if (employee.City == findCity)
                    {
                        foundCities.Add(employee);
                        check = 1;
                    }
                }
                if (check == 0)
                {
                    Console.WriteLine("Nie ma podanego miasta w bazie");
                }
            }
            

            return foundCities;

        }
    }
}
