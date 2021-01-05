﻿using System;

using MyLibrary.Interfaces.Vehicles; //Cet espace de nom est défini dans la librairie ddl, que j'ai ajoutée 
                                     // dans les Dépendances du présent projet.
                                     // Cet espace de nom contient la définition de l'interface : IVehicle,
                                     // dont j'ai besoin ici.


namespace MyConsoleAppli1_UsingMyLibrary.Concretes.Vehicles
{
    class Car : IVehicle
    {
        public string getLabel()
        {
            return ("une Porsche");
        }

        public void run()
        {
            Console.WriteLine("Je suis " + this.getLabel() + ", et je démarre.");
        }
    }
}





