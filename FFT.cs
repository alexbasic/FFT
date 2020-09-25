using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FFT
{
    /// <summary>
    /// Implementation of fast fourier transform
    /// </summary>
    public class FFT
    {
        /// <summary>
        /// Converts signal to frequencies sequence
        /// </summary>
        public static Complex[] CalcForward(int[] input)
        {
            int N = input.Length;
            Complex[] complexResult = new Complex[N];
            int n2 = N / 2;
            Complex j = new Complex(0, 1);
            double pi2 = Math.PI * 2;
            for (int k = 0; k < N; k++)
            {
                Complex jpi2k = -j * pi2 * k;
                for (int n = 0; n < N; n++)
                {
                    Complex s = (jpi2k * n) / N;
                    complexResult[k] += Complex.Exp(s) * input[n];
                }
            }
            return complexResult;
        }

        /// <summary>
        /// Converts frequencies sequence to signal
        /// </summary>
        public static Complex[] CalcBackward(Complex[] input)
        {
            int N = input.Length;
            Complex[] complexResult = new Complex[N];
            int n2 = N / 2;
            Complex j = new Complex(0, 1);
            double pi2 = Math.PI * 2;
            for (int k = 0; k < N; k++)
            {
                Complex xk = new Complex(0, 0);
                Complex jpi2k = j * pi2 * k;
                for (int n = 0; n < N; n++)
                {
                    Complex s = (jpi2k * n) / N;
                    xk += Complex.Exp(s) * input[n];
                }
                complexResult[k] = xk/N;
            }
            return complexResult;
        }
    }
}
