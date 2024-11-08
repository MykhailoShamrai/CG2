using CG2.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CG2.Drawers
{
    public class MainDrawer
    {
        public int LevelOfTriang { get; set; } = 0;
        private readonly Pen _controlPen = new Pen(Color.Crimson, 0.5f);
        private readonly Pen _triangleBorderPen = new Pen(Color.BlueViolet, 1);
        public MyPlane Plane { get; set; }
        

        public MainDrawer(MyPlane plane)
        {
            Plane = plane;
        }

        public void Draw(Graphics g)
        {
            DrawControlPoints(g);
            DrawBordersOfTriangles(g);
        }

        public void DrawControlPoints(Graphics g, int size = 4)
        {
            // I assume, that I have 16 control points.
            Vector3 tmp;
            Vector3 tmp2;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tmp = Plane.RotatedControlPoints[size * i + j];
                    g.DrawEllipse(_controlPen, tmp.X - 2, tmp.Y - 2, 4, 4);
                    if ((j - 1) >= 0)
                    {
                        tmp2 = Plane.RotatedControlPoints[size * i + j - 1];
                        g.DrawLine(_controlPen, tmp.X, tmp.Y, tmp2.X, tmp2.Y);
                    }
                    if ((i - 1) >= 0)
                    {
                        tmp2 = Plane.RotatedControlPoints[size * (i - 1)  + j];
                        g.DrawLine(_controlPen, tmp.X, tmp.Y, tmp2.X, tmp2.Y);
                    }
                }
            }
        }

        public void DrawBordersOfTriangles(Graphics g)
        {
            foreach (var vertices in Plane.Triangles.Select(tr => tr.Points))
            {
                g.DrawLine(_triangleBorderPen, new Point((int)vertices[0].RotatedPosition.X, (int)vertices[0].RotatedPosition.Y),
                    new Point((int)vertices[1].RotatedPosition.X, (int)vertices[1].RotatedPosition.Y));
                g.DrawLine(_triangleBorderPen, new Point((int)vertices[1].RotatedPosition.X, (int)vertices[1].RotatedPosition.Y),
                    new Point((int)vertices[2].RotatedPosition.X, (int)vertices[2].RotatedPosition.Y));
                g.DrawLine(_triangleBorderPen, new Point((int)vertices[2].RotatedPosition.X, (int)vertices[2].RotatedPosition.Y),
                    new Point((int)vertices[0].RotatedPosition.X, (int)vertices[0].RotatedPosition.Y));
            }
        }
    }
}
