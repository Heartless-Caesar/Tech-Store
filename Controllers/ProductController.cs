using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechDistributor.Data;
using TechDistributor.Models;

namespace TechDistributor.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public ProductController(AppDbContext context)
    {
        _context = context;
    }
    
    //GET Product List
    [HttpGet("/products/catalog")]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var productList = await _context.products.ToListAsync();

        return Ok(productList);
    }
    
    //GET Single Product
    [HttpGet("/product/{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var singleProduct = await _context.products.FindAsync(id);

        if (singleProduct == null)
        {
            return NotFound($"No item with Id for {id}");
        }

        return Ok(singleProduct);
    }

    [HttpPost("product/create")]
    public async Task<ActionResult<List<Product>>> PostProduct(Product obj)
    {
            _context.products.Add(obj);
            await _context.SaveChangesAsync();
            
            var updatedList = await _context.products.ToListAsync();
            
            return Ok(updatedList);
    }

    [HttpPut("product/edit")]
    public async Task<ActionResult<Product>> UpdateProduct(Product obj)
    {
        var checkProduct = await _context.products.FindAsync(obj.Id);
        
        if (checkProduct == null) return NotFound($"No element with id of {obj.Id}");

        checkProduct.Title = obj.Title;
        checkProduct.Description = obj.Description;
        checkProduct.Price = obj.Price;

        await _context.SaveChangesAsync();

        var updatedList = await _context.products.ToListAsync();
        
        return Ok(updatedList);
    }
}