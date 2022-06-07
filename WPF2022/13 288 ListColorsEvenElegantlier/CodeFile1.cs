//--------- -------------------------------------------------
// ListColorsEvenElegantlier.cs (c) 2006 by  Charles Petzold
//------------------------------------------------ ----------
using Petzold.ListNamedBrushes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Petzold.ListColorsEvenElegantlier
{
    public class ListColorsEvenElegantlier : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ListColorsEvenElegantlier());
        }
        public ListColorsEvenElegantlier()
        {
            Title = "List Colors Even Elegantlier";
            // Создание шаблона DataTemlate для вариантов
            DataTemplate template = new DataTemplate(typeof(NamedBrush));
            // Создание объекта FrameorkElemenntFactory для StackPanel 
            FrameworkElementFactory factoryStack =
                new FrameworkElementFactory(typeof(StackPanel));
            factoryStack.SetValue(StackPanel.OrientationProperty,
                Orientation.Horizontal);
            //  Назначение объекта корнем визуального дерева DataTemplate.
            template.VisualTree = factoryStack;
            // Создание объекта FrameworkElementFactory для Rectangle.
            FrameworkElementFactory factoryRectangle =
                new FrameworkElementFactory(typeof(Rectangle));
            factoryRectangle.SetValue(Rectangle.WidthProperty, 16.0);
            factoryRectangle.SetValue(Rectangle.HeightProperty, 16.0);
            factoryRectangle.SetValue(Rectangle.MarginProperty, new Thickness(2));
            factoryRectangle.SetValue(Rectangle.StrokeProperty,
                SystemColors.WindowTextBrush);
            factoryRectangle.SetBinding(Rectangle.FillProperty,
                new Binding("Brush"));
            // Добавление к StackPanel.
            factoryStack.AppendChild(factoryRectangle);
            // Создание объекта FrameworkElementFactory  для TextBlock.
            FrameworkElementFactory factoryTextBlock =
                new FrameworkElementFactory(typeof(TextBlock));
            factoryTextBlock.SetValue(TextBlock.VerticalAlignmentProperty,
                VerticalAlignment.Center);
            factoryTextBlock.SetValue(TextBlock.TextProperty,
                new Binding("Name"));
            // Снова добавление к StackPanel.
            factoryStack.AppendChild(factoryTextBlock);
            // Создание объекта ListBox как содержимого окна.
            ListBox lstbox = new ListBox();
            lstbox.Width = 150;
            lstbox.Height = 150;
            Content = lstbox;
            // Свойству ItemTemplate задаётся ранее созданный шаблон.
            lstbox.ItemTemplate = template;
            // Свойству ItemsSource задаётся массив объектов NamedBrush.
            lstbox.ItemsSource = NamedBrush.All;
            //SelectedValue привязывается к свойству Background окна.
            lstbox.SelectedValuePath = "Brush";
            lstbox.SetBinding(ListBox.SelectedValueProperty, "Background");
            lstbox.DataContext = this;
        }
    }
}