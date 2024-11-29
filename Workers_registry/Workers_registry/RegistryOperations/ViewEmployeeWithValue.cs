using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry
{
    internal class ViewEmployeeWithValue
    {
        public Dictionary<EmployeeInterface, double> View()
        {
            List<EmployeeInterface> employees = Registry.Instance.Employees;
            var employeeWithValue = new Dictionary<EmployeeInterface, double>();

            if (employees == null)
            {
                Console.WriteLine("Lista jest pusta");
            }
            else 
            {
                foreach (EmployeeInterface employee in employees)
                {
                    employeeWithValue.Add(employee, employee.EmployeeValue());
                }
            }

            return employeeWithValue;
        }
    }
}
