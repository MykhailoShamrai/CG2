using CG2.Drawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CG2.Shapes
{
    public class Cube
    {
        // Cube can be representecd as two planes
        public int size = 6;
        public MainDrawer[] drawers { get; set; }
        public MyPlane[] planes { get; set; }

        public Cube(DirectBitmap bitmap, IColorer colorer, int size)
        {
            this.size = size;
            planes = new MyPlane[size];
            drawers = new MainDrawer[size];
            
            for (int i = 0; i < size; i++)
            {
                planes[i] = new MyPlane();
            }



            initCube();
            foreach (var plane in planes)
            {
                plane._dim_n = 2;
                plane._dim_m = 2;
                plane.RotatedControlPoints = new List<Vector3>(planes[0].ControlPoints);
                plane.Triangularization();
            }
            for (int i = 0; i < size; i++)
            {
                drawers[i] = new MainDrawer(planes[i], bitmap, colorer);
            }
        }

        // Hardcoded vertices for start
        public void initCube()
        {
            if (planes == null || planes[0] == null || planes[1] == null)
            {
                return;
            }
            if (size == 6)
            {
                // front
                planes[0].ControlPoints.Add(new System.Numerics.Vector3(-100.0f, -100.0f, 100.0f));
                planes[0].ControlPoints.Add(new System.Numerics.Vector3(-100.0f, 100.0f, 100.0f));
                planes[0].ControlPoints.Add(new System.Numerics.Vector3(100.0f, -100.0f, 100.0f));
                planes[0].ControlPoints.Add(new System.Numerics.Vector3(100.0f, 100.0f, 100.0f));

                // right side
                planes[1].ControlPoints.Add(new System.Numerics.Vector3( 100.0f, -100.0f, 100.0f));
                planes[1].ControlPoints.Add(new System.Numerics.Vector3( 100.0f,  100.0f, 100.0f));
                planes[1].ControlPoints.Add(new System.Numerics.Vector3( 100.0f, -100.0f, -100.0f));
                planes[1].ControlPoints.Add(new System.Numerics.Vector3( 100.0f,  100.0f, -100.0f));
                //
                //// top
                planes[2].ControlPoints.Add(new System.Numerics.Vector3(-100.0f, 100.0f, 100.0f));
                planes[2].ControlPoints.Add(new System.Numerics.Vector3(-100.0f, 100.0f, -100.0f));
                planes[2].ControlPoints.Add(new System.Numerics.Vector3(100.0f, 100.0f, 100.0f));
                planes[2].ControlPoints.Add(new System.Numerics.Vector3(100.0f, 100.0f, -100.0f));
                //
                //// left side
                planes[3].ControlPoints.Add(new System.Numerics.Vector3(-100.0f, -100.0f, -100.0f));
                planes[3].ControlPoints.Add(new System.Numerics.Vector3(-100.0f, 100.0f, -100.0f));
                planes[3].ControlPoints.Add(new System.Numerics.Vector3(-100.0f, -100.0f, 100.0f));
                planes[3].ControlPoints.Add(new System.Numerics.Vector3(-100.0f, 100.0f, 100.0f));

                // bottom
                planes[4].ControlPoints.Add(new System.Numerics.Vector3(-100.0f, -100.0f, 100.0f));
                planes[4].ControlPoints.Add(new System.Numerics.Vector3(-100.0f, -100.0f, -100.0f));
                planes[4].ControlPoints.Add(new System.Numerics.Vector3(100.0f, -100.0f, 100.0f));
                planes[4].ControlPoints.Add(new System.Numerics.Vector3(100.0f, -100.0f, -100.0f));

                // back
                planes[5].ControlPoints.Add(new System.Numerics.Vector3(-100.0f, -100.0f, -100.0f));
                planes[5].ControlPoints.Add(new System.Numerics.Vector3(-100.0f, 100.0f, -100.0f));
                planes[5].ControlPoints.Add(new System.Numerics.Vector3(100.0f, -100.0f, -100.0f));
                planes[5].ControlPoints.Add(new System.Numerics.Vector3(100.0f, 100.0f, -100.0f));
            }
            
        }
    }
}
