using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{
    interface III
    {
        void toto(string p2, int p1 = 10);
        void titi(int p0 = 78);
    }

    class CIII : III
    {
        public void toto(string p20="jj", int pz=999) //AUTORISÉ, OK.
        {
        }
        public void titi(int p0)  //AUTORISÉ, OK.
        {

        }
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
