using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenFinalProgramacionIII;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly AppDbContext _context;

    public CartController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cart>> GetCart(int id)
    {
        var cart = await _context.Carts
            .Include(c => c.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cart == null)
            return NotFound();

        return cart;
    }

    [HttpPost]
    public async Task<ActionResult<Cart>> CreateCart()
    {
        var cart = new Cart
        {
            CreatedAt = DateTime.UtcNow
        };

        await _context.Carts.AddAsync(cart);
        await _context.SaveChangesAsync();

        return Ok(cart);
    }

    [HttpPost("{cartId}/add")]
    public async Task<IActionResult> AddProduct(
        int cartId,
        int productId,
        int quantity)
    {
        var cart = await _context.Carts.FindAsync(cartId);

        if (cart == null)
            return NotFound("Cart not found");

        var product = await _context.Products.FindAsync(productId);

        if (product == null)
            return NotFound("Product not found");

        if (product.Stock < quantity)
            return BadRequest("Insufficient stock");

        var item = new CartItem
        {
            CartId = cartId,
            ProductId = productId,
            Quantity = quantity
        };

        await _context.CartItems.AddAsync(item);

        await _context.SaveChangesAsync();

        return Ok(item);
    }

    [HttpDelete("item/{id}")]
    public async Task<IActionResult> RemoveItem(int id)
    {
        var item = await _context.CartItems.FindAsync(id);

        if (item == null)
            return NotFound();

        _context.CartItems.Remove(item);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("{id}/total")]
    public async Task<ActionResult<decimal>> GetTotal(int id)
    {
        var cart = await _context.Carts
            .Include(c => c.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cart == null)
            return NotFound();

        decimal total = cart.Items.Sum(i =>
            i.Product.Price * i.Quantity);

        return Ok(total);
    }
}