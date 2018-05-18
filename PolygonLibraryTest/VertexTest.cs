using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolygonLibrary;

namespace PolygonLibraryTest
{
    [TestClass]
    public class VertexTest
    {
        private Vertex _sampleVertex;

        [TestInitialize]
        public void Setup()
        {
            _sampleVertex = new Vertex(3, 4);
        }

        [TestMethod]
        public void CalculateLength_WhenCalled_ShouldReturnCorrectValue()
        {
            Vertex v = new Vertex(0, 0);

            Assert.AreEqual(5.0, _sampleVertex.CalculateLength(v), 0.00001);
        }

        [TestMethod]
        public void Equals_WhenCalledOnEqualVertices_ShouldReturnTrue()
        {
            Vertex v = new Vertex(3, 4);

            Assert.IsTrue(_sampleVertex.Equals(v));
        }

        [TestMethod]
        public void Equals_WhenCalledOnUnequalVertices_ShouldReturnFalse()
        {
            Vertex v = new Vertex(1, 4);

            Assert.IsFalse(_sampleVertex.Equals(v));
        }

        [TestMethod]
        public void Equals_WhenCalledOnVertexAndNull_ShouldReturnFalse()
        {
            Assert.IsFalse(_sampleVertex.Equals(null));
        }
    }
}