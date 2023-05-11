  TMPS
  
 Cucuietu Ion 
 
  TI-202 
  
  Laborator 4

Theory:

  Behavioral design pattern-urile sunt un tip de design pattern-uri software care se concentrează pe modul în care diferite obiecte și clase colaborează între ele și își îndeplinesc sarcinile. Acestea se concentrează pe comportamentul obiectelor și oferă soluții pentru problemele de comunicare între obiecte și de gestionare a fluxurilor de date într-o aplicație.

  Unul dintre cele mai importante aspecte ale behavioral design pattern-urilor este că acestea sunt în mare parte independente de platforma sau limbajul de programare utilizat pentru a dezvolta aplicația. Prin urmare, acestea sunt utile pentru programatorii care doresc să își îmbunătățească abilitățile de proiectare a software-ului.

Visitor Încapsulează un algoritm în interiorul unei clase

Iterator Accesează secvențial elementele unei colecții

Memento Capturează și restabilește starea internă a unui obiect

Observer O modalitate de a notifica modificarea unui număr de clase

Template Amânați pașii exacti ai unui algoritm la o subclasă



Objectives:

Prin extinderea proiectului, implementați cel puțin 1 model de design comportamental în proiectul dvs.

Păstrați fișierele grupate în funcție de responsabilitățile lor

Documentați-vă munca într-un fișier separat de reducere, conform cerințelor prezentate mai jos



Implementation description

1. Iterator

Design patternul Iterator este un pattern comportamental care permite iterarea printr-o colecție de obiecte fără a dezvălui implementarea acesteia. Acesta separă procesul de traversare a unei colecții de implementarea acesteia, permițând astfel colecțiilor să fie modificate fără a afecta codul care le traversează.

În general, iteratorul oferă o interfață pentru iterarea printr-o colecție de obiecte, permițând unui client să itereze prin aceasta fără a cunoaște detaliile de implementare. Prin utilizarea iteratorului, obiectele din colecție pot fi parcurse în mod secvențial, fără a fi necesară o cunoaștere a structurii interne a colecției.

Design patternul Iterator poate fi folosit pentru a simplifica codul de iterare în cazul unor structuri de date complexe, cum ar fi arbori sau grafuri, sau pentru a abstractiza procesul de accesare a datelor dintr-o colecție mare de obiecte.


Pentru a implementa design pattern-ul Iterator în proiectul meu, trebuie să adăugăm o nouă interfață IIterator și o nouă clasă BookCollection care implementează această interfață și care conține o listă de cărți și un index curent. Interfața IIterator trebuie să declare metodele HasNext, Next și proprietatea Current, astfel încât să putem itera prin colecția de cărți.

Mai întâi, vom adăuga interfața IIterator:


public interface IIterator

{

     bool HasNext();
     
     ILibraryItem Next();
     
     ILibraryItem Current { get; }
     
}


Apoi vom adăuga clasa BookCollection care va implementa această interfață:


public class BookCollection : IIterator

{

     private List<Book> books;
     
     private int current = 0;

     public BookCollection(List<Book> books)
     {
          this.books = books;
     }

     public bool HasNext()
     {
          return current < books.Count;
     }

     public ILibraryItem Next()
     {
          var book = books[current];
          current++;
          return book;
     }

     public ILibraryItem Current
     {
          get { return books[current]; }
     }
}

În final, vom modifica clasa Program pentru a utiliza noua clasă BookCollection și pentru a itera prin colecția de cărți:


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


Acum putem itera prin colecția de cărți utilizând metodele din interfața IIterator.

2. Observer

Observer este un pattern de design care permite obiectelor sa fie notificate automat atunci cand starea unui alt obiect se schimba. Aceasta comunicare se face printr-un mecanism de abonare, in care unul sau mai multi obiecte observatori sunt inregistrati la un obiect subiect pentru a primi notificari despre schimbarile de stare ale acestuia.

Acest pattern este utilizat frecvent in situatii in care se doreste sa se mentina doua obiecte sincronizate, astfel incat schimbarile dintr-un obiect sa fie reflectate in mod automat in celalalt obiect. De exemplu, in interfetele grafice, se poate utiliza Observer pentru a actualiza automat afisajul unei componente grafice atunci cand utilizatorul face o modificare in alta componenta.


Pentru a implementa pattern-ul Observer în codul meu, vom avea nevoie de două noi interfețe și o clasă:

ISubject - acesta este subiectul (sau subiectele) care ar trebui să informeze obiectele observator atunci când se produce o anumită acțiune. Interfața conține două metode: Attach și Detach, care sunt utilizate pentru a adăuga sau a elimina observatori la/din lista de observatori a subiectului și o metodă Notify, care este utilizată pentru a informa observatorii despre evenimentul produs.

IObserver - acesta este obiectul care va fi notificat atunci când se produce evenimentul. Interfața conține o metodă Update, care este apelată de subiect atunci când se produce un eveniment. Argumentul acestei metode poate fi orice informație suplimentară pe care subiectul o transmite observatorului.

Library - aceasta este clasa care va acționa ca subiect și va informa observatorii despre evenimentele care apar. În exemplul nostru, vom presupune că evenimentul este adăugarea sau eliminarea unui element din bibliotecă. Astfel, vom adăuga două metode noi în această clasă: AddItem și RemoveItem, care vor fi utilizate pentru a adăuga sau a elimina un element din bibliotecă și vor notifica observatorii despre acțiunea realizată.

Iată cum ar putea arăta implementarea:

public interface ISubject

{

     void Attach(IObserver observer);
     
     void Detach(IObserver observer);
     
     void Notify(string eventType, object eventData);
     
}

public interface IObserver

{

     void Update(string eventType, object eventData);
     
}

public class Library : ISubject

{

     private List<ILibraryItem> items;
  
     private List<IObserver> observers;

     public Library(List<ILibraryItem> items)
  
     {
  
          this.items = items;
  
          observers = new List<IObserver>();
          
     }

     public void Attach(IObserver observer)
     
     {
     
          observers.Add(observer);
          
     }

     public void Detach(IObserver observer)
     
     {
     
          observers.Remove(observer);
          
     }

     public void Notify(string eventType, object eventData)
     
     {
     
          foreach (var observer in observers)
          
          {
          
               observer.Update(eventType, eventData);
               
          }
          
     }

     public void AddItem(ILibraryItem item)
     
     {
     
          items.Add(item);
          
          Notify("ItemAdded", item);
          
     }

     public void RemoveItem(ILibraryItem item)
     
     {
     
          items.Remove(item);
          
          Notify("ItemRemoved", item);
          
     }
     
}

Mai departe, vom modifica acum clasa BookCollection pentru a implementa interfața IObserver, astfel încât să putem monitoriza evenimentele ItemAdded și ItemRemoved și să le afișăm în consolă:


 public class BookCollection : IIterator, IObserver
 
     {
     
          private List<Book> books;
          
          private int current = 0;
          
          private List<IObserver> observers = new List<IObserver>();

          public BookCollection(List<Book> books)
          
          {
          
               this.books = books;
               
          }

          public bool HasNext()
          
          {
          
               return current < books.Count;
               
          }

          public ILibraryItem Next()
          
          {
          
               var book = books[current];
               
               current++;

               // Notificăm observatorii cu privire la evenimentul următorului element din colecție
               
               NotifyObservers();

               return book;
          }

          public ILibraryItem Current
          
          {
          
               get { return books[current]; }
               
          }

          // Implementarea metodelor din ISubject
          
          public void RegisterObserver(IObserver observer)
          
          {
          
               observers.Add(observer);
               
          }

          public void RemoveObserver(IObserver observer)
          
          {
          
               observers.Remove(observer);
               
          }

          public void NotifyObservers()
          
          {
          
               foreach (IObserver observer in observers)
               
               {
               
                    observer.Update(this);
                    
               }
               
          }
          
          public void Update(string message, object sender)
          
          {
          
               Console.WriteLine($"Book Collection received message: {message}");
               
          }

          public void Update(BookCollection bookCollection)
          
          {
          
               this.books = bookCollection.books;
               
          }
          
     }

3. Memento


Memento este un design pattern de tip behavioral care permite salvarea stării interne a unui obiect fără a dezvălui detaliile interne ale obiectului și fără a încălca principiul de încapsulare.

Acest pattern este util atunci când un obiect trebuie să poată fi readus la o anumită stare anterioară și poate fi folosit pentru a implementa funcționalități de undo/redo.

În mod tradițional, acest pattern constă din trei componente principale:

Originator: este clasa care deține starea internă și care poate crea un memento pentru a salva această stare sau poate utiliza un memento pentru a-și restabili starea anterioară.

Memento: este clasa care reprezintă starea internă salvată a originatorului și care poate fi restaurată la o dată ulterioară.

Caretaker: este clasa care este responsabilă pentru gestionarea memento-urilor create de originator și care le poate restabili la cerere.


// Clasa Memento

public class BookCollectionMemento

{

    public List<Book> Books { get; set; }

    public BookCollectionMemento(List<Book> books)
    
    {
    
        Books = new List<Book>(books);
        
    }
    
}

// Clasa Caretaker

public class BookCollectionCaretaker

{

    private List<BookCollectionMemento> mementos = new List<BookCollectionMemento>();
    
    private BookCollection bookCollection;

    public BookCollectionCaretaker(BookCollection bookCollection)
    
    {
    
        this.bookCollection = bookCollection;
        
    }

    public void Backup()
    
    {
    
        Console.WriteLine("Saving Book Collection state...");
        
        mementos.Add(new BookCollectionMemento(bookCollection.Books));
        
    }

    public void Undo()
    
    {
    
        if (mementos.Count == 0)
        
        {
        
            Console.WriteLine("There are no more mementos to restore.");
            
            return;
            
        }

        Console.WriteLine("Restoring Book Collection state...");
        
        var memento = mementos.Last();
        
        mementos.Remove(memento);

        bookCollection.Restore(memento);
        
    }
    
}

// Clasa BookCollection actualizată cu metoda Restore()

public class BookCollection : IIterator, IObserver

{

    private List<Book> books;
    
    private int current = 0;
    
    private List<IObserver> observers = new List<IObserver>();

    public BookCollection(List<Book> books)
    
    {
    
        this.books = books;
        
    }

    public bool HasNext()
    
    {
    
        return current < books.Count;
        
    }

    public ILibraryItem Next()
    
    {
    
        var book = books[current];
        
        current++;

        // Notificăm observatorii cu privire la evenimentul următorului element din colecție
        
        NotifyObservers();

        return book;
        
    }

    public ILibraryItem Current
    
    {
    
        get { return books[current]; }
        
    }

    // Implementarea metodelor din ISubject
    
    public void RegisterObserver(IObserver observer)
    
    {
    
        observers.Add(observer);
        
    }

    public void RemoveObserver(IObserver observer)
    
    {
    
        observers.Remove(observer);
        
    }

    public void NotifyObservers()
    
    {
    
        foreach (IObserver observer in observers)
        
        {
        
            observer.Update(this);
            
        }
        
    }

    public void Update(string message, object sender)
    
    {
    
        Console.WriteLine($"Book Collection received message: {message}");
        
    }

    public void Update(BookCollection bookCollection)
    
    {
    
        this.books = bookCollection.books;
        
    }

    public void Restore(BookCollectionMemento memento)
    
    {
    
        books = memento.Books;
        
        current = 0;
       
    }
    
}


În clasa BookCollection, am adăugat metoda Restore() care permite restabilirea stării colecției de cărți la o stare anterioară.

În clasa BookCollectionCaretaker, am adăugat metoda Backup() care creează un nou obiect Memento și îl adaugă la lista de mementouri. De asemenea, am adăugat metoda Undo() care ia ultimul obiect Memento din lista de mementouri și restabilește starea colecției de cărți.


Concluzie:

Implementarea design pattern-urilor behavioral precum Iterator, Observer și Memento a adus o serie de beneficii proiectului meu.

Iterator a permis o iterare simplă și eficientă a elementelor colecției de cărți, fără a fi nevoie de cunoștințe avansate de programare sau structuri de date complexe.

Observer a permis decuplarea între diferitele componente ale proiectului și le-a permis să comunice între ele într-un mod eficient, fără a fi nevoie de cuplare strânsă și fără a afecta prea mult performanța.

Memento a oferit o soluție elegantă pentru salvarea și restaurarea stării obiectelor, permițând astfel restabilirea datelor stocate într-un moment anterior al programului.

Toate aceste design pattern-uri behavioral au contribuit la o mai bună organizare și structurare a codului, reducând astfel complexitatea și creșterea flexibilității și ușurinței de întreținere a proiectului.
