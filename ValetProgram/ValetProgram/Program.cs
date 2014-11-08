using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

//SID 1336286

namespace ValetProgram
{
    class Program
    {
        const int HANDLE_GUEST_ARRIVAL = 1; //Used in switch case to handle action
        const int FIND_PARKED_CAR = 2; //Used in switch case to handle action
        const int RETURN_CAR_TO_USER = 3; //Used in switch case to handle action
        const int LIST_CARS = 4; //Used in switch case to handle action
        const int EXIT_PROGRAM = 5; //Used in switch case to handle action
        const int MAX_PARKING_SPACE = 10; //Maximum parking spaces

        static ParkingDetail[] parkingList = new ParkingDetail[MAX_PARKING_SPACE]; //Array stores the parking details

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Valet Program.");

            for (; ;) //Loop to keep display menu going
                displayMenu(); //Displays menu
        }

        //This method will display menu and ask user for input
        //After user has given the input it will match the number to the action
        static void displayMenu()
        {
        WriteMenu:
            Console.WriteLine();
            Console.WriteLine("[1] Handle Guest Arrival");
            Console.WriteLine("[2] Find a parked car");
            Console.WriteLine("[3] Return car to user");
            Console.WriteLine("[4] List cars");
            Console.WriteLine("[5] Exit program");
            Console.Write("Select a number: ");

            int actionIndex; //Action index which will be used to process action as number
            bool isNumber = int.TryParse(Console.ReadLine(), out actionIndex); //Checks if input is actually a number

            if (!isNumber) //If input is not a number then go back to label WriteMenu
            {
                Console.WriteLine("Invalid input please input a number.");
                goto WriteMenu;
            }

            if (actionIndex <= 0 && actionIndex >= 6) //If input is too small or too big then go back to WriteMenu
            {
                Console.WriteLine("Action not found please try entering a number between 1-5.");
                goto WriteMenu;
            }

            Console.WriteLine();
            doAction(actionIndex); //Processes action
        }

        //Processes all actions of the program using switch statement
        static void doAction(int actionIndex)
        {
            switch (actionIndex) //actionIndex obtained from user as a integer then processed in this case
            {
                case HANDLE_GUEST_ARRIVAL: //Enter new parking details
                
                EnterGuestName: //Enter the guest name details
                    String licencePlate; //licence plate of the car
                    String name; //Drivers name
                    String confirmation; //Confirmation if employee wants to confirm save or not

                    Console.Write("Enter guest name: "); 
                    name = Console.ReadLine(); //Reads Drivers name input from employee
                    
                    if (String.IsNullOrWhiteSpace(name)) //If the name is a white space or is null or is empty then go back to label EnterGuestName
                    {
                        Console.WriteLine("Invalid name please try again.");
                        goto EnterGuestName;
                    }

                EnterLcensePlate: //Enter the licence plate details
                    Console.Write("Enter license plate: ");
                    licencePlate = Console.ReadLine(); //Reads licence plate input from employee

                    if (String.IsNullOrWhiteSpace(name)) //If the license plate is a white space or is null or is empty then go back to label EnterLcensePlate
                    {
                        Console.WriteLine("Invalid license plate please try again.");
                        goto EnterLcensePlate;
                    }

                ConfirmBooking: //Confirm booking using Y or N
                    Console.Write("Would you like to confirm the booking [Y/N]: ");
                    confirmation = Console.ReadLine().ToLower(); //Read confirmation letter (Y/N)

                    if (String.IsNullOrWhiteSpace(confirmation)) //If the confirmation letter is a white space or is null or is empty then go back to label ConfirmBooking
                    {
                        Console.WriteLine("Invalid input please try y or n.");
                        goto ConfirmBooking;
                    }

                    if (confirmation.Equals("y")) //If confirmation is yes
                    {
                        int freeSpace = getFreeSpace(); //Find the free space
                        if (freeSpace == -1) //If there is no free space then redirect to main menu
                        {
                            Console.WriteLine("Not enough space please wait for cars to leave.");
                            break;
                        }

                        ParkingDetail parkingDetail = new ParkingDetail(name, licencePlate, freeSpace); //New Parking details created using user input
                        parkingList[freeSpace] = parkingDetail; //Set parking details inside the array
                        //Write Parking details
                        Console.WriteLine("Parking details set for: " + name + ""); 
                        Console.WriteLine("Licence Plate: " + licencePlate);
                        Console.WriteLine("Parking slot: " + freeSpace);
                    }
                    else if(confirmation.Equals("n")) //If the confirmation is no then redirect to main menu
                    {
                        Console.WriteLine("Booking cancelled."); 
                    }
                    else //If the letter isn't y or n then allow user to enter the confirmation input again 
                    {
                        Console.WriteLine("Invalid input please try y or n.");
                        goto ConfirmBooking;
                    }
                    break;

                case FIND_PARKED_CAR: //Find a parked car using search
                    String searchPhrase; //The search phrase which is later read from input
                    Console.Write("Please enter a search phrase such as name or licence plate: ");
                    searchPhrase = Console.ReadLine(); //Read search phrase input from console
                    findCar(searchPhrase); //Find the car and display all search results
                    break;

                case LIST_CARS: //List all cars in pool
                    Console.WriteLine("Parking Pool: ");
                    foreach (ParkingDetail detail in parkingList) //Searches the whole parking pool array
                    {
                        if (detail == null) continue; //Some objects in the array will be null to prevent error we skip these
                        Console.WriteLine("SPACE[" + detail.getParkingSpace() + "]: Name = " + detail.getName() + " || License Plate = " + detail.getLicensePlate() + " || Car Space = " + detail.getParkingSpace()); //Print out parking space details
                    }
                    Console.WriteLine("End of parking pool.");
                    break;

                case RETURN_CAR_TO_USER: //Return car to user
                    Console.Write("Please enter a search phrase such as name or licence plate to remove: ");
                    searchPhrase = Console.ReadLine(); //The search phrase entered on the console is read

            SelectIndex: //The selection index on which car to remove
                    Dictionary<int, ParkingDetail> searchList = findCar(searchPhrase); //Dictionary of search incase of multiple search clashes

                    if (searchList.Count == 0) //If search list has no objects then redirect to main menu
                    {
                        Console.WriteLine("No cars found to remove redirecting to main menu.");
                        break;
                    }

                    Console.Write("Please select car index to remove: ");
                    int indexToRemove; //indexToRemove will be the key of the searchList which will return a ParkingDetail value to remove
                    bool isNumber = int.TryParse(Console.ReadLine(), out indexToRemove); //Checks if input is number then sets indexToRemove

                    if (!isNumber) //If indexToRemove is not a number then go back to selecting the index to remove
                    {
                        Console.WriteLine("Invalid input please input a number.");
                        goto SelectIndex;
                    }

                    ParkingDetail toRemoveDetail; //ParkingDetail to remove from the index
                    
                    //This try and catch block is to prevent errors if the index to remove is too high or too low.
                    try 
                    {
                        toRemoveDetail = searchList[indexToRemove];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid number please input a number which is listed.");
                        goto SelectIndex; //re-select index if this error occurs.
                    }

            RemoveConfirmation: //Confirm that employee wants to remove the ParkingDetail
                    Console.WriteLine();
                    Console.Write("Do you wish to remove this car [Y/N] : ");
                    confirmation = Console.ReadLine().ToLower(); //confirmation is a y or a n which is read from the console


                    if (String.IsNullOrWhiteSpace(confirmation)) //If confirmation is empty or null or white space then re-try asking for the confirmation
                    {
                        Console.WriteLine("Invalid input please try y or n.");
                        goto RemoveConfirmation;
                    }

                    if (confirmation.Equals("n")) //If confirmation is a no then go back to main menu
                    {
                        break;
                    }
                    else if (confirmation.Equals("y")) //If confirmation is a yes process removal of space
                    {
                        for (int i = 0; i < MAX_PARKING_SPACE; i++) //Loop through parking list
                        {
                            if (toRemoveDetail == parkingList[i]) //If parking list is equal to the toRemoveDetail then process removal
                            {
                                parkingList[i] = null; //Removes the parking details from the parking list
                                Console.WriteLine("Removed car from car pool sucessfully.");
                            }
                        }
                    }
                    else //If the input isn't a y or a n then ask for the remove confirmation again
                    {
                        Console.WriteLine("Invalid input please try y or n.");
                        goto RemoveConfirmation;
                    }
                    break;

                case EXIT_PROGRAM: //Close program
                    Console.WriteLine("Program closed.");
                    System.Environment.Exit(1);
                    break;
            }
        }

        //Finds car by searching valid matches of number plate or name
        //Returns a dictionary with a Integer key and a value of ParkingDetail object
        //The key will be used if any actions need to be processed such as removal 
        //A dictionary is used because there can be multiple values for search results
        static Dictionary<int, ParkingDetail> findCar(String input)
        {
            Dictionary<int, ParkingDetail> searchList = new Dictionary<int, ParkingDetail>();
            int searchIndex = 1;

            input = input.ToLower();
            foreach(ParkingDetail detail in parkingList) { //For every detail in parking list
                if (detail == null) continue; //Prevent null pointer errors
                if (detail.getName().ToLower().Contains(input) || detail.getLicensePlate().ToLower().Contains(input)) //Find matches in input (Compares input to number plate and name)
                {
                    searchList.Add(searchIndex++, detail); //Add to search list and increase search index
                }
            }

            if (searchList.Count <= 0) //If there are no search results then return a empty search list
            {
                Console.WriteLine("No search results found.");
                return searchList;
            }

            Console.WriteLine("Search Results: ");

            foreach (KeyValuePair<int, ParkingDetail> keyValuePair in searchList) //If search results are found display Details of the parking and key value of searchIndex
            {
                Console.WriteLine("[" + keyValuePair.Key + "]: Name = " + keyValuePair.Value.getName() + " || License Plate = " + keyValuePair.Value.getLicensePlate() + " || Car Space = " + keyValuePair.Value.getParkingSpace());
            }
            return searchList; //Return search list with items inside
        }

        //Obtains a parking space if there is no free parking space then return -1
        static int getFreeSpace() 
        {
            for (int i = 0; i < MAX_PARKING_SPACE; i++) //Iterates through all parking spots
            {
                if (parkingList[i] == null) //If parking spot is null then the spot is free hence a car can take the spot
                {
                    return i;
                }
            }
            return -1; //Parking space is not free
        }

    }
}
