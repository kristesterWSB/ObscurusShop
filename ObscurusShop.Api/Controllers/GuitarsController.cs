using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObscurusShop.Api.Data;
using ObscurusShop.Api.Models;
namespace ObscurusShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuitarsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GuitarsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guitar>>> GetAll()
        {
            return await _context.Guitars.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Guitar>> GetById(int id)
        {
            var guitar = await _context.Guitars.FindAsync(id);
            if (guitar == null) return NotFound();
            
            return Ok(guitar);
        }

        [HttpPost]
        public async Task<ActionResult<Guitar>> Create(Guitar guitar)
        {
            _context.Guitars.Add(guitar);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = guitar.Id }, guitar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Guitar updatedGuitar)
        {
            var guitar = await _context.Guitars.FindAsync(id);
            if (guitar == null)
                return NotFound();
            
            guitar.Brand = updatedGuitar.Brand;
            guitar.Model = updatedGuitar.Model;
            guitar.Price = updatedGuitar.Price;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var guitar = await _context.Guitars.FindAsync(id);
            if (guitar == null)
                return NotFound();

            _context.Guitars.Remove(guitar);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
