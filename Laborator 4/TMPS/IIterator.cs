using SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
     public interface IIterator
     {
          
               bool HasNext();
               ILibraryItem Next();
               ILibraryItem Current { get; }
          
     }
}
