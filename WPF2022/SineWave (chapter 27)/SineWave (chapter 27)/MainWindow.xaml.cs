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

namespace SineWave__chapter_27_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Title = "Sine Wave";
            // Make Polyline content of window.
            Polyline poly = new Polyline();
            poly.VerticalAlignment = VerticalAlignment.Center;
            poly.Stroke = SystemColors.WindowTextBrush;
            poly.StrokeThickness = 2;
            Content = poly;
            // Define the points.
            for (int i = 0; i < 2000; i++)
                poly.Points.Add(new Point(i, 96 * (1 - Math.Sin(i * Math.PI / 192))));
        }
    }
}
/