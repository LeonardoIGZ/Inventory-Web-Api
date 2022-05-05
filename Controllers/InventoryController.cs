using Inventory_Web_Api.Models;
using Inventory_Web_Api.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;


namespace Inventory_Web_Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase{
    
    InventoryServices service;
    
    public InventoryController(InventoryServices service)
    {
        this.service = service;
    }


    /// Categories

    [HttpGet]
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

    [Authorize]
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

    [Authorize]
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

    [Authorize]
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


    /// Product
    
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

    [Authorize]
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

    [Authorize]
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

    [Authorize]
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
    [Authorize]
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