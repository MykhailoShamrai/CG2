using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CG2.Shapes
{
    public class Triangle
    {
        public MyVertex[] Points { get; set; } = new MyVertex[3];

        public Triangle() { }
        public Triangle(MyVertex first, MyVertex second, MyVertex third)
        {
            Points[0] = first;
            Points[1] = second;
            Points[2] = third;
        }
    }
}
