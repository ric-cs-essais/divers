using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{
    public interface IAnimal
    {

    }

    public interface IChien : IAnimal
    {
        Int32 obtenirId();
        string obtenirNom();
    }

    public interface ICaillou
    {
        Int32 obtenirIdentifDuCaillou();
    }



    public class Chien: IChien
    {
        private Int32 id;
        private string nom;

        public Chien(Int32 id, string nom="")
        {
            this.id = id;
            this.nom = nom;
        }

        public Int32 obtenirId()
        {
            return (this.id);
        }

        public string obtenirNom()
        {
            return (this.nom);
        }
    }

    public class Caillou : ICaillou
    {
        private Int32 identif;

        public Caillou(Int32 identif)
        {
            this.identif = identif;
        }

        public Int32 obtenirIdentifDuCaillou()
        {
            return (this.identif);
        }
    }

    // ----------

    public abstract class Liste<T> where T: IAnimal
    {
        protected T[] liste;

        protected Liste(T[] liste)
        {
            this.liste = liste;
        }

        public T obtenir(Int32 index)
        //public virtual T obtenir(Int32 index) //Pour essai
        {
            return (this.obtenirParIndex(index));
        }

        public T obtenirParIndex(Int32 index)
        {
            return (this.liste[index]);
        }

        public string rappelSurOperatorNewDansSignature(Int64 param) //NON virtual exprès.
        {
            return ("");
        }

        public virtual string rappelSurOverrideDansSignature(Int64 param) //Méthode virtual (donc Overridable)
        {                                                                

            return ("");
        }

        public string rappelSurSurcharge(Int64 param) //NON virtual exprès.
        {
            return ("surch");
        }

    }

    public class ListeChiens : Liste<IChien>
    {
        public ListeChiens(IChien[] liste): base(liste)
        {
            
        }

        public new IChien obtenirParIndex(Int32 index) //Juste pour montrer que  :
        {                                              //L'operator new est obligatoire en pareil cas, car seul le type de retour diffère
                                                       //de celui de la classe parente (même si IChien est de type IAnimal).

            return (base.obtenirParIndex(index)); //Inutile de caster en IChien ('as IChien'), car le type de retour est bien IChien et 
                                                  //le type générique (T) est bien IChien ici (bien qu'il ne semble même pas le vérifier!)
        }

        public new ICaillou obtenir(Int32 index) //L'operator new est obligatoire en pareil cas, car seul le type de retour diffère
        {                                        //de celui de la classe parente.
                                                 // BIZARREMENT le type de retour (ICaillou) est accepté alors qu'il ne respecte pas 
                                                 // la contrainte:  T de type IAnimal (ICaillou ne dérivant PAS de IAnimal !!!)
            return (new Caillou(index));
        }

        public IChien obtenir(IChien chienCherche) //SURCHARGE, pas de souci (params différents)
        {
            //Sur un [], la méthode First retournera le premier élément matchant le prédicat.
            IChien chienTrouveParId = this.liste.First<IChien>( (IChien chien) => chien.obtenirId() == chienCherche.obtenirId());
            return (chienTrouveParId); //Inutile de caster en IChien ('as IChien'), car le type de retour est bien IChien.
        }

        //-----

        //public override IChien obtenir(Int32 index) //<<< Syntaxe et redéf. ok, dans le cas ou la méthode parente aurait été virtual !
       /* public new IChien obtenir(Int32 index) //<< L'operator new est obligatoire en pareil cas, car on vient masquer la méthode parente
        {                                      //(c-à-d :IChien obtenir(Int32),  qui est non virtual).
            return (base.obtenirParIndex(2*index)); //Non fonctionnel bien sûr, mais juste dans l'idée de ré-implémenter différemment
        }
       */

        public new string rappelSurOperatorNewDansSignature(Int64 param) //L'operator new est obligatoire car la méthode parente 
        {                                                                //a les même params, et est NON virtual, ni abstract.
                                                                         
            return ("yy");
        }

        public override string rappelSurOverrideDansSignature(Int64 param) //La méthode parente est Virtual, donc overridable (même sigature exactement).
        {                                                                  

            return ("zz");
        }

        public string rappelSurSurcharge(Int64 param, Int32 zz) //Simple surcharge (même nom mais params différents)
        {                                                       //Pas besoin qu'elle soit virtual, ni d'operator new, car 
                                                                //pas même params que la méthode parente.
                                                                //Donc les 2 méthodes cohabitent, le compilo. saura faie la différence.
            return ("surch");
        }


    }


    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            IChien chien10 = new Chien(10, "Titus");
            IChien chien10Bis = new Chien(10, "Sosie de Titus");
            IChien chien20 = new Chien(20, "Chien20!");
            IChien chien30 = new Chien(30);
            IChien chien40 = new Chien(40);

            
            IChien[] chiens = new IChien[] { chien20, chien30, chien10, chien10Bis, chien40 }; //Tableau de IChien.
            ListeChiens listeChiens = new ListeChiens(chiens);

            Console.WriteLine(listeChiens.obtenir(chien10Bis).obtenirNom()); //Recherche par id (Résultat: chien10 (premier matchant l'id chien10Bis.id))

            Console.WriteLine(listeChiens.obtenirParIndex(3).obtenirNom()); //Recherche par index (Résultat: chien10Bis)

            //Console.WriteLine(listeChiens.obtenir(2).obtenirNom()); //NON ! interdit car la méthode parente est masquée par celle enfant (qui renvoie un ICaillou).


            Console.WriteLine(listeChiens.obtenir(1000).obtenirIdentifDuCaillou()); //1000
             //La ligne juste ci-dessus fonctionne!!? Bizarrement donc, car comme je disais :
             //  bien que ICaillou ne descende pas de IAnimal (contrainte posée dans Liste<T> where T: IAnimal)
             // La méthode    new ICaillou obtenir(Int32)  ré-implémentée dans ListeChiens est acceptée !!!!
             // alors que dans la parente Liste<T> elle a pour signature : T Obtenir(Int32), 
             //   avec donc T dérivant normalement de IAnimal !!
             // A NOTER que cette ré-implémentation de obtenir(Int32), MASQUE celle parente, du fait du 'new' dans la signature
             //  (new obligatoire car seul le type de retour différe de celui parent, pour cette méthode).

            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
