using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zzzzzTestsRapides
{   interface IReportItem
    {
        void addToReportDocument(IReportDocument poReportDocument);
    }

    interface IGraphBars
    {
        string getImageAsHTML();
        string getImageFileAsString();
    }
    interface IReportGraphBars : IGraphBars, IReportItem
    {
    }
    interface IReportComment: IReportItem
    {
        string getData();
    }

    interface IReportDocument
    {
        IReportDocument addComment(IReportComment poReportComment);
        IReportDocument addGraphBars(IReportGraphBars poGraphBars);

        void show();
    }

    //----------------------------------


    class GraphBars: IGraphBars
    {
        public string getImageAsHTML()
        {
            return ("Image du graphe au format HTML");
        }
        public string getImageFileAsString()
        {
            return ("Forme base 64 de l'image du graphe");
        }
    }

    class ReportComment: IReportComment, IReportItem
    {
        string _sData;
        public ReportComment(string psData)
        {
            this._sData = psData;
        }
        public void addToReportDocument(IReportDocument poReportDocument)
        {
            poReportDocument.addComment(this);

        }
        public string getData()
        {
            return(this._sData);
        }
    }

    class ReportGrapHBars : GraphBars, IReportGraphBars, IReportItem
    {
        public void addToReportDocument(IReportDocument poReportDocument)
        {
            poReportDocument.addGraphBars(this);

        }

    }

    //-----------------------------------

    class ReportDocumentHTML: IReportDocument
    {
        List<string> _aHTML;

        public ReportDocumentHTML()
        {
            this._aHTML = new List<string>();
        }
        public IReportDocument addComment(IReportComment poReportComment)
        {
            this._aHTML.Add("/HTMLText - "+poReportComment.getData()+ " - HTMLText/");
            return (this);
        }
        public IReportDocument addGraphBars(IReportGraphBars poGraphBars)
        {
            this._aHTML.Add("/HTMLImage - " + poGraphBars.getImageAsHTML() + " - HTMLImage/");
            return (this);
        }
        public void show()
        {
            Console.WriteLine(String.Join("\n", this._aHTML.ToArray()));
            Console.WriteLine("\n\n\n");
        }

    }

    class ReportDocumentWord : IReportDocument
    {
        List<string> _aWordData;

        public ReportDocumentWord()
        {
            this._aWordData = new List<string>();
        }
        public IReportDocument addComment(IReportComment poReportComment)
        {
            this._aWordData.Add("/WORDText - "+poReportComment.getData()+" - WORDText/");
            return (this);
        }
        public IReportDocument addGraphBars(IReportGraphBars poGraphBars)
        {
            this._aWordData.Add("/WORDImage - " + poGraphBars.getImageFileAsString() + " - WORDImage/");
            return (this);
        }
        public void show()
        {
            Console.WriteLine(String.Join("\n", this._aWordData.ToArray()));
            Console.WriteLine("\n\n\n");
        }
    }

    //--------------------------------------
    interface IReportDocumentBuilder
    {
        IReportDocumentBuilder setReportItemsList(List<IReportItem> poReportItemsList);
        void build(IReportDocument poReportDocument);
    }
    class ReportDocumentBuilder: IReportDocumentBuilder
    {
        private List<IReportItem> _oReportItemsList;

        public IReportDocumentBuilder setReportItemsList(List<IReportItem> poReportItemsList)
        {
            this._oReportItemsList = poReportItemsList;
            return (this);
        }
        public void build(IReportDocument poReportDocument)
        {
            foreach(IReportItem oReportItem in this._oReportItemsList)
            {
                oReportItem.addToReportDocument(poReportDocument);
            }
        }
    }

    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            List<IReportItem> oReportItemsList = new List<IReportItem>();
            IReportGraphBars oReportGraphBars = new ReportGrapHBars();
            IReportComment oReportComment = new ReportComment("Commentaire 1");
            oReportItemsList.Add(oReportGraphBars);
            oReportItemsList.Add(oReportComment);
            oReportItemsList.Add(new ReportComment("Commentaire 2"));
            oReportItemsList.Add(new ReportGrapHBars());

            //-------- Remplissage de Documents de nature différente à partir d'une même liste de IReportItem ---------

            IReportDocumentBuilder oReportDocumentBuilder = new ReportDocumentBuilder();
            oReportDocumentBuilder.setReportItemsList(oReportItemsList);

            IReportDocument oReportDocumentHTML = new ReportDocumentHTML();
            IReportDocument oReportDocumentWord = new ReportDocumentWord();
             
            oReportDocumentBuilder.build(oReportDocumentHTML);
            oReportDocumentBuilder.build(oReportDocumentWord);

            oReportDocumentHTML.show();
            oReportDocumentWord.show();

            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
