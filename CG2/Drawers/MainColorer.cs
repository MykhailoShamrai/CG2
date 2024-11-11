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
            while (x1 < x2)
            {
                canvas.SetPixel(x1, y, color);
                x1 += k;
            }
        }

        public void DrawLineBetween(Vector3 lightPosition, AbstractPolygon polygon, int x1, int x2, int y, Color color, DirectBitmap canvas)
        {
            throw new NotImplementedException();
        }
    }
}
