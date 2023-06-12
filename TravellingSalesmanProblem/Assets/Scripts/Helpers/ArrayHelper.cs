using System;

namespace Helpers
{
    public static class ArrayHelper
    {
        public static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }

        public static void Copy(in int[] source, ref int[,] destination, int m)
        {
            Buffer.BlockCopy(
                source,
                0,
                destination,
                m * source.Length * sizeof(int),
                source.Length * sizeof(int));
        }
    }
}
