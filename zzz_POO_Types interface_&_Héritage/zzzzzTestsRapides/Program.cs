using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{



    class B
    {
        public B(I0 poAsI0)
        {
            poAsI0.meth00("From B");
        }
    }

    class C
    {
        public C(I1 poAsI1)
        {
            poAsI1.meth11("From C");
        }
    }



    interface I0
    {
        void meth00(string ps);
    }

    interface I1
    {
        void meth11(string ps);
    }

    abstract class AParent: I0, I1
    {

        public void meth0(string ps)
        {
            Console.WriteLine("meth0 called " + ps);
            B oB = new B(this);
        }
        public void meth00(string ps)
        {
            Console.WriteLine("meth00 called " + ps);
            Console.WriteLine("\n\n");
        }

        public void meth1(string ps)
        {
            Console.WriteLine("meth1 called " + ps);
            C oC = new C(this);
        }
        public virtual void meth11(string ps)
        {
            Console.WriteLine("meth11 called " + ps);
            Console.WriteLine("\n\n");
        }

    }


    class Child : AParent
    {
        public override void meth11(string ps)
        {
            Console.WriteLine("meth11(de Child) called " + ps);
            Console.WriteLine("\n\n");
            B oB = new B(this); //Child est bien vue comme implémentant I0 (et I1 également d'ailleurs)
                                //car son parent implémente explicitement I0 (et I1).
        }
    }






    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            Child oChild = new Child();
            oChild.meth0("From main");
            oChild.meth1("From main");

            Console.WriteLine("YO");

            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
