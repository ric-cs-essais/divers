using System;


using MyVehiclesLib; //Pour l'interface : IVehicle.  RAPPEL : cet espace de nom, MyVehiclesLib, est accessible, car
                     //ma DLL, MyVehiclesLib.dll est mentionnée dans les Dépendances de mon présent projet.
                     //Cette DLL (générée depuis un autre projet VStudio (en tant que "Bibliothèque")),
                     //comporte l'espace de nom MyVehiclesLib, qu'on importe ici, et qui comporte à son tour, 
                     //une interface exportée (public), qu'on va donc pouvoir ici utiliser (IVehicle).
                     // Remarque : évidemment, le nom de la DLL, est totalement indépendant des espaces de noms
                     //            qu'elle comporte (même si là j'ai nommé ma DLL à l'identique).
                     


namespace MesVehicules
{
    class Avion : IVehicle
    {
        public string getLabel()
        {
            return ("un boeing");
        }

        public void run()
        {
            Console.WriteLine("Je suis " + this.getLabel() + ", et je démarre !");
        }
    }
}
