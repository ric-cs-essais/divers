using System;


namespace MyVehiclesLib
{
    public interface IVehicle //public : équivaut à un export de cette interface
    {
        void run();
        String getLabel();
    }
}
