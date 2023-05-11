using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
     public class BookCollectionCaretaker
     {
          private List<BookCollectionMemento> mementos = new List<BookCollectionMemento>();
          private BookCollection bookCollection;

          public BookCollectionCaretaker(BookCollection bookCollection)
          {
               this.bookCollection = bookCollection;
          }

          public void Backup()
          {
               Console.WriteLine("Saving Book Collection state...");
               mementos.Add(new BookCollectionMemento(bookCollection.Book));
          }

          public void Undo()
          {
               if (mementos.Count == 0)
               {
                    Console.WriteLine("There are no more mementos to restore.");
                    return;
               }

               Console.WriteLine("Restoring Book Collection state...");
               var memento = mementos.Last();
               mementos.Remove(memento);

          }
     }
}
