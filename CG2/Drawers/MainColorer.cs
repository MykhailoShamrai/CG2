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
        public void DrawLineBetween(Vector3 lightPosition, Triangle polygon, int x1, int x2, int y, Color color, DirectBitmap canvas)
        {
            int dx = x2 - x1;
            int k = dx < 0 ? -1 : 1;
            Vector3 a = new Vector3(polygon.Points[0].RotatedPosition.X, polygon.Points[0].RotatedPosition.Y, 0);
            Vector3 b = new Vector3(polygon.Points[1].RotatedPosition.X, polygon.Points[1].RotatedPosition.Y, 0);
            Vector3 c = new Vector3(polygon.Points[2].RotatedPosition.X, polygon.Points[2].RotatedPosition.Y, 0);
            Vector3 tmp = new Vector3(0 ,0, 0);
            Vector3 L = new Vector3();
            while (x1 < x2)
            {
                tmp.X = x1;
                tmp.Y = y;
                var res = Triangle.ReturnBarycentricCoords(tmp, a, b, c);
                // Change this hard coded values
                Color col = ReturnColor(res, lightPosition, polygon, color, Color.White, 1, 0, 0);
                canvas.SetPixel(x1, y, col);
                x1 += k;
            }
        }

        public void DrawLineBetween(Vector3 lightPosition, AbstractPolygon polygon, int x1, int x2, int y, Color color, DirectBitmap canvas)
        {
            throw new NotImplementedException();
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
            float cos2 = 1.0f;
            for (int i = 0; i < m; i++)
            {
                cos2 *= tmp;
            }
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
            r = r < 0 ? 0 : r;
            g = g * 255;
            g = g > 255 ? 255 : g;
            g = g < 0 ? 0 : g;
            b = b * 255;
            b = b > 255 ? 255 : b;
            b = b < 0 ? 0 : b;
            return Color.FromArgb((int)r, (int)g, (int)b);
        }
    }
}
