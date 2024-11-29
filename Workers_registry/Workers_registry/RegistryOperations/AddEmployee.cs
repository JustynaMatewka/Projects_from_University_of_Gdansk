using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry
{
    public class AddEmployee
    {
        public void AddE(EmployeeInterface newEmployee)
        {
            int checkId = 0;

            List<EmployeeInterface> employees = Registry.Instance.Employees;
            
            foreach (EmployeeInterface employee in employees)
            {
                if (employee.EmployeeId == newEmployee.EmployeeId)
                {
                    checkId = 1;
                }
            }
            if (checkId == 0)
            {
                employees.Add(newEmployee);
            }
            else
            {
                Console.WriteLine("ID pracownika już istnieje w bazie!");
            }
        }
    }
}

