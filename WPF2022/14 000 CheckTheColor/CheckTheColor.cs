using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Petzold.CheckTheColor
{
    public class CheckTheColor : Window
    {
        TextBlock text;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new CheckTheColor());
        }
        
        public CheckTheColor()
        {
            Title = "Check the Color";

            // Создание DockPanel для размещения элементов.
            DockPanel dock = new DockPanel();
            Content = dock;

            // Создание Menu и привязка его к верхней части DockPanel.
            Menu menu = new Menu();
            dock.Children.Add(menu);
            DockPanel.SetDock(menu, Dock.Top);

            // Создание TextBlock, заполняющего оставшуюся часть окна.
            text = new TextBlock();
            text.Text = Title;
            text.TextAlignment = TextAlignment.Center;
            text.FontSize = 32;
            text.Background = SystemColors.WindowBrush;
            text.Foreground = SystemColors.WindowTextBrush;
            dock.Children.Add(text);

            // Создание пункта меню "Color".
            MenuItem itemColor = new MenuItem();
            itemColor.Header = "_Color";
            menu.Items.Add(itemColor);

            // Создание подпункта меню "Foreground" и его обработчиков.
            MenuItem itemForeground = new MenuItem();
            itemForeground.Header = "_Foreground";
            itemForeground.SubmenuOpened += ForegroundOnOpened;
            itemColor.Items.Add(itemForeground);
            FillWithColors(itemForeground, ForegroundOnClick);

            // Создание подпункта меню "Background" и его обработчиков.
            MenuItem itemBackground = new MenuItem();
            itemBackground.Header = "_Background";
            itemBackground.SubmenuOpened += BackgroundOnOpened;
            itemColor.Items.Add(itemBackground);
            FillWithColors(itemBackground, BackgroundOnClick);
        }

        // Заполнение подпункта меню цветами из класса Colors.
        void FillWithColors(MenuItem itemParent, RoutedEventHandler handler)
        {
            foreach (PropertyInfo prop in typeof(Colors).GetProperties())
            {
                Color clr = (Color)prop.GetValue(null, null);
                int iCount = 0;
                iCount += clr.R == 0 || clr.R == 255 ? 1 : 0;
                iCount += clr.G == 0 || clr.G == 255 ? 1 : 0;
                iCount += clr.B == 0 || clr.B == 255 ? 1 : 0;

                // Фильтрация цветов: пропускаются цвета с неполностью непрозрачным значением и цвета, состоящие только из одной компоненты (R, G или B).
                if (clr.A == 255 && iCount > 1)
                {
                    MenuItem item = new MenuItem();
                    item.Header = "_" + prop.Name;
                    item.Tag = clr;
                    item.Click += handler;
                    itemParent.Items.Add(item);
                }
            }
        }

        // Обработчик события SubmenuOpened для подпункта меню "Foreground".
        // Отмечает текущий цвет в меню.
        void ForegroundOnOpened(object sender, RoutedEventArgs args)
        {
            MenuItem itemParent = sender as MenuItem;
            foreach (MenuItem item in itemParent.Items)
            {
                item.IsChecked = ((text.Foreground as SolidColorBrush).Color == (Color)item.Tag);
            }
        }

        // Обработчик события SubmenuOpened для подпункта меню "Background".
        // Отмечает текущий цвет в меню.
        void BackgroundOnOpened(object sender, RoutedEventArgs args)
        {
            MenuItem itemParent = sender as MenuItem;
            foreach (MenuItem item in itemParent.Items)
            {
                item.IsChecked = ((text.Background as SolidColorBrush).Color == (Color)item.Tag);
            }
        }

        // Обработчик события Click для подпункта меню "Foreground".
        // Изменяет цвет Foreground в TextBlock.
        void ForegroundOnClick(object sender, RoutedEventArgs args)
        {
            MenuItem item = sender as MenuItem;
            Color clr = (Color)item.Tag;
            text.Foreground = new SolidColorBrush(clr);
        }

        // Обработчик события Click для подпункта меню "Background".
        // Изменяет цвет Background в TextBlock.
        void BackgroundOnClick(object sender, RoutedEventArgs args)
        {
            MenuItem item = sender as MenuItem;
            Color clr = (Color)item.Tag;
            text.Background = new SolidColorBrush(clr);
        }
    }
}
