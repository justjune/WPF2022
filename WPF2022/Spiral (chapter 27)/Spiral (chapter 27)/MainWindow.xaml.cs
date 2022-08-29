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

namespace Spiral__chapter_27_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int revs = 20;
        const int numpts = 1000 * revs;
        Polyline poly;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Title = "Spiral";
            // Make Canvas content of window.
            Canvas canv = new Canvas();
            canv.SizeChanged += CanvasOnSizeChanged;
            Content = canv;
            // Make Polyline child of Canvas.
            poly = new Polyline();
            poly.Stroke = SystemColors.WindowTextBrush;
            canv.Children.Add(poly);
            // Define the points.
            Point[] pts = new Point[numpts];
            for (int i = 0; i < numpts; i++)
            {
                double angle = i * 2 * Math.PI / (numpts / revs);
                double scale = 250 * (1 - (double)i / numpts);
                pts[i].X = scale * Math.Cos(angle);
                pts[i].Y = scale * Math.Sin(angle);
            }
            poly.Points = new PointCollection(pts);
        }
        void CanvasOnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            Canvas.SetLeft(poly, args.NewSize.Width / 2);
            Canvas.SetTop(poly, args.NewSize.Height / 2);
        }
    }
}
/*using System; 
using System.Windows;
using System.Windows.Controls; 
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
 namespace Spiral {
    public class Spiral : Window { 
        const int revs = 20; 
        const int numpts = 1000 * revs; 
        Polyline poly; 
        [STAThread] 
        public static void Main() { 
            Application app = new Application();
            app.Run(new Spiral()); 
        } 
        public Spiral() {
            Title = "Spiral";  
            // Make Canvas content of window.
            Canvas canv = new Canvas();    
            canv.SizeChanged += CanvasOnSizeChanged; 
            Content = canv;          
            // Make Polyline child of Canvas.
            poly = new Polyline();  
            poly.Stroke = SystemColors .WindowTextBrush;  
            canv.Children.Add(poly);      
            // Define the points.
            Point[] pts = new Point[numpts];  
            for (int i = 0; i < numpts; i++)             {    
                double angle = i * 2 * Math.PI /  (numpts / revs);     
                double scale = 250 * (1 - (double)  i / numpts);   
                pts[i].X = scale * Math.Cos(angle);       
                pts[i].Y = scale * Math.Sin(angle);      
            }       
            poly.Points = new PointCollection(pts);      
        }     
        void CanvasOnSizeChanged(object sender,  SizeChangedEventArgs args)         {     
            Canvas.SetLeft(poly, args.NewSize .Width / 2);  
            Canvas.SetTop(poly, args.NewSize .Height / 2);   
        } 
    } 
} */