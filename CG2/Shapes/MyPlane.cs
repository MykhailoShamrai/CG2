using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CG2.Shapes
{
    public class MyPlane
    {
        public List<Vector3> ControlPoints { get; set; }
        
        public MyPlane()
        {
            ControlPoints = new List<Vector3>();
        }
    }
}
