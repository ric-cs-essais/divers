using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{
    //--------------------------------------------------
    interface IMere
    {
        void methode();
    }
    interface IEnfant : IMere
    {
        void methodeEnfant();
    }

    //---

    class Mere : IMere
    {
        public virtual void methode() //virtual OBLIGATOIRE SI utilisation du mot-clef override, pour redéfinition de cette méthode dans une classe enfant.
        {
            Console.WriteLine("methode from Mere\n");
        }
    }

    class Enfant : Mere , IEnfant
    {
        /*
        public new void methode() //utilisation du mot-clef new possible aussi.
        {
            Console.WriteLine("methode from Enfant\n");
        }
        */
        
        public override void methode() //override possible car la méthode parente est virtual ET la signature ici RESTE TOTALEMENT la même.
        {
            Console.WriteLine("methode from Enfant\n");
        }
        
        public void methodeEnfant()
        {
            Console.WriteLine("methodeEnfant from Enfant\n");
        }
    }

    //--------------------------------------------------

class Client0
{
    public Client0(IMere poMere) //<<<< Param. de type plus général que le constructeur de la classe enfant Client0
    {
        Console.WriteLine("\n\n-------- Dans constructeur de Client0 --------\n");
        poMere.methode(); //Lorsque poMere est AUSSI de type IEnfant, alors par POLYMORPHISME (car override methode() dans classe Enfant), 
                          //c'est bien methode() de Enfant qui sera appelée (tout comme dans le cas d'un new Client0(new Enfant())
                          //REMARQUE: si dans Enfant j'avais utilisé le mot-clef new au lieu de override, eh bien le résultat aurait été le même !?
        //poMere.methodeEnfant(); //INTERDIT bien sûr !! ok
        Console.WriteLine("\n-------- FIN constructeur de Client0 !--------\n\n\n");
    }

}


class Client1 : Client0
{
    public Client1(IEnfant poEnfant): base(poEnfant)  //<<<< Param. de type plus spécifique que le constructeur de la classe parente Client1
    {
        
    }

    
 }


//------------------------------------------------------------------------

class Program
    {
        static void Main(string[] args)
        {
            IMere oMere = new Mere();
            IEnfant oEnfant = new Enfant();

            //Client0 c0 = new Client0(oMere);
            Client1 c1 = new Client1(oEnfant);

            new Client0(new Enfant()); //même comportement

            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
