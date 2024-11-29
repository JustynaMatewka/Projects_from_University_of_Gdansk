using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry
{
    public class Registry
    {
        private static List<EmployeeInterface> employees = new List<EmployeeInterface>();

        private static readonly Registry instance = new Registry();

        private Registry() { }

        public static Registry Instance
        {
            get { return instance; }
        }

        public List<EmployeeInterface> Employees
        {
            get { return employees; }
        }
    }
}