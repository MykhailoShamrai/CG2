using CG2.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static CG2.Shapes.MyPlane;

namespace CG2.Drawers
{
    public class MainDrawer
    {
        public bool DrawControlPointsBool { get; set; } = true;
        public bool DrawBordersBool { get; set; } = true;
        IColorer Colorer { get; set; }
        public DirectBitmap Canvas { get; set; }
        public int LevelOfTriang { get; set; } = 0;
        private readonly Pen _controlPen = new Pen(Color.Crimson, 0.5f);
        private readonly Pen _triangleBorderPen = new Pen(Color.BlueViolet, 1);
        public MyPlane Plane { get; set; }
        

        public MainDrawer(MyPlane plane, DirectBitmap canvas, IColorer colorer)
        {
            Plane = plane;
            Canvas = canvas;
            Colorer = colorer;
        }

        public void Draw(Graphics g, LightSource lightSource, Color color, LightSourceDirect[] directSources)
        {
            FillTrianglesAccordingToLightSource(g, lightSource, color, directSources);
            if (DrawBordersBool) 
                DrawBordersOfTriangles(g);
            if (DrawControlPointsBool)
                DrawControlPoints(g);
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

        public class AET
        {
            //public float ymax { get; set; }
            public float x { get; set; }
            public float dxdy { get; set; }
            public int firstInd { get; set; }
            public AET(MyVertex first, MyVertex second, int firstInd)
            {
                //ymax = second.RotatedPosition.Y;
                x = first.RotatedPosition.X;
                dxdy = (second.RotatedPosition.X - first.RotatedPosition.X) / (second.RotatedPosition.Y - first.RotatedPosition.Y);
                if (MathF.Abs(second.RotatedPosition.Y - first.RotatedPosition.Y) < 10e-5)
                    dxdy = 0;
                this.firstInd = firstInd;
            }
        }

        public static int RetIndexMinOne(int index, int len)
        {
            return index - 1 >= 0 ? index - 1 : len + index - 1;
        }


        public class MyComparer : IComparer<MyVertex>
        {
            public int Compare(MyVertex? x, MyVertex? y)
            {
                return x.RotatedPosition.Y.CompareTo(y.RotatedPosition.Y);
            }
        }

        public static int[] SortIndices(MyVertex[] vertices)
        {
            // Sort vertices according to Y. It;s important, that index of a vertex gives us an index of edge where this vertex is the first end.
            // It means, that index - 1 gives us an edge wher ethis vertex is second.
            int[] res = new int[vertices.Length];
            MyVertex[] tmp = new MyVertex[vertices.Length];
            Array.Copy(vertices, tmp, vertices.Length);
            for (int i = 0; i < vertices.Length; i++)
            {
                res[i] = i;
            }
            Array.Sort<MyVertex, int>(tmp, res, new MyComparer());
            return res;
        }
        public static void ColorAPolygon(IColorer colorer, AbstractPolygon polygon, LightSource lightSource, Color color, DirectBitmap canvas, LightSourceDirect[] directs)
        {
            MyVertex[] vertices = polygon.Points;
            MyEdge[] edges = polygon.Edges;
            List<AET> list = new List<AET>();
            int[] indices = SortIndices(vertices);
            int ymin = (int)vertices[indices[0]].RotatedPosition.Y;
            int ymax = (int)vertices[indices[vertices.Length - 1]].RotatedPosition.Y;
            int y = ymin;
            int i = 0;
            bool flag = false;
            while (y != ymax)
            {
                int ii = i;
                while (i < indices.Length && (int)vertices[indices[i]].RotatedPosition.Y == y)
                {
                    if (ii == i - 1)
                    {
                        ii++;
                        float x1 = vertices[indices[i]].RotatedPosition.X;
                        float x2 = vertices[indices[i - 1]].RotatedPosition.X;
                        (x1, x2) = x1 < x2 ? (x1, x2) : (x2, x1);
                        polygon.VisitColorer(colorer, lightSource, (int)MathF.Ceiling(x1),
                                                                (int)MathF.Round(x2), y, color, canvas, directs);
                    }
                    flag = true;
                    // Check if we should add lines
                    int first = RetIndexMinOne(indices[i], vertices.Length);
                    int second = indices[i];
                    // Check first edge
                    // TODO: What's going on here if we have horiyontal line
                    if ((int)edges[first].First.RotatedPosition.Y > y)
                    {
                        list.Add(new AET(edges[first].Second, edges[first].First, first));
                    }
                    if ((int)edges[first].First.RotatedPosition.Y < y)
                    {
                        // BUG here!!! Nothing is deleted
                        for (int k = 0; k < list.Count; k++)
                        {
                            if (list[k].firstInd == first)
                            {
                                list.RemoveAt(k);
                                break;
                            }
                        }
                    }
                    // Check second edge
                    if ((int)edges[second].Second.RotatedPosition.Y > y)
                    {
                        list.Add(new AET(edges[second].First, edges[second].Second, second));
                    }
                    if ((int)edges[second].Second.RotatedPosition.Y < y)
                    {
                        for (int k = 0; k < list.Count; k++)
                        {
                            if (list[k].firstInd == second)
                            {
                                list.RemoveAt(k);
                                //i++;
                                break;
                            }
                        }
                    }
                    i++;

                }
                if (flag)
                    list.Sort((first, second) => first.x.CompareTo(second.x));
                // After we had sorted everything, we must paint every pixel that is to be painted!!!
                for (int j = 0; j < list.Count; j += 2)
                {
                    polygon.VisitColorer(colorer, lightSource, (int)MathF.Ceiling(list[j].x), (int)MathF.Round(list[j + 1].x), y, color, canvas, directs);
                    list[j].x = list[j].x + list[j].dxdy;
                    list[j + 1].x = list[j + 1].x + list[j + 1].dxdy;
                }
                flag = false;
                // if two points in the sorted array have same y
                
                y += 1;
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

        public void FillTrianglesAccordingToLightSource(Graphics g, LightSource lightSource, Color color, LightSourceDirect[] directs)
        {
            foreach (var triangle in Plane.Triangles)
                ColorAPolygon(Colorer, triangle, lightSource, color, Canvas, directs);
        }
    }
}
