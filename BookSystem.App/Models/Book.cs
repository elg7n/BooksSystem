using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookSystem.App.Models
{
    internal class Book:IEquatable<Book>
    {
        static int counter = 0;

        public bool Equals(Book other)
        {
            return Id == other.Id;
        }
        public Book()
        {
            counter++;
            this.Id = counter;
        }

        public Book(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public double Price { get; set; }

       

        public override string ToString()
        {
            return $"{Id} {Name} {Author} {PageCount}. {Price:0.00}{Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol}";
        }
    }
}
