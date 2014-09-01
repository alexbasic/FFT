using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FFT
{
    public static class Helper
    {
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
