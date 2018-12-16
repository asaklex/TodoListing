using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoListing.DAL;
using TodoListing.DAL.DTO;
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

        public Todo AddTodo(TodoDTO todoDto)
        {
            var todo = new Todo
            {
                Title = todoDto.Title,
                Description = todoDto.Description
            };

            _dbContext.Todos.Add(todo);
            _dbContext.SaveChanges();
            return todo;
        }

        public Todo UpdateTodo(int id, TodoDTO todo)
        {
            var existing = _dbContext.Todos.Find(id);
            if(existing != null)
            {
                if(!string.IsNullOrEmpty(todo.Description) && !todo.Title.Equals(existing.Description))
                    existing.Description = todo.Description;

                if (!string.IsNullOrEmpty(todo.Title) && !todo.Title.Equals(existing.Title))
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
