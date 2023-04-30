using SOLID;
using System;
using System.Collections.Generic;
namespace SRP
{

     public class Program
     {
          public static void Main(string[] args)
          {
               // Creăm o carte și un utilizator
               var book = new Book
               {
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    Pages = 224,
                    Publisher = "Little, Brown and Company"
               };

               var user = new User
               {
                    Name = "John Doe",
                    Address = "123 Main St.",
                    Age = 30
               };

               var inventoryNumber = 1001;
               ILibraryItem item = new InventoryNumberDecorator(book, inventoryNumber);

               // Afisam informatii despre carte cu numarul de inventar
               Console.WriteLine($"'{item.Title}' de {item.Author} cu numarul de inventar {((InventoryNumberDecorator)item).Title}");

               // Împrumutăm cartea utilizatorului
               ILoan loan = new BookLoan(book);
               ILoan loanProxy = new LoanProxy(loan, user);
               loanProxy.Borrow(user);

               // Afisam informatii despre imprumut
               Console.WriteLine($"'{loan.Item.Title}' de {loan.Item.Author}, {loan.Item.Pages} pagini, a fost împrumutat de către {loan.Borrower.Name} la data de {loan.BorrowDate}");

               // Returnăm cartea
               loan.Return();

               // Creăm un DVD 
               var dvd = new DVD
               {
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    Runtime = 175
               };

               // Împrumutăm DVD-ul utilizatorului
               loan = new DVDLoan(dvd);
               ((ILoan)loan).Borrow(user);

               // Afisam informatii despre imprumut
               Console.WriteLine($"'{loan.Item.Title}' regizat de {loan.Item.Author}, {loan.Item.Pages} pagini, a fost împrumutat de către {loan.Borrower.Name} la data de {loan.BorrowDate}");
               // Returnăm DVD-ul
               loan.Return();
          }
     }
}
