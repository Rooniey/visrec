using System;

namespace PolygonLibrary
{
    public static class PolygonLibraryUtility
    {
        private static readonly double _doubleComparisonPrecision = 0.01;

        public static bool CompareDouble(double x1, double x2)
        {
            return Math.Abs(x1 - x2) < _doubleComparisonPrecision;
        }
    }
}