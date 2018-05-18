using System;
using Utility = PolygonLibrary.PolygonLibraryUtility;

namespace PolygonLibrary
{
    public struct Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vertex))
                return false;

            Vertex second = (Vertex)obj;

            if (Utility.CompareDouble(X, second.X) && Utility.CompareDouble(Y, second.Y))
            {
                return true;
            }

            return false;
        }

        public double CalculateLength(Vertex v)
        {
            return Math.Sqrt(Math.Pow(this.X - v.X, 2) + Math.Pow(this.Y - v.Y, 2));
        }
    }
}