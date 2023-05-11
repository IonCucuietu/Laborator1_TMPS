using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
     // ILibraryItem.cs - Interfața pentru toate elementele din bibliotecă
    public interface ILibraryItem
     {
          string Title { get; }
          string Author { get; }
          int Pages { get; }
     }
}
