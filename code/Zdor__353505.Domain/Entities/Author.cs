using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Domain.Entities
{
    public class Author : Entity
    {
        private List<Book> _books = new List<Book>();
        private Author()
        {

        }
        public Author(string name,string sex,DateTime BirthDate)
        {
            this.BirthDate = BirthDate;
            this.Name = name;
            this.Sex = sex;
        }
        public string Name { get; set; }
        public string Sex { get; set; }

        public DateTime BirthDate { get; set; }


        public IReadOnlyList<Book> Books { get => _books.AsReadOnly(); }
    }
}
