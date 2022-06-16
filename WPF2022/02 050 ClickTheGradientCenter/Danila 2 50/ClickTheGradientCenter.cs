namespace Petzold.ClickTheGradientCenter
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    class ClickTheGradientCenter : Window
    {
        /*используется конструктор RadialGradientBrush с двумя 
        аргументами, определяющий цвет GradientOrigin и цвет на периметре эллипса. При этом
        программа задает свойства RadiusX и RadiusY равными 0,10, а свойство Spread-
        Method равным Repeat, чтобы кисть выглядела как набор концентрических 
        градиентных кругов.*/


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
            /*Программа переопределяет OnMouseDown для обработки щелчков в 
            клиентской области. Левая кнопка мыши задает свойствам Center и GradientOrigin 
            одинаковые значения, а вся кисть просто сдвигается от центра клиентской области.
            Щелчок правой кнопкой мыши изменяет только GradientOrigin. */
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