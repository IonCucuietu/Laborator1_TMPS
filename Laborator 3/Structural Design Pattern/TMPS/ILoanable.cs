using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{

     // ILoanable.cs - Interfața pentru toate obiectele care pot fi împrumutate
     public interface ILoanable
     {
          IUser Borrower { get; }
          DateTime BorrowDate { get; }
          object Item { get; set; }
          void Borrow(IUser user);
          void Return();
     }
}
