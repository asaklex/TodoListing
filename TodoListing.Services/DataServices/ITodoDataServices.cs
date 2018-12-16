using System;
using System.Collections.Generic;
using System.Text;
using TodoListing.DAL.DTO;
using TodoListing.DAL.Models;

namespace TodoListing.Services.DataServices
{
    public interface ITodoDataServices
    {
        Todo AddTodo(TodoDTO todo);
        void RemoveTodo(int id);
        Todo UpdateTodo(int id, TodoDTO todo);
    }
}
