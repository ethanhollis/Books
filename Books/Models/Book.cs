using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        [RegularExpression("^[0-9]{3}-[0-9]{9}$", ErrorMessage = "Enter a valid ISBN")]
        public string ISBN { get; set; }
        public double Price { get; set; }
        public string AuthorFirst { get; set; }
        public string AuthorLast { get; set; }
        public string AuthorMiddle { get; set; }
        public string Publisher { get; set; }
        public string Classification { get; set; }
        public string Category { get; set; }
        public int Pages { get; set; }

    }
}
