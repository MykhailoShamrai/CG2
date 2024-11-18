using CG2.Shapes;
using Microsoft.VisualBasic.Logging;
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
        public DirectBitmap? Image { get; set; } = null;
        public DirectBitmap? NormalMap { get; set; } = null;
        public float Mdirect { get; set; }
        public float Kd { get; set; }
        public float Ks { get; set; }
        public int M { get; set; }

        public MainColorer(float kd, float ks, int m, float mdirect)
        {
            Kd = kd;
            Ks = ks;
            M = m;
            Mdirect = mdirect;
        }

        public void DrawHorizontalLineBetween(LightSource lightSource, Triangle polygon, int x1, int x2, int y, Color color, DirectBitmap canvas, LightSourceDirect[] directs)
        {
            int dx = x2 - x1;
            Color normInColors;
            Vector3? norm = null;
            int k = dx < 0 ? -1 : 1;
            Vector3 tmp = new Vector3(0, 0, 0);
            while (x1 <= x2)
            {
                tmp.X = x1;
                tmp.Y = y;
                var res = Triangle.ReturnBarycentricCoords(tmp, polygon);
                if (Image != null)
                {
                    color = FindColorFromImage(res, polygon, Image);
                }
                if (NormalMap != null)
                {
                    normInColors = FindColorFromImage(res, polygon, NormalMap);
                    norm = new Vector3(
                        (normInColors.R / 255f) * 2 - 1,
                        (normInColors.G / 255f) * 2 - 1,
                        (normInColors.B / 255f) * 2 - 1);
                }
                Vector3 col = ReturnColor(res, lightSource, polygon, color, Kd, Ks, M, norm);
                col += ReturnColor(res, directs[0], polygon, color, Kd, Ks, M, norm);
                col += ReturnColor(res, directs[1], polygon, color, Kd, Ks, M, norm);
                col += ReturnColor(res, directs[2], polygon, color, Kd, Ks, M, norm);

                col = Vector3.Clamp(col, new Vector3(0, 0, 0), new Vector3(255, 255, 255));
                
                canvas.SetPixel(x1, y, Color.FromArgb((int)col.X, (int)col.Y, (int)col.Z));
                x1 += k;
            }
        }

        private Color FindColorFromImage((float lam1, float lam2, float lam3) res, Triangle polygon, DirectBitmap Image)
        {
            var vertices = polygon.Points;
            float u = res.lam1 * vertices[0].U + res.lam2 * vertices[1].U + res.lam3 * vertices[2].U;
            float v = res.lam1 * vertices[0].V + res.lam2 * vertices[1].V + res.lam3 * vertices[2].V;
            u = u > 1 ? 1 : u;
            u = u < 0 ? 0 : u;
            v = v > 1 ? 1 : v;
            v = v < 0 ? 0 : v;
            var col = Image.GetPixel((int)(v * (Image.Width - 1)), (int)(u * (Image.Height - 1)));
            return col;
        }

        public void DrawHorizontalLineBetween(LightSource lightSource, AbstractPolygon polygon, int x1, int x2, int y, Color color, DirectBitmap canvas, LightSourceDirect[] directs)
        {
        }


        public Vector3 ReturnColor((float lam1, float lam2, float lam3) lambdas, LightSource lightSource, Triangle tr,
                                    Color color, float kd, float ks, int m, Vector3? nNormalMap = null)
        {
            Vector3 lightPos = lightSource.Position;
            Color lightColor = lightSource.Color;
            Vector3 N = Vector3.Normalize(lambdas.lam1 * tr.Points[0].NAfter +
                                                lambdas.lam2 * tr.Points[1].NAfter +
                                                lambdas.lam3 * tr.Points[2].NAfter);

            if (nNormalMap != null)
            {
                Vector3 Pu = Vector3.Normalize(lambdas.lam1 * tr.Points[0].PuAfter +
                                                 lambdas.lam2 * tr.Points[1].PuAfter +
                                                 lambdas.lam3 * tr.Points[2].PuAfter);
                Vector3 Pv = Vector3.Normalize(lambdas.lam1 * tr.Points[0].PvAfter +
                                                 lambdas.lam2 * tr.Points[1].PvAfter +
                                                 lambdas.lam3 * tr.Points[2].PvAfter);
                Matrix4x4 matrix = new Matrix4x4(Pu.X, Pv.X, N.X, 0,
                                                Pu.Y, Pv.Y, N.Y, 0,
                                                Pu.Z, Pv.Z, N.Z, 0,
                                                0, 0, 0, 1);
                N = Vector3.Transform(nNormalMap.Value, matrix);
            }

            Vector3 interpolated = lambdas.lam1 * tr.Points[0].RotatedPosition +
                                    lambdas.lam2 * tr.Points[1].RotatedPosition +
                                    lambdas.lam3 * tr.Points[2].RotatedPosition;
            Vector3 L = Vector3.Normalize(lightPos - interpolated);
            Vector3 R = Vector3.Normalize(2 * Vector3.Dot(N, L) * N - L);

            Vector3 V = new Vector3(0, 0, 1);
            float cos1 = Vector3.Dot(N, L);
            cos1 = cos1 < 0 ? 0 : cos1;
            float cos2 = ReturnCosForLight(lightSource, V, R, L);
            cos2 = MathF.Pow(cos2, m);
            cos2 = cos2 < 0 ? 0 : cos2;
            float rO = (float)color.R / 255;
            float gO = (float)color.G / 255;
            float bO = (float)color.B / 255;

            float rL = (float)lightColor.R / 255;
            float gL = (float)lightColor.G / 255;
            float bL = (float)lightColor.B / 255;

            float r = lightSource.IsOn * (kd * rL * rO * cos1 + ks * rL * rO * cos2);
            float g = lightSource.IsOn * (kd * gL * gO * cos1 + ks * gL * gO * cos2);
            float b = lightSource.IsOn * (kd * bL * bO * cos1 + ks * bL * bO * cos2);

            r = r * 255;
            r = r > 255 ? 255 : r;
            g = g * 255;
            g = g > 255 ? 255 : g;
            b = b * 255;
            b = b > 255 ? 255 : b;
            return new Vector3(r, g, b);
            //return Color.FromArgb((int)r, (int)g, (int)b);
        }

        public float ReturnCosForLight(LightSource lightSource, Vector3 V, Vector3 R, Vector3 L)
        {
            return Vector3.Dot(V, R);
        }

        public float ReturnCosForLight(LightSourceDirect lightSource, Vector3 V, Vector3 R, Vector3 L)
        {
            return Vector3.Dot(L, lightSource.Lr);
        }

        // This part of code is unused, but I leave it, may be in future I'll need it

    }
}
