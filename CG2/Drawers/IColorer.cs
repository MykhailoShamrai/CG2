using CG2.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CG2.Drawers
{
    public interface IColorer
    {
        public int Mdirect { get; set; }
        public DirectBitmap? Image { get; set; }
        public DirectBitmap? NormalMap { get; set; }
        public float Kd { get; set; }
        public float Ks { get; set; }
        public int M { get; set; }
        public void DrawHorizontalLineBetween(LightSource lightSource, AbstractPolygon polygon, int x1, int x2, int y, Color color, DirectBitmap canvas, LightSourceDirect[] direct);
        public void DrawHorizontalLineBetween(LightSource lightSource, Triangle polygon, int x1, int x2, int y, Color color, DirectBitmap canvas, LightSourceDirect[] directs);
    }
}
