using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IDrawable
    {
        public Circle(int radius)
        {
            Radius = radius;
        }

        public int Radius { get; set; }
        public void Draw()
        {
            Console.WriteLine($"drawing Circle with {Radius}");
        }
    }
}
