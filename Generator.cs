using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFT
{
    public static class Generator
    {
        public static int[] GetSin(int length, double hzRad = 6.28, int amplitude = 128)
        {
            int[] buf = new int[length];
            for (var i = 0; i < length; i++)
            {
                int v = (int)(Math.Sin(i / hzRad) * amplitude);
                if (v > 129) v = 129;
                if (v < -129) v = -129;
                buf[i] = v;
            }
            return buf;
        }

        public static int[] GetMeandr(int length, double hzRad = 6.28, int amplitude = 128)
        {
            int[] buf = new int[length];
            for (var i = 0; i < length; i++)
            {
                int v = (int)(Math.Sin(i / hzRad) * amplitude);
                if (v > 0) v = amplitude;
                if (v < 0) v = -amplitude;
                buf[i] = v;
            }
            return buf;
        }

        public static int[] CombineSignal(int[] signal1, int[] signal2)
        {
            int[] buf = new int[signal1.Length];
            for (var i = 0; i < signal1.Length; i++)
            {
                buf[i] = signal1[i] + signal2[i];
            }
            return buf;
        }
    }
}
