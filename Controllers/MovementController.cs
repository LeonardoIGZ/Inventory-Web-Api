using Inventory_Web_Api.Models;
using Inventory_Web_Api.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;


namespace Inventory_Web_Api.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class MovementController : ControllerBase
{

    InventoryServices service;

    public MovementController(InventoryServices service)
    {
        this.service = service;
    }

    [HttpGet]
    public IEnumerable<Movement> GetAllMovements()
    {
        return service.GetAllMovements();
    }

    [HttpGet("{id}")]
    public ActionResult<Movement> GetMovementById(int id)
    {
        var movement = service.GetMovementsByID(id);

        if(movement is not null)
        {
            return movement;
        }
        else
        {
            return NotFound();
        }
    }

    //[Authorize]
    [HttpPost]
    public IActionResult CreateMovement(Movement newMovement)
    {
        var movement = service.CreateMovements(newMovement);
        return CreatedAtAction(nameof(GetMovementById), new { id = movement!.MovementId }, movement);
    }

    [HttpPut]
    public IActionResult UpdateMovement(Movement movementUpdate){
        service.UpdateMovements(movementUpdate);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovement(int id)
    {
        var movement = service.GetMovementsByID(id);

        if(movement is not null)
        {
            service.DeleteMovementById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

}