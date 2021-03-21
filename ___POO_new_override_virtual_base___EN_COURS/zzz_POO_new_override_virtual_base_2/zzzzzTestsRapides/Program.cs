using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{

    public interface IAnimal {
        void merge(IAnimal poAnimal); //Je vais la surcharger
        //
        int getPoids();
        IAnimal setPoids(int piPoids);
        void setAnneeNaiss(int piAnneeNaiss);
        int getAnneeNaiss();
        //
        IAnimal addComment(String psComment);
        List<string> getComments();
        //
        List<string> getDataAsListOfString();
        string toString();
        void showData();
   }
    public interface IChien: IAnimal {
        IChien merge(IChien poChien); //SURCHARGE (signature différente)
        //
        new IChien setPoids(int piPoids); //new car on veut masquer la signature parente pour cette méthode, 
                                          //qui ici diffère par son type de retour: IChien au lieu de IAnimal
        //
        new IChien addComment(string psComment); //new car on veut masquer la signature parente pour cette méthode, 
                                                 //qui ici diffère par son type de retour: IChien au lieu de IAnimal.
        //
        IChien addPrenom(string psPrenom);
        List<string> getPrenoms();
    }

    public abstract class AAnimal: IAnimal { //Je mets qu'elle implémente IAnimal JUSTE parce-que sinon mes return(this) sont incompatibles dans mes méthodes de AAnimal renvoyant un IAnimal !
        int _iPoids;
        int _iAnneeNais;
        List<string> _aComments;

        public AAnimal(int piAnneeNaiss)
        {
            this._aComments = new List<string>();
            this._iAnneeNais = piAnneeNaiss;
        }
        
        public IAnimal setPoids(int piPoids) { this._iPoids = piPoids; return (this);  }
        public int getPoids() { return (this._iPoids); }

        public void setAnneeNaiss(int piAnneeNaiss) { this._iAnneeNais = piAnneeNaiss; }
        public int getAnneeNaiss() { return (this._iAnneeNais); }

        public IAnimal addComment(string psComment) { this._aComments.Add(psComment); return (this);  }
        public List<string> getComments() { return (this._aComments); }

        public void merge(IAnimal poAnimal)
        {
            this.setPoids(poAnimal.getPoids());
            this.setAnneeNaiss(poAnimal.getAnneeNaiss());

            List<string> aComments = poAnimal.getComments();
            foreach (string sComment in aComments)
            {
                this.addComment(sComment);
            }
        }

        public virtual List<string> getDataAsListOfString()
        {
            List<string> aData = new List<string>();
            aData.Add("Poids: " + this.getPoids());
            aData.Add("Année naissance: " + this.getAnneeNaiss());
            aData.Add( "Comments: " + String.Join(", ", this.getComments().ToArray()) );
            return (aData);
        }

        public string toString()
        {
           string sString = String.Join("\n", this.getDataAsListOfString().ToArray());
            return (sString);
        }

        public void showData()
        {
            Console.WriteLine(this.toString());
        }

    }

    class Chien: AAnimal, IChien {
        List<string> _aPrenoms;

        public Chien(int piAnneeNaiss, string psPrenom1): base(piAnneeNaiss)
        {
            this._aPrenoms = new List<string>();
            this.addPrenom(psPrenom1);
        }

        //ICI on SURCHARGE merge (et non : redéfinit), car la méthode parente merge, n'a PAS la même signature ! <<<<<<<<
        public IChien merge(IChien poChien)
        {
            base.merge(poChien); //<<<<<<<<<<<<<<<<<<<<<<< appel méthode parente, pour la partie commune (IAnimal)

            //Pour la partie spécifique à un IChien
            List<string> aPrenoms = poChien.getPrenoms();
            foreach (string sPrenom in aPrenoms)
            {
                this.addPrenom(sPrenom);
            }
            return (this);
        }

        public IChien addPrenom(string psPrenom) { this._aPrenoms.Add(psPrenom); return (this); }
        public List<string> getPrenoms() { return (this._aPrenoms); }

        public override List<string> getDataAsListOfString()
        {
            List<string> aData = base.getDataAsListOfString();
            aData.Add("Prenoms: " + String.Join(", ", this.getPrenoms().ToArray()) );
            aData.Add(""); aData.Add(""); aData.Add("");
            return (aData);
        }

        public new IChien setPoids(int piPoids) //REFDEF. pour avoir un type de retour différent, plus précis.
        {
            base.setPoids(piPoids);
            return (this); //IChien et NON juste IAnimal !
        }
        public new IChien addComment(string psComment) //REFDEF. pour avoir un type de retour différent, plus précis
        {
            base.addComment(psComment);
            return (this); //IChien et NON juste IAnimal !
        }
    }


    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            IChien oChien1 = new Chien(1980, "Polo");
            oChien1.addPrenom("Polux").addComment("Un bon chienchien ce Polo/Polux").setPoids(30);

            IChien oChien2 = new Chien(1975, "Frigo");
            //oChien2.addPrenom("Frigolux").setPoids(60).addComment("Un peu frileux ce Frigololux!"); //OK
            //  La ligne CI-DESSOUS est acceptée CAR :
            // J'ai redéfini dans Chien, la méthode setPoids pour stipuler qu'elle retourne bien un IChien et NON plus un IAnimal !
            // Ainsi ce sera bien la méthode addComment de IChien et non IAnimal qui sera appelée, laquelle redéfinie, renvoie bien un IChien
            // et non pas un IAnimal ! ce qui permet enfin, d'avoir l'appel à addPrenom autorisé ! Car un IAnimal n'a pas 
            //de méthode addPrenom, mais un IChien si !
            oChien2.setPoids(60).addComment("Un peu frileux ce Frigololux!").addPrenom("Frigolux"); //Interdit puisque addComment ne renvoie pas un IChien mais un IAnimal.


            oChien1.showData(); //overridée simplement (même signature) (mais la parente doit être virtual).

            oChien2.merge(oChien1).addPrenom("Biloute"); //<<<<<<<<< Appel à merge de IChien ! car je l'ai surchargée !
            oChien2.showData(); //overridée simplement (même signature) (mais la parente doit être virtual).


            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
