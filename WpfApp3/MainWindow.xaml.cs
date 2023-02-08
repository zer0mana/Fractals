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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Polyline l = new Polyline();
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Не забудьте прочитать README");
            FractalTree.Builder += BuilderLine;
            KochCurve.Builder += BuilderPolyline;
            SierpinskiCarpet.Builder += BuilderPolygone;
            SierpinskiTriangle.Builder += BuilderPolygone;
            CantorSet.Builder += BuilderPolygone;
            AllButtonsHidden();
        }
        public void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Menu();
        }
        private void Menu()
        {
            switch (combobox.SelectedIndex)
            {
                case 0:
                    Canvas.Children.RemoveRange(0, Canvas.Children.Count);
                    Title2.Text = "Отношение длин отрезков на разных интерациях ";
                    TitleInformation();
                    slider1.Maximum = 10;
                    new FractalTree(10 - (int)slider1.Value, (int)slider3.Value, (int)slider4.Value, (int)Canvas.ActualWidth / 2, (int)Canvas.ActualHeight / 2, (int)Canvas.ActualHeight/8, (int)slider2.Value).BuildFractal();
                    break;
                case 1:
                    Canvas.Children.RemoveRange(0, Canvas.Children.Count);
                    slider1.Maximum = 6;
                    Polyline line = new Polyline();
                    line.Points.Add(new Point((int)Canvas.ActualWidth / 3, (int)Canvas.ActualHeight / 2));
                    line.Points.Add(new Point(2 * (int)Canvas.ActualWidth / 3, (int)Canvas.ActualHeight / 2));
                    line.Stroke = new SolidColorBrush(Colors.Blue);
                    TitleInformation();
                    new KochCurve(line, 6 - (int)slider1.Value).BuildFractal();
                    break;
                case 2:
                    slider1.Maximum = 5;
                    Canvas.Children.RemoveRange(0, Canvas.Children.Count);
                    TitleInformation();
                    new SierpinskiCarpet(3 * (int)Canvas.ActualWidth / 4, 3 * (int)Canvas.ActualHeight / 4, Math.Min((int)Canvas.ActualWidth / 2, (int)Canvas.ActualHeight / 2), 6 - (int)slider1.Value).BuildFractal();
                    break;
                case 3:
                    slider1.Maximum = 6;
                    Canvas.Children.RemoveRange(0, Canvas.Children.Count);
                    TitleInformation();
                    new SierpinskiTriangle((int)Canvas.ActualWidth / 3, 2 * (int)Canvas.ActualWidth / 3, 2 * (int)Canvas.ActualHeight / 3, -(int)Canvas.ActualHeight / 3, 6 - (int)slider1.Value).BuildFractal();
                    break;
                case 4:
                    Canvas.Children.RemoveRange(0, Canvas.Children.Count);
                    slider1.Maximum = 5;
                    Title2.Text = "Расстояние между итерациями ";
                    TitleInformation();
                    new CantorSet(3 * (int)Canvas.ActualWidth / 4, 2 * (int)Canvas.ActualHeight / 18, (int)Canvas.ActualHeight / 18, (int)Canvas.ActualWidth / 2, (int)(slider2.Value * (int)Canvas.ActualHeight / 32), 10 - (int)slider1.Value).BuildFractal();
                    break;

            }

        }
        public void BuilderLine(Line line)
        {
            Canvas.Children.Add(line);
        }
        public void BuilderPolyline(Polyline line)
        {
            Canvas.Children.Add(line);
        }
        public void BuilderPolygone(Polygon line)
        {
            Canvas.Children.Add(line);
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (combobox.SelectedIndex)
            {
                case 0:
                    AllButtonsVisible();
                    break;
                case 1:
                    AllButtonsHidden();
                    Title1.Visibility = Visibility.Visible;
                    slider1.Visibility = Visibility.Visible;
                    break;
                case 2:
                    AllButtonsHidden();
                    Title1.Visibility = Visibility.Visible;
                    slider1.Visibility = Visibility.Visible;
                    break;
                case 3:
                    AllButtonsHidden();
                    Title1.Visibility = Visibility.Visible;
                    slider1.Visibility = Visibility.Visible;
                    break;
                case 4:
                    AllButtonsHidden();
                    Title1.Visibility = Visibility.Visible;
                    slider1.Visibility = Visibility.Visible;
                    Title2.Visibility = Visibility.Visible;
                    slider2.Visibility = Visibility.Visible;
                    break;
            }
            SlidersDefault();
            Menu();
        }
        private void TitleInformation()
        {
            Title1.Text = Title1.Text.Split(' ')[0] + " " + slider1.Value;
            Title3.Text = Title3.Text.Remove(Title3.Text.LastIndexOf(' ')) + " " + slider3.Value + "°";
            Title4.Text = Title4.Text.Remove(Title4.Text.LastIndexOf(' ')) + " " + slider4.Value + "°";
            if (combobox.SelectedIndex == 0)
            {
                Title2.Text = $"{Title2.Text.Remove(Title2.Text.LastIndexOf(' '))} 1.{slider2.Value}";
            }
            else
            {
                Title2.Text = $"{Title2.Text.Remove(Title2.Text.LastIndexOf(' '))} {slider2.Value}00";
            }
        }
        private void SlidersDefault()
        {
            slider1.Value = 0;
            slider2.Value = 1;
            slider3.Value = 0;
            slider4.Value = 0;
        }
        private void AllButtonsVisible()
        {
            Title1.Visibility = Visibility.Visible;
            Title2.Visibility = Visibility.Visible;
            Title3.Visibility = Visibility.Visible;
            Title4.Visibility = Visibility.Visible;
            slider1.Visibility = Visibility.Visible;
            slider2.Visibility = Visibility.Visible;
            slider3.Visibility = Visibility.Visible;
            slider4.Visibility = Visibility.Visible;
        }
        private void AllButtonsHidden()
        {
            Title1.Visibility = Visibility.Hidden;
            Title2.Visibility = Visibility.Hidden;
            Title3.Visibility = Visibility.Hidden;
            Title4.Visibility = Visibility.Hidden;
            slider1.Visibility = Visibility.Hidden;
            slider2.Visibility = Visibility.Hidden;
            slider3.Visibility = Visibility.Hidden;
            slider4.Visibility = Visibility.Hidden;
        }
    }
}
