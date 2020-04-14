using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCollectionMain.Models
{
    public class BooksModel
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<int> Pages { get; set; }
    }
}