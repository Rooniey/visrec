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
            Assert.IsTrue(new Vertex(0, 0).Equals(vertices[0]));
            Assert.IsTrue(new Vertex(2, 0).Equals(vertices[1]));
            Assert.IsTrue(new Vertex(1, 1.73).Equals(vertices[2]));
        }

        [TestMethod]
        public void CreateRegularHexagonFromZeroZeroPoint()
        {

            int numberOfVertices = 6;
            RegularPolygon polygon = _factory.CreateRegularPolygon(numberOfVertices, _standardLength, _initiaVertex);
            Vertex[] vertices = polygon.Vertices;
            Assert.IsTrue(new Vertex(0, 0).Equals(vertices[0]));
            Assert.IsTrue(new Vertex(2, 0).Equals(vertices[1]));
            Assert.IsTrue(new Vertex(3, 1.73).Equals(vertices[2]));
            Assert.IsTrue(new Vertex(2, 3.464).Equals(vertices[3]));
            Assert.IsTrue(new Vertex(0, 3.46).Equals(vertices[4]));
            Assert.IsTrue(new Vertex(-1, 1.73).Equals(vertices[5]));
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