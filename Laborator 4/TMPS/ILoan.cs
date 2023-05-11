using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
     // ILoan.cs - Interfața pentru gestionarea împrumuturilor
     public interface ILoan
     {
          ILibraryItem Item { get; }
          IUser Borrower { get; }
          DateTime BorrowDate { get; }
          void Borrow(IUser user);
          void Return();
     }
}
