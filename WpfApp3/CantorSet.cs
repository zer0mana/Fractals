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
    internal class CantorSet : Fractal
    {
        public delegate void Build(Polygon line);
        public static event Build Builder;

        private int X;
        private int Y;
        private int Height;
        private int Length;
        private int Ratio;
        public CantorSet(int x, int y, int height, int length, int ratio, int depth) : base(depth)
        {
            X = x;
            Y = y;
            Height = height;
            Length = length;
            Ratio = ratio;
        }
        override public void BuildFractal()
        {
            if (Depth < 10)
            {
                Polygon polygon = new Polygon();
                polygon.Points.Add(new Point(X - Length, Y - Height));
                polygon.Points.Add(new Point(X, Y - Height));
                polygon.Points.Add(new Point(X, Y));
                polygon.Points.Add(new Point(X - Length, Y));
                polygon.Fill = new SolidColorBrush(Colors.Blue);
                Builder(polygon);
                new CantorSet(X - 2 * Length / 3, Y + Ratio + Height, Height, Length / 3, Ratio, Depth + 1).BuildFractal();
                new CantorSet(X, Y + Ratio + Height, Height, Length / 3, Ratio, Depth + 1).BuildFractal();
            }
            else
            {
                Polygon polygon = new Polygon();
                polygon.Points.Add(new Point(X - Length, Y - Height));
                polygon.Points.Add(new Point(X, Y - Height));
                polygon.Points.Add(new Point(X, Y));
                polygon.Points.Add(new Point(X - Length, Y));
                polygon.Fill = new SolidColorBrush(Colors.Blue);
                Builder(polygon);
            }
        }
    }
}
