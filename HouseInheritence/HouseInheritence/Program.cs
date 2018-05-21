using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSalesInheritance
{
    public class Property
    {
        //create a blueprint for a property object
        //non-static or instance fields
        public string address = "";
        public int numberOfBedrooms = 0;

        public int price = 0;
        public bool sold = false;

        //static field
        public static int propertiesForSale = 0;

        //the AddDetailsOfHouse method has been changed to a constructor by
        //1. giving it the same name as the class
        //2. removing the return type
        public Property(string address, int numberOfBedrooms, int price)
        {
            this.address = address;
            this.numberOfBedrooms = numberOfBedrooms;
            this.price = price;
            this.sold = false;

            propertiesForSale++;                    //House. isn't needed here because the static variable is in the House class
        }

        public void DisplayProperty()
        {
            Console.WriteLine("Address: {0} \n No. bedrooms {1}\n Size of garden (sqM): {2} \n Price: £{3:N0}.", address, numberOfBedrooms, price);  //:N0 formats the number
            if (sold)
            {
                Console.WriteLine("This property has been sold.");
            }
            else
            {
                Console.WriteLine("This property is available to buy.");
            }
            Console.WriteLine();
        }

        public void SellProperty(int price)
        {
            this.sold = true;
            this.price = price;

            propertiesForSale--;

            Console.WriteLine();
        }

        public static void DisplayAllProperties(List<Property> propertiesList)
        {
            int totalValueSold = 0;
            int totalValueAvailable = 0;

            Console.WriteLine();
            Console.WriteLine("The details of the properties on our books are: ");
            Console.WriteLine();
            //go through the properties list, displaying details and calculating totals
            foreach (Property item in propertiesList)
            {
                string type = "";

                //display general property details from base class
                Console.WriteLine("Address: {0} \n No. bedrooms: {1}\n Price: £{2:N0}.", item.address, item.numberOfBedrooms, item.price);  //:N0 formats the number

                //set or display details specific to derived classes
                if (item is House)
                {
                    type = "house";
                }
                else if (item is Flat)
                {
                    type = "flat";
                }

                if (item.sold)
                {
                    Console.WriteLine("This {0} has been sold.", type);
                    totalValueSold += item.price;
                }
                else
                {
                    Console.WriteLine("This {0} is available to buy.", type);
                    totalValueAvailable += item.price;
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            //display summary data
            Console.WriteLine("The total number of properties on our books is: " + Property.propertiesForSale);
            Console.WriteLine();
            Console.WriteLine("The total value of properties sold is: £{0:N0}.", totalValueSold);
            Console.WriteLine("The total value of properties available is: £{0:N0}.", totalValueAvailable);
            Console.WriteLine();
        }

    }//end property class

    class House : Property
    {
        public int sizeGardenSqM = 0;
        public static int numberOfHousesForSale = 0;

        public House(string address, int numberOfBedrooms, int price, int sizeGardenSqM) : base(address, numberOfBedrooms, price)
        {
            this.sizeGardenSqM = sizeGardenSqM;
            numberOfHousesForSale++;
        }

        public void SellHouse(int price)
        {
            SellProperty(price);
            //adjust the number of houses for sale
            numberOfHousesForSale--;
            Console.WriteLine("The house at {0} has been sold for £{1:N0}.", this.address, this.price);
        }

        public static void DisplayAllHouses(List<Property> propertiesList)
        {
            int totalHousesSoldValue = 0;
            int totalHousesAvailableValue = 0;

            Console.WriteLine();
            Console.WriteLine("Houses on our books");
            Console.WriteLine();

            foreach (Property property in propertiesList)
            {
                //display house details
                if (property is House)
                {
                    Console.WriteLine("Address: {0} \n No. bedrooms: {1}\n Price: £{2:N0}.", property.address, property.numberOfBedrooms, property.price);  //:N0 formats the number

                    //property must be explicitly cast back to a house to access its fields from the House class
                    House house = property as House;

                    Console.WriteLine(" Size of garden (sq metres): {0}", house.sizeGardenSqM);

                    if (property.sold)
                    {
                        Console.WriteLine("This house has been sold.");
                        totalHousesSoldValue += property.price;
                    }
                    else
                    {
                        Console.WriteLine("This house is available to buy.");
                        totalHousesAvailableValue += property.price;
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            //display summary data
            Console.WriteLine("The total number of houses on our books is: " + numberOfHousesForSale);
            Console.WriteLine();
            Console.WriteLine("The total value of houses sold is: £{0:N0}.", totalHousesSoldValue);
            Console.WriteLine("The total value of houses available is: £{0:N0}.", totalHousesAvailableValue);
            Console.WriteLine();
        }

    }//end house class

    class Flat : Property
    {
        public string freeholder = "";
        public static int numberOfFlatsForSale = 0;

        public Flat(string address, int numberOfBedrooms, int price, string freeholder) : base(address, numberOfBedrooms, price)
        {
            this.freeholder = freeholder;
            numberOfFlatsForSale++;
        }

        public void SellFlat(int price)
        {
            SellProperty(price);

            //reduce the number of flats for sale
            numberOfFlatsForSale--;

            Console.WriteLine("The flat at {0} has been sold for £{1:N0}.", this.address, this.price);
        }

        public static void DisplayAllFlats(List<Property> propertiesList)
        {
            int totalFlatsSoldValue = 0;
            int totalFlatsAvailableValue = 0;

            Console.WriteLine();
            Console.WriteLine("Flats on our books");
            Console.WriteLine();

            foreach (Property property in propertiesList)
            {
                //display flat details
                if (property is Flat)
                {
                    Console.WriteLine("Address: {0} \n No. bedrooms: {1}\n Price: £{2:N0}.", property.address, property.numberOfBedrooms, property.price);  //:N0 formats the number

                    //property must be explicitly cast back to a flat to access its fields from the Flat class
                    Flat flat = property as Flat;

                    Console.WriteLine(" Name of freeholder: {0}", flat.freeholder);

                    if (property.sold)
                    {
                        Console.WriteLine("This flat has been sold.");
                        totalFlatsSoldValue += property.price;
                    }
                    else
                    {
                        Console.WriteLine("This flat is available to buy.");
                        totalFlatsAvailableValue += property.price;
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

            //display summary data
            Console.WriteLine("The total number of flats on our books is: " + numberOfFlatsForSale);
            Console.WriteLine();
            Console.WriteLine("The total value of flats sold is: £{0:N0}.", totalFlatsSoldValue);
            Console.WriteLine("The total value of flats available is: £{0:N0}.", totalFlatsAvailableValue);
            Console.WriteLine();

        }

    }//end flat class

    class Program
    {
        static void Main(string[] args)
        {
            //initialise the static variable
            Property.propertiesForSale = 0;

            //initialise a list of properties for use in the non-static 
            //DisplayAllproperties method
            List<Property> propertiesList = new List<Property>();

            //instantiate house objects and give values to their fields using add method, 
            //incrementing the static variable each time a house is added and adding each
            //Property to the list
            //a constructor is now being used, so the field values for each object are
            //passed as parameters to the constructor
            House house1 = new House("23 Railway Cuttings, East Cheam", 1, 150000, 10);
            propertiesList.Add(house1);

            House house2 = new House("4 Privet Drive, Little Whinging, Surrey", 4, 750000, 200);
            propertiesList.Add(house2);

            Flat flat1 = new Flat("Flat 368, Nelson Mandela House, Dockside Estate, Peckham", 3, 250000, "Lewisham Council");
            propertiesList.Add(flat1);

            Flat flat2 = new Flat("Upstairs Flat, 11 Mafeking Parade, Hammersmith", 2, 50000, "Mr Harrison");
            propertiesList.Add(flat2);

            //display the details of the properties
            Property.DisplayAllProperties(propertiesList);

            //sell a Property
            house1.SellHouse(135000);
            flat1.SellFlat(270000);

            //display the details of all the properties
            Property.DisplayAllProperties(propertiesList);

            //display details of the houses
            House.DisplayAllHouses(propertiesList);

            //display the details of the flats
            Flat.DisplayAllFlats(propertiesList);

        }
    }
}
