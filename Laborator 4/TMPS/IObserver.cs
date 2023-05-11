using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
     public interface IObserver
     {
          void Update(string eventType, object eventData);
          void Update(BookCollection bookCollection);
     }
}
