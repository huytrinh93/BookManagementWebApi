using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementWebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        public string author { get; set; }
        public double Price { get; set; }
    }
}