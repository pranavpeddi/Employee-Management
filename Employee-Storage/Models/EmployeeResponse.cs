using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Storage.Models
{
    public class EmployeeResponse
    {
        public Employee employee { get; set; }

        public List<Department> departments { get; set; }


    }
}
