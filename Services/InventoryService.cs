using Microsoft.EntityFrameworkCore;
using Inventory_Web_Api.Data;
using Inventory_Web_Api.Models;

namespace Inventory_Web_Api.Services;

public class InventoryServices
{
    private readonly mynwindContext context;

    public InventoryServices(mynwindContext context)
    {
        this.context = context;
    }

    /// --- Categories
    public IEnumerable<Category> GetAllCategories()
    {
        return context.Categories
         .AsNoTracking()
         .ToList();
    }

    public Category? GetCategoriesByID(int id)
    {
        return context.Categories
         .AsNoTracking()
         .SingleOrDefault(c => c.CategoryId == id);
    }

    public void DeleteCategoryById(int id)
    {
        var categoryDelete = context.Categories.Find(id);
        if (categoryDelete is null)
        {
            throw new NullReferenceException("The categorie does not exist");
        }
        context.Categories.Remove(categoryDelete);
        context.SaveChanges();
    }

    public Category? CreateCategory(Category newCategory)
    {

        var category = new Category
        {
            CategoryId = newCategory.CategoryId,
            CategoryName = newCategory.CategoryName,
            Description = newCategory.Description,
            Picture = newCategory.Picture
        };

        context.Categories.Add(category);
        context.SaveChanges();

        return newCategory;
    }

    public void UpdateCategory(Category categoryUpdate)
    {

        var category = context.Categories
                        .SingleOrDefault(c => c.CategoryId == categoryUpdate.CategoryId);

        if (category != null)
        {

            if (category.CategoryId != categoryUpdate.CategoryId)
                categoryUpdate.CategoryId = category.CategoryId;

            if (category.CategoryName != categoryUpdate.CategoryName)
                categoryUpdate.CategoryName = category.CategoryName;

            if (category.Description != categoryUpdate.Description)
                categoryUpdate.Description = category.Description;

            if (category.Picture != categoryUpdate.Picture)
                categoryUpdate.Picture = category.Picture;

            if (category.CompanyId != categoryUpdate.CompanyId)
                categoryUpdate.CompanyId = category.CompanyId;

            context.Categories.Update(category);
            context.SaveChanges();
        }
    }

    /// --- Company
    public IEnumerable<Company> GetAllCompanies()
    {
        return context.Companies
         .AsNoTracking()
         .ToList();
    }

    public Company? GetCompanyByID(int id)
    {
        return context.Companies
         .AsNoTracking()
         .SingleOrDefault(c => c.CompanyId == id);
    }

    public void DeleteCompanyById(int id)
    {
        var companyDelete = context.Companies.Find(id);
        if (companyDelete is null)
        {
            throw new NullReferenceException("The company does not exist");
        }
        context.Companies.Remove(companyDelete);
        context.SaveChanges();
    }

    public Company? CreateCompany(Company newCompany)
    {

        var company = new Company
        {
            CompanyId = newCompany.CompanyId,
            CompanyName = newCompany.CompanyName,
            AccountEmail = newCompany.AccountEmail,
            Password = newCompany.Password,
            BeginPlan = newCompany.BeginPlan,
            EndPlan = newCompany.EndPlan,
            Active = newCompany.Active
        };

        context.Companies.Add(company);
        context.SaveChanges();

        return newCompany;
    }

    public void UpdateCompany(Company companyUpdate)
    {

        var company = context.Companies
                        .SingleOrDefault(c => c.CompanyId == companyUpdate.CompanyId);

        if (company != null)
        {
            if (company.CompanyId != companyUpdate.CompanyId)
                companyUpdate.CompanyId = company.CompanyId;

            if (company.CompanyName != companyUpdate.CompanyName)
                companyUpdate.CompanyName = company.CompanyName;

            if (company.AccountEmail != companyUpdate.AccountEmail)
                companyUpdate.AccountEmail = company.AccountEmail;

            if (company.Password != companyUpdate.Password)
                companyUpdate.Password = company.Password;

            if (company.BeginPlan != companyUpdate.BeginPlan)
                companyUpdate.BeginPlan = company.BeginPlan;

            if (company.EndPlan != companyUpdate.EndPlan)
                companyUpdate.EndPlan = company.EndPlan;

            if (company.Active != companyUpdate.Active)
                companyUpdate.Active = company.Active;

            context.Companies.Update(company);
            context.SaveChanges();
        }
    }

    /// --- Employee
    public IEnumerable<Employee> GetAllEmployees()
    {
        return context.Employees
         .AsNoTracking()
         .ToList();
    }

    public Employee? GetEmployeeByID(int id)
    {
        return context.Employees
         .AsNoTracking()
         .SingleOrDefault(c => c.CompanyId == id);
    }

    public void DeleteEmployeeById(int id)
    {
        var employeeDelete = context.Employees.Find(id);
        if (employeeDelete is null)
        {
            throw new NullReferenceException("The employee does not exist");
        }
        context.Employees.Remove(employeeDelete);
        context.SaveChanges();
    }

    public Employee? CreateEmployee(Employee newEmployee)
    {

        var employee = new Employee
        {
            EmployeeId = newEmployee.CompanyId,
            LastName = newEmployee.LastName,
            FirstName = newEmployee.FirstName,
            HireDate = newEmployee.HireDate,
            Address = newEmployee.Address,
            HomePhone = newEmployee.HomePhone,
            ReportsTo = newEmployee.ReportsTo,
            Email = newEmployee.Email,
            Password = newEmployee.Password,
            CompanyId = newEmployee.CompanyId
        };

        context.Employees.Add(employee);
        context.SaveChanges();

        return newEmployee;
    }

    public void UpdateEmployee(Employee employeeUpdate)
    {

        var employee = context.Employees
                        .SingleOrDefault(e => e.EmployeeId == employeeUpdate.EmployeeId);

        if (employee != null)
        {

            if (employee.EmployeeId != employeeUpdate.EmployeeId)
                employeeUpdate.EmployeeId = employee.EmployeeId;

            if (employee.LastName != employeeUpdate.LastName)
                employeeUpdate.LastName = employee.LastName;

            if (employee.FirstName != employeeUpdate.FirstName)
                employeeUpdate.FirstName = employee.FirstName;

            if (employee.HireDate != employeeUpdate.HireDate)
                employeeUpdate.HireDate = employee.HireDate;

            if (employee.Address != employeeUpdate.Address)
                employeeUpdate.Address = employee.Address;

            if (employee.HomePhone != employeeUpdate.HomePhone)
                employeeUpdate.HomePhone = employee.HomePhone;

            if (employee.ReportsTo != employeeUpdate.ReportsTo)
                employeeUpdate.ReportsTo = employee.ReportsTo;

            if (employee.Email != employeeUpdate.Email)
                employeeUpdate.Email = employee.Email;

            if (employee.Password != employeeUpdate.Password)
                employeeUpdate.Password = employee.Password;

            if (employee.CompanyId != employeeUpdate.CompanyId)
                employeeUpdate.CompanyId = employee.CompanyId;

            context.Employees.Update(employee);
            context.SaveChanges();
        }
    }


    /// ---Movements
    public IEnumerable<Movement> GetAllMovements()
    {
        return context.Movements
         .AsNoTracking()
         .ToList();
    }

    public Movement? GetMovementsByID(int id)
    {
        return context.Movements
         .AsNoTracking()
         .SingleOrDefault(m => m.MovementId == id);
    }

    public void DeleteMovementById(int id)
    {
        var movementDelete = context.Movements.Find(id);
        if (movementDelete is null)
        {
            throw new NullReferenceException("The movement does not exist");
        }
        context.Movements.Remove(movementDelete);
        context.SaveChanges();
    }

    public Movement? CreateMovements(Movement newMovement)
    {

        var movement = new Movement
        {
            MovementId = newMovement.MovementId,
            Date = newMovement.Date,
            SupplierId = newMovement.SupplierId,
            SourceWarehouse = newMovement.SourceWarehouse,
            TargetWarehouse = newMovement.TargetWarehouse,
            Type = newMovement.Type,
            Notes = newMovement.Notes,
            CompanyId = newMovement.CompanyId,
            EmployeeId = newMovement.EmployeeId,
        };

        context.Movements.Add(movement);
        context.SaveChanges();

        return newMovement;
    }

    public void UpdateMovements(Movement movementUpdate)
    {

        var movement = context.Movements
                        .SingleOrDefault(m => m.MovementId == movementUpdate.MovementId);

        if (movement != null)
        {
            if (movement.MovementId != movementUpdate.MovementId)
                movementUpdate.MovementId = movement.MovementId;

            if (movement.Date != movementUpdate.Date)
                movementUpdate.Date = movement.Date;

            if (movement.SupplierId != movementUpdate.SupplierId)
                movementUpdate.SupplierId = movement.SupplierId;

            if (movement.TargetWarehouse != movementUpdate.TargetWarehouse)
                movementUpdate.TargetWarehouse = movement.TargetWarehouse;

            if (movement.SourceWarehouse != movementUpdate.SourceWarehouse)
                movementUpdate.SourceWarehouse = movement.SourceWarehouse;

            if (movement.Type != movementUpdate.Type)
                movementUpdate.Type = movement.Type;

            if (movement.Notes != movementUpdate.Notes)
                movementUpdate.Notes = movement.Notes;

            if (movement.CompanyId != movementUpdate.CompanyId)
                movementUpdate.CompanyId = movement.CompanyId;

            if (movement.EmployeeId != movementUpdate.EmployeeId)
                movementUpdate.EmployeeId = movement.EmployeeId;

            context.Movements.Update(movement);
            context.SaveChanges();
        }
    }

    // ---Products
    public IEnumerable<Product> GetAllProducts()
    {
        return context.Products
         .AsNoTracking()
         .ToList();
    }

    public Product? GetProductsByID(int id)
    {
        return context.Products
         .AsNoTracking()
         .SingleOrDefault(p => p.ProductId == id);
    }

    public void DeleteProductById(int id)
    {
        var productDelete = context.Products.Find(id);
        if (productDelete is null)
        {
            throw new NullReferenceException("The product does not exist");
        }
        context.Products.Remove(productDelete);
        context.SaveChanges();
    }

    public Product? CreateProduct(Product newProduct)
    {

        var product = new Product
        {
            ProductId = newProduct.ProductId,
            ProductName = newProduct.ProductName,
            SupplierId = newProduct.SupplierId,
            CategoryId = newProduct.CategoryId,
            QuantityPerUnit = newProduct.QuantityPerUnit,
            UnitPrice = newProduct.UnitPrice,
            PhotoPath = newProduct.PhotoPath,
            CompanyId = newProduct.CompanyId
        };

        context.Products.Add(product);
        context.SaveChanges();

        return newProduct;
    }

    public void UpdateProducts(Product productUpdate)
    {

        var product = context.Products
                        .SingleOrDefault(p => p.ProductId == productUpdate.ProductId);
        if (product != null)
        {
            if (product.ProductId != productUpdate.ProductId)
                productUpdate.ProductId = product.ProductId;

            if (product.ProductName != productUpdate.ProductName)
                productUpdate.ProductName = product.ProductName;

            if (product.SupplierId != productUpdate.SupplierId)
                productUpdate.SupplierId = product.SupplierId;

            if (product.CategoryId != productUpdate.CategoryId)
                productUpdate.CategoryId = product.CategoryId;

            if (product.QuantityPerUnit != productUpdate.QuantityPerUnit)
                productUpdate.QuantityPerUnit = product.QuantityPerUnit;

            if (product.UnitPrice != productUpdate.UnitPrice)
                productUpdate.UnitPrice = product.UnitPrice;

            if (product.PhotoPath != productUpdate.PhotoPath)
                productUpdate.PhotoPath = product.PhotoPath;


            if (product.CompanyId != productUpdate.CompanyId)
                productUpdate.CompanyId = product.CompanyId;

            context.Products.Update(product);
            context.SaveChanges();
        }
    }

    // ---Suppliers
    public IEnumerable<Supplier> GetAllSuppliers()
    {
        return context.Suppliers
         .AsNoTracking()
         .ToList();
    }

    public Supplier? GetSuppliersByID(int id)
    {
        return context.Suppliers
         .AsNoTracking()
         .SingleOrDefault(s => s.SupplierId == id);
    }

    public void DeleteSupplierById(int id)
    {
        var supplierDelete = context.Suppliers.Find(id);
        if (supplierDelete is null)
        {
            throw new NullReferenceException("The supplier does not exist");
        }
        context.Suppliers.Remove(supplierDelete);
        context.SaveChanges();
    }

    public Supplier? CreateSupplier(Supplier newSupplier)
    {
        var supplier = new Supplier
        {
            SupplierId = newSupplier.SupplierId,
            CompanyName = newSupplier.CompanyName,
            ContactName = newSupplier.ContactName,
            Address = newSupplier.Address,
            City = newSupplier.City,
            PostalCode = newSupplier.PostalCode,
            Country = newSupplier.Country,
            Phone = newSupplier.Phone,
            CompanyId = newSupplier.CompanyId
        };

        context.Suppliers.Add(supplier);
        context.SaveChanges();

        return newSupplier;
    }

    public void UpdateSuppliers(Supplier supplierUpdate)
    {

        var supplier = context.Suppliers
                        .SingleOrDefault(s => s.SupplierId == supplierUpdate.SupplierId);
        if (supplier != null)
        {
            if (supplier.SupplierId != supplierUpdate.SupplierId)
                supplierUpdate.SupplierId = supplier.SupplierId;

            if (supplier.CompanyName != supplierUpdate.CompanyName)
                supplierUpdate.CompanyName = supplier.CompanyName;

            if (supplier.ContactName != supplierUpdate.ContactName)
                supplierUpdate.ContactName = supplier.ContactName;

            if (supplier.Address != supplierUpdate.Address)
                supplierUpdate.Address = supplier.Address;

            if (supplier.City != supplierUpdate.City)
                supplierUpdate.City = supplier.City;

            if (supplier.PostalCode != supplierUpdate.PostalCode)
                supplierUpdate.PostalCode = supplier.PostalCode;

            if (supplier.Country != supplierUpdate.Country)
                supplierUpdate.Country = supplier.Country;

            if (supplier.Phone != supplierUpdate.Phone)
                supplierUpdate.Phone = supplier.Phone;

            if (supplier.CompanyId != supplierUpdate.CompanyId)
                supplierUpdate.CompanyId = supplier.CompanyId;

            context.Suppliers.Update(supplier);
            context.SaveChanges();
        }
    }

    /// ---WareHouses
    public IEnumerable<Warehouse> GetAllWarehouse()
    {
        return context.Warehouses
         .AsNoTracking()
         .ToList();
    }

    public Warehouse? GetWarehouseByID(int id)
    {
        return context.Warehouses
         .AsNoTracking()
         .SingleOrDefault(w => w.WarehouseId == id);
    }

    public void DeleteWarehouseById(int id)
    {
        var warehouseDelete = context.Warehouses.Find(id);
        if (warehouseDelete is null)
        {
            throw new NullReferenceException("The movement does not exist");
        }
        context.Warehouses.Remove(warehouseDelete);
        context.SaveChanges();
    }

    public Warehouse? CreateWarehouse(Warehouse newWH)
    {

        var wh = new Warehouse
        {
            WarehouseId = newWH.WarehouseId,
            Description = newWH.Description,
            Address = newWH.Address,
            CompanyId = newWH.CompanyId
        };

        context.Warehouses.Add(wh);
        context.SaveChanges();

        return newWH;
    }

    public void UpdateWareHaouses(Warehouse whUpdate)
    {

        var wh = context.Warehouses
                        .SingleOrDefault(w => w.WarehouseId == whUpdate.WarehouseId);

        if (wh != null)
        {
            if (wh.WarehouseId != whUpdate.WarehouseId)
                whUpdate.WarehouseId = wh.WarehouseId;

            if (wh.Description != whUpdate.Description)
                whUpdate.Description = wh.Description;

            if (wh.Address != whUpdate.Address)
                whUpdate.Address = wh.Address;

            if (wh.CompanyId != whUpdate.CompanyId)
                whUpdate.CompanyId = wh.CompanyId;

            context.Warehouses.Update(wh);
            context.SaveChanges();
        }
    }

    /// ---WareHousesproducts
    public IEnumerable<Warehouseproduct> GetAllWareHouseproducts()
    {
        return context.Warehouseproducts
         .AsNoTracking()
         .ToList();
    }

    /*

    public Warehouseproduct? GetWarehouseproductByID(int id)
    {
        return context.Warehouseproducts
         .AsNoTracking()
         .SingleOrDefault(w => w.WarehouseId == id);
    }

    public void DeleteWarehouseproductById(int id)
    {
        var warehousepDelete = context.Warehouseproducts.Find(id);
        if (warehousepDelete is null)
        {
            throw new NullReferenceException("The movement does not exist");
        }
        context.Warehouseproducts.Remove(warehousepDelete);
        context.SaveChanges();
    }

    */

    public Warehouseproduct? CreateWarehouseproduct(Warehouseproduct newWHP)
    {

        var whp = new Warehouseproduct
        {
            WarehouseId = newWHP.WarehouseId,
            ProductId = newWHP.ProductId,
            UnitsInStock = newWHP.UnitsInStock,
            UnitsOnOrder = newWHP.UnitsOnOrder,
            ReorderLevel = newWHP.ReorderLevel,
            Discontinued = newWHP.Discontinued
        };

        context.Warehouseproducts.Add(whp);
        context.SaveChanges();

        return newWHP;
    }

    public void UpdateWareHaousesP(Warehouseproduct whpUpdate)
    {

        var whp = context.Warehouseproducts
                        .SingleOrDefault(w => w.WarehouseId == whpUpdate.WarehouseId);
        if (whp != null)
        {
            if (whp.WarehouseId != whpUpdate.WarehouseId)
                whpUpdate.WarehouseId = whp.WarehouseId;

            if (whp.ProductId != whpUpdate.ProductId)
                whpUpdate.ProductId = whp.ProductId;

            if (whp.UnitsInStock != whpUpdate.UnitsInStock)
                whpUpdate.UnitsInStock = whp.UnitsInStock;

            if (whp.UnitsOnOrder != whpUpdate.UnitsOnOrder)
                whpUpdate.UnitsOnOrder = whp.UnitsOnOrder;

            if (whp.ReorderLevel != whpUpdate.ReorderLevel)
                whpUpdate.ReorderLevel = whp.ReorderLevel;

            if (whp.Discontinued != whpUpdate.Discontinued)
                whpUpdate.Discontinued = whp.Discontinued;

            context.Warehouseproducts.Update(whp);
            context.SaveChanges();
        }
    }

}