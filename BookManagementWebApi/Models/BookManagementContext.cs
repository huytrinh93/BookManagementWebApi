using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookManagementWebApi.Models
{
    public class BookManagementContext : DbContext,IManagementContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public BookManagementContext() : base("name=BookManagementContext")
        {
           
        }

        public System.Data.Entity.DbSet<BookManagementWebApi.Models.Book> Books { get; set; }

        public void MarkAsModified(Book item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}
