using Inventory_Web_Api.Models;
using Inventory_Web_Api.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;


namespace Inventory_Web_Api.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class SupplierController : ControllerBase
{

    InventoryServices service;

    public SupplierController(InventoryServices service)
    {
        this.service = service;
    }

    
     /// Supplier
    
    [HttpGet]
    public IEnumerable<Supplier> GetAllSupplier()
    {
        return service.GetAllSuppliers();
    }

    [HttpGet("{id}")]
    public ActionResult<Supplier> GetSupplierById(int id)
    {
        var supplier = service.GetSuppliersByID(id);

        if(supplier is not null)
        {
            return supplier;
        }
        else
        {
            return NotFound();
        }
    }

    //[Authorize]
    [HttpPost]
    public IActionResult CreateSupplier(Supplier newSupplier)
    {
        var supplier = service.CreateSupplier(newSupplier);
        return CreatedAtAction(nameof(GetSupplierById), new { id = supplier!.SupplierId }, supplier);
    }

    [HttpPut]
    public IActionResult UpdateSupplier(Supplier supplierUpdate){
        service.UpdateSuppliers(supplierUpdate);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSupplier(int id)
    {
        var supplier = service.GetSuppliersByID(id);

        if(supplier is not null)
        {
            service.DeleteSupplierById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

}