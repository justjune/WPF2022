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
            // Создание объекта StackPanel как содержимого окна
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            Content = stack;
            // Фиктивная кнопка для проверки передачи фокуса
            Button btn = new Button();
            btn.Content = "Do-nothing button\nto test tabbing";
            btn.Margin = new Thickness(24);
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            stack.Children.Add(btn);
            // Создание элемента ColorGridBox
            ColorGridBox clrgrid = new ColorGridBox();
            clrgrid.Margin = new Thickness(24);
            clrgrid.HorizontalAlignment = HorizontalAlignment.Center;
            clrgrid.VerticalAlignment = VerticalAlignment.Center;
            stack.Children.Add(clrgrid);
            // Привязка свойства Background окна
            // к выделенному значению ColorGridBox
            clrgrid.SetBinding(ColorGridBox.SelectedValueProperty, "Background");
            clrgrid.DataContext = this;
            // Создание другой фиктивной кнопки
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