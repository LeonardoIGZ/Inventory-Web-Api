using Inventory_Web_Api.Models;
using Inventory_Web_Api.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;


namespace Inventory_Web_Api.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class WarehouseController : ControllerBase
{

    InventoryServices service;

    public WarehouseController(InventoryServices service)
    {
        this.service = service;
    }

    
/// WareHouse
    
    [HttpGet]
    public IEnumerable<Warehouse> GetAllWarehouse()
    {
        return service.GetAllWarehouse();
    }

    [HttpGet("{id}")]
    public ActionResult<Warehouse> GetWarehouseById(int id)
    {
        var wh = service.GetWarehouseByID(id);

        if(wh is not null)
        {
            return wh;
        }
        else
        {
            return NotFound();
        }
    }

    //[Authorize]
    [HttpPost]
    public IActionResult CreateWarehouse(Warehouse newWarehouse)
    {
        var wh = service.CreateWarehouse(newWarehouse);
        return CreatedAtAction(nameof(GetWarehouseById), new { id = wh!.WarehouseId }, wh);
    }

    [HttpPut]
    public IActionResult UpdateWarehouse(Warehouse whUpdate){
        service.UpdateWareHaouses(whUpdate);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteWarehouse(int id)
    {
        var wh = service.GetWarehouseByID(id);

        if(wh is not null)
        {
            service.DeleteWarehouseById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }


}