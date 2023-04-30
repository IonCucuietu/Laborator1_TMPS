using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
     // BookLoan.cs - Clasa de împrumut specifică pentru cărți
     public class BookLoan : ILoan
     {
          public BookLoan(Book book)
          {
               Item = book;
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
