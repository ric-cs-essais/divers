using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{
    interface IAnimal
    {
        string infoType { set; get; }

        void avancer();
    }

    abstract class AAnimal
    {
        private string _infoType;

        protected AAnimal(string infoType)
        {
            this.infoType = infoType;
        }

        public string infoType
        {
            set
            {
                this._infoType = value;
            }
            get
            {
                return (this._infoType);
            }
        }
    }

    class Cheval : AAnimal, IAnimal
    {
        public static string INFO_TYPE = "CHV";
        public Cheval(): base(Cheval.INFO_TYPE)
        {
            
        }

        public void avancer()
        {
            Console.WriteLine("Je suis un cheval, et je trotte à présent.");
        }

        public void hennir()
        {
            Console.WriteLine("Je suis un cheval, et j'hennis à présent.");
        }
    }

    class Mouton : AAnimal, IAnimal
    {
        public static string INFO_TYPE = "MTN";
        public Mouton() : base(Mouton.INFO_TYPE)
        {

        }

        public void avancer()
        {
            Console.WriteLine("Je suis un mouton, et j'avance broutant à présent.");
        }

        public void beler()
        {
            Console.WriteLine("Je suis un mouton, et je bêle à présent.");
        }
    }

    interface IAnimalFactory
    {
        IAnimal create();
    }

    class ChevalFactory: IAnimalFactory
    {
        public IAnimal create()
        {
            return (new Cheval());
        }
    }

    class MoutonFactory : IAnimalFactory
    {
        public IAnimal create()
        {
            return (new Mouton());
        }
    }

    //==============================================================

    class Test
    {
        public void run()
        {
            IAnimalFactory oAnimalFactory1 = this._getAnimalFactory1();
            IAnimal oAnimal1 = oAnimalFactory1.create(); //create() renvoie un IAnimal !!!
            oAnimal1.avancer(); //OK, tout IAnimal possède et implémente cette méthode.
            ((Mouton)oAnimal1).beler(); //CAST obligatoire, même si je suis sûr que ce qui est retourné est un type Mouton
            //((Cheval)oAnimal1).hennir(); //INTERDIT : plante à l'exécution : convsersion impossible !

            Mouton oAnimal1b = (Mouton)oAnimalFactory1.create(); //CAST obligatoire ! car  create() renvoie un IAnimal !!!
            oAnimal1b.beler(); 

            //---------------

            IAnimalFactory oAnimalFactory2 = this._getAnimalFactory2(); //OK, tout IAnimal possède et implémente cette méthode.
            IAnimal oAnimal2 = oAnimalFactory2.create(); //create() renvoie un IAnimal !!!
            oAnimal2.avancer();
            ((Cheval)oAnimal2).hennir(); //CAST obligatoire, même si je suis sûr que ce qui est retourné est un type Cheval
            //((Mouton)oAnimal2).beler(); //INTERDIT : plante à l'exécution : convsersion impossible !

            Cheval oAnimal2b = (Cheval)oAnimalFactory2.create(); //CAST obligatoire ! car  create() renvoie un IAnimal !!!
            oAnimal2b.hennir();

            Console.WriteLine("\n\n*******************\n\n");
            this.faireCrierAnimal(oAnimal1); //Mouton
            this.faireCrierAnimal(oAnimal2); //Cheval

        }

        private void faireCrierAnimal(IAnimal animal)
        {
            if (animal.infoType == Cheval.INFO_TYPE)
            {
                ((Cheval)animal).hennir();
                //((Mouton)animal).beler(); //PLANTERA à l'éxecution

            } else if (animal.infoType == Mouton.INFO_TYPE) {

                ((Mouton)animal).beler();
                //((Cheval)animal).hennir(); //PLANTERA à l'éxecution

            }
        }

        private IAnimalFactory _getAnimalFactory1()
        {
            return (new MoutonFactory());
        }
        private IAnimalFactory _getAnimalFactory2()
        {
            return (new ChevalFactory());
        }
    }


    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            (new Test()).run();
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
