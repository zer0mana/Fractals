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
    internal class FractalTree : Fractal
    {
        public delegate void Build(Line line);
        public static event Build Builder;
        private int Angle1;
        private int Angle2;
        private int X;
        private int Y;
        private int Length;
        private int Ratio;
        public FractalTree(int depth, int angle1, int angle2, int x, int y, int length, int ratio) : base(depth)
        {
            Angle1 = angle1;
            Angle2 = angle2;
            X = x;
            Y = y;
            Length = length;
            Ratio = ratio;
        }
        override public void BuildFractal()
        {
            if (Depth < 10)
            {
                Line l1 = new Line();
                Line l2 = new Line();
                l1.X1 = X;
                l1.X2 = X + Length * Math.Cos(Angle1 * Math.PI / 180);
                l1.Y1 = Y;
                l1.Y2 = Y - Length * Math.Sin(Angle1 * Math.PI / 180);
                l2.X1 = X;
                l2.X2 = X + Length * Math.Cos(Angle2 * Math.PI / 180);
                l2.Y1 = Y;
                l2.Y2 = Y - Length * Math.Sin(Angle2 * Math.PI / 180);
                l1.Stroke = new SolidColorBrush(Colors.Blue);
                l2.Stroke = new SolidColorBrush(Colors.Red);
                Builder(l1);
                Builder(l2);
                new FractalTree(Depth + 1, Angle1 - 45, Angle2 - 45, (int)(X + Length * Math.Cos(Angle1 * Math.PI / 180)), (int)(Y - Length * Math.Sin(Angle1 * Math.PI / 180)), (int)(Length / (1 + Ratio * 0.1)), Ratio).BuildFractal();
                new FractalTree(Depth + 1, Angle1 + 45, Angle2 + 45, (int)(X + Length * Math.Cos(Angle2 * Math.PI / 180)), (int)(Y - Length * Math.Sin(Angle2 * Math.PI / 180)), (int)(Length / (1 + Ratio * 0.1)), Ratio).BuildFractal();
            }
        }
    }
}
