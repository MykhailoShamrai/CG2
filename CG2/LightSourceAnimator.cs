using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CG2
{
    public class LightSourceAnimator
    {
        public LightSource LightSource { get; set; }
        public int Radius { get; set; }
        private int _radiusNow;
        public int Step { get; set; }
        private int _angle = 0;

        public void LightMove()
        {
            _angle = (_angle + 1) % 360;
            float radAngle = (_angle * (MathF.PI / 180)) % (2 * MathF.PI);
            _radiusNow += Step;
            if (_radiusNow + Step <= 0 || _radiusNow + Step > Radius)
            {
                Step = -Step;
            }
            
            LightSource.Position = new Vector3(MathF.Cos(radAngle) * _radiusNow, MathF.Sin(radAngle) * _radiusNow, LightSource.Position.Z);  
        }
    }
}
