using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
     // IUser.cs - Interfața pentru utilizator
     public interface IUser
     {
          string Name { get; }
          string Address { get; }
          int Age { get; }
     }
}
