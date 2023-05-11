using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
     // Book.cs - Clasa care implementează interfața ILibraryItem
     public class Book : ILibraryItem
     {
          public string Title { get; set; }
          public string Author { get; set; }
          public int Pages { get; set; }
          public string Publisher { get; set; }
     }
}
