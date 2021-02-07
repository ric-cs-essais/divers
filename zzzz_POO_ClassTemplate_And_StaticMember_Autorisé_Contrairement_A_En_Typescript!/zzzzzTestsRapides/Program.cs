using System;
using System.Collections.Generic;
using Newtonsoft.Json; //J'ai installé pour ça le Nugget NewonSoft.Json

namespace zzzzzTestsRapides
{

    public class TestTemplateClassWithStatic<T>
    {
        public static List<T> myStaticMember; //Syntaxe acceptée

        public static void myStaticMethod(List<T> param) { //Syntaxe acceptée
            TestTemplateClassWithStatic<T>.myStaticMember = param;
        }


}

//------------------------------------------------------------------------

class Program
    {
        static void Main(string[] args)
        {
            TestTemplateClassWithStatic<int>.myStaticMethod(new List<int> {1,2,3});

            string liste = JsonConvert.SerializeObject(TestTemplateClassWithStatic<int>.myStaticMember); //J'ai installé pour ça le Nugget NewonSoft.Json
            Console.WriteLine(liste);

            Console.WriteLine("OK");
            Console.ReadKey();

        }


    }
}
