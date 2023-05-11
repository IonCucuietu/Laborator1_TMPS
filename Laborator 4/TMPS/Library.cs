using SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
     public class Library : ISubject
     {
          private List<ILibraryItem> items;
          private List<IObserver> observers;

          public Library(List<ILibraryItem> items)
          {
               this.items = items;
               observers = new List<IObserver>();
          }

          public void Attach(IObserver observer)
          {
               observers.Add(observer);
          }

          public void Detach(IObserver observer)
          {
               observers.Remove(observer);
          }

          public void Notify(string eventType, object eventData)
          {
               foreach (var observer in observers)
               {
                    observer.Update(eventType, eventData);
               }
          }

          public void AddItem(ILibraryItem item)
          {
               items.Add(item);
               Notify("ItemAdded", item);
          }

          public void RemoveItem(ILibraryItem item)
          {
               items.Remove(item);
               Notify("ItemRemoved", item);
          }
     }
}
