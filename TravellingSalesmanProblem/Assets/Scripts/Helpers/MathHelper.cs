using UnityEngine;

namespace Helpers
{
    public static class MathHelper
    {
        public static int Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        /*
        /// <summary>
        /// Intersection point of two line segments a1-a2 and b1-b2
        /// </summary>
        /// <param name="a1">Line A start point</param>
        /// <param name="a2">Line A finish point</param>
        /// <param name="b1">Line B start point</param>
        /// <param name="b2">Line B finish point</param>
        /// <returns>Intersection point</returns>
        public static Vector2 IntersectionPointOfTwoLineSegments(
            Vector2 a1, Vector2 a2,
            Vector2 b1, Vector2 b2)
        {
            if (a1 == b1 || a1 == b2 ||
                a2 == b1 || a2 == b2)
            {
                return Vector2.positiveInfinity;
            }

            var k = (b2.y - b1.y) * (a2.x - a1.x) - (b2.x - b1.x) * (a2.y - a1.y);

            var uAch = (b2.x - b1.x) * (a1.y - b1.y) - (b2.y - b1.y) * (a1.x - b1.x);
            var uBch = (a2.x - a1.x) * (a1.y - b1.y) - (a2.y - a1.y) * (a1.x - b1.x);

            if (uAch == 0f && uBch == 0f && k == 0f)
            {
                // The lines match
                return Vector2.positiveInfinity;
            }

            if (k == 0f)
            {
                // Parallel lines
                return Vector2.positiveInfinity;
            }

            var uA = uAch / k;
            var uB = uBch / k;

            if (uA < 0f || uA > 1f || uB < 0f || uB > 1f)
            {
                // No intersection point
                return Vector2.positiveInfinity;
            }

            var p = a1 + uA * (a2 - a1);
            return p;
        }
        */
    }
}
