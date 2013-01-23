using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ToDoListApp.Models
{
    public class ToDoItem
    {
        public int ToDoItemId { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
    public class ToDoDb : DbContext
    {
        public DbSet<ToDoItem> ToDoItemEntries { get; set; }
    }
}