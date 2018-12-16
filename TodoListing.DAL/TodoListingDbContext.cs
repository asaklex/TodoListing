using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoListing.DAL.Models;

namespace TodoListing.DAL
{
    public class TodoListingDbContext:DbContext
    {
        public TodoListingDbContext(DbContextOptions<TodoListingDbContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; }
    }
}
