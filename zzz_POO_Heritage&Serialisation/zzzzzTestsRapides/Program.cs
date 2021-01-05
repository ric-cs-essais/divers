using System;
using System.Collections.Generic; 
using Newtonsoft.Json; //J'ai installé pour ça le Nugget NewonSoft.Json



namespace zzzzzTestsRapides
{

    interface IAnimal
    {
        void crier();
    }

    [Serializable]
    class Chien: IAnimal
    {
        public List<string> nomsChien = new List<string>();

        [NonSerialized] //<<<<<<<<<<<<<<<<<< Atorisé: le membre "poids" ne sea donc pas sérialisable
        public int poids = 75;

        public Chien()
        {
            this.nomsChien.Add("NomChien");
            this.nomsChien.Add("PseudoChien");
        }

        public void crier()
        {
            Console.WriteLine("Wouaff!");
        }
    }

    [Serializable] //<<<<<<<<<<<<<<<<<<
    class Chat : IAnimal
    {
        public List<string> noms = new List<string>();

        //[Serializable] //<<< Interdit : ne s'applique pas à des membres.
        public int poids;

        //[Serializable] //<<< Interdit
        // protected int taille = 120; //<<< Non sérialisable (erreur compil.),  car PAS Public !!

        public InfoSupplChat infoSuppl;  //Pour test Serialisation/Deserialisation d'un membre de type instance.


        public Chat(int poids, InfoSupplChat infoSuppl)
        {
            this.poids = poids;
            this.infoSuppl = infoSuppl;

            this.noms.Add("NomChat");
            this.noms.Add("PseudoChat");
        }

        public void crier()
        {
            Console.WriteLine("Miaou!");
        }

        public void allerALaLitiere()
        {
            Console.WriteLine("Je pèse "+this.poids+"Kg et je vais à la litière");
        }

        public InfoSupplChat getInfoSuppl()
        {
            return (infoSuppl);
        }



    }

    class InfoSupplChat
    {
        private string _infoSpecial1;

        public string infoSpecial1
        {
            set {
                this._infoSpecial1 = value;
            }
            get
            {
                return(this._infoSpecial1);
            }
        }

        public string infoSpecial2 = "Info. speciale 2";
        
    }



    //------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            Chien monChien = new Chien();
            InfoSupplChat infoSupplChat1 = new InfoSupplChat();
            infoSupplChat1.infoSpecial1 = "Chat1 gentil!!";
            InfoSupplChat infoSupplChat2 = new InfoSupplChat();
            infoSupplChat2.infoSpecial1 = "Chat2 pas sympa!!";
            Chat monChat1 = new Chat(12, infoSupplChat1);
            Chat monChat2 = new Chat(14, infoSupplChat2);

            List<IAnimal> animaux = new List<IAnimal>() { monChien, monChat1 };
            animaux.Add(monChat2);

            //SERIALISATION
            string animauxToString = JsonConvert.SerializeObject(animaux); //J'ai installé pour ça le Nugget NewonSoft.Json
            Console.WriteLine("List<IAnimal> sérialisée: \n\n"+animauxToString); //OK
            Console.ReadKey();


            //DESERIALISATION : ci-dessous, CAST IMPOSSIBLE de la caîne sérialisée, en List<IAnimal>, car IAnimal étant un type abstrait
            //                  il ne peut être instancié !!!   
            //List<IAnimal> animaux2 = JsonConvert.DeserializeObject<List<IAnimal>>(animauxToString); //J'ai installé pour ça le Nugget NewonSoft.Json

            List<Chat> chats = new List<Chat>() { monChat1, monChat2 };
            string chatsToString = JsonConvert.SerializeObject(chats); //J'ai installé pour ça le Nugget NewonSoft.Json
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("List<Chat> sérialisée: \n\n" + chatsToString + "\n\n\n"); //OK

            Console.WriteLine("LECTURE List<Chat> Désérialisée :\n\n");
            List <Chat> chats2 = JsonConvert.DeserializeObject<List<Chat>>(chatsToString); //J'ai installé pour ça le Nugget NewonSoft.Json
            foreach(Chat chat in chats2) {
                Console.WriteLine(chat.poids);
                chat.crier();
                chat.allerALaLitiere();
                Console.WriteLine("chat.getInfoSuppl().infoSpecial1: "+chat.getInfoSuppl().infoSpecial1);
                Console.WriteLine("chat.getInfoSuppl().infoSpecial2: " + chat.getInfoSuppl().infoSpecial2);
                Console.WriteLine("\n\n");
            };

            Console.WriteLine("OK");
            Console.ReadKey();
        }


    }
}
