Laborator1_TMPS
Principiul SRP ( Single responsability principle)
SRP este unul dintre principiile SOLID, care spune că o clasă ar trebui să aibă o singură responsabilitate și să fie responsabilă pentru un singur aspect al aplicației.

În programul meu, putem vedea implementarea SRP în felul următor:

• Interfața ILibraryItem definește o singură responsabilitate: de a oferi informații despre un element din bibliotecă, cum ar fi titlul, autorul și numărul de pagini.

• Clasa Book implementează interfața ILibraryItem și este responsabilă doar pentru stocarea informațiilor despre o carte.

• Interfața IUser definește o singură responsabilitate: de a oferi informații despre un utilizator, cum ar fi numele și adresa.

• Clasa User implementează interfața IUser și este responsabilă doar pentru stocarea informațiilor despre un utilizator.

• Interfața ILoanable definește o singură responsabilitate: de a permite împrumutarea și returnarea unui element din bibliotecă către un utilizator.

Astfel, fiecare clasă și interfață din programul meu își îndeplinește o singură responsabilitate, ceea ce face ca programul să fie ușor de înțeles, de întreținut și de extins în viitor.

Principiul OCP ( Open – close principle)
OCP prevede că o entitate trebuie să fie deschisă pentru extensie, dar închisă pentru modificare. Acest principiu sugerează că o entitate ar trebui să poată fi extinsă cu noi funcționalități fără a fi nevoie să modificăm codul existent. În programul meu, principiul OCP este respectat prin faptul că clasele BookLoan și DVDLoan extind interfața ILoan și implementează funcționalitățile specifice împrumutului de cărți și DVD-uri. Aceste clase pot fi extinse pentru a adăuga noi tipuri de împrumuturi fără a fi nevoie să modificăm codul existent al interfeței ILoan. În plus, clasa Book și clasa DVD implementează interfața ILibraryItem, care defineste proprietăți comune pentru toate elementele din bibliotecă, astfel încât o altă implementare a interfeței (cum ar fi împrumutul de jocuri video) ar putea fi adăugată fără a fi nevoie să se modifice codul existent al interfeței.

Principiul LSP ( Liskov substitution principle)
Principiul LSP afirmă că obiectele unei clase derivate trebuie să poată fi utilizate în locul obiectelor clasei de bază, fără a afecta corectitudinea programului. În program, ambele clase Book și DVD implementează interfața ILibraryItem și au implementate toate proprietățile din interfață: Title, Author și Pages. În plus, clasa DVD adaugă două proprietăți specifice unui DVD, dar în ceea ce privește implementarea interfeței, respectă aceeași semnătură a metodelor. De asemenea, clasa DVD implementează proprietățile Author și Pages într-un mod adecvat pentru un DVD, fără a afecta comportamentul general al interfeței ILibraryItem. Astfel, obiectele de tipul Book și DVD pot fi utilizate în locul obiectelor de tipul ILibraryItem, fără a afecta corectitudinea programului și fără a modifica comportamentul general al interfeței.

Principiul ISP ( Interface segregation principle)

ISP presupune că o interfață ar trebui să fie cât mai specifică posibil și să nu conțină mai multe metode decât cele necesare pentru funcționalitatea sa. În cadrul programului meu, interfețele sunt definite astfel încât fiecare interfață are o singură responsabilitate. De exemplu, interfața ILoan este responsabilă pentru gestionarea împrumuturilor, în timp ce interfața ILibraryItem este responsabilă pentru definirea proprietăților elementelor din bibliotecă. De asemenea, clasele implementează numai interfețele de care au nevoie și nu implementează metode pe care nu le folosesc. De exemplu, clasa User implementează interfața IUser, care definește doar proprietățile de bază ale utilizatorului, fără a include alte metode sau proprietăți inutile.

Principiul DIP (Dependency inversion principle)

Principiul DIP se referă la faptul că modulele de nivel superior nu trebuie să depindă de modulele de nivel inferior și că ambele ar trebui să depindă de abstracții. În programul meu, clasa BookLoan depinde de interfața ILibraryItem, care este implementată de clasa Book. Astfel, clasa BookLoan depinde de o abstracție, și nu de o implementare concretă. La fel, clasa DVDLoan depinde de interfața ILibraryItem, care este implementată de clasa DVD. Prin utilizarea acestor interfețe, modulele de nivel superior (cum ar fi clasele BookLoan și DVDLoan) nu depind de modulele de nivel inferior (cum ar fi clasele Book și DVD), ci depind de abstracții (cum ar fi interfața ILibraryItem). Acest lucru face programul mai flexibil și mai ușor de întreținut.
