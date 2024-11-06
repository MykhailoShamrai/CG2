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
        public Pen ControlPen = new Pen(Color.Crimson);
        public MyPlane Plane { get; set; }
        // beta angle
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

        private Matrix4x4 _zTransformMatrix = new Matrix4x4(1, 0 ,0, 0,
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
        public MainDrawer(MyPlane plane)
        {
            Plane = plane;
            AngleChanged += ChangeRotationMatrices;
            XAngle = 0;
            ZAngle = 0;
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
        }

        public void Draw(Graphics g)
        {
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
                    tmp = Vector3.Transform(Plane.ControlPoints[size * i + j], _zTransformMatrix);
                    tmp = Vector3.Transform(tmp, _xTransformMatrix);
                    g.DrawEllipse(ControlPen, tmp.X - 2, tmp.Y - 2, 4, 4);
                    if ((j - 1) >= 0)
                    {
                        tmp2 = Vector3.Transform(Plane.ControlPoints[size * i + j - 1], _zTransformMatrix);
                        tmp2 = Vector3.Transform(tmp2, _xTransformMatrix);
                        g.DrawLine(ControlPen, tmp.X, tmp.Y, tmp2.X, tmp2.Y);
                    }
                    if ((i - 1) >= 0)
                    {
                        tmp2 = Vector3.Transform(Plane.ControlPoints[size * (i - 1) + j], _zTransformMatrix);
                        tmp2 = Vector3.Transform(tmp2, _xTransformMatrix);
                        g.DrawLine(ControlPen, tmp.X, tmp.Y, tmp2.X, tmp2.Y);
                    }
                }
            }
        }
    }
}
