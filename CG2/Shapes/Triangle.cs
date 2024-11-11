using CG2.Drawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CG2.Shapes
{
    public class Triangle: Polygon
    {
        public Triangle() { }
        public Triangle(MyVertex first, MyVertex second, MyVertex third)
        {
            Edges = new MyEdge[3];
            Points = new MyVertex[3];
            Points[0] = first;
            Points[1] = second;
            Points[2] = third;
            Edges[0] = new MyEdge(first, second);
            Edges[1] = new MyEdge(second, third);
            Edges[2] = new MyEdge(third, first);
        }

        public override void VisitColorer(IColorer colorer, Vector3 lightPos, int x1, int x2, int y, Color color)
        {
            colorer.DrawLineBetween(lightPos, this, x1, x2, y, color);
        }
    }
}
