using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Name = "Default Item" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<TodoItem> GetById(long id)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet("name/{name}", Name = "GetTodoByName")]
        public ActionResult<TodoItem> GetByName(string name)
        {
            var item = _context.TodoItems.FirstOrDefault(a => a.Name == name );
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }


        [HttpPost]
        public IActionResult Create(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, TodoItem item)
        {
            var item2Chg = _context.TodoItems.Find(id);
            if (item2Chg == null)
            {
                return NotFound();
            }
            // Found it, update the other fields (Name & IsComplete)
            item2Chg.Name = item.Name;
            item2Chg.IsComplete = item.IsComplete;

            // Update Entity Framework
            _context.TodoItems.Update(item2Chg);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var item2Del = _context.TodoItems.Find(id);
            if (item2Del == null)
            {
                return NotFound();
            }

            // Update Entity Framework
            _context.TodoItems.Remove(item2Del);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
