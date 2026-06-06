using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenFinalProgramacionIII;

[ApiController]
[Route("api/[controller]")]
public class ClientSyncController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientSyncController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Client>> GetClient()
    {
        return _context.Clients.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Client> GetClient(int id)
    {
        var client = _context.Clients.Find(id);

        if (client == null)
            return NotFound();

        return client;
    }

    [HttpPost]
    public ActionResult<Client> CreateClient(Client client)
    {
        client.Id = 0;

        _context.Clients.Add(client);

        _context.SaveChanges();

        return CreatedAtAction(
            nameof(GetClient),
            new { id = client.Id },
            client);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateClient(int id, Client client)
    {
        if (id != client.Id)
            return BadRequest();

        _context.Entry(client).State = EntityState.Modified;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteClient(int id)
    {
        var client = _context.Clients.Find(id);

        if (client == null)
            return NotFound();

        _context.Clients.Remove(client);

        _context.SaveChanges();

        return NoContent();
    }
}