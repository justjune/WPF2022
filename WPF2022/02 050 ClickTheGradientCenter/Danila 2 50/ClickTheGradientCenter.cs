namespace Petzold.ClickTheGradientCenter
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    class ClickTheGradientCenter : Window
    {


        RadialGradientBrush brush;



        public ClickTheGradientCenter()
        {
            Title = "Click the Gradient Center";

            brush = new RadialGradientBrush(Colors.White, Colors.Red);
            brush.RadiusX = brush.RadiusY = 0.1;
            brush.SpreadMethod = GradientSpreadMethod.Repeat;
            Background = brush;
        }



        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ClickTheGradientCenter());
        }

        protected override void OnMouseDown(MouseButtonEventArgs args)
        {
            double width = ActualWidth - 2 * SystemParameters.ResizeFrameVerticalBorderWidth;
            double height = ActualHeight - 2 * SystemParameters.ResizeFrameHorizontalBorderHeight - SystemParameters.CaptionHeight;
            Point ptMouse = args.GetPosition(this);
            ptMouse.X /= width;
            ptMouse.Y /= height;

            if (args.ChangedButton == MouseButton.Left)
            {
                brush.Center = ptMouse;
                brush.GradientOrigin = ptMouse;
            }
            else if (args.ChangedButton == MouseButton.Right)
            {
                brush.GradientOrigin = ptMouse;
            }
        }

    }
}