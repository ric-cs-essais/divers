using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    interface IAliment
    {
        string getName();
    }
    interface IAnimal
    {
        void nourir(IAliment poAliment); //Cette méthode devra être EXACTEMENT implémentée
        //c-à-d avec cette signature EXACTEMENT. Même si (cf. plus bas: classes Banane et Lion, auront EN PLUS leur propre méthode nourir(...))
    }
    //--------
    interface IFruit : IAliment
    {
        Double getFibersPercentage();
    }
    interface IViande : IAliment
    {
        Double getProteinsPercentage();
    }

    //=============
    abstract class AAliment : IAliment
    {
        private string _sName;
        public AAliment(string psName)
        {
            this._sName = psName;
        }
        public string getName() { return (this._sName); }
    }

    abstract class AAnimal : IAnimal
    {
        public void nourir(IAliment poAliment)
        {
            Console.WriteLine("Dans AAnimal::nourir(IAliment) !!! Nom de l'aliment : " + poAliment.getName() + ".   <<<");
        }
    }


    //=============
    class Banane : AAliment, IFruit
    {
        public Banane() : base("Banane") { }
        public Double getFibersPercentage() { return (3); }
    }

    class Steak : AAliment, IViande
    {
        public Steak() : base("Steak") { }
        public Double getProteinsPercentage() { return (26); }
    }

    //--------
    interface ISinge : IAnimal
    {
        void nourir(IFruit poFruit);
    }
    class Singe : AAnimal, ISinge
    { //LE FAIT d'hériter de AAnimal permet d'avoir aussi une méthode nourir(IAliment), et donc d'assurer l'obligation d'implémentation de IAnimal.
        public void nourir(IFruit poFruit)
        {
            Console.WriteLine("Dans Singe::nourir(IFruit) ;  Singe nourri de " + poFruit.getName() + "s (" + poFruit.getFibersPercentage() + "% de fibres).");
        }
    }

    interface ILion : IAnimal
    {
        void nourir(IViande poViande);
    }
    class Lion : ILion
    { //Contrairement à la classe Singe, ici on choisit de ne pas hériter de AAnimal, donc on DOIT impérativement définir nourir(IAliment) (implém. de IAnimal).
        public void nourir(IAliment poAliment)
        {  //<<<<< DOIT quand même être définie, mais NE sera PAS appelée si on transmet à nourir() un IViande ! Ce sera en effet l'autre ci-dessous dans ce cas !
            Console.WriteLine("Dans Lion::nourir(IAliment) !!! Nom de l'aliment : " + poAliment.getName() + ".   <<<");
        }
        public void nourir(IViande poViande)
        {
            Console.WriteLine("Dans Lion::nourir(IViande) ;  Lion nourri de " + poViande.getName() + " (" + poViande.getProteinsPercentage() + "% de protéines).");
        }
    }



    //=============================================================
    class Program
    {
        static void Main(string[] args)
        {
            IFruit oBanane = new Banane();
            IViande oSteak = new Steak();

            Singe oSinge = new Singe();
            Lion oLion = new Lion();


            //----
            oSinge.nourir(oBanane); //Reçoit un IFruit, donc c'est nourir(IFruit) qui sera appelée et non nourir(IAliment) (héritée de AAnimal).
            oSinge.nourir(oSteak); //<<<< Appelera nourir(IAliment) cette fois(héritée de AAnimal), car c'est la correspondance la plus proche.
            Console.WriteLine("\n");

            oLion.nourir(oSteak); //Reçoit un IViande, donc c'est nourir(IViande) qui sera appelée et non nourir(IAliment).
            oLion.nourir(oBanane); //<<<< Appelera nourir(IAliment) cette fois, car c'est la correspondance la plus proche.
            Console.WriteLine("\n");


            //----
            System.Console.ReadKey();


        }
    }

}
