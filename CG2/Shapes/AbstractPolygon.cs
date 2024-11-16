﻿using CG2.Drawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CG2.Shapes
{
    public abstract class AbstractPolygon
    {
        public MyVertex[] Points { get; set; }
        public MyEdge[] Edges { get; set; }
        public virtual void VisitColorer(IColorer colorer, LightSource lightSource, int x1, int x2, int y, Color color, DirectBitmap canvas)
        {
            colorer.DrawHorizontalLineBetween(lightSource, this, x1, x2, y, color, canvas);
        }

        // Method for filling edges of a polygon
        public virtual void VisitColorerEdges(IColorer colorer, LightSource lihgtSource, Color color, DirectBitmap canvas)
        {
            colorer.DrawLineBetween(lihgtSource, this, color, canvas);
        }
    }
}
