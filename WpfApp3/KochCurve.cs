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
    internal class KochCurve : Fractal
    {
        public delegate void Build(Polyline line);
        public static event Build Builder;
        private Polyline Line;
        public KochCurve(Polyline line, int depth) : base(depth)
        {
            Line = line;
        }
        override public void BuildFractal()
        {
            while (Depth < 6)
            {
                int n = Line.Points.Count;
                for (var i = 0; i < n - 1; i++)
                {
                    double x1 = Line.Points[4 * i].X;
                    double x2 = Line.Points[1 + 4 * i].X;
                    double y1 = Line.Points[4 * i].Y;
                    double y2 = Line.Points[1 + 4 * i].Y;
                    double xx1 = (x2 - x1) / 3 + x1;
                    double xx2 = 2 * (x2 - x1) / 3 + x1;
                    double yy1 = (y2 - y1) / 3 + y1;
                    double yy2 = 2 * (y2 - y1) / 3 + y1;
                    double x3 = (xx2 - xx1) / 2 + (yy2 - yy1) * Math.Sqrt(3) / 2 + xx1;
                    double y3 = - (xx2 - xx1) * Math.Sqrt(3) / 2 + (yy2 - yy1) / 2 + yy1;
                    Line.Points.Insert(1 + 4 * i, new Point(2 * (x2 - x1) / 3 + x1, 2 * (y2 - y1) / 3 + y1));
                    Line.Points.Insert(1 + 4 * i, new Point(x3, y3));
                    Line.Points.Insert(1 + 4 * i, new Point((x2 - x1) / 3 + x1, (y2 - y1) / 3 + y1));
                }
                Depth = Depth + 1;
            }
            Builder(Line);
        }
    }
}
