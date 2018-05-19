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

        /// <summary>
        /// Checks if the current vertex is equal to the provided object, using PolygonLibraryUtility class' CompareDouble method
        /// </summary>
        /// <see cref="PolygonLibraryUtility.CompareDouble(double, double)"/>
        /// <param name="obj">Object to compare</param>
        /// <returns>Objects' equality as boolean</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vertex))
                return false;

            Vertex second = (Vertex)obj;

            return Utility.CompareDouble(X, second.X) && Utility.CompareDouble(Y, second.Y);
        }

        /// <summary>
        /// Calculates the euclidean distance between the current vertex and the provided one
        /// </summary>
        /// <param name="v">Other vertex</param>
        /// <returns>Distance between vertices</returns>
        public double CalculateLength(Vertex v)
        {
            return Math.Sqrt(Math.Pow(this.X - v.X, 2) + Math.Pow(this.Y - v.Y, 2));
        }
    }
}