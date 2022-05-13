using Inventory_Web_Api.Models;
using Inventory_Web_Api.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;


namespace Inventory_Web_Api.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    InventoryServices service;

    public ProductController(InventoryServices service)
    {
        this.service = service;
    }

    
    [HttpGet]
    public IEnumerable<Product> GetAllProduct()
    {
        return service.GetAllProducts();
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = service.GetProductsByID(id);

        if(product is not null)
        {
            return product;
        }
        else
        {
            return NotFound();
        }
    }

    //[Authorize]
    [HttpPost]
    public IActionResult CreateProduct(Product newProduct)
    {
        var product = service.CreateProduct(newProduct);
        return CreatedAtAction(nameof(GetProductById), new { id = product!.ProductId }, product);
    }

    [HttpPut]
    public IActionResult UpdateProduct(Product productUpdate){
        service.UpdateProducts(productUpdate);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = service.GetProductsByID(id);

        if(product is not null)
        {
            service.DeleteProductById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }


}