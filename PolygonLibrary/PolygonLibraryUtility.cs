using System;

namespace PolygonLibrary
{
    /// <summary>
    /// Helper class that stores common resources and provides basic utilities
    /// </summary>
    public static class PolygonLibraryUtility
    {
        private static readonly double _doubleComparisonPrecision = 0.01;

        /// <summary>
        /// Compares two double values. If their absolute difference is: less than the given precision returns true; greater than the given precision returns false.
        /// The double comparison precision is stored in _doubleComparisonPrecision variable.
        /// </summary>
        /// <param name="x1">first value to compare</param>
        /// <param name="x2">second value to compare </param>
        /// <returns></returns>
        public static bool CompareDouble(double x1, double x2)
        {
            return Math.Abs(x1 - x2) < _doubleComparisonPrecision;
        }
    }
}