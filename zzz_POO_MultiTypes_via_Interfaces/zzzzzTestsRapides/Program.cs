using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{
    interface IDocument
    {
        void show();
    }

    interface IHTMLDocument: IDocument
    {
        string getHeader();
    }

    abstract class ADocument
    {
        public void show()
        {
            Console.WriteLine("Showing");
        }

    }

    class HTMLDocument: ADocument, IHTMLDocument
    {
        public string getHeader()
        {
            return ("xxx");
        }
    }

    interface IDocumentsFactory
    {
        IHTMLDocument getDocumentAsHTMLDocument();
        IDocument getDocument();
    }

    class DocumentsFactory: IDocumentsFactory
    {
        public IHTMLDocument getDocumentAsHTMLDocument()
        {
            return (new HTMLDocument());
        }
        public IDocument getDocument()
        {
            return (this.getDocumentAsHTMLDocument());
        }
    }

    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            IDocumentsFactory oDocumentsFactory = new DocumentsFactory();

            oDocumentsFactory.getDocument().show();
            //oDocumentsFactory.getDocument().getHeader(); //INTERDIT BIEN SÛR car getDocument(), vu comme renvoyant le type IDocument et NON IHTMLDocument
            Console.WriteLine( oDocumentsFactory.getDocumentAsHTMLDocument().getHeader() ); //Autorisé bien sûr !


            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
