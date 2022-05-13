using Inventory_Web_Api.Models;
using Inventory_Web_Api.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;


namespace Inventory_Web_Api.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{

    InventoryServices service;

    public EmployeeController(InventoryServices service)
    {
        this.service = service;
    }

/// Company
    
    [HttpGet]
    public IEnumerable<Employee> GetAllEmployees()
    {
        return service.GetAllEmployees();
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> GetEmployeeById(int id)
    {
        var employee = service.GetEmployeeByID(id);

        if(employee is not null)
        {
            return employee;
        }
        else
        {
            return NotFound();
        }
    }

    //[Authorize]
    [HttpPost]
    public IActionResult CreateEmployee(Employee newEmployee)
    {
        var employee = service.CreateEmployee(newEmployee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee!.EmployeeId }, employee);
    }

    [HttpPut]
    public IActionResult UpdateEmployee(Employee employeeUpdate){
        service.UpdateEmployee(employeeUpdate);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        var employee = service.GetEmployeeByID(id);

        if(employee is not null)
        {
            service.DeleteEmployeeById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

}