using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEncapsulationExercise
{
    public class Meal
    {
        public string name;
        public decimal price;
        public decimal cost;

        public Meal(string name, decimal price, decimal cost)
        {
            this.name = name;
            this.price = price;
            this.cost = cost;
        }

        public void cookMeal(Meal meal)
        {
            Console.WriteLine("The meal {0} has been cooked.", meal.name);
        }
    }


    public class Order
    {
        public void takeOrder(Meal meal)
        {
            Console.WriteLine("The meal {0} has been ordered.", meal.name);
        }
    }

    class Accounts
    {
        public static decimal calculateCost(Meal meal, decimal balance)
        {
            balance = balance + meal.price;
            balance = balance - meal.cost;

            return balance;
        }

    }
   

    class Program
    {
        static void Main(string[] args)
        {
            decimal balance = 0;

            //add some meals data
            Meal steak = new Meal("steak", 20.00M, 5.00M);

            Meal fajitas = new Meal("fajitas", 12.00M, 2.00M);

            Meal pumpkinRisotto = new Meal("pumpkinRisotto", 10.00M, 1.00M);

            Order order1 = new Order();
            order1.takeOrder(steak);
            balance = Accounts.calculateCost(steak, balance);
       

            Order order2 = new Order();
            order2.takeOrder(pumpkinRisotto);
            balance = Accounts.calculateCost(pumpkinRisotto, balance);

            Console.WriteLine("Tonight in the restaurant, we made £{0:N2}.", balance);

        }
    }
}