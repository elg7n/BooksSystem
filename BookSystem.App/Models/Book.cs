using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookSystem.App.Models
{
    [Serializable]
    public class Book:IEquatable<Book>
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

        public static void SetCounter(int counter)
        {
            Book.counter = counter;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int PageCount { get; set; }
        public double Price { get; set; }

       

        public override string ToString()
        {
            return $"{Id} {Name} {AuthorId} {PageCount}. {Price:0.00}{Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol}";
        }

        public string ToString(Author a)
        {
            string data = (a == null) ?null:$"{a.Name} {a.Surname}";
            return $"{Id} {Name} \"{data??this.AuthorId.ToString()}\" {PageCount}. {Price:0.00}{Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol}";
        }
    }
}
