using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    internal class SierpinskiCarpet : Fractal
    {
        public delegate void Build(Polygon line);
        public static event Build Builder;
        private int X;
        private int Y;
        private int Length;
        public SierpinskiCarpet(int x, int y, int length, int depth) : base(depth)
        {
            X = x;
            Y = y;
            Length = length;
        }
        override public void BuildFractal()
        {
            if (Depth < 6)
            {
                Polygon n = new Polygon();
                n.Points.Add(new Point(X - Length, Y - Length));
                n.Points.Add(new Point(X, Y - Length));
                n.Points.Add(new Point(X, Y));
                n.Points.Add(new Point(X - Length, Y));
                n.Fill = new SolidColorBrush(Colors.Blue);
                Builder(n);
                Polygon w = new Polygon();
                w.Points.Add(new Point(X - Length / (double)3, Y - Length / (double)3));
                w.Points.Add(new Point(X - 2 * Length / (double)3, Y - Length / (double)3));
                w.Points.Add(new Point(X - 2 * Length / (double)3, Y - 2 * Length / (double)3));
                w.Points.Add(new Point(X - Length / (double)3, Y - 2 * Length / (double)3));
                w.Fill = new SolidColorBrush(Colors.White);
                Builder(w);
                for (var i1 = 0; i1 < 3; i1++)
                {
                    for (var i2 = 0; i2 < 3; i2++)
                    {
                        if (!((i1 == 1) & (i2 == 1)))
                        {
                            new SierpinskiCarpet(X - (int)(Length / (double)3) * i1, Y - (int)(Length / (double)3) * i2, (int)(Length / (double)3), Depth + 1).BuildFractal();
                        }
                    }
                }
            }
            else
            {
                Polygon n = new Polygon();
                n.Points.Add(new Point(X - Length, Y - Length));
                n.Points.Add(new Point(X, Y - Length));
                n.Points.Add(new Point(X, Y));
                n.Points.Add(new Point(X - Length, Y));
                n.Fill = new SolidColorBrush(Colors.Blue);
                Builder(n);
            }
        }
    }
}
