using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesInheritance
{
    public class Vehicle
    {
        
        public string make = "";
        public string model = "";

        public int price = 0;
        public bool sold = false;
        
        public static int vehiclesForSale = 0;

        public Vehicle(string make, string model, int price)
        {
            this.make = make;
            this.model = model;
            this.price = price;
            this.sold = false;

            vehiclesForSale++;
        }

        public void DisplayVehicle()
        {
            Console.WriteLine("Make: {0} \nModel{1} \nSize of engine: {2} \nPrice: £{3:N0}.", make, model, price);  //:N0 formats the number
            if (sold)
            {
                Console.WriteLine("This vehicle has been sold.");
            }
            else
            {
                Console.WriteLine("This vehicle is available to buy.");
            }
            Console.WriteLine();
        }

        public void SellVehicle(int price)
        {
            this.sold = true;
            this.price = price;

            vehiclesForSale--;

            Console.WriteLine();
        }

        public static void DisplayAllVehicles(List<Vehicle> vehiclesList)
        {
            int totalValueSold = 0;
            int totalValueAvailable = 0;

            Console.WriteLine();
            Console.WriteLine("The details of the vehicles on our books are: ");
            Console.WriteLine();

            foreach (Vehicle item in vehiclesList)
            {
                string type = "";


                Console.WriteLine("Make: {0} \nModel: {1}\nPrice: £{2:N0}.", item.make, item.model, item.price);  //:N0 formats the number


                if (item is Car)
                {
                    type = "car";
                }
                else if (item is Motorcycle)
                {
                    type = "motorcycle";
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

            Console.WriteLine("The total number of vehicles on our books is: " + Vehicle.vehiclesForSale);
            Console.WriteLine();
            Console.WriteLine("The total value of vehicles sold is: £{0:N0}.", totalValueSold);
            Console.WriteLine("The total value of vehicles available is: £{0:N0}.", totalValueAvailable);
            Console.WriteLine();
        }

    }//end property class

    class Car : Vehicle
    {
        public decimal sizeOfEngine = 0;
        public static int numberOfCarsForSale = 0;

        public Car(string make, string model, int price, int sizeOfEngine) : base(make, model, price)
        {
            this.sizeOfEngine = sizeOfEngine;
            numberOfCarsForSale++;
        }

        public void SellHouse(int price)
        {
            SellVehicle(price);

            numberOfCarsForSale--;
            Console.WriteLine("The {0}, {1} has been sold for £{2:N0}.", this.make, this.model, this.price);
        }

        public static new void DisplayAllVehicles(List<Vehicle> vehiclesList)
        {
            int totalCarsSoldValue = 0;
            int totalCarsAvailableValue = 0;

            Console.WriteLine();
            Console.WriteLine("Cars on our books");
            Console.WriteLine();

            foreach (Vehicle vehicle in vehiclesList)
            {

                if (vehicle is Car)
                {
                    Console.WriteLine("Make: {0} \nModel: {1}\nPrice: £{2:N0}.", vehicle.make, vehicle.model, vehicle.price);  //:N0 formats the number

                    Car car = vehicle as Car;

                    Console.WriteLine(" Size of engine: {0}", car.sizeOfEngine);

                    if (vehicle.sold)
                    {
                        Console.WriteLine("This car has been sold.");
                        totalCarsSoldValue += vehicle.price;
                    }
                    else
                    {
                        Console.WriteLine("This car is available to buy.");
                        totalCarsAvailableValue += vehicle.price;
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
 
            Console.WriteLine("The total number of cars on our books is: " + numberOfCarsForSale);
            Console.WriteLine();
            Console.WriteLine("The total value of cars sold is: £{0:N0}.", totalCarsSoldValue);
            Console.WriteLine("The total value of cars available is: £{0:N0}.", totalCarsAvailableValue);
            Console.WriteLine();
        }

    }//end house class

    class Motorcycle : Vehicle
    {
        public int gears = 0;
        public static int numberOfMotorcyclesForSale = 0;

        public Motorcycle(string make, string model, int price, int gears) : base(make, model, price)
        {
            this.gears = gears;
            numberOfMotorcyclesForSale++;
        }

        public void SellMotorcycle(int price)
        {
            SellVehicle(price);


            numberOfMotorcyclesForSale--;

            Console.WriteLine("The {0} {1} has been sold for £{1:N0}.", this.make, this.model, this.price);
        }

        public static void DisplayAllVehicles(List<Vehicle> vehiclesList)
        {
            int totalMotorcyclesSoldValue = 0;
            int totalMotorcyclesAvailableValue = 0;

            Console.WriteLine();
            Console.WriteLine("Motorcycles on our books");
            Console.WriteLine();

            foreach (Vehicle vehicle in vehiclesList)
            {

                if (vehicle is Motorcycle)
                {
                    Console.WriteLine("Make: {0} \nModel: {1}\nPrice: £{2:N0}.", vehicle.make, vehicle.model, vehicle.price);  //:N0 formats the number

 
                    Motorcycle motorcycle = vehicle as Motorcycle;

                    Console.WriteLine("Number of gears: {0}", motorcycle.gears);

                    if (vehicle.sold)
                    {
                        Console.WriteLine("This motorcycle has been sold.");
                        totalMotorcyclesSoldValue += vehicle.price;
                    }
                    else
                    {
                        Console.WriteLine("This motorcycle is available to buy.");
                        totalMotorcyclesAvailableValue += vehicle.price;
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

    
            Console.WriteLine("The total number of motorcycles on our books is: " + numberOfMotorcyclesForSale);
            Console.WriteLine();
            Console.WriteLine("The total value of motorcycles sold is: £{0:N0}.", totalMotorcyclesSoldValue);
            Console.WriteLine("The total value of motorcycles available is: £{0:N0}.", totalMotorcyclesAvailableValue);
            Console.WriteLine();

        }

    }//end motorcycle class

    class Program
    {
        static void Main(string[] args)
        {
            
            Vehicle.vehiclesForSale = 0;

            
            List<Vehicle> vehiclesList = new List<Vehicle>();

          
            Car car1 = new Car("BMW", "3 Series", 135000, 3);
            vehiclesList.Add(car1);

            Car car2 = new Car("Audi", "TT", 38000, 2);
            vehiclesList.Add(car2);

            Motorcycle motorcycle1 = new Motorcycle("Honda", "3000", 270000, 6);
            vehiclesList.Add(motorcycle1);

            Motorcycle motorcycle2 = new Motorcycle("Kawasaki", "6730", 35000, 6);
            vehiclesList.Add(motorcycle2);

            Vehicle.DisplayAllVehicles(vehiclesList);

          
            car1.SellVehicle(135000);
            motorcycle1.SellMotorcycle(270000);

       
            Vehicle.DisplayAllVehicles(vehiclesList);


            Car.DisplayAllVehicles(vehiclesList);


            Motorcycle.DisplayAllVehicles(vehiclesList);

        }
    }
}
