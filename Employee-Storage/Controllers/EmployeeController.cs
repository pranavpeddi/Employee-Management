using Employee_Storage.Models;
using Employee_Storage.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Storage.Controllers
{

    
    [ApiController]
    [Route("main")]
    public class EmployeeController : ControllerBase
    {
        public readonly EmployeeDBcontext _context;

        public EmployeeController(EmployeeDBcontext employeeDBcontext)
        {
            _context = employeeDBcontext;
        }

        //api/
        [HttpGet]
        [Route("/getEmp/{id}")]

        public async Task<ActionResult<Employee>> getEmployee(int id)
        {
            var employee = await _context.employees.FindAsync(id);
            if(employee==null)
            {
                return NotFound();
            }

            List<Employee> req_departments = _context.employees.Include();
            var my_req = _context.employees.Include(e => e.department);
            Console.WriteLine(req_departments);
            EmployeeResponse employeeResponse = new EmployeeResponse();
            return my_req;
          
        }

        [HttpGet]
        [Route("/dept/{id}")]
        public async Task<ActionResult<Department>> getDepartment(int id)
        {
            var department = await _context.departments.FindAsync(id);
            if(department==null)
            {
                return NotFound();
            }
            return department;
               
           
        }


        [HttpPost]
        [Route("/saveDept")]

        public async Task<ActionResult<Department>> saveDepartment(Department department)
        {
            _context.departments.Add(department);
            await _context.SaveChangesAsync();
            return CreatedAtAction("getDepartment", new { id = department.dept_id }, department);
        }


        [HttpPost]
        [Route("/saveEmployee/{dept_id}")]
        public async Task<ActionResult<Employee>> saveEmployee(Employee employee,int dept_id)
        {
            Department dept = _context.departments.Find(dept_id);
            if (dept == null)
            {
                return NotFound();
            }
            employee.department = dept;
          _context.employees.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction("getEmployee",new {id=employee.id },employee);


        }


        [HttpDelete]
        [Route("/deleteemployee/{id}")]
        public async Task<ActionResult<Employee>> deleteEmployee(int id)
        {
            var employee =await _context.employees.FindAsync(id);
            if(employee==null)
            {
                return NotFound();
            }
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        [HttpPut]
        [Route("/updateEmployee/{id}")]
        public async Task<IActionResult> changeEmpDetails(int id, Employee employee)
        {
        
        if(id!=employee.id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!employeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                
            }
            return NoContent();
        }






        public bool employeeExists(int id)
        {
            return _context.employees.Any(emp => emp.id == id);
        }

    }
}
