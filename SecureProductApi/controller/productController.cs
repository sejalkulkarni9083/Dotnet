using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureProductApi.DTOs;
using Serilog;

namespace SecureProductApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            Log.Information("User {User} accessed products",
                User.Identity?.Name);

            return Ok("Secure product list");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateProductDto dto)
        {
            Log.Information("Admin {User} created product {Product}",
                User.Identity?.Name, dto.Name);

            return Ok("Product created");
        }
    }
}
