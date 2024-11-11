using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CG2.Shapes
{
    public class MyVertex
    {
        public Vector3 OriginalPosition { get; set; }
        public Vector3 RotatedPosition { get; set; }
        public Vector3 PuBefore { get; set; }
        public Vector3 PvBefore { get; set; }
        public Vector3 NBefore { get; set; }
        public Vector3 PuAfter { get; set; }
        public Vector3 PvAfter { get; set; }
        public Vector3 NAfter { get; set; }
        public float U { get; set; }
        public float V { get; set; }
    }
}
