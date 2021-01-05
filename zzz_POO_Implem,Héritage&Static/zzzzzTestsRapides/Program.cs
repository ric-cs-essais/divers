using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{
    interface IMyInterface
    {
        //static void MethStatic(); // PAS DE STATIC autorisé dans une interface !!!! <<<<<<<<<<<<<<<<<<
    }

    abstract class AMyClass {
        private AMyClass() { }
        //public abstract static void getInstance(); // PAS DE STATIC autorisé pour un membre abstract !!!! <<<<<<<<<<<<<<<<<<
    }


    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            //JUSTE VOIR commentaire plus haut.     Rien à voir à l'exécution.                
            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
