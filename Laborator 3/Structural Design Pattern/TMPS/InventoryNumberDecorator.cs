using SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
     public class InventoryNumberDecorator : LibraryItemDecoratorBase
     {
          private readonly int _inventoryNumber;

          public InventoryNumberDecorator(ILibraryItem libraryItem, int inventoryNumber) : base(libraryItem)
          {
               _inventoryNumber = inventoryNumber;
          }

          public override string Title => $"({_inventoryNumber}) {LibraryItem.Title}";
     }
}
