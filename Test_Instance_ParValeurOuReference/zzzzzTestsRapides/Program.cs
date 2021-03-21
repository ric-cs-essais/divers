using System;
using System.Collections.Generic;
using System.Text;
using zzzzzTestsRapides._MyClasses;

namespace zzzzzTestsRapides
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClasse oObj = new MyClasse(10, 20);
            oObj.show();
            Console.WriteLine("\n==========================\n");

            //

            //Le passage d'une instance de classe, se fait par référence 
            //(mais en réalité sous le capot, c'est une copie du pointeur(adresse) de l'instance).

            MyClasseInstanceModifier oMyClassInstanceModifier = new MyClasseInstanceModifier();

            MyClasse oObj2 = oMyClassInstanceModifier.justReturnInstance(oObj);
            Console.WriteLine(oObj2 == oObj); //True, donc le retour est bien par Reference.
            Console.WriteLine("\n==========================\n");

            MyClasse oObj3 = oMyClassInstanceModifier.returnACopyOfTheInstance(oObj);
            Console.WriteLine(oObj3 == oObj); //False, car il s'agit bien de 2 instances différentes.
            Console.WriteLine("\n==========================\n");

            MyClasse oObj4 = oMyClassInstanceModifier.changeInstance(oObj);
            Console.WriteLine(oObj4 == oObj); //True, ok.
            oObj.show();
            Console.WriteLine("\n==========================\n");


            Console.ReadKey();
        }
    }
}
