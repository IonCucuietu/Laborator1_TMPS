using SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
     public class BookCollection : IIterator, IObserver
     {
          private List<Book> books;
          private int current = 0;
          private List<IObserver> observers = new List<IObserver>();

          public BookCollection(List<Book> books)
          {
               this.books = books;
          }

          public bool HasNext()
          {
               return current < books.Count;
          }

          public ILibraryItem Next()
          {
               var book = books[current];
               current++;

               // Notificăm observatorii cu privire la evenimentul următorului element din colecție
               NotifyObservers();

               return book;
          }

          public ILibraryItem Current
          {
               get { return books[current]; }
          }

          public List<Book> Books { get; internal set; }
          public List<Book> Book { get; internal set; }

          // Implementarea metodelor din ISubject
          public void RegisterObserver(IObserver observer)
          {
               observers.Add(observer);
          }

          internal void Restore(BookCollectionMemento memento)
          {
               throw new NotImplementedException();
          }

          public void RemoveObserver(IObserver observer)
          {
               observers.Remove(observer);
          }

          public void NotifyObservers()
          {
               foreach (IObserver observer in observers)
               {
                    observer.Update(this);
               }
          }
          public void Update(string message, object sender)
          {
               Console.WriteLine($"Book Collection received message: {message}");
          }

          public void Update(BookCollection bookCollection)
          {
               this.books = bookCollection.books;
          }

          
          public void Restore(BookCollection memento)
          {
               Restore(memento);
          }
     }
}
