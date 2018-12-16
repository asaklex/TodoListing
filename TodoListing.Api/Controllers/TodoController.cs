using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListing.DAL;
using TodoListing.DAL.Models;
using TodoListing.Services.DataServices;

namespace TodoListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private TodoListingDbContext _todoListingDbContext;
        private ITodoDataServices _todoDataServices;
        public TodoController(TodoListingDbContext todoListingDbContext, ITodoDataServices todoDataServices)
        {
            _todoListingDbContext = todoListingDbContext;
            _todoDataServices = todoDataServices;
        }

        // GET: api/Todo
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _todoListingDbContext.Todos;
        }

        // GET: api/Todo/5
        [HttpGet("{id}", Name = "Get")]
        public Todo Get(int id)
        {
            return _todoListingDbContext.Todos.Find(id);
        }

        // POST: api/Todo
        [HttpPost]
        public void Post([FromBody] Todo _todo)
        {
            _todoDataServices.AddTodo(_todo);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Todo todo)
        {
            _todoDataServices.UpdateTodo(id, todo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _todoDataServices.RemoveTodo(id);
        }
    }
}
