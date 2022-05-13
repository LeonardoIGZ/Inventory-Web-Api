using Inventory_Web_Api.Models;
using Inventory_Web_Api.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;


namespace Inventory_Web_Api.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{

    InventoryServices service;

    public CategoriesController(InventoryServices service)
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

    /// Company

    [HttpGet]
    public IEnumerable<Company> GetAllCompany()
    {
        return service.GetAllCompanies();
    }

    [HttpGet("{id}")]
    public ActionResult<Company> GetCompanyById(int id)
    {
        var company = service.GetCompanyByID(id);

        if(company is not null)
        {
            return company;
        }
        else
        {
            return NotFound();
        }
    }

    //[Authorize]
    [HttpPost]
    public IActionResult CreateCompany(Company newCompany)
    {
        var company = service.CreateCompany(newCompany);
        return CreatedAtAction(nameof(GetCompanyById), new { id = company!.CompanyId }, company);
    }

    [HttpPut]
    public IActionResult UpdateCompany(Company companyUpdate){
        service.UpdateCompany(companyUpdate);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCompany(int id)
    {
        var company = service.GetCompanyByID(id);

        if(company is not null)
        {
            service.DeleteCompanyById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

}