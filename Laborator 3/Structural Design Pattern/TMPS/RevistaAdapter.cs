using SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
     public class RevistaAdapter : ILibraryItem
     {
          private readonly Revista _revista;

          public RevistaAdapter(Revista revista)
          {
               _revista = revista;
          }

          public string Title => _revista.Title;
          public string Author => _revista.Author;
          public int Pages => _revista.Pages;
     }
}
