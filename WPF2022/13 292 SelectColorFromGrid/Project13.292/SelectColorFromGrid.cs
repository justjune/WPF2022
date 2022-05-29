namespace Petzold.SelectColorFromGrid
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    public class SelectColorFromGrid : Window
    {


        public SelectColorFromGrid()
        {
            Title = "Select Color from Grid";
            SizeToContent = SizeToContent.WidthAndHeight;

            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            Content = stack;

            Button btn = new Button();
            btn.Content = "Do-nothing button\nto test tabbing";
            btn.Margin = new Thickness(24);
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            stack.Children.Add(btn);

            ColorGridBox clrgrid = new ColorGridBox();
            clrgrid.Margin = new Thickness(24);
            clrgrid.HorizontalAlignment = HorizontalAlignment.Center;
            clrgrid.VerticalAlignment = VerticalAlignment.Center;
            stack.Children.Add(clrgrid);

            clrgrid.SetBinding(ColorGridBox.SelectedValueProperty, "Background");
            clrgrid.DataContext = this;

            btn = new Button();
            btn.Content = "Do-nothing button\nto test tabbing";
            btn.Margin = new Thickness(24);
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            stack.Children.Add(btn);
        }


        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SelectColorFromGrid());
        }

    }
}