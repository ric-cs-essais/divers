using System;

using System.Collections.Generic; //Pour classe : List


using MyVehicles; //Pour la classe : Car

using MyVehiclesLib; //Pour l'interface : IVehicle.  RAPPEL : cet espace de nom, MyVehiclesLib, est accessible, car
                     //mon projet MY_LIB_PROJECT est mentionné dans les Références de mon présent projet (MY_APPLI1_PROJECT).


/*
 * RAPPEL :
 *    Une Solution peut contenir plusieurs Projets (ici j'en ai créé 2) : 
 *      - un de type "Console App", que j'ai nommé MY_APPLI1_PROJECT,
 *      - et l'autre de type "Bibliothèque .NET Framework", que j'ai nommé MY_LIB_PROJECT,
 *         et que j'ai ajouté aux Références du Projet MY_APPLI1_PROJECT, afin de pouvoir depuis ce dernier, 
 *         en importer les espaces de noms (ici par exemple : MyVehiclesLib), ainsi je peux invoquer les éléments 
 *         public (exportés) de ces espaces de noms importés.
 *         
 *    . REMARQUE 1 : dans les propriétés de ma Solution, MY_APPLI1_PROJECT est défini comme Projet de démarrage.     
 *    
 *    . REMARQUE 2 : pour changer le nom de l'EXE généré, aller dans les propriétés du Projet de démarrage,
 *                   et modifier (onglet Application), on peut également y modifier le nom de l'espace de nom par défaut.
 *                   Et c'est Exactement, la même manip., pour les propriétés de mon projet MY_LIB_PROJECT. <<<<
 *
 *    . REMARQUE 3 : la "compil." de Solution , crée non seulement l'exe du Projet de démarrage, mais aussi
 *                   une .dll (autonome ici) : MyLibVehicles.dll ! Donc réutilisable !!
 *                   (générée dans bin/debug(ou bin/Release) de MY_LIB_PROJECT ainsi 
  *                   que bin/debug(ou bin/Release), de ses projets dépendants).
 *                   
 *    . REMARQUE 4 : à l'avenir, lors de la création d'un Projet de type "Bibliothèque", ne pas ajouter de sous-chemin
 *                   au chemin physique de création proposé,  (ici j'avais ajouté le sous-chemin MY_LIB/, 
 *                   du coup il m'a créé mon Projet dans MY_LIB/ , donc au final je me retrouve avec ma lib. dans
 *                   MY_LIB/MY_LIB_PROJECT/    au lieu de     MY_LIB_PROJECT/  , pas joli !)
 */

namespace MyAppli1
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle oMyCar = new Car();
            IVehicle oMyMoto = new Moto();

            List<IVehicle> oVehiclesList = new List<IVehicle>();
            oVehiclesList.Add(oMyCar);
            oVehiclesList.Add(oMyMoto);

            foreach(IVehicle oVehicle in oVehiclesList) {
                oVehicle.run();
            }


            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
