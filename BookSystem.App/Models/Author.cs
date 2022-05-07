using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.App.Models
{
    [Serializable]
    public class Author:IEquatable<Author>
    {
        
        static int counter = 0;

        public Author()
        {
            counter++;
            this.Id = counter;
        }

        public Author(int id)
        {
            this.Id = id;
        }

        public static void SetCounter(int counter)
        {
            Author.counter = counter;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public bool Equals(Author other)
        {
            return Id == other.Id;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Surname}";
        }
    }
}
