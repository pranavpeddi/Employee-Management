using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Storage.Models
{
    public class Employee
    {

        public int id { get; set; }

        public string name { get; set; }

        public string desgination { get; set; }

        public Department department { get; set; }
    }
}
