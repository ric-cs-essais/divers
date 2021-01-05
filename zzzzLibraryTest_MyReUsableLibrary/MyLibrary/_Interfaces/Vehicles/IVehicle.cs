using System;

namespace MyLibrary.Interfaces.Vehicles
{
    public interface IVehicle //public : équivaut à un export de cette interface, lui permettant donc d'être importable.
    {
        void run();
        String getLabel();
    }
}
