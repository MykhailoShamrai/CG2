using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CG2.Shapes
{
    public class MyPlane
    {
        public int LevelOfTriang { get; set; } = 1;
        private int _baseDimTriang = 4;
        private int _dim = 4;
        public List<Vector3> ControlPoints { get; set; }
        public List<Triangle> Triangles { get; set; }
        public MyPlane()
        {
            ControlPoints = new List<Vector3>();
            Triangles = new List<Triangle>();
            //Triangularization();
        }

        public void Triangularization()
        {
            // How  many triangles in one "column"
            // Is implemented only adding points to triangles. Now I want to check if it works
            int nn = _baseDimTriang * (1 << LevelOfTriang);
            int m = _dim;
            int n = _dim;
            float kk = 1f / nn; // in my case it's always is power of 2
            MyVertex[] points = new MyVertex[nn + 1];
            MyVertex[] newPoints = new MyVertex[nn + 1];
            Vector3 tmp;
            float v = 0;
            for (int vi = 0; vi <= nn; v += kk, vi++)
            {
                float u = 0;
                for (int ui = 0; ui <= nn; u += kk, ui++)
                {
                    //Math.
                    // Finding new vertex
                    tmp = new Vector3(0, 0, 0);
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            tmp += ControlPoints[m * i + j] * Bernstein(n - 1, i, u) * Bernstein(m - 1, j, v);
                        }
                    }
                    if (vi == 0)
                    {
                        MyVertex vert = new MyVertex();
                        vert.OriginalPosition = new Vector3(tmp.X, tmp.Y, tmp.Z);
                        points[ui] = vert;
                    }
                    else
                    {
                        MyVertex vert = new MyVertex();
                        vert.OriginalPosition = new Vector3(tmp.X, tmp.Y, tmp.Z);
                        newPoints[ui] = vert;
                        if (ui > 0)
                        {
                            // if it's any other case, we must add two triangles
                            Triangles.Add(new Triangle(points[ui - 1], points[ui], newPoints[ui]));
                            Triangles.Add(new Triangle(newPoints[ui], newPoints[ui - 1], points[ui - 1]));
                        }
                    }
                }
                if (vi != 0)
                {
                    Array.Copy(newPoints, points, points.Length);
                }
            }
        }

        public static Vector3 Bernstein(int n, int i, float u)
        {
            float firstNumerator = 1;
            float firstDenominator = 1;
            int kk = n - i;
            float secondNumerator = 1;
            float thirdNumerator = 1;
            float oneMinusU = 1f - u; 
            for (int j = kk + 1; j <= n; j++)
            {
                firstNumerator *= j;
            }
            for (int j = 1; j <= i; j++)
            {
                firstDenominator *= j;
                secondNumerator *= u; // elemeent by element multiplication
            }
            for (int j = 0; j < kk; j++)
            {
                thirdNumerator *= oneMinusU;
            }
            float tmp = firstNumerator / firstDenominator;
            Vector3 temp = new Vector3(tmp, tmp, tmp);
            return temp * secondNumerator * thirdNumerator;
        }
    }
}
