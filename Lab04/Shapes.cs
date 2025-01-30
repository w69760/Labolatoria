using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04z1
{
    internal class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rysuje prostokat");
        }
    }
    internal class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rysuje trojkat");
        }
    }
    internal class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rysuje kolo");
        }
    }
}
