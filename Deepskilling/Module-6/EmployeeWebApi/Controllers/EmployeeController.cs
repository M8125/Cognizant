using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,POC")]
public class EmployeeController : ControllerBase
{
    private readonly List<Employee> _employees;

    public EmployeeController()
    {
        _employees = GetStandardEmployeeList();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Employee>> Get()
    {
        return GetStandardEmployeeList();
    }

    [HttpGet("throws")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Employee> GetThatThrows()
    {
        throw new InvalidOperationException("Simulated failure for exception filter testing.");
    }

    [HttpPost]
    public ActionResult<Employee> Post([FromBody] Employee employee)
    {
        return CreatedAtAction(nameof(Get), employee);
    }

    [HttpPut("{id}")]
    public ActionResult<Employee> Put(int id, [FromBody] Employee updated)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var employees = GetStandardEmployeeList();
        var existing = employees.FirstOrDefault(e => e.Id == id);
        if (existing is null)
        {
            return BadRequest("Invalid employee id");
        }

        existing.Name = updated.Name;
        existing.Salary = updated.Salary;
        existing.Permanent = updated.Permanent;
        existing.Department = updated.Department;
        existing.Skills = updated.Skills;
        existing.DateOfBirth = updated.DateOfBirth;

        return existing;
    }

    private static List<Employee> GetStandardEmployeeList()
    {
        var engineering = new Department { Id = 1, Name = "Engineering" };
        var sales = new Department { Id = 2, Name = "Sales" };

        return new List<Employee>
        {
            new()
            {
                Id = 1,
                Name = "Asha Rao",
                Salary = 85000,
                Permanent = true,
                Department = engineering,
                Skills = new List<Skill> { new() { Id = 1, Name = "C#" }, new() { Id = 2, Name = "EF Core" } },
                DateOfBirth = new DateTime(1992, 4, 12)
            },
            new()
            {
                Id = 2,
                Name = "Vikram Shah",
                Salary = 62000,
                Permanent = false,
                Department = sales,
                Skills = new List<Skill> { new() { Id = 3, Name = "Negotiation" } },
                DateOfBirth = new DateTime(1995, 9, 3)
            }
        };
    }
}
