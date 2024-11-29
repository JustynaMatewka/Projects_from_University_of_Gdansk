using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry
{
    internal class RemoveEmployee
    {
        public void RemoveE(string employeeToDelete)
        {
            int check = 0;

            List<EmployeeInterface> employees = Registry.Instance.Employees;

            foreach (EmployeeInterface employee in employees)
            {
                if (employee.EmployeeId == employeeToDelete)
                {
                    employees.Remove(employee);
                    check = 1;
                    break;
                }
            }
            if (check == 0)
            {
                Console.WriteLine("W bazie nie ma pracownika o podanym ID");
            }
        }
    }
}
