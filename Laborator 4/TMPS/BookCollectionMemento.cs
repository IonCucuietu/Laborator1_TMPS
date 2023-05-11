using SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
     public class BookCollectionMemento
     {
          public List<Book> Books { get; set; }

          public BookCollectionMemento(List<Book> books)
          {
               Books = new List<Book>(books);
          }
     }
}
