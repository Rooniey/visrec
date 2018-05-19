using System;
using Utility = PolygonLibrary.PolygonLibraryUtility;

namespace PolygonLibrary
{
    public struct Vertex : IEquatable<Vertex>
    {
        public double X { get; }
        public double Y { get; }

        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
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

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type. Uses PolygonLibraryUtility.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <see cref="PolygonLibrary.PolygonLibraryUtility.CompareDouble"/>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Vertex other)
        {
            return Utility.CompareDouble(X, other.X) && Utility.CompareDouble(Y, other.Y);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }
    }
}