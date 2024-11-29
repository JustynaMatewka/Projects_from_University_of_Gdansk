using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry
{
    public interface EmployeeInterface 
    {
        string EmployeeId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        int Experience { get; set; }
        string Street { get; set; }
        string Building { get; set; }
        string Place { get; set; }
        string City { get; set; }

        public double EmployeeValue() { return 0.0;  }
    }
}
