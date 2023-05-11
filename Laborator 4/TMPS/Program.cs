using SOLID;
using System;
using System.Collections.Generic;
namespace SRP
{

     public class Program
     {
          public static void Main(string[] args)
          {
               var books = new List<Book>
     {
          new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Pages = 224, Publisher = "Little, Brown and Company" },
          new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Pages = 336, Publisher = "J.B. Lippincott & Co." },
          new Book { Title = "1984", Author = "George Orwell", Pages = 328, Publisher = "Secker & Warburg" }
     };
               var bookCollection = new BookCollection(books);

               // Iteram prin colecția de cărți
               while (bookCollection.HasNext())
               {
                    var book = (Book)bookCollection.Next();
                    Console.WriteLine($"Titlu: {book.Title}, Autor: {book.Author}, Pagini: {book.Pages}, Editura: {book.Publisher}");
               }

                         
          }
     }
}
