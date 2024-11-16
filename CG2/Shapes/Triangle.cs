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
    public class Triangle: AbstractPolygon
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

        public override void VisitColorer(IColorer colorer, LightSource lightSource, int x1, int x2, int y, Color color, DirectBitmap canvas)
        {
            colorer.DrawHorizontalLineBetween(lightSource, this, x1, x2, y, color, canvas);
        }

        public override void VisitColorerEdges(IColorer colorer, LightSource lightSource, Color color, DirectBitmap canvas)
        {
            colorer.DrawLineBetween(lightSource, this, color, canvas);
        }

        public static (float lam1, float lam2, float lam3) ReturnBarycentricCoords(Vector3 point, Triangle polygon)
        {
            Vector3 a = new Vector3(polygon.Points[0].RotatedPosition.X, polygon.Points[0].RotatedPosition.Y, 0);
            Vector3 b = new Vector3(polygon.Points[1].RotatedPosition.X, polygon.Points[1].RotatedPosition.Y, 0);
            Vector3 c = new Vector3(polygon.Points[2].RotatedPosition.X, polygon.Points[2].RotatedPosition.Y, 0);

            float sareaABC = Vector3.Cross(b - a,
                                           c - a).Length();
            float sareaPBC = Vector3.Cross(point - b,
                                           c - b).Length();
            float sareaAPC = Vector3.Cross(point - a,
                                           c - a).Length();
            float sareaABP = Vector3.Cross(point - a,
                                           b - a).Length();
            return (sareaPBC / sareaABC, sareaAPC / sareaABC, sareaABP / sareaABC);
        }
    }
}
