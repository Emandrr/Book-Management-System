using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Domain.Entities
{
    public class Book: Entity
    {
        private Book()
        {

        }
        public Book(BookData bookData,double rate,int AuthorId)
        {
            this.Rate = rate;
            this.BookPersonalInfo = bookData;
            this.AuthorId = AuthorId;
        }
        public double Rate { get; set; }

        public int AuthorId { get; set; }

        public BookData BookPersonalInfo {get; set;}
        
    }
}
