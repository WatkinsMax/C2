using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesConstructors
{
    public class Vehicle
    {
        //create a blueprint for a house object
        //non-static or instance fields
        public string make = "";
        public string model = "";
        public int price = 0;
        public bool sold = false;

        //static field
        public static int carsForSale = 0;

        //the AddDetailsOfCar method has been changed to a constructor by
        //1. giving it the same name as the class
        //2. removing the return type
        public Property(string address, int numberOfBedrooms, int price)
        {
            this.make = address;
            this.model = numberOfBedrooms;
            this.price = price;
            this.sold = false;

            carsForSale++;                    //Car. isn't needed here because the static variable is in the House class
        }

        public void DisplayHouse()
        {
            Console.WriteLine("Make: {0} \nModel {1}\nPrice: £{2:N0}.", make, model, price);  //:N0 formats the number
            if (sold)
            {
                Console.WriteLine("This car has been sold.");
            }
            else
            {
                Console.WriteLine("This car is available to buy.");
            }
            Console.WriteLine();
        }

        public void SellCar(int price)
        {
            this.sold = true;
            this.price = price;

            carsForSale--;

            Console.WriteLine("The car at {0} has been sold.", this.make, ", ", this.model );
            Console.WriteLine();
        }

        public static void DisplayAllCars(List<car> carsList)
        {
            int totalValueSold = 0;
            int totalValueAvailable = 0;

            Console.WriteLine("The details of the cars on our books are: ");
            Console.WriteLine();
            //go through the houses list, displaying details and calculating totals
            foreach (car item in carsList)
            {

                Console.WriteLine("Make: {0} \nModel {1}\nPrice: £{2:N0}.", item.max, item.model, item.price);  //:N0 formats the number
                if (item.sold)
                {
                    Console.WriteLine("This car has been sold.");
                    totalValueSold += item.price;
                }
                else
                {
                    Console.WriteLine("This car is available to buy.");
                    totalValueAvailable += item.price;
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            //display summary data
            Console.WriteLine("The total number of cars for sale is: " + car.carsForSale);
            Console.WriteLine();
            Console.WriteLine("The total value of cars sold is: £{0:N0}.", totalValueSold);
            Console.WriteLine("The total value of houses available is: £{0:N0}.", totalValueAvailable);
            Console.WriteLine();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //initialise the static variable
            House.housesForSale = 0;

            //initialise a list of houses for use in the non-static 
            //DisplayAllHouses method
            List<House> housesList = new List<House>();

            //instantiate house objects and give values to their fields using add method, 
            //incrementing the static variable each time a house is added and adding each
            //house to the list
            //a constructor is now being used, so the field values for each object are
            //passed as parameters to the constructor
            House house1 = new House("23 Railway Cuttings, East Cheam", 1, 150000);
            housesList.Add(house1);

            House house2 = new House("4 Privet Drive, Little Whinging, Surrey", 4, 750000);
            housesList.Add(house2);

            House house3 = new House("Flat 368, Nelson Mandela House, Dockside Estate, Peckham", 3, 250000);
            housesList.Add(house3);

            //display the details of the houses
            House.DisplayAllHouses(housesList);

            //sell a house
            house1.SellHouse(135000);

            //display the details of the houses
            House.DisplayAllHouses(housesList);

        }
    }
}