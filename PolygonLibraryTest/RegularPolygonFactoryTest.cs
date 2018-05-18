using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolygonLibrary;
using PolygonLibrary.Exceptions;

namespace PolygonLibraryTest
{
    [TestClass]
    public class RegularPolygonFactoryTest
    {
        private RegularPolygonFactory _factory;
        private Vertex _initiaVertex;
        private double _standardLength;

        [TestInitialize]
        public void Setup()
        {
            _factory = new PolygonLibrary.RegularPolygonFactory();
            _initiaVertex = new Vertex(0, 0);
            _standardLength = 2.0;
        }

        [TestMethod]
        public void CreateEquilateralTriangleFromZeroZeroPoint()
        {
            int numberOfVertices = 3;
            RegularPolygon polygon = _factory.CreateRegularPolygon(numberOfVertices, _standardLength, _initiaVertex);
            Vertex[] vertices = polygon.Vertices;
            Assert.AreEqual(new Vertex(0, 0), vertices[0]);
            Assert.AreEqual(new Vertex(2, 0), vertices[1]);
            Assert.AreEqual(new Vertex(1, 1.73), vertices[2]);
        }

        [TestMethod]
        public void CreateRegularHexagonFromZeroZeroPoint()
        {
            int numberOfVertices = 6;
            RegularPolygon polygon = _factory.CreateRegularPolygon(numberOfVertices, _standardLength, _initiaVertex);
            Vertex[] vertices = polygon.Vertices;
            Assert.AreEqual(new Vertex(0, 0), vertices[0]);
            Assert.AreEqual(new Vertex(2, 0), vertices[1]);
            Assert.AreEqual(new Vertex(3, 1.73), vertices[2]);
            Assert.AreEqual(new Vertex(2, 3.46), vertices[3]);
            Assert.AreEqual(new Vertex(0, 3.46), vertices[4]);
            Assert.AreEqual(new Vertex(-1, 1.73), vertices[5]);
        }

        [TestMethod]
        [ExpectedException(typeof(RegularPolygonFactoryLogicalException))]
        public void CreateRegularPolygon_WhenCalledWithLessThanThreeVertices_ShouldThrowException()
        {
            int numberOfVertices = 2;
            RegularPolygon polygon = _factory.CreateRegularPolygon(numberOfVertices, _standardLength, _initiaVertex);
        }

        [TestMethod]
        [ExpectedException(typeof(RegularPolygonFactoryLogicalException))]
        public void CreateRegularPolygon_WhenCalledWithLessOrEqualZeroSideLength_ShouldThrowException()
        {
            double length = 0;
            RegularPolygon polygon = _factory.CreateRegularPolygon(6, length, _initiaVertex);
        }
    }
}