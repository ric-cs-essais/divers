using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{

/*---------------- PROBLEME --------------------*/
/*
    interface IBase
    {
        void meth1();
        void meth2();
    }

    abstract class ABase : IBase
    {
        public abstract void meth1(); //Si je commente cette ligne, le compilo. dit que ABase n'implémente pas IBase !
        public void meth2()
        {
            Console.WriteLine("ABase::meth2()");
        }
    }

    class MaBase : ABase, IBase  //Mais Si je décommente la ligne "abstract public void meth1()" de ABase ci-dessus, 
    {                            //alors le compilo. dit que MaBase n'implémente pas le membre abstrait ABase::meth1() !!?
        public void meth1()
        {
            Console.WriteLine("MaBase::meth1()");
        }
    }
    */


    /*------------ SOLUTION 1 : utilisation du mot-clef override ----------------*/
    /*
    interface IBase
    {
        void meth1();
        void meth2();
    }

    abstract class ABase : IBase
    {
        public abstract void meth1(); //MAIS : Si je commente cette ligne, le compilo. dit que ABase n'implémente pas IBase !!
                                      // Ca ça me déplaît, de devoir le faire, je préfère donc la SOLUTION 2 plus bas.
        public void meth2()
        {
            Console.WriteLine("ABase::meth2()");
        }
    }

    class MaBase : ABase, IBase
    {
        public override void meth1() //<<<<<<<<<<<<<<<<<<<<<<<< OVERRIDE ! ok la compil. passe.
        {
            Console.WriteLine("MaBase::meth1()");
        }
    }
    */

    
   /*------------>> SOLUTION 2 (ma préférée) :  Interface Segregation <<----------------*/
    
    interface IBase1
    {
        void meth1();
    }

    interface IBase2
    {
        void meth2();
    }

    interface IBase : IBase1, IBase2 { }


    abstract class ABase : IBase2 //N'IMPLEMENTE  en effet  QUE IBase2, ok.
    {
        public void meth2() {
            Console.WriteLine("ABase::meth2()");
        }
    }


    //class MaBase : ABase, IBase1, IBase2 // OU BIEN :
    class MaBase : ABase, IBase  //Implémente bien IBase1 et,    IBase2(par héritage).
    {
        public void meth1()
        {
            Console.WriteLine("MaBase::meth1()");
        }
    }
    

    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            IBase oObj = new MaBase();

            oObj.meth1();
            oObj.meth2();

            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
