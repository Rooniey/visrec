using PolygonLibrary.Exceptions;
using System;
using Utility = PolygonLibrary.PolygonLibraryUtility;

namespace PolygonLibrary
{
    public class RegularPolygon
    {
        private readonly Vertex[] _vertices;

        public Vertex[] Vertices
        {
            get
            {
                Vertex[] copy = new Vertex[_vertices.Length];
                Array.Copy(_vertices, copy, _vertices.Length);
                return copy;
            }
        }

        public double SideLength { get; }

        public int NumberOfSides => _vertices.Length;

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

        public double CalculateArea()
        {
            return (1.0 / 4) * NumberOfSides
                             * Math.Pow(SideLength, 2)
                             * (1 / Math.Tan(Math.PI / NumberOfSides));
        }
    }
}