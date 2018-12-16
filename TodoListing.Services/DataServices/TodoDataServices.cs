using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoListing.DAL;
using TodoListing.DAL.Models;

namespace TodoListing.Services.DataServices
{
    public class TodoDataServices : ITodoDataServices
    {
        TodoListingDbContext _dbContext;

        public TodoDataServices(TodoListingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Todo AddTodo(Todo todo)
        {
            _dbContext.Todos.Add(todo);
            _dbContext.SaveChanges();
            return todo;
        }

        public Todo UpdateTodo(int id, Todo todo)
        {
            var existing = _dbContext.Todos.Find(id);
            if(existing != null)
            {
                existing.Description = todo.Description;
                existing.Title = todo.Title;
                _dbContext.Entry(existing).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }

            return existing;
        }

        public void RemoveTodo(int id)
        {
            var existing = _dbContext.Todos.Find(id);
            if (existing != null)
            {
                _dbContext.Todos.Remove(existing);
                _dbContext.SaveChanges();
            }
        }

     
    }
}
