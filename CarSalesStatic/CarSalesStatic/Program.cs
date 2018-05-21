using System;
using System.Collections.Generic;

namespace CarSalesStaticMethods
{
    class Car
    {
        public string make;
        public string model;
        public int price;
        public Boolean sold;

        public static int numberOfCars;

        public void AddCar(string make, string model, int price)
        {
            this.make = make;
            this.model = model;
            this.price = price;
            this.sold = false;
            Car.numberOfCars++;
        }

        public void ListCar()
        {
            //display details for an individual car
            Console.WriteLine("The details of this car are: ");
            Console.Write("Make and model: {0} {1}, price: £{2:N0}.", make, model, price);  //:N0 formats the number
            if (sold)
            {
                Console.WriteLine("This car has been sold.");
            }
            else
            {
                Console.WriteLine("This car has not yet been sold.");
            }
            Console.WriteLine();
        }

        //record the sale of a car
        public void Sold(bool isSold, int price)
        {
            this.sold = isSold;
            this.price = price;
            //adjust the number of cars
            Car.numberOfCars--;
        }

        //list all the cars
        public static void ListAllCars(List<Car> allCars)
        {
            int totalValueSold = 0;
            int totalValueInStock = 0;

            foreach (Car item in allCars)
            {
                Console.WriteLine("The details of this car are: ");
                Console.Write("Make and model: {0} {1}, price: £{2:N0}.", item.make, item.model, item.price);  //:N0 formats the number
                if (item.sold)
                {
                    Console.WriteLine("This car has been sold.");
                    totalValueSold += item.price;
                }
                else
                {
                    Console.WriteLine("This car is unsold.");
                    totalValueInStock += item.price;
                }
                Console.WriteLine();
            }
            Console.WriteLine("The total value of cars sold is: £{0:N0}.", totalValueSold);
            Console.WriteLine("The total value of cars still in stock is: £{0:N0}.", totalValueInStock);
            Console.WriteLine();
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Car.numberOfCars = 0;
            List<Car> allCars = new List<Car>();

            //add cars
            Car car1 = new Car();
            car1.AddCar("RollsRoyce", "Silver Cloud", 35000);
            allCars.Add(car1);

            Car car2 = new Car();
            car2.AddCar("Aston Martin", "DB5", 750000);
            allCars.Add(car2);

            Car car3 = new Car();
            car3.AddCar("Reliant", "Robin", 550);
            allCars.Add(car3);

            //display cars data
            Console.WriteLine("Total number of cars in stock is: {0}", Car.numberOfCars);
            Console.WriteLine();

            Car.ListAllCars(allCars);

            //record the sale of a car
            car3.Sold(true, 350);

            //display cars data
            Console.WriteLine("Total number of cars in stock is: {0}", Car.numberOfCars);
            Console.WriteLine();

            Car.ListAllCars(allCars);


        }
    }
}