using System;
using System.Numerics;

namespace FFT
{
    /// <summary>
    /// For converting any values
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Converts Complex array to int array
        /// </summary>
        public static int[] ComplexToInt(Complex[] input, double multipler = 1, bool abs = false)
        {
            int N = input.Length;
            int[] result = new int[N];
            if (abs)
            {
                for (int i = 0; i < N; i++)
                {
                    result[i] = Math.Abs((int)(input[i].Real * multipler));
                }
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    result[i] = (int)input[i].Real;
                }
            }
            return result;
        }

        /// <summary>
        /// Converts Double array to int array
        /// </summary>
        public static int[] DoubleToInt(double[] input, double multipler=1, bool abs = false)
        {
            int N = input.Length;
            int[] result = new int[N];
            if (abs)
            {
                for (int i = 0; i < N; i++)
                {
                    result[i] = Math.Abs((int)(input[i] * multipler));
                }
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    result[i] = (int)(input[i] * multipler);
                }
            }
            return result;
        }
    }
}
