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

namespace SimpleEllipse__chapter_10_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Grid grid)
        {
            Ellipse el = new Ellipse();
            el.Width = 50;
            el.Height = 50;
            el.VerticalAlignment = VerticalAlignment.Top;
            el.Fill = Brushes.Green;
            el.Stroke = Brushes.Red;
            el.StrokeThickness = 3;
            grid.Children.Add(el);
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ellipse el = new Ellipse();
            el.Width = 50;
            el.Height = 50;
            el.VerticalAlignment = VerticalAlignment.Top;
            el.Fill = Brushes.Green;
            el.Stroke = Brushes.Red;
            el.StrokeThickness = 3;
            //Grid.Children.Add(el);
        }
    }
}
/*using System; 
using System.Windows;
using System.Windows.Media;
 namespace Petzold.RenderTheGraphic { 
    class SimpleEllipse : FrameworkElement { 
        protected override void OnRender(DrawingContext dc) { 
            dc.DrawEllipse(Brushes.Blue, new Pen(Brushes.Red, 24), new Point(RenderSize.Width / 2, RenderSize.Height / 2), RenderSize.Width / 2, RenderSize.Height / 2); 
        } 
    } 
}*/