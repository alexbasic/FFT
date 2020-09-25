using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFT
{
    /// <summary>
    /// Window class for displaying charts and signals
    /// </summary>
    public class PlotWindow
    {
        private Task _task;

        public Form form { get; set; }

        public int[] SignalBuffer { get; set; }
        public bool DrawLine { get; set; }

        public bool Invert { get; set; }

        public PlotWindow(string name, int[] buffer, bool invert = true, bool drawLine = false)
        {
            DrawLine = drawLine;
            Invert = invert;
            SignalBuffer = buffer;
            MakeWindow(name);
        }

        public PlotWindow(string name)
        {
            MakeWindow(name);
        }

        private void MakeWindow(string name) 
        {
            Action<object> action = (object obj) =>
            {
                form = new Form();
                form.Name = obj.ToString();
                form.Text = obj.ToString();
                form.Left = 50;
                form.Top = 50;
                form.Width = 400;
                form.Height = 400;
                form.Paint += OnPaint;
                form.Resize += OnResize;
                form.Show();
                Application.Run(form);
            };
            _task = Task.Factory.StartNew(action, name);
        }

        private void OnResize(object sender, EventArgs e)
        {
            (sender as Form)?.Refresh();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            int y0 = 0;
            int y1 = 0;
            if (SignalBuffer != null)
            {
                int deltaHeight = e.ClipRectangle.Height / 2;
                e.Graphics.DrawLine(Pens.Red,
                        0, deltaHeight,
                        e.ClipRectangle.Width, deltaHeight);
                for (var i = 0; i < SignalBuffer.Length - 1; i++)
                {
                    if (DrawLine && (i % 10) == 0)
                    {
                        e.Graphics.DrawLine(Pens.Red,
                        i, deltaHeight,
                        i, deltaHeight+5);
                    }
                    y0 = deltaHeight + SignalBuffer[i];
                    y1 = deltaHeight + SignalBuffer[i + 1];
                    if (Invert)
                    {
                        y0 = e.ClipRectangle.Height - y0;
                        y1 = e.ClipRectangle.Height - y1;
                    }
                    e.Graphics.DrawLine(Pens.Black, 
                        i, y0,
                        i + 1, y1);
                }
            }
        }
    }
}
