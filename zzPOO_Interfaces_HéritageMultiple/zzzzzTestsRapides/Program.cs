using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{

    //------------------------------------------------------------------------

        interface I1
        {
            void f1(string p);
        }

        interface I2
        {
            bool f2(Int32 p);
        }

        interface I3: I1, I2  //<<<<<<<<<<<< Héritage multiple d'interfaces OK.
        {
            string f3();
        }

    public class C1
    {

    }

    public class C2
    {

    }

    // public class Test : C1, C2, I3 //<<<< Héritage multiple de classes interdit !!
    public class Test : C1, I3
    {
        public void f1(string p)
        {
            throw new NotImplementedException();
        }

        public bool f2(int p)
        {
            throw new NotImplementedException();
        }

        public string f3()
        {
            throw new NotImplementedException();
        }
    }

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
