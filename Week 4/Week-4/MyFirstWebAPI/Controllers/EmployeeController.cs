using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Models;
using MyFirstWebAPI.Filters;

namespace MyFirstWebAPI.Controllers
{
    [Authorize] // Secures the controller
    [ApiController]
    [Route("api/emp")]
    //[ServiceFilter(typeof(CustomAuthFilter))]
    //[AllowAnonymous] // Allow public access without auth for now
    public class EmployeeController : ControllerBase
    {
        private List<Employee> _employees;

        public EmployeeController()
        {
            try
            {
                _employees = GetStandardEmployeeList();
            }
            catch (Exception ex)
            {
                _employees = new List<Employee>(); // fallback
                Console.WriteLine($"Error in constructor: {ex.Message}");
            }
        }


        // GET: api/emp
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> Get()
        {
            //throw new Exception("Simulated unhandled exception for testing");

            return Ok(_employees);
        }

        // POST: api/emp
        [HttpPost]
        public ActionResult Post([FromBody] Employee emp)
        {
            _employees.Add(emp);
            return Ok(emp);
        }

        // PUT: api/emp/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existingEmp = _employees.FirstOrDefault(e => e.Id == id);

            if (existingEmp == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Update the existing employee with the new data
            existingEmp.Name = updatedEmp.Name;
            existingEmp.Salary = updatedEmp.Salary;
            existingEmp.Permanent = updatedEmp.Permanent;
            existingEmp.Department = updatedEmp.Department;
            existingEmp.Skills = updatedEmp.Skills;
            existingEmp.DateOfBirth = updatedEmp.DateOfBirth;

            return Ok(existingEmp);
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Alice",
                    Salary = 60000,
                    Permanent = true,
                    Department = new Department { DeptId = 101, DeptName = "HR" },
                    Skills = new List<Skill> {
                        new Skill { SkillId = 1, SkillName = "Communication" },
                        new Skill { SkillId = 2, SkillName = "Recruitment" }
                    },
                    DateOfBirth = new DateTime(1995, 5, 1)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Bob",
                    Salary = 75000,
                    Permanent = false,
                    Department = new Department { DeptId = 102, DeptName = "IT" },
                    Skills = new List<Skill> {
                        new Skill { SkillId = 3, SkillName = "C#" },
                        new Skill { SkillId = 4, SkillName = "Azure" }
                    },
                    DateOfBirth = new DateTime(1992, 10, 12)
                }
            };
        }
    }
}
