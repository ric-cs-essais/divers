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
        public virtual void methode()
        {
            Console.WriteLine("methode from Mere\n");
        }
    }

    class Enfant : Mere , IEnfant
    {
        public override void methode()
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
    private IMere _oMere; //{IMere}
    public Client0(IMere poMere) //<<<< Param. de type plus général que le constructeur de la classe enfant Client0
    {
        this._oMere = poMere;
        Console.WriteLine("\n\n-------- Dans constructeur de Client0 --------\n");
        this._oMere.methode(); //Pourquoi ????? est-ce methode() de IEnfant qui est appelée !?? Lorsque poMere reçu est de type réel IEnfant !??
        this._getMere().methode(); //Même question !!!!! puisqu'à ce stade this._oEnfant dans Client1 n'est même pas encore défini !!!????
        //this._oMere.methodeEnfant(); //INTERDIT bien sûr !! ok
        Console.WriteLine("n-------- FIN constructeur de Client0 !--------\n\n\n");
    }
    //@return {IMere} 
    protected virtual IMere _getMere()
    {
        return (this._oMere);
    }
    public void show()
    {
        this._getMere().methode(); //En fonction que this._getMere() retourne un type IEnfant ou juste IMere, 
                                   //la méthode methode() appelée ne sera ici, pas la même.
    }

}


class Client1 : Client0
{
    private IEnfant _oEnfant; //{IEnfant}
    public Client1(IEnfant poEnfant): base(poEnfant)  //<<<< Param. de type plus spécifique que le constructeur de la classe parente Client1
    {
        this._oEnfant = poEnfant;
    }

    
    //@return {IEnfant}
    //protected override IEnfant _getMere() //<<<<<< NON autorisé car pour pouvoir utiliser override, 
                                          //la signature Complète (type de retour compris donc), doit être la même
                                          //que celle de la classe parente !!
    protected new IEnfant _getMere() //La signature au niveau des PARAMETRES étant la même que la méthode parente 
                                     //MAIS PAS le type de retour: on ne peut utiliser le mot-clef override, alors j'utilise le mot-clef new.
    {
        return(this._oEnfant);
    }

    /*protected override IMere _getMere() //La signature au niveau des PARAMETRES étant la même que la méthode parente ainsi que le type de retour
                                          //on peut dans ce cas, utiliser le mot-clef override !!
    {
        return ((IMere)this._oEnfant);
    }*/

    protected IMere _getMere(int a) //<<<<SIMPLE SURCHARGE car pas la même signature que la parente AU NIVEAU DES PARAMETRES
    {                              
       return((IMere)this);
    }
    protected void _getMere(string s) //<<<<SIMPLE SURCHARGE car pas la même signature que la parente AU NIVEAU DES PARAMETRES, ni que l'autre de Client1.
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

            //c0.show();
            c1.show(); //OK appelera bien la méthode _getMere() de la classe Client1 ! Qui elle renvoie un IEnfant.

            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
