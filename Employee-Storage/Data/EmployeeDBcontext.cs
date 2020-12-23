using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Employee_Storage.Models;

namespace Employee_Storage.Repository
{
    public class EmployeeDBcontext:DbContext

    {
        public EmployeeDBcontext(DbContextOptions<EmployeeDBcontext> options):base(options)
        {
           
        }

        public EmployeeDBcontext()
        {
           
        }
        
        public DbSet<Employee> employees { get; set; }

        public DbSet<Department> departments { get; set; }
    }
}
