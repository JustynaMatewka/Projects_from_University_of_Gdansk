using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry
{
    internal class ViewEmployee
    {
        public List<EmployeeInterface> FindE()
        {
            List<EmployeeInterface> employees = Registry.Instance.Employees;

            if (employees == null)
            {
                Console.WriteLine("Lista jest pusta");
            }
            
            var sortedEmployees = employees.OrderByDescending(e => e.Experience).ThenBy(e => e.Age).ThenBy(e => e.LastName).ToList();


            return sortedEmployees;
        }
    }
}
