using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using toDoApi.Models;

namespace toDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class toDoItemsController : ControllerBase
    {
        private readonly toDoContext _context;

        public toDoItemsController(toDoContext context)
        {
            _context = context;
        }

        // GET: api/toDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<toDoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/toDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<toDoItem>> GettoDoItem(long id)
        {
            var toDoItem = await _context.TodoItems.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return toDoItem;
        }

        // PUT: api/toDoItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttoDoItem(long id, toDoItem toDoItem)
        {
            if (id != toDoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!toDoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/toDoItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<toDoItem>> PosttoDoItem(toDoItem toDoItem)
        {
            _context.TodoItems.Add(toDoItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GettoDoItem", new { id = toDoItem.Id }, toDoItem);
            return CreatedAtAction(nameof(GettoDoItem), new { id = toDoItem.Id }, toDoItem);
        }

        // DELETE: api/toDoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<toDoItem>> DeletetoDoItem(long id)
        {
            var toDoItem = await _context.TodoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return toDoItem;
        }

        private bool toDoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
