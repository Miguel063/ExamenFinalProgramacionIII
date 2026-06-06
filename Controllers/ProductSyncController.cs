using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenFinalProgramacionIII;

[ApiController]
[Route("api/productssync")]
public class ProductsSyncController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsSyncController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return _context.Products.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = _context.Products.Find(id);

        if (product == null)
            return NotFound();

        return product;
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        _context.Products.Add(product);

        _context.SaveChanges();

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.Id },
            product);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        if (id != product.Id)
            return BadRequest();

        _context.Entry(product).State = EntityState.Modified;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _context.Products.Find(id);

        if (product == null)
            return NotFound();

        _context.Products.Remove(product);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpPost("process")]
    public IActionResult Process()
    {
        Thread.Sleep(3000);

        return Ok("Proceso síncrono completado");
    }
}