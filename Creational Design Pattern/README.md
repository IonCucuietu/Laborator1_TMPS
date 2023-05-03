Laborator nr.2

Cucuietu Ion TI-202

#Creational patterns:

Aceasta este o categorie de modele de design în ingineria software care se ocupă de procesul de creare a obiectelor. 
Ele oferă modalități de creare a obiectelor fără a cupla crearea obiectului la clasele de implementare, promovând astfel flexibilitatea, reutilizabilitatea și ușurința în întreținere.

1.Modelul Singleton

2.Modelul Factory Method

3.Modelul Abstract Factory

4.Modelul Builder

5.Modelul Prototype

#Singleton

Patternul Singleton este un design pattern de software care face ca o clasă să aibă o singură instanță, garantând că aceasta poate fi accesată global, fără a crea multiple instanțe ale aceleiași clase. 

Principalele caracteristici ale Singleton includ:

1. O singură instanță: Singleton permite crearea unei singure instanțe a unei clase în cadrul unei aplicații, iar această instanță poate fi accesată global. 
2. Acces global: Instanța Singleton poate fi accesată din oricare altă parte a aplicației care are acces la aceasta, fără a necesita crearea de noi instanțe ale clasei. 
3. Constructor privat: Singleton are un constructor privat pentru a preveni crearea de noi instanțe ale clasei din afara acesteia. 
4. Metodă statică de acces: Singleton oferă de obicei o metodă statică de acces la instanța sa, care verifică dacă instanța există deja și o returnează sau o creează în caz contrar.
 5. Persistență: Singleton poate menține starea sa pe toată durata rulării aplicației, astfel încât să poată fi accesată și modificată în mod consistent de către diverse componente ale aplicației.

Singleton este adesea folosit în situații în care trebuie să fie garantată existența unei singure instanțe a unei clase în cadrul unei aplicații, cum ar fi gestionarea resurselor comune (cum ar fi un sistem de logare sau o configurație) sau gestionarea conexiunilor la bază de date. Cu toate acestea, trebuie avută grijă în utilizarea acestui pattern, deoarece poate introduce potențiale probleme de concurență sau poate face codul dificil de testat, din cauza dependenței strânse între componente.



public class Map

    {
        private static Map MapObject;
        public static Graphics Graphics;
        private static Point PointStart;

        public static Size Size;
        private Map(Point p,int height, int width)
        {
            Size = new Size(width, height);
            PointStart = p;
            GameField = new Rectangle(PointStart, Size);
            Graphics.FillRectangle(new SolidBrush(Color.OldLace), GameField);
        }

        public void DrawMap()
        {
            GameField = new Rectangle(PointStart, Size);
            Graphics.FillRectangle(new SolidBrush(Color.OldLace), GameField);
        }

        public static Map GetInstance(Point p, int height, int width, Graphics gs)
        {
            if (MapObject == null)
            {
                Graphics = gs;
                MapObject = new Map(p, height, width);
                return MapObject;
            }
            else
                return MapObject;
        }

        public List<IObjectBuilder> MapObjects = new List<IObjectBuilder>();

        public Rectangle GameField;


    }
}


Sunt prezente câteva indicii care sugerează că aceasta este o implementare a acestui pattern: 

1. Variabila statică privată MapObject: Aceasta este variabila care păstrează singura instanță a clasei Map. Este declarată ca fiind statică și privată, ceea ce înseamnă că poate fi accesată doar în interiorul clasei și că există o singură copie a acesteia care este partajată între toate instanțele obiectului. 
2. Constructor privat Map: Constructorul clasei Map este declarat ca fiind privat, ceea ce înseamnă că nu poate fi apelat din exteriorul clasei. Aceasta restricționează crearea de noi instanțe ale clasei în afara acesteia. 
3. Metoda statică GetInstance: Aceasta este o metodă statică care creează sau returnează instanța existentă a clasei Map. Metoda verifică dacă MapObject este null, ceea ce indică faptul că instanța nu a fost creată încă, și o creează dacă este necesar, altfel returnează instanța existentă. 

Aceasta asigură că există doar o singură instanță a clasei Map care este partajată între toate apelurile metodei. Aceasta implementare de Singleton are o variabilă statică privată pentru păstrarea instanței unice, un constructor privat pentru a preveni crearea de noi instanțe din exteriorul clasei și o metodă statică pentru a obține instanța unică.

#Factory Method


Factory Method este un design pattern  creational care furnizează o interfață pentru crearea de obiecte într-o clasă, dar permite subclaselor să modifice tipul obiectelor create. Factory Method oferă o metodă abstractă într-o clasă de bază, care este implementată de subclase pentru a crea obiecte specifice, în funcție de nevoile lor. Astfel, Factory Method oferă o modalitate de a delega crearea de obiecte la clasele derivate, fără a expune detaliile de creare în clasa de bază. 

Principalele elemente ale Factory Method includ:

1. Produse: Acestea sunt obiectele create de Factory Method, care pot fi de diverse tipuri și implementări, dar care respectă o interfață sau o clasă comună. 
2. Interfața Fabricii: Aceasta este o interfață sau o clasă abstractă care definește metoda abstractă de creare a produselor. Aceasta poate conține și alte metode comune sau funcționalități legate de crearea obiectelor. 
3. Fabrici Concrete: Acestea sunt clasele care implementează interfața fabricii și furnizează implementări concrete ale metodei de creare a produselor. Acestea pot avea logica specifică pentru crearea obiectelor în funcție de nevoile lor. 
4. Produse Concrete: Acestea sunt clasele care reprezintă obiectele create de Factory Method. Acestea pot avea implementări specifice și pot să moștenească dintr-o clasă comună sau să implementeze o interfață comună.

Factory Method este folosit atunci când se dorește ca procesul de creare a obiectelor să fie decuplat de utilizarea acestora și să se permită subclaselor să decidă tipul obiectelor create în funcție de contextul lor specific. Acest pattern oferă flexibilitate și extensibilitate, permițând adăugarea ușoară de noi produse sau fabrici concrete fără a modifica clasa de bază. Factory Method este utilizat într-o varietate de situații, cum ar fi gestionarea resurselor, tratarea diverselor tipuri de date sau generarea de rapoarte, unde se dorește o abordare flexibilă și extensibilă pentru crearea de obiecte.


În codul meu, clasa AbstractObject este o clasă abstractă care implementează interfața IObjectBuilder:



public abstract class AbstractObject : IObjectBuilder

{

*** 

}

Aceasta conține o serie de metode și proprietăți, cum ar fi ChangeColor(),  BuildObject(), Draw(), Animate(), care pot fi suprascrise în clasele concrete care moștenesc această clasă abstractă.
Clasele concrete care moștenesc clasa AbstractObject, cum ar fi CircleBuilder:

public class CircleBuilder : AbstractObject, IObjectBuilder
{
  ***
}


și RectangleBuilder:

public class RectangleBuilder: AbstractObject, IObjectBuilder
{
  ***
}


Acestea pot să își implementeze propria logică de creare a obiectelor și de animație, prin suprascrierea metodelor abstracte din clasa AbstractObject. Acesta este un exemplu de utilizare a pattern-ului Factory Method, în care clasa abstractă AbstractObject oferă o metodă abstractă BuildObject() pentru crearea de obiecte, iar clasele concrete care o moștenesc își implementează propria logică de creare a obiectelor.

#Abstract Factory


Abstract Factory furnizează o interfață comună pentru crearea familii de obiecte conexe. Acesta definește o interfață abstractă pentru o fabrică de obiecte, care poate să aibă multiple implementări concrete, fiecare generând un set de obiecte specifice. Astfel, Abstract Factory permite crearea de obiecte conexe sau dependente, fără a specifica clasele concrete ale acestora.



     public interface IUnitFactory 
     { 
     string Name {get;set;} 
     IObjectBuilder ObjectBuilder { get; }
     }

Clasele descendente sunt:


public class RectangleFactory : IUnitFactory
{
  *** 
}

public class CircleFactory : IUnitFactory
{
  ***
}


#Builder

 Builder este folosit atunci când avem nevoie să construim un obiect complex, care poate avea o serie de atribute sau proprietăți. În loc să construim obiectul într-un singur pas, putem utiliza un Builder pentru a construi obiectul treptat, pas cu pas.

Structura de bază a design pattern-ului Builder este formată din următoarele componente:


Product: obiectul complex care urmează să fie construit.

Builder: interfața care specifică metodele necesare pentru construcția obiectului complex.

ConcreteBuilder: clasa care implementează interfața Builder și care construiește obiectul complex pas cu pas.

Director: clasa care coordonează construcția obiectului complex, folosind obiectele ConcreteBuilder.

Aici avem uitilizat Object builder interface:

public interface IObjectBuilder

{    

Graphics formGraphics { get; set; }

IObjectBuilder BuildObject();

UserColor ObjectColor { get; set; }

void ChangeColor();


}

