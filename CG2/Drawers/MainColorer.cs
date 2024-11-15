using CG2.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CG2.Drawers
{
    public class MainColorer : IColorer
    {
        public float Kd { get; set; }
        public float Ks { get; set; }
        public int M { get; set; }

        public MainColorer(float kd, float ks, int m)
        {
            Kd = kd;
            Ks = ks;
            M = m;
        }

        public void DrawHorizontalLineBetween(Vector3 lightPosition, Triangle polygon, int x1, int x2, int y, Color color, DirectBitmap canvas)
        {
            int dx = x2 - x1;
            int k = dx < 0 ? -1 : 1;
            Vector3 tmp = new Vector3(0 ,0, 0);
            Vector3 L = new Vector3();
            while (x1 <= x2)
            {
                tmp.X = x1;
                tmp.Y = y;
                var res = Triangle.ReturnBarycentricCoords(tmp, polygon);
                // Change this hard coded values
                Color col = ReturnColor(res, lightPosition, polygon, color, Color.White, Kd, Ks, M);
                canvas.SetPixel(x1, y, col);
                x1 += k;
            }
        }

        public void DrawHorizontalLineBetween(Vector3 lightPosition, AbstractPolygon polygon, int x1, int x2, int y, Color color, DirectBitmap canvas)
        {        
        }


        public Color ReturnColor((float lam1, float lam2, float lam3) lambdas, Vector3 lightPos, Triangle tr,
                                    Color color, Color lightColor, float kd, float ks, int m)
        {
            Vector3 N = Vector3.Normalize(lambdas.lam1 * tr.Points[0].NAfter +
                                                lambdas.lam2 * tr.Points[1].NAfter + 
                                                lambdas.lam3 * tr.Points[2].NAfter);
            Vector3 interploated = lambdas.lam1 * tr.Points[0].RotatedPosition +
                                    lambdas.lam2 * tr.Points[1].RotatedPosition +
                                    lambdas.lam3 * tr.Points[2].RotatedPosition;
            Vector3 L = Vector3.Normalize(lightPos - interploated);
            Vector3 R = Vector3.Normalize(2 * Vector3.Dot(N, L) * N - L);
            
            Vector3 V = new Vector3(0, 0, 1);
            float cos1 = Vector3.Dot(N, L);
            cos1 = cos1 < 0 ? 0 : cos1;
            //if (float.IsNaN(cos1)) 
            //    cos1 = 0;
            float tmp = Vector3.Dot(V, R);
            float cos2 = tmp;
            cos2 = MathF.Pow(cos2, m);
            //for (int i = 0; i < m; i++)
            //{
            //    cos2 *= tmp;
            //}
            cos2 = cos2 < 0 ? 0 : cos2;
            float rO = (float)color.R / 255;
            float gO = (float)color.G / 255;
            float bO = (float)color.B / 255;

            float rL = (float)lightColor.R / 255;
            float gL = (float)lightColor.G / 255;
            float bL = (float)lightColor.B / 255;

            float r = kd * rL * rO * cos1 + ks * rL * rO * cos2;
            float g = kd * gL * gO * cos1 + ks * gL * gO * cos2;
            float b = kd * bL * bO * cos1 + ks * bL * bO * cos2;

            r = r * 255;
            r = r > 255 ? 255 : r;
            g = g * 255;
            g = g > 255 ? 255 : g;
            b = b * 255;
            b = b > 255 ? 255 : b;
            return Color.FromArgb((int)r, (int)g, (int)b);
        }

        // This part of code is unused, but I leave it, may be in future I'll need it


        public void DrawLineBetween(Vector3 lightPosition, Triangle polygon, Color color, DirectBitmap canvas)
        {
            // TODO:
            Point first = new Point(0, 0);
            Point second = new Point(0, 0);
            foreach (MyEdge edge in polygon.Edges)
            {
                first.X = (int)edge.First.RotatedPosition.X;
                first.Y = (int)edge.First.RotatedPosition.Y;
                second.X = (int)edge.Second.RotatedPosition.X;
                second.Y = (int)edge.Second.RotatedPosition.Y;
                Draw(first, second, canvas, lightPosition, polygon, Color.White, 1, 1, 3, Color.Yellow);
            }
        }

        public void DrawLineBetween(Vector3 lightPosition, AbstractPolygon polygon, Color color, DirectBitmap canvas)
        {
            return;
        }

        // Brezenham drawing algo
        public void Draw(Point first, Point second, DirectBitmap canvas, Vector3 lightPos, Triangle tr,
                                    Color lightColor, float kd, float ks, int m, Color? color = null)
        {
            if (Math.Abs(second.Y - first.Y) < Math.Abs(second.X - first.X))
            {
                if (first.X > second.X)
                {
                    plotLineLow(second, first, canvas, lightPos, tr, lightColor, kd, ks, m, color);
                }
                else
                {
                    plotLineLow(first, second, canvas, lightPos, tr, lightColor, kd, ks, m, color);
                }
            }
            else
            {
                if (first.Y > second.Y)
                {
                    plotLineHigh(second, first, canvas, lightPos, tr, lightColor, kd, ks, m, color);
                }
                else
                {
                    plotLineHigh(first, second, canvas, lightPos, tr, lightColor, kd, ks, m, color);
                }
            }
        }

        private void plotLineLow(Point first, Point second, DirectBitmap canvas, Vector3 lightPos, Triangle tr,
                                    Color lightColor, float kd, float ks, int m, Color? color = null)
        {
            int dx = second.X - first.X;
            int dy = second.Y - first.Y;
            int yi = 1;

            if (dy < 0)
            {
                yi = -1;
                dy = -dy;
            }

            int D = (2 * dy) - dx;
            int y = first.Y;

            for (int x = first.X; x <= second.X; x++)
            {
                //if (x >= 0 && y >= 0)
                {
                    if (color.HasValue)
                    {
                        Vector3 tmp = new Vector3(x, y, 0);
                        Vector3 L = new Vector3();
                        var res = Triangle.ReturnBarycentricCoords(tmp, tr);
                        canvas.SetPixel(x, y, ReturnColor(res, lightPos, tr, color.Value, lightColor, kd, ks, m));
                    }
                    else
                    {
                        canvas.SetPixel(x, y, Color.Black);
                    }
                }
                if (D > 0)
                {
                    y += yi;
                    D += (2 * (dy - dx));
                }
                else
                {
                    D += 2 * dy;
                }
            }
        }

        private void plotLineHigh(Point first, Point second, DirectBitmap canvas, Vector3 lightPos, Triangle tr,
                                    Color lightColor, float kd, float ks, int m, Color? color = null)
        {
            int dx = second.X - first.X;
            int dy = second.Y - first.Y;
            int xi = 1;

            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }

            int D = (2 * dx) - dy;
            int x = first.X;

            for (int y = first.Y; y <= second.Y; y++)
            {
                //if (x >= 0 && y >= 0)
                {
                    if (color.HasValue)
                    {
                        Vector3 tmp = new Vector3(x, y, 0);
                        Vector3 L = new Vector3();
                        var res = Triangle.ReturnBarycentricCoords(tmp, tr);
                        canvas.SetPixel(x, y, ReturnColor(res, lightPos, tr, color.Value, lightColor, kd, ks, m));
                    }
                    else
                    {
                        canvas.SetPixel(x, y, Color.Black);
                    }
                }
                if (D > 0)
                {
                    x += xi;
                    D += (2 * (dx - dy));
                }
                else
                {
                    D += 2 * dx;
                }
            }
        }
    }
}
