using SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
     public class LoanProxy : ILoan
     {
          private readonly ILoan _loan;
          private readonly IUser _user;

          public LoanProxy(ILoan loan, IUser user)
          {
               _loan = loan;
               _user = user;
          }

          public ILibraryItem Item => _loan.Item;
          public IUser Borrower => _loan.Borrower;
          public DateTime BorrowDate => _loan.BorrowDate;

          public void Borrow(IUser user)
          {
               if (user.Age >= 15) // verificăm dacă utilizatorul are vârsta minimă necesară pentru a împrumuta o carte
               {
                    _loan.Borrow(user);
               }
               else
               {
                    Console.WriteLine("Nu puteți împrumuta această carte deoarece aveți mai puțin de 18 ani.");
               }
          }

          public void Return()
          {
               _loan.Return();
          }
     }
}
