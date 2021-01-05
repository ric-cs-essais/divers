using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{

    public class CParente
    {
        public virtual string methode1()
        {
            return("CParente - methode1");
        }

        public void callMethode1()
        {
            Console.WriteLine( this.methode1() );
        }

        //----------------------------

        public virtual string methode2()
        {
            return ("CParente - methode2");
        }

        public void callMethode2()
        {
            Console.WriteLine(this.methode2());
        }


        public string methode3()
        {
            return ("CParente - methode3");
        }

        public void callMethode3()
        {
            Console.WriteLine(this.methode3());
        }
    }

    public class CEnfant: CParente
    {
        public override string methode1()
        {
            return ("CEnfant - methode1");
        }

        //--------

        public new string methode2()
        {
            return ("CEnfant - methode2");
        }

        public new string methode3()
        {
            return ("CEnfant - methode3");
        }

        //-------

        public string methodeSpecifALEnfant()
        {
            return("CEnfant - methodeSpecifALEnfant");
        }
    }

    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            CParente enfant1 = new CEnfant();
            CEnfant enfant2 = new CEnfant();

            CParente[] arrayOfCParente = new CParente[] { enfant1, enfant2 };
            CEnfant[] arrayOfCEnfant = new CEnfant[] { enfant2 };


            //------------- Les mots-clefs virtual et override, permettent bien d'utiliser le POLYMORPHISME -----------------------
            //C-à-d que si la méthode redéfinie (avec 'override') dans l'enfant,
            //est appelée depuis la classe parente, alors c'est bien celle enfant qui sera appelée !!! et non celle parente.
            //RAPPEL : l'utilisation de 'override', n'est possible que si la méthode parente est virtual ET que celle enfant
            //         a anbsolument et Strictement la même signature. 
            foreach (CParente element in arrayOfCParente)
            {
                element.callMethode1(); //On a bien pour les 2 éléments, la méthode CEnfant::methode1() qui sera appelée.
                                        //Car virtual dans la parente, et override dans l'enfant.

                Console.WriteLine((element as CEnfant).methodeSpecifALEnfant()); //petit test suppl. d'un cast (obligatoire ici de par
                                                                                 // le type de element dans cette boucle).
            }
            Console.WriteLine("\n\n");
            
            foreach (CEnfant element in arrayOfCParente) //Engendre un Cast auto.  (CParent ---> CEnfant)
            {
                element.callMethode1(); //On a évidemment pour les 2 éléments, la méthode CEnfant::methode1() qui sera appelée.
                                        //Car virtual dans la parente, et override dans l'enfant.

                Console.WriteLine(element.methodeSpecifALEnfant()); //petit test suppl., pas besoin de cast de par le type de element 
                                                                    //dans cette boucle.
            }
            Console.WriteLine("\n\n");





            //------------- L'OPERATOR 'new' plombe totalement le polymorphisme -----------------------------
            //C-à-d que si la méthode redéfinie (avec 'new') dans l'enfant,
            //est appelée depuis la classe parente, alors c'est celle parente qui sera 
            //appelée, dans tous les cas !!! :/
            //PAR CONTRE (voir autre projet de test), l'operator 'new' aura son utilité lorsque l'on voudra
            //redéfinir dans l'enfant une méthode ayant un type de retour différant de celui de la méthode parente.
            //(Enfin, on rappelle aussi au passage, que dés lors qu'une méthode de même nom (qu'une parente) 
            // mais de type ou nb. de params différant, est créée dans une classe enfant, alors il y a juste surcharge, 
            // et donc cohabitation des 2 méthodes, aucune ne masquant l'autre).

            //foreach (CParente element in array) //Donnera idem qu'avec : foreach (CEnfant element in array)
            foreach (CEnfant element in arrayOfCParente) //Donnera idem qu'avec : foreach (CParente element in array) !!!!!!! Eh oui !
            {
                element.callMethode2(); //On aura pour les 2 éléments, la méthode CParente::methode2() qui sera appelée !
                                        //Car avec l'operator new dans la classe enfant.
                                        //Et donc dans ce cas, peu importe que la méthode parente soit virtual ou pas, rien à voir !

                element.callMethode3(); //On aura pour les 2 éléments, la méthode CParente::methode3() qui sera appelée.
                                        //Car avec l'operator new dans la classe enfant.
            }
            Console.WriteLine("\n\n");


            //foreach (CParente element in array2) //Donnera idem qu'avec : foreach (CEnfant element in array2)
            foreach (CEnfant element in arrayOfCEnfant) //Donnera idem qu'avec : foreach (CParente element in array2) !!!!!!! Eh oui !
            {
                element.callMethode2(); //On aura pour l'élément du tableau, la méthode CParente::methode2() qui sera appelée.
                                        //Car avec l'operator new dans la classe enfant.
                                        //Et donc dans ce cas, peu importe que la méthode parente soit virtual ou pas, rien à voir !

                element.callMethode3(); //On aura pour l'élément du tableau, la méthode CParente::methode3() qui sera appelée.
                                        //Car avec l'operator new dans la classe enfant.
            }
            Console.WriteLine("\n\n");



            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
