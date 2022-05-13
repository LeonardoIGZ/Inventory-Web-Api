using Inventory_Web_Api.Models;
using Inventory_Web_Api.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;


namespace Inventory_Web_Api.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class MovementDetailsController : ControllerBase
{

    InventoryServices service;

    public MovementDetailsController(InventoryServices service)
    {
        this.service = service;
    }

    

}