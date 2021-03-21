using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{
    interface IMyInterface
    {
        void method1();
    }

    class MyClass1 // : IMyInterface
    {
        public void method1()
        {

        }
    }

    class MyClass2 : MyClass1, IMyInterface
    {

    }

    //--------------------------------------------------

    abstract class AMyClass
    {
       abstract protected void method2();
    }

    class MyClass: AMyClass
    {
        public override void method2()
        {

        }
    }


    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
      
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
