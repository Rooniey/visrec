using PolygonLibrary.Exceptions;
using System;

namespace PolygonLibrary
{
    /// <summary>
    /// Regular polygon factory. Implementation of factory pattern.
    /// </summary>
    public class RegularPolygonFactory
    {
        /// <summary>
        /// Given the arguments, creates proper regular polygon, using the presented algorithm:
        ///     1. Add the initial vertex to the array of vertices and initialize current angle with 0 value.
        ///     2. Calculate the position of the next vertex by using the previous vertex' coordinates.
        ///         Translate the previous vertex' positon by the translation vector (determined by the side length and the current angle value)
        ///     3. Increment the current angle value (counter clockwise) to specify the direction of the next translation vector.
        ///     4. If all vertices were determined - quit algorithm, otherwise go to step 2.
        /// The arguments of the method must meet the requirements presented below:
        /// - numberOfVertices > 2
        /// - sideLength > 0
        /// </summary>
        /// <exception cref="PolygonLibrary.Exceptions.RegularPolygonFactoryLogicalException">
        ///     If one of the logical requirements is not fulfilled, throws exception.
        /// </exception>
        /// <param name="numberOfVertices">Number of regular polygon's vertices.</param>
        /// <param name="sideLength">Regular polygon's side length.</param>
        /// <param name="initialVertex">Regular polygon's initial vertex.</param>
        /// <returns>Regular polygon </returns>
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