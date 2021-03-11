using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Book book, int amount)
        {
            CartLine line = Lines
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Amount = amount
                });
            }
            else
            {
                line.Amount += amount;
            }
        }

        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        public virtual void Clear() => Lines.Clear();

        public double ComputeSum() =>
            Lines.Sum(e => e.Book.Price * e.Amount);
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Amount { get; set; }
        }
    }
}
