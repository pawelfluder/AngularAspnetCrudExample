using AspNetWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private FullStackDbContext _fullStackDbContext;

        public EmployeesController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

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
