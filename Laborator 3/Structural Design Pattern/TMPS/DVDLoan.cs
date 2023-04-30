using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
     // DVDLoan.cs - Clasa de împrumut specifică pentru DVD-uri
     public class DVDLoan : ILoan
     {
          public DVDLoan(DVD dvd)
          {
               Item = dvd;
          }

          public ILibraryItem Item { get; private set; }
          public IUser Borrower { get; private set; }
          public DateTime BorrowDate { get; private set; }

          public void Borrow(IUser user)
          {
               Borrower = user;
               BorrowDate = DateTime.Now;
          }

          public void Return()
          {
               Borrower = null;
               BorrowDate = default(DateTime);
          }
     }
}
