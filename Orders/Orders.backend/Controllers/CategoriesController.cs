using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.backend.Data;
using Orders.shared.Entities;

namespace Orders.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
       
            private readonly DataContext _context;

            public CategoriesController (DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> GetAsync()
            {
                return Ok(await _context.Categories.ToListAsync());
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetAsync(int id)
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }

            [HttpPost]
            public async Task<IActionResult> PostAsync(Category category)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAsync(int id)
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (category == null)
                {
                    return NotFound();
                }

                _context.Remove(category);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpPut]
            public async Task<IActionResult> PutAsync(Category category)
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
        }
    }

