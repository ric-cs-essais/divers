using System;

using System.Collections.Generic; //Pour classe : List


using MyConsoleAppli1_UsingMyLibrary.Concretes.Vehicles; //Pour mes classes : Car et Moto.

using MyLibrary.Interfaces.Vehicles; //Cet espace de nom est défini dans la librairie ddl, que j'ai ajoutée 
                                     // dans les Dépendances du présent projet.
                                     // Cet espace de nom contient la définition de l'interface : IVehicle,
                                     // dont j'ai besoin ici.



namespace MyConsoleAppli1_UsingMyLibrary
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

            foreach (IVehicle oVehicle in oVehiclesList)
            {
                oVehicle.run();
            }


            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}

