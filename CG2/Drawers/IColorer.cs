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
        public void DrawLineBetween(Vector3 lightPosition, AbstractPolygon polygon, int x1, int x2, int y, Color color, DirectBitmap canvas);
        public void DrawLineBetween(Vector3 lightPosition, Triangle polygon, int x1, int x2, int y, Color color, DirectBitmap canvas);
    }
}
