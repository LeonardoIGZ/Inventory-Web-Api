using Inventory_Web_Api.Models;
using Inventory_Web_Api.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;


namespace Inventory_Web_Api.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class WarehouseproductController : ControllerBase
{

    InventoryServices service;

    public WarehouseproductController(InventoryServices service)
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

    [HttpGet]
    public IEnumerable<Warehouseproduct> GetAllWarehouseproducts()
    {
        return service.GetAllWareHouseproducts();
    }

    /*
    //[Authorize]
    [HttpPost]
    public IActionResult CreateWarehouseproduct(Warehouseproduct newWarehouseproduct)
    {
        var wh = service.CreateWarehouseproduct(newWarehouseproduct);
        return CreatedAtAction(nameof(GetWarehousepById), new { id = wh!.WarehouseId }, wh);
    }*/

    [HttpPut]
    public IActionResult UpdateWarehouseproduct(Warehouseproduct whpUpdate){
        service.UpdateWareHaousesP(whpUpdate);

        return NoContent();
    }
}