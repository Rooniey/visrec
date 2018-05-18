using PolygonLibrary.Exceptions;
using System;

namespace PolygonLibrary
{
    public class RegularPolygonFactory
    {
        public RegularPolygon CreateRegularPolygon(int numberOfVertices, double sideLength, Vertex initialVertex)
        {
            if (numberOfVertices < 3) throw new RegularPolygonFactoryLogicalException("Number of vertices must be greater than 2.");
            if (sideLength <= 0) throw new RegularPolygonFactoryLogicalException("The side length must be greater than zero.");

            Vertex[] vertices = new Vertex[numberOfVertices];
            vertices[0] = initialVertex;
            double currentAngle = 0;

            for (int i = 1; i < numberOfVertices; i++)
            {
                double dx = sideLength * Math.Cos(currentAngle);
                double dy = sideLength * Math.Sin(currentAngle);
                vertices[i] = new Vertex(vertices[i - 1].X + dx, vertices[i - 1].Y + dy);
                currentAngle += (2 * Math.PI / numberOfVertices);
            }

            return new RegularPolygon(vertices);
        }
    }
}