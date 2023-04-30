using SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
     public abstract class LibraryItemDecoratorBase : ILibraryItemDecorator
     {
          protected readonly ILibraryItem LibraryItem;

          public LibraryItemDecoratorBase(ILibraryItem libraryItem)
          {
               LibraryItem = libraryItem;
          }

          public virtual string Title => LibraryItem.Title;
          public virtual string Author => LibraryItem.Author;
          public virtual int Pages => LibraryItem.Pages;

          // Adaugă calificatorul "this." în fața câmpului "LibraryItem"
          ILibraryItem ILibraryItemDecorator.LibraryItem => this.LibraryItem;
     }
}
