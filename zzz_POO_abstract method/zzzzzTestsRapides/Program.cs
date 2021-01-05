using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{
    interface IAnimal
    {
        void respirer();
    }
    interface IChien: IAnimal
    {
        void aboyer();
    }

    class Animal : IAnimal
    {
        public void respirer() {

        }
    }

    class Chien : Animal, IChien
    {
        public void aboyer()
        {

        }
    }

    //------

    abstract class A1 {
        public abstract IAnimal methode();
        public void faire()
        {
            this.methode().respirer();
        }
    }

    class A2: A1
    {
        /*
        public override IAnimal methode() //override car celle parente est comme virtual puisqu'elle est abstract.
        {
            return (new Animal());
        }*/
        //Autre possibilité si besoin :
        public override IAnimal methode() //override car celle parente est comme virtual puisqu'elle est abstract.
        {
            return (new Chien());
        }


        /*
        public override IChien methode() //Que l'on mette override ou new, le compilo. considère que l'on n'a PAS implementé
        {                                //la méthode abstraite de la classe A1, car le type de retour ici diffère !
                                         //Pour qu'il n'y ait pas de souci, il faut que le type de retour
                                         //soit aussi rigoureusement le même !! Comme les 2 cas valides ci-dessus !
            return (new Chien());
        }*/
    }



    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("YO");

            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
