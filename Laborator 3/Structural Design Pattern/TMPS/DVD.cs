using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
     // DVD.cs - Clasa care implementează interfața ILibraryItem
     public class DVD : ILibraryItem
     {
          public string Title { get; set; }
          public string Director { get; set; }
          public int Runtime { get; set; }
          public string Studio { get; set; }

          public string Author => Director; // Nu există un autor în cazul unui DVD, deci se folosește directorul ca autor

          public int Pages => Runtime / 60; // Durata în minute împărțită la 60 va da numărul de pagini (presupunând că o pagină corespunde cu un minut)
     }
}
