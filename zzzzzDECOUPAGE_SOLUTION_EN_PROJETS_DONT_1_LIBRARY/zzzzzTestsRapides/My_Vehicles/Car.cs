using System;

using MyVehiclesLib; //Permet d'avoir accès à l'espace de nom en question (tiré du projet MY_LIB_PROJECT,
                     //que j'ai dû pralablement ajouter dans les Références de mon présent projet (MY_APPLI1_PROJECT)).

namespace MyVehicles
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
