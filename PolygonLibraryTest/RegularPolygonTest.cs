using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolygonLibrary;
using PolygonLibrary.Exceptions;

namespace PolygonLibraryTest
{
    [TestClass]
    public class RegularPolygonTest
    {
        [TestMethod]
        public void CalculateArea_WhenCalled_ShouldReturnProperValues()
        {
            //creating regular hexagon with the side length of 2
            Vertex[] vertices = new Vertex[]
            {
                new Vertex(0, 0),
                new Vertex(2, 0),
                new Vertex(3, 1.732),
                new Vertex(2, 3.464),
                new Vertex(0, 3.464),
                new Vertex(-1, 1.732)
            };
            RegularPolygon polygon = new RegularPolygon(vertices);

            Assert.AreEqual(10.39, polygon.CalculateArea(), 0.01);
        }

        [TestMethod]
        public void Constructor_After_ShouldReturnProperSideLength()
        {
            //creating regular hexagon with the side length of 2
            Vertex[] vertices = new Vertex[]
            {
                new Vertex(0, 0),
                new Vertex(2, 0),
                new Vertex(3, 1.732),
                new Vertex(2, 3.464),
                new Vertex(0, 3.464),
                new Vertex(-1, 1.732)
            };
            RegularPolygon polygon = new RegularPolygon(vertices);

            Assert.AreEqual(2.00, polygon.SideLength, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(RegularPolygonLogicalException))]
        public void Constructor_WhenCalledWithNullVertices_ShouldThrowException_()
        {
            RegularPolygon polygon = new RegularPolygon(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RegularPolygonLogicalException))]
        public void Constructor_WhenCalledWithLessThanThreeVertices_ShouldThrowException_()
        {
            Vertex[] vertices = new Vertex[]
            {
                new Vertex(0, 0),
                new Vertex(2, 0),
            };
            RegularPolygon polygon = new RegularPolygon(vertices);
        }

        [TestMethod]
        [ExpectedException(typeof(RegularPolygonLogicalException))]
        public void Constructor_WhenCalledWithUnequalSideLengths_ShouldThrowException_()
        {
            Vertex[] vertices = new Vertex[]
            {
                new Vertex(0, 0),
                new Vertex(2, 0),
                new Vertex(2, 3)
            };
            RegularPolygon polygon = new RegularPolygon(vertices);
        }

        [TestMethod]
        [ExpectedException(typeof(RegularPolygonLogicalException))]
        public void Constructor_WhenCalledWithRhombus_ShouldThrowException_()
        {
            //creating rhombus with the side length of sqrt(2)
            Vertex[] vertices = new Vertex[]
            {
                new Vertex(0, 0),
                new Vertex(Math.Sqrt(2), 0),
                new Vertex(1 + Math.Sqrt(2), 1),
                new Vertex(1, 1)
            };
            RegularPolygon polygon = new RegularPolygon(vertices);
        }

        [TestMethod]
        [ExpectedException(typeof(RegularPolygonLogicalException))]
        public void Constructor_WhenCalledWithNotUniqueVertices_ShouldThrowException_()
        {
            Vertex[] vertices = new Vertex[]
            {
                new Vertex(0, 0),
                new Vertex(2, 0),
                new Vertex(0,0)
            };
            RegularPolygon polygon = new RegularPolygon(vertices);
        }
    }
}