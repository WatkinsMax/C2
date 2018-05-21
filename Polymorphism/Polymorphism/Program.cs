using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismNewExample
{
    class Polygon
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing a Polygon.");
        }
    }
    class Rectangle : Polygon
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Rectangle.");
        }
    }
    class Triangle : Polygon
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Triangle.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Polygon> polygonsList = new List<Polygon>();

            Polygon polygon1 = new Polygon();
            Polygon rectangle1 = new Rectangle();      //rectangle that has been cast as a polygon
            Polygon triangle1 = new Triangle();        //triangle that has been cast as a polygon

            //shapes added to list of polygons
            polygonsList.Add(polygon1);
            polygonsList.Add(rectangle1);
            polygonsList.Add(triangle1);

            //draw method called for each shape in the list
            foreach (Polygon p in polygonsList)
            {

                Console.Write(p.GetType() + ": ");
                p.Draw();
            }

            //draw method called on a triangle that is just
            //a triangle - it hasn't been cast as a polygon
            Triangle triangle2 = new Triangle();

            Console.Write(triangle2.GetType() + ": ");
            triangle2.Draw();

            Console.ReadLine();
        }
    }
}
