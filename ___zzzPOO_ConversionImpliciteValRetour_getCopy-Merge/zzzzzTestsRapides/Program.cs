using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{
    public interface IInterf
    {
        String getS();
        int getI();

        IInterf merge(IInterf poInterf);

        String getAsString();

    }
    public class Mere: IInterf
    {
        private String ss = "rien";
        private int ii;

        public Mere(int pI, String pS)
        {
            this.ii = pI;
            this.ss = pS;
        }

        protected void _setI(int pI)
        {
            this.ii = pI;
        }
        public int getI()
        {
            return (this.ii);
        }

        protected void _setS(String pS)
        {
            this.ss = pS;
        }
        public string getS()
        {
            return (this.ss);
        }

        /*protected IInterf _getCopy()
        {
            IInterf oCopy = new Mere(this.getI(), this.getS());
            return (oCopy);
        }*/

        public IInterf merge(IInterf poInterf)
        {
            this._setI(poInterf.getI());
            this._setS(poInterf.getS());
            return (this);
        }
        public virtual String getAsString()
        {
            return("ii="+this.getI()+"; ss="+this.getS());
        }
    }


    public interface IEnfant: IInterf {
        void setI2(int pI2);
        int getI2();
        IEnfant getCopy();

        IInterf getAsIInterf();

        IEnfant setS(String pS);
    }
    public class Enfant: Mere, IEnfant
    {
        private int i2;
        public Enfant(int pI=0, String pS="", int pI2=0) : base(pI, pS)
        {
            this.setI2(pI2);
        }

        public void setI2(int pI2)
        {
            this.i2 = pI2;
        }
        public int getI2()
        {
            return (this.i2);
        }

        public IEnfant getCopy()
        {
            //IEnfant oCopy = this._getCopy(); //Non car _getCopy retourne juste un IInterf.
            IEnfant oCopy = new Enfant();
            oCopy.merge(this); //<<<<<<<<<<<<<<< Pour les membres en commun avec un IInterf.

            oCopy.setI2(this.getI2()); //Pour les membres spécifiques à la présente classe.

            return (oCopy);
        }

        public override String getAsString()
        {
            string sAsString = base.getAsString() + "; i2=" + this.getI2();
            return (sAsString);
        }

        public IEnfant setS(String pS)
        {
            base._setS(pS);
            return (this);
        }

        public IInterf getAsIInterf()
        {
            return (this); //La conversion sera implicite.
        }

    }
    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            IEnfant oEnfant1 = new Enfant(10, "Enfant1", 100);
            IEnfant oEnfant2 = oEnfant1.getCopy().setS("Enfant2");
            Console.WriteLine(oEnfant1.getAsString());
            Console.WriteLine(oEnfant2.getAsString());

            //
            Console.WriteLine("\n\n---------\n\n");

            //oEnfant1.getAsIInterf().setS("xx"); //Interdit évidemment car ce que renvoie getAsIInterf() est de type IInterf et NON IEnfant.


            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
