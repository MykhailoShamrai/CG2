using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CG2
{
    public class LightSource
    {
        public Vector3 Position { get; set; }
        public Color Color { get; set; }
        public int IsOn { get; set; } = 1; // 1 or 0
    }
}
