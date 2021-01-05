using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{

    public class Animal
    {
        private string espece;

        public Animal(string espece)
        {
            this.espece = espece;
        }

        public string obtenirEspece()
        {
            return(this.espece);
        }
    }
    public class Chien: Animal
    {
        private string prenom;

        public Chien(string espece, string prenom): base(espece)
        {
            this.prenom = prenom;
        }

        public string obtenirPrenom()
        {
            return (this.prenom);
        }
    }

    //----------------------------------------------

    public class CParent
    {
        public virtual string method1(Int32 n)  //virtual donc overridable (même type de retour, même type de params)
        {
            return ("CParent - method1");
        }

        public virtual string method1b(Int32 n)  //virtual donc overridable (même type de retour, même type de params)
        {
            return ("CParent - method1b");
        }

        public virtual string method1c(Animal animal)
        {
            return ("CParent - method1c / " + animal.obtenirEspece());
        }

        public virtual string method1d(Animal animal)
        {
            return ("CParent - method1d / " + animal.obtenirEspece());
        }

        public virtual Animal method1e()
        {
            return (new Animal("Félin"));
        }

        //----------

        public string method2(Int32 n)  //pas virtual donc non overridable (même type de retour, même type de params)
        {
            return ("CParent - method2");
        }

        public string method2b(Int32 n)
        {                              
            return ("CParent - method2b");
        }

        public string method2c(Int32 n)
        {
            return ("CParent - method2c");
        }

        public string method2d(Int32 n)
        {
            return ("CParent - method2d");
        }

        public string method2e(Animal animal)
        {
            return ("CParent - method2e / " + animal.obtenirEspece());
        }


        //-------------

        public string method3(Int32 n)
        {
            return ("CParent - method3");
        }

        public string method3b(Int32 n)
        {
            return ("CParent - method3b");
        }

    }




    public class CChild: CParent
    {
        //--- Concernant les virtual de la classe parente ----
        public override string method1(Int32 n)  //override (même type de retour, même type de params) de la méthode parente virtual.
        {                                        //L'OVERRIDE (REDEFINITION avec mot-clef 'override') n'est POSSIBLE QUE SI :
                                                 //  - la méthode parente est virtual 
                                                 //  - ET la méthode redéfinie a Exactement la même signature.
            return (base.method1(n) + " puis  CChild - method1");
        }

        public new string method1b(Int32 n)  //même si la parente est overridable (virtual), je peux faire comme si que non,
        {                                    //avec l'operator 'new'. Ici la méthode enfant a exactement la même signature que 
                                             //celle parente. Mais ceci est sans intérêt, il vaut mieux simplement utiliser 'override' comme ci-dessus.
            return (base.method1b(n) + " puis  CChild - method1b"); //<<< MAIS JE PEUX ENCORE QUAND MËME appeler la méthode parente !
        }

        //public override string method1c(Chien chien) ///mot-clef OVERRIDE INTERDIT, car la signature n'est PAS 
        /*{                                            // Exactement la même que celle parente (même si Chien dérive de Animal).
                                                       // IL S'AGIRA donc ici en fait D'UNE SIMPLE SURCHARGE (params différant) !!! 
                                                       // voir plus bas method1c dans les surcharges.
            string localeVar = base.method1c(chien); //On peut bien sûr appeler la méthode parente.
            Console.WriteLine(localeVar);
            return ("CChild - method1c / " + chien.obtenirEspece() + "/" + chien.obtenirPrenom());
        }*/



        //public override Chien method1e() //mot-clef OVERRIDE INTERDIT, car la signature n'est PAS 
        /*{                                // Exactement la même que celle parente (même si Chien dérive de Animal).
                                           // Une surcharge ne sera pas possible (car params idem que la parente),
                                           // on va donc utiliser plus bas l'operator 'new' (method1e()).
            return (new Chien("Caniche", "Bijou"));
        }
        */




        //------ SURCHARGES des méthodes parentes (type et/ou nombre de PARAMS différant) --------

        public string method2(Int32 n, Int64 z)  //Ici il s'agit d'une SURCHARGE : POSSIBLE CAR TYPE/NOMBRE PARAMS DIFFÉRANT 
        {                                        //de ceux de la méthode parente. (Pas nécessaire que le type de retour diffère).
                                                 //Remarque: cette méthode cohabite avec celle héritée de la classe parente.
                                                 //          ce sont bien 2 méthodes vues comme différentes dans la classe enfant.     
            return (base.method2(n) + " puis  CChild - method2");
        }
        public Int32 method2b(Int32 n, Int64 z)  //Ici il s'agit d'une SURCHARGE : possible car type/nombre de params différant 
        {                                        //de ceux de la méthode parente. (Pas nécessaire que le type de retour diffère, 
                                                 // même si là il diffère). 
                                                 //Remarque: cette méthode cohabite avec celle héritée de la classe parente.
                                                 //          ce sont bien 2 méthodes vues comme différentes dans la classe enfant.
            string localeVar = base.method2b(n) + " puis  CChild - method2b";
            Console.WriteLine(localeVar);
            return (10*n);
        }

        /*
        public new Int32 method2c(Int32 n, Int64 z)  //Ici il s'agit d'une SURCHARGE(type/nombre de params différant) : 
        {                                            //donc l'OPERATOR new est INUTILE. Mais passe à la compil.  . 
            string localeVar = base.method2c(n) + " puis  CChild - method2c"; //On peut quand même appeler la méthode parente.
            Console.WriteLine(localeVar);
            return (10 * n);
        }
        */
        /*
        public new string method2d(Int32 n, Int64 z)  //Ici il s'agit d'une SURCHARGE(type/nombre de params différant) : 
        {                                            //donc l'OPERATOR new est INUTILE. Mais passe à la compil.  . 
            string localeVar = base.method2d(n) + " puis  CChild - method2d"; //On peut quand même appeler la méthode parente.
            return (localeVar);
        }
        */

        public string method2e(Chien chien) //SURCHARGE de la méthode parente (type de param. différant bien qu'étant un type enfant).
        {
            string localeVar = base.method2e(chien); //On peut bien sûr appeler la méthode parente.
            Console.WriteLine(localeVar);
            return ("CChild - method2e / " + chien.obtenirEspece() + "/" + chien.obtenirPrenom());
        }


        //Surcharge d'une méthode parente virtual :
        public string method1c(Chien chien) //le mot-clef OVERRIDE étant ici INTERDIT, car la signature n'est PAS 
        {                                   // Exactement la même que celle parente (même si Chien dérive de Animal).
                                            // IL S'AGIRA donc ici en fait D'UNE SIMPLE SURCHARGE (params différant) !!! 
                                            //Peu importe le type de retour (identique ici).       
            string localeVar = base.method1c(chien); //On peut bien sûr appeler la méthode parente.
            Console.WriteLine(localeVar);
            return ("CChild - method1c / " + chien.obtenirEspece() + "/" + chien.obtenirPrenom());
        }

        //Surcharge d'une méthode parente virtual :
        public void method1d(Chien chien) //le mot-clef OVERRIDE étant ici INTERDIT, car la signature n'est PAS 
        {                                   // Exactement la même que celle parente.
                                            // IL S'AGIRA donc ici en fait D'UNE SIMPLE SURCHARGE (params différant) !!! 
                                            //Peu importe le type de retour (d'ailleurs différent ici).
            string localeVar = base.method1d(chien); //On peut bien sûr appeler la méthode parente.
            Console.WriteLine(localeVar);
            Console.WriteLine("CChild - method1d / " + chien.obtenirEspece() + "/" + chien.obtenirPrenom());
        }



        //------ OPERATOR new obligatoire --------

        public new string method3(Int32 n) //OPERATOR new obligatoire car ce n'est pas une surcharge(params idem que la parente).
        {                                  //Rem.: ici le type de retour est idem que celui parent, mais peu importe.
            return (base.method3(n) + " puis  CChild - method3"); //On peut quand même appeler la méthode parente.
        }

        public new Int32 method3b(Int32 n) //OPERATOR new obligatoire car ce n'est pas une surcharge(params idem que la parente).
        {                                  //Rem.: ici le type de retour est différent de celle parente, mais peu importe.
            string localeVar = base.method3b(n) + " puis  CChild - method3b"; //On peut quand même appeler la méthode parente.
            Console.WriteLine(localeVar);
            return (100 * n);
        }

        public new Chien method1e()  //OPERATOR new obligatoire car ce n'est pas une surcharge(params idem que la parente).
        {                            //Rem.: ici le type de retour est différent de celle parente, mais peu importe pour le new.
                                     //Donc même si type de retour dérive du type de retour de la méthode parente, le 'new' est obligatoire.
                                     //(car on ne peut utiliser "override" si pas Exactement la même signature que la méthode parente !).
            Console.WriteLine("____");
            string localeVar = " "+base.method1e().obtenirEspece() + " ; puis  CChild - method1e"; //On peut quand même appeler la méthode parente.
            Console.WriteLine(localeVar);
            return (new Chien("Caniche", "Bijou"));
        }
        


    }

    /*
     CONCLUSION :

        * A) REDÉFINITION de méthode possible dans la classe enfant possible SI et seulement SI : *
          - La méthode enfant :
             . a EXACTEMENT la même signature que celle parente
             . sa signature comporte le mot-clef 'override'
          - ET la méthode parente est définie avec le mot-clef 'virtual'.

             Rem.: si en pareil cas, on utilise dans la signature enfant, le mot-clef 'new' au lieu de 'override'
                   ça passe, mais c'est sans intérêt. Il vaut mieux n'utiliser 'new' qu'en cas d'obligation comme évoqué plus bas cas C.
             
           (exemple ici : method1 )
        


         * SINON SI les 3 conditions évoquées ci-dessus ne sont pas vérifiées, alors pas d'override possible et : *
           .B) SI le type ou nombre des params diffère dans l'enfant, alors il s'agit tout simplement d'une SURCHARGE,
              et donc les 2 méthodes cohabitent dans l'enfant (celle parente de signature différente donc, et celle enfant).
              ATTENTION: si un param. parmi les params de la méthode enfant est d'un type différent 
                         mais dérivé, du type du même param. de la méthode parente,
                         alors il s'agira tout de même bien d'une Surcharge (car types considérés comme différant, strictement parlant).   

             Tout ceci, que la méthode parente soit virtual ou non.
             De plus, en pareil cas, l'utilisation d'un operator 'new' dans la signature enfant, n'aura ici aucun intérêt, 
              bien que toléré par le compilo. .

            (exemples ici : method2, method2b, method2e, method1c, method1d)


           .C) SI le type ET le nombre de params est le même MAIS, le type de la valeur de retour diffère dans l'enfant, 
               alors là il FAUDRA OBLIGATOIREMENT utiliser l'operator 'new' dans la signature de la méthode enfant.
               Tout ceci, que la méthode parente soit virtual ou non.

              (exemples ici: method3, method3b, method1e)
          


        REMARQUE : dans TOUS LES CAS, la méthode de la parente sera toujours appelable depuis celle enfant, 
                   via la syntaxe : base.nomMethode(...);
      
    */




    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            CChild ch1 = new CChild();
            Animal animal = new Animal("Elephant");
            Chien dog = new Chien("Pitbull", "Brutus");

            //---- Méthodes virtual dans la classe parente -----
            Console.WriteLine( ch1.method1(10) ); //Appelle bien celle overridant.
            Console.WriteLine( ch1.method1b(10) ); //Appelle bien celle de l'enfant (non override mais avec operator 'new').
            Console.WriteLine("\n\n");


            //---- Surcharges ------
            Console.WriteLine(ch1.method2(10)); //Appelle la méthode parente car les paramètres ne correspondent pas à celle surchargée.
            Console.WriteLine(ch1.method2b(5)); //Appelle la méthode parente car les paramètres ne correspondent pas à celle surchargée.
            //Console.WriteLine(ch1.method2c(5)); //Appellerait bien la méthode parente car les paramètres ne correspondent pas à celle surchargée.
            //Console.WriteLine(ch1.method2d(5)); //Appellerait bien la méthode parente car les paramètres ne correspondent pas à celle surchargée.
            Console.WriteLine(ch1.method2e(animal));  //Appelle la méthode parente car paramètre de type Animal (et non de type Chien).
            Console.WriteLine(ch1.method2e(dog as Animal));  //Appelle la méthode parente car paramètre de type Animal (et non de type Chien).
            Console.WriteLine(ch1.method1c(animal));  //Appelle la méthode parente car paramètre de type Animal (et non de type Chien).
            Console.WriteLine(ch1.method1c(dog as Animal));  //Appelle la méthode parente car paramètre de type Animal (et non de type Chien).
            Console.WriteLine(ch1.method1d(animal));  //Appelle la méthode parente car paramètre de type Animal (et non de type Chien).
            Console.WriteLine(ch1.method1d(dog as Animal));  //Appelle la méthode parente car paramètre de type Animal (et non de type Chien).
            Console.WriteLine("\n\n");

            Console.WriteLine(ch1.method2(10, 100)); //Appelle bien la méthode enfant surcharge, car les paramètres correspondent bien.
            Console.WriteLine(ch1.method2b(5, 50));  //Appelle bien la méthode enfant surcharge, car les paramètres correspondent bien.
            //Console.WriteLine(ch1.method2c(5, 50));  //Appellerait bien la méthode enfant surcharge, car les paramètres correspondent bien.
            //Console.WriteLine(ch1.method2d(5, 50));  //Appellerait bien la méthode enfant surcharge, car les paramètres correspondent bien.
            Console.WriteLine(ch1.method2e(dog));  //Appelle bien la méthode enfant surcharge, car paramètre de type Chien (et non juste de type Animal).
            Console.WriteLine(ch1.method1c(dog));  //Appelle bien la méthode enfant surcharge, car paramètre de type Chien (et non juste de type Animal).
            ch1.method1d(dog);  //Appelle bien la méthode enfant surcharge, car paramètre de type Chien (et non juste de type Animal).
            Console.WriteLine("\n\n");



            //----- Méthodes avec operator 'new' obligatoire dans la classe enfant ------
            Console.WriteLine(ch1.method3(10));
            Console.WriteLine(ch1.method3b(200));

            Console.WriteLine(ch1.method1e().obtenirEspece());
            Console.WriteLine(ch1.method1e().obtenirPrenom());
            Console.WriteLine("\n\n");




            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}

