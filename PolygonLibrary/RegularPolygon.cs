using PolygonLibrary.Exceptions;
using System;
using System.Text;
using Utility = PolygonLibrary.PolygonLibraryUtility;

namespace PolygonLibrary
{
    public class RegularPolygon
    {
        private readonly Vertex[] _vertices;

        /// <summary>
        /// Readonly property that returns a copy of the array of vertices in order to ensure the regular polygon's correct state
        /// </summary>
        public Vertex[] Vertices
        {
            get
            {
                Vertex[] copy = new Vertex[_vertices.Length];
                Array.Copy(_vertices, copy, _vertices.Length);
                return copy;
            }
        }

        /// <summary>
        /// Readonly property (ensure the regular polygon's correct state) that returns regular polygon's side length.
        /// </summary>
        public double SideLength { get; }

        /// <summary>
        /// Readonly property (ensure the regular polygon's correct state) that returns regular polygon's number of sides.
        /// It returns the length of the inside array of vertices.
        /// </summary>
        public int NumberOfSides => _vertices.Length;

        /// <summary>
        /// If an array of vertices meets the requirements (at least 3 vertices, all sides are of equal length), constructs the regular polygon.
        /// </summary>
        /// <exception cref="PolygonLibrary.Exceptions.RegularPolygonLogicalException">
        ///     If one of the logical requirements is not fulfilled, throws exception.
        /// </exception>
        /// <param name="vertices">Array of vertices that creates regular polygon</param>
        public RegularPolygon(Vertex[] vertices)
        {
            if (vertices == null) throw new RegularPolygonLogicalException("Regular polygon can not be created without providing vertices.");
            if (vertices.Length < 3) throw new RegularPolygonLogicalException($"Regular polygon has at least 3 vertices ({vertices.Length} < 3).");

            double sideLength = vertices[0].CalculateLength(vertices[vertices.Length - 1]);
            for (int i = 0; i < vertices.Length - 1; i++)
            {
                if (!Utility.CompareDouble(vertices[i].CalculateLength(vertices[i + 1]), sideLength))
                {
                    throw new RegularPolygonLogicalException("Regular polygon must have all sides the same length.");
                }
            }

            _vertices = vertices;
            SideLength = sideLength;
        }

        /// <summary>
        /// Calculates the area of regular polygon using methematical formula: P = (1/4)*n*(a^2)*ctg(PI/n),
        /// where:
        /// n - number of sides
        /// a - side length
        /// </summary>
        /// <returns>area of regular polygon</returns>
        public double CalculateArea()
        {
            return (1.0 / 4) * NumberOfSides
                             * Math.Pow(SideLength, 2)
                             * (1 / Math.Tan(Math.PI / NumberOfSides));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(FormattableString.Invariant($"Area: {CalculateArea():F}"));
            sb.AppendLine("Vertices: ");
            foreach (var vertex in _vertices)
            {
                sb.AppendLine(FormattableString.Invariant($"({vertex.X:F}, {vertex.Y:F}) "));
            }

            return sb.ToString();
        }
    }
}