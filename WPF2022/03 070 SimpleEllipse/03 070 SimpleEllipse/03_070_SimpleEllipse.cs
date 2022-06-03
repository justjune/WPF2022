using System; 
using System.Windows; 
using System.Windows.Media; 
namespace Petzold.RenderTheGraphic 
{     
    class SimpleEllipse : FrameworkElement     
    {         
        protected override void OnRender (DrawingContext dc)         
        {             
            dc.DrawEllipse(Brushes.Blue, 
                new Pen (Brushes.Red, 15),new Point(RenderSize.Width / 2,  RenderSize.Height / 2),
                RenderSize.Width / 2, RenderSize .Height / 2);         
        }
        class RenderTheGraphic : Window
        {
            [STAThread]
            public static void Main()
            {
                Application app = new Application();
                app.Run(new ReplaceMainWindow());
            }

            public void ReplaceMainWindow()
            {
                Title = "Render the Graphic";
                SimpleEllipse elips = new SimpleEllipse();
                Content = elips;
            }
        }
    }

    internal class ReplaceMainWindow : Window
    {
    }
}
