using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FFT
{
    class Program
    {
        static void Main(string[] args)
        {
            int period = 1024;
            int[] signal = Generator.GetSin(period, 30, 128);
            int[] signal2 = Generator.GetSin(period, 1.5, 0);
            signal = Generator.CombineSignal(signal, signal2);
            //signal = GetMeandr(period);
            Complex[] output = FFT.CalcForward(signal);
            var pl = new PlotWindow("signal", signal);
            var p2 = new PlotWindow("FFT", Converter.ComplexToInt(output, 0.03, true));
            var p3 = new PlotWindow("sin", Converter.ComplexToInt(FFT.CalcBackward(output)));
            Console.WriteLine("Waiting for exit...");
            Console.ReadKey();
        }
    }
}
