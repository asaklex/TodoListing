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
using TodoListing.Api.Filters;
using TodoListing.DAL.DTO;

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
        [HttpGet("{todoId}", Name = "Get")]
        public Todo Get(int todoId)
        {
            return _todoListingDbContext.Todos.Find(todoId);
        }

        // POST: api/Todo
        [HttpPost]
        [ValidatorActionFilter]
        public void Post([FromBody] TodoDTO todo)
        {
            _todoDataServices.AddTodo(todo);
        }

        // PUT: api/Todo/5
        [HttpPut("{todoId}")]
        public void Put(int todoId, [FromBody] TodoDTO todo)
        {
            _todoDataServices.UpdateTodo(todoId, todo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{todoId}")]
        public void Delete(int todoId)
        {
            _todoDataServices.RemoveTodo(todoId);
        }
    }
}
