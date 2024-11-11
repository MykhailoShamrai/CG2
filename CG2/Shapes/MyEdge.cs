using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG2.Shapes
{
    public class MyEdge
    {
        public MyVertex First { get; set; }
        public MyVertex Second { get; set; }
        public MyEdge(MyVertex first, MyVertex second)
        {
            First = first;
            Second = second;
        }
    }
}
