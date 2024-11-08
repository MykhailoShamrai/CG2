using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CG2.Shapes
{
    public class MyPlane
    {
        public int LevelOfTriang { get; set; } = 2;
        private readonly int _baseDimTriang = 4;
        private readonly int _dim = 4;
        public List<Vector3> ControlPoints { get; set; }
        public List<Triangle> Triangles { get; set; }
        private float _xAngle = 0;
        private float _zAngle = 0;
        public float XAngle
        {
            get
            {
                return _xAngle;
            }
            set
            {
                // Stack overflow here???
                if (Math.Abs(_xAngle - value) > 10e-8)
                {
                    _xAngle = value;
                    OnAngleChanged(nameof(XAngle));
                }
            }
        }
        // alpha angle
        public float ZAngle
        {
            get
            {
                return _zAngle;
            }
            set
            {
                if (Math.Abs(_zAngle - value) > 10e-8)
                {
                    _zAngle = value;
                    OnAngleChanged(nameof(ZAngle));
                }
            }
        }

        private Matrix4x4 _zTransformMatrix = new Matrix4x4(1, 0, 0, 0,
                                                           0, 1, 0, 0,
                                                           0, 0, 1, 0,
                                                           0, 0, 0, 1);

        private Matrix4x4 _xTransformMatrix = new Matrix4x4(1, 0, 0, 0,
                                                           0, 1, 0, 0,
                                                           0, 0, 1, 0,
                                                           0, 0, 0, 1);

        //private EventHandler _onAngleChanged;
        public event EventHandler AngleChanged;
        private void OnAngleChanged(string propertyName)
        {
            AngleChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public MyPlane()
        {
            ControlPoints = new List<Vector3>();
            Triangles = new List<Triangle>();
            //Triangularization();
            AngleChanged += ChangeRotationMatrices;
        }

        private void ChangeRotationMatrices(object? sender, EventArgs e)
        {
            float sinOfZ = MathF.Sin(ZAngle);
            float sinOfX = MathF.Sin(XAngle);
            float cosOfZ = MathF.Cos(ZAngle);
            float cosOfX = MathF.Cos(XAngle);
            // Changing for ZTransformMatrix
            _zTransformMatrix[0, 0] = cosOfZ;
            _zTransformMatrix[0, 1] = -sinOfZ;
            _zTransformMatrix[1, 0] = sinOfZ;
            _zTransformMatrix[1, 1] = cosOfX;
            // Changing git XTransformMatrix
            _xTransformMatrix[1, 1] = cosOfX;
            _xTransformMatrix[1, 2] = -sinOfX;
            _xTransformMatrix[2, 1] = sinOfX;
            _xTransformMatrix[2, 2] = cosOfX;

            RotateAllTriangles();
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
                    MyVertex vert = new MyVertex();
                    vert.OriginalPosition = new Vector3(tmp.X, tmp.Y, tmp.Z);
                    vert.RotatedPosition = Vector3.Transform(Vector3.Transform(vert.OriginalPosition, _xTransformMatrix), _zTransformMatrix);
                    if (vi == 0)
                    {
                        points[ui] = vert;
                    }
                    else
                    {
                        //MyVertex vert = new MyVertex();
                        //vert.OriginalPosition = new Vector3(tmp.X, tmp.Y, tmp.Z);
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


        public void RotateAllTriangles()
        {
            foreach (Triangle triangle in Triangles)
            {
                foreach (MyVertex vert in triangle.Points)
                {
                    vert.RotatedPosition = Vector3.Transform(Vector3.Transform(vert.OriginalPosition, _xTransformMatrix), _zTransformMatrix);
                }
            }
        }
    }

}
