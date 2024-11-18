using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CG2
{
    public class LightSourceDirect: LightSource
    {
        public Vector3 Lr { get; set; }
        public LightSourceDirect(Vector3 pos, Color color)
        {
            
            IsOn = 0;
            Position = pos;
            Lr = Vector3.Normalize(pos);
            this.Color = color;
        }
    }
}
