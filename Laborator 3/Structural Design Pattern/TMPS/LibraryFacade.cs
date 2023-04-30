using SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
     public class LibraryFacade
     {
          private readonly Dictionary<int, ILoanable> _items;

          public LibraryFacade()
          {
               _items = new Dictionary<int, ILoanable>();
          }

          public void AddItem(ILoanable item, int inventoryNumber)
          {
               _items.Add(inventoryNumber, item);
          }

          public void BorrowItem(int inventoryNumber, IUser user)
          {
               if (_items.TryGetValue(inventoryNumber, out var loanable))
               {
                    loanable.Borrow(user);
                    if (loanable.Item is Book book)
                    {
                         Console.WriteLine($"Book '{book.Title}' a fost împrumutat de către {user.Name} la data de {loanable.BorrowDate}");
                    }
                    else
                    {
                         Console.WriteLine($"Obiectul '{loanable.Item.ToString()}' a fost împrumutat de către {user.Name} la data de {loanable.BorrowDate}");
                    }
               }
          }

          public void ReturnItem(int inventoryNumber)
          {
               if (_items.TryGetValue(inventoryNumber, out var loanable))
               {
                    loanable.Return();
                    Console.WriteLine($"{loanable.GetType().Name} '{loanable.Item}' a fost returnat cu succes");
               }
               else
               {
                    Console.WriteLine($"Nu există niciun obiect cu numărul de inventar {inventoryNumber}");
               }
          }
     }
}
