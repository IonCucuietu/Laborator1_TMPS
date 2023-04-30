using SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
     public class Revista : ILibraryItem
     {
          public string Title { get; set; }
          public string Author { get; set; }
          public int Pages { get; set; }
     }
}
