using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureProductApi.DTO;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok("Secure product list");
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(ProductDto dto)
    {
        return Ok("Product created");
    }
}