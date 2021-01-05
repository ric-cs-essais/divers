using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{
    interface Ixx
    {
    }

    class mm
    {
        private int toto;
        private void ff() { }
        private void ff2() { }
    }

    class ee : mm   //Passage de membre private à protected.
    {
      protected int toto; //Accepté
      protected void ff() { }  //Accepté
      private void ff2(Ixx p) { }  //Accepté
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
