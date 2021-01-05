using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{

    public interface IInterfaceVide
    {

    }

    public class Test
    {
        public void methode1(IInterfaceVide pp)
        {

        }
    }

    class Implem: IInterfaceVide
    {

    }

    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            Test oTest = new Test();

            // oTest.methode1(); //Interdit
            // oTest.methode1(10); //Interdit: conversion impossible. (Alors que c'est accepté en Typescript).
            // oTest.methode1(""); //Interdit: conversion impossible. (Alors que c'est accepté en Typescript).

            // oTest.methode1(new Test()); //Interdit: conversion impossible. (Alors que c'est accepté en Typescript).

            oTest.methode1(new Implem()); //OK car la classe Implem est bien notée comme "implémentant" IInterfaceVide.

            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
