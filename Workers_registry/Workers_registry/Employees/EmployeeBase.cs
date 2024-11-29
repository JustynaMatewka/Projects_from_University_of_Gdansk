using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry
{
    public abstract class EmployeeBase : EmployeeInterface, EmployeeValueInterface
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Place { get; set; }
        public string City { get; set; }

        public virtual double EmployeeValue()
        {
            return 0.0;
        }
    }
}
