using Inventory_Web_Api.Models;
using Inventory_Web_Api.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;


namespace Inventory_Web_Api.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase{
    
    InventoryServices service;
    
    public InventoryController(InventoryServices service)
    {
        this.service = service;
    }


    /// Categories

    [HttpGet("category")]
    
    public IEnumerable<Category> GetAllCategories()
    {
        return service.GetAllCategories();
    }

    [HttpGet("{id}")]
    public ActionResult<Category> GetCategoryById(int id)
    {
        var category = service.GetCategoriesByID(id);

        if(category is not null)
        {
            return category;
        }
        else
        {
            return NotFound();
        }
    }

    //[Authorize]
    [HttpPost]
    public IActionResult CreateCategory(Category newCategory)
    {
        var category = service.CreateCategory(newCategory);
        return CreatedAtAction(nameof(GetCategoryById), new { id = category!.CategoryId }, category);
    }

    [HttpPut]
    public IActionResult UpdateCategory(Category categoryUpdate){
        service.UpdateCategory(categoryUpdate);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var pizza = service.GetCategoriesByID(id);

        if(pizza is not null)
        {
            service.DeleteCategoryById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

    

    


    /// Product
    

    /// Supplier
    
    

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

    /// WareHouse
    
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