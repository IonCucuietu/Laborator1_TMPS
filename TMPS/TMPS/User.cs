using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
     // User.cs - Clasa care implementează interfața IUser
     public class User : IUser
     {
          public string Name { get; set; }
          public string Address { get; set; }
          public int Age { get; set; }
     }
}
