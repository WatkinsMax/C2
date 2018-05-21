using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism2
{
   
        class Vehicle
        {
            public virtual void Draw()
            {
                Console.WriteLine("You have a vehicle.");
            }
        }
        class Car : Vehicle
        {
            public override void Draw()
            {
                Console.WriteLine("Your vehicle has four wheels.");
            }
        }
        class Motorcycle : Vehicle
        {
            public override void Draw()
            {
                Console.WriteLine("Your vehicle has two wheels.");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                List<Vehicle> vehiclesList = new List<Vehicle>();

                Vehicle vehicle1 = new Vehicle();
                Vehicle car1 = new Car();
                Vehicle motorcycle1 = new Motorcycle();
            
                vehiclesList.Add(vehicle1);
                vehiclesList.Add(car1);
                vehiclesList.Add(motorcycle1);

               
                foreach (Vehicle v in vehiclesList)
                {

                    Console.Write(v.GetType() + ": ");
                    v.Draw();
                }

            Console.ReadLine();
            }
        }
    }