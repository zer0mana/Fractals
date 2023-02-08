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
    internal class SierpinskiTriangle : Fractal
    {
        public delegate void Build(Polygon line);
        public static event Build Builder;
        private int X1;
        private int X2;
        private int Y;
        private int Height;
        public SierpinskiTriangle(int x1, int x2, int y, int height, int depth) : base(depth)
        {
            X1 = x1;
            X2 = x2;
            Y = y;
            Height = height;
        }
        override public void BuildFractal()
        {
            if (Depth < 7)
            {
                Polygon n = new Polygon();
                n.Points.Add(new Point(X1, Y));
                n.Points.Add(new Point(X2, Y));
                n.Points.Add(new Point((X1 + X2) / (double)2, Y + Height));
                n.Stroke = new SolidColorBrush(Colors.Blue);
                Builder(n);
                new SierpinskiTriangle(X1, (X2 - X1) / 2 + X1, Y, Height / 2, Depth + 1).BuildFractal();
                new SierpinskiTriangle((X2 - X1) / 2 + X1, X2, Y, Height / 2, Depth + 1).BuildFractal();
                //SerpinskiiTriangle((x2 - x1) / 4 + x1, 3 * (x2 - x1) / 4 + x1, y + height / 2, -height / 2, depth + 1);
                new SierpinskiTriangle((X2 - X1) / 4 + X1, 3 * (X2 - X1) / 4 + X1, Y + Height / 2, Height / 2, Depth + 1).BuildFractal();
            }
        }
    }
}
