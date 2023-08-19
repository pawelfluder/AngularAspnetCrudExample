using AspNetWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private FullStackDbContext _fullStackDbContext = null;

        public EmployeesController(FullStackDbContext fullStackDbContext)
        {
           _fullStackDbContext = fullStackDbContext;
        }
        //public EmployeesController()
        //{

        //}

        [HttpGet]
        public async Task<IActionResult> GetAllEployees()
        {
            var employees = await _fullStackDbContext.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(
            [FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();

            await _fullStackDbContext.Employees.AddAsync(employeeRequest);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(employeeRequest);
        }
    }
}
