using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagementBackend.Data;

[ApiController]
//[controller] gets replaced with the class, when this route is called
[Route("api/[controller]")]
public class ProductsController : ControllerBase{
    //unmodifiable member variable
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context){
        _context = context;
    }
    //task, and async route, allows freeing up of threads while awaiting .Include() and .ToListAsync() to finish
    //IActionResult to handle different response object types
    [HttpGet]
    public async Task<IActionResult> GetProducts(){
        //return products, and their associated categories in a list
        return Ok(await _context.Products.Include(p => p.Category).ToListAsync());
    }
}
