using APIProject.BLL;
using APIProject.Entities;
using APIProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]s/[action]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            _employeeService.Create(employee);
            return Ok();
        }

        [HttpPut("Id")]
        public IActionResult Update(int id, [FromBody] Employee employee)
        {
            var employeeUpdate=_employeeService.GetById(id);
            if (employeeUpdate is null)
            {
                return BadRequest();
            }
            else
            {
                //book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
                employeeUpdate.FirstName= employeeUpdate.FirstName != "string" ? employeeUpdate.FirstName:employee.FirstName;
                employeeUpdate.LastName = employeeUpdate.LastName != "string" ? employeeUpdate.LastName : employee.LastName;
                employeeUpdate.Departmant = employeeUpdate.Departmant != "string" ? employeeUpdate.Departmant : employee.Departmant;

                return Ok();
            }
        }

        [HttpDelete("id")]
        public void DeleteEmployee(int id)
        {
            var employee = _employeeService.GetById(id);
            _employeeService.Delete(employee);
        }

        [HttpGet]
        public IList<Employee> Employees()
        {
            return _employeeService.GetAll();
        }
    }
}
