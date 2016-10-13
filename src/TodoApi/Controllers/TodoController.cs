using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private ITodoRepository _todoItems;

        public TodoController(ITodoRepository todoItems)
        {
            _todoItems = todoItems;
        }

        // GET api/todo
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _todoItems.GetAll();
        }

        // GET api/todo/5
        [HttpGet("{id}", Name = "GetTodo")]
        public TodoItem Get(string id)
        {
            return _todoItems.Find(id);
        }

        // POST api/todo
        [HttpPost]
        public IActionResult Post([FromBody]TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _todoItems.Add(item);
            return CreatedAtRoute("GetTodo", new {id = item.Key}, item);
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = _todoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _todoItems.Update(item);
            return new NoContentResult();
        }

        // PUT api/todo/5
        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] TodoItem item, string id)
        {
            if (item == null)
            {
                return BadRequest();
            } 

            var todo = _todoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _todoItems.Update(item);
            return new NoContentResult();
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todo = _todoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _todoItems.Remove(id);
            return new NoContentResult();
        }
    }
}
