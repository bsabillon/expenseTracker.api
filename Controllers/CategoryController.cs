using System.Threading.Tasks;
using expenseTracker.api.data;
using expenseTracker.api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;



namespace expenseTracker.api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

public class CategoryController : ControllerBase
{

    private readonly DataContext _context;
    public CategoryController(DataContext context)
    {
        _context = context;
    }


        [HttpGet]
            public async Task<IActionResult> GetAll(){
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);

            }
  
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(long id)
        {

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            return category;
        }


        [HttpPost]
        public async Task<ActionResult<Category>>PostCategory(Category item)
        {
            _context.Categories.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategory), new { Id = item.Id }, item);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Category item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category==null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();

        }
}
}