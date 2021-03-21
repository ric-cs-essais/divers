using System;

using MesVehicules;

using MyVehiclesLib; //Pour l'interface : IVehicle.  RAPPEL : cet espace de nom, MyVehiclesLib, est accessible, car
                     //ma DLL, MyVehiclesLib.dll est mentionnée dans les Dépendances de mon présent projet.
                     //Cette DLL (générée depuis un autre projet VStudio (en tant que "Bibliothèque")),
                     //comporte l'espace de nom MyVehiclesLib, qu'on importe ici, et qui comporte à son tour, 
                     //une interface exportée (public), qu'on va donc pouvoir ici utiliser (IVehicle).
                     // Remarque : évidemment, le nom de la DLL, est totalement indépendant des espaces de noms
                     //            qu'elle comporte (même si là j'ai nommé ma DLL à l'identique).

    
    /*--- PAR CONTRE : IL FAUT FAIRE CTRL+F5, et NON F5, POUR LANCER LA COURANTE APPLI la 1ère fois !!!! ?? ---*/
    /* Je suppose que c'est pcq je n'ai pas les infos de debuggage dans ma DLL mise en dépendances du présent Projet ?? 
     */


namespace MyAppli2_Prj_UseMyDLL
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle oMyPlane = new Avion();
            oMyPlane.run();

            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
