using System;
using System.Collections.Generic;
using System.Text;
using TodoListing.DAL.Models;

namespace TodoListing.Services.DataServices
{
    public interface ITodoDataServices
    {
        Todo AddTodo(Todo todo);
        void RemoveTodo(int id);
        Todo UpdateTodo(int id, Todo todo);
    }
}
