using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04z1
{
    internal class Shape
    {
        public int x;
        public int y;
        public int height;
        public int width;

        public Shape()
        {}

        public Shape(int x, int y, int height, int width)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }

        public virtual void Draw()
        {
            Console.WriteLine("Rysujemy...");
        }

    }

}
