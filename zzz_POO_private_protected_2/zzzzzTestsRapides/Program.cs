using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{
    class Mere
    {
        public void methode()
        {
            this._action();
        }

        private void _action()
        {
            Console.WriteLine("_action() from mere.");
        }
    }

    class Fille: Mere
    {
         protected void _action()
        {
            Console.WriteLine("_action() from fille.");
        }
    }


    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            Fille oFille = new Fille();
            oFille.methode();  //MALHEUREUSEMENT la méthode _action() DE LA MERE QUI SERA APPELÉE !!

            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
