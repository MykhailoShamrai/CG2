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
        public MyVertex First { get; set; }
        public MyVertex Second { get; set; }
        public MyVertex Third { get; set; }

        public Triangle() { }
        public Triangle(MyVertex first, MyVertex second, MyVertex third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }
}
