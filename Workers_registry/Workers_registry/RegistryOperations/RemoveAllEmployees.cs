using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry
{
    internal class RemoveAllEmployees
    {
        public void RemoveAll()
        {
            List<EmployeeInterface> employees = Registry.Instance.Employees;

            employees.Clear();
        }
    }
}
