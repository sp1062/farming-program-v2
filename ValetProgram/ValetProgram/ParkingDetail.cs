using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//SID 1336286

namespace ValetProgram
{
    //This class stores details of the users name and licence plate and where the driver is meant to be parked.
    class ParkingDetail
    {
        string name; //Name of the driver
        string licencePlate; //Number plate of the drivers car
        int parkingIndex; //Parking index will be the parking space the car is in

        //Constructor which will initialize the variables.
        public ParkingDetail(string name, string licencePlate, int parkingIndex)
        {
            this.name = name; //variable name (drivers name) is initialized
            this.licencePlate = licencePlate; //variable licensePlate (drivers car plate) is initialized
            this.parkingIndex = parkingIndex; //The parking space of the car is set
        }

        //Getter for name
        public string getName()
        {
            return name;
        }

        //Getter for license plate
        public string getLicensePlate()
        {
            return licencePlate;
        }

        //Gets parking space
        public int getParkingSpace()
        {
            return parkingIndex;
        }

        //Sets parking space
        public void setParkingSpace(int parkingIndex)
        {
            this.parkingIndex = parkingIndex;
        }
    }
}
