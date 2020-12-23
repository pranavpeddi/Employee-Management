using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Storage.Models
{
    public class Department
    {

        public Department()
        {
            this.employees = new HashSet<Employee>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dept_id { get; set; }

        

        public string department_name { get; set; }

        public ICollection<Employee> employees;

        
    }
}
