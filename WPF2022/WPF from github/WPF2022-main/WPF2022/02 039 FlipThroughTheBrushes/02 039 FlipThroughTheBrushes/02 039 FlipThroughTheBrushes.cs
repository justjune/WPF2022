//------------------------------------------------------
// FlipThroughTheBrushes.cs (c) 2006 by Charles  Petzold 
//------------------------------------------------------
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.FlipThroughTheBrushes
{
    public class FlipThroughTheBrushes : Window// создан класс FlipThroughTheBrushes типа Window
    {
        int index = 0;
        PropertyInfo[] props;
        [STAThread]
        public static void Main()
        {
            Application app = new Application();// создание приложения
            app.Run(new FlipThroughTheBrushes());// открывает окно приложения
        }
        public FlipThroughTheBrushes()
        {
            props = typeof(Brushes).GetProperties(BindingFlags.Public | BindingFlags.Static);
            SetTitleAndBackground();
        }
        protected override void OnKeyDown(KeyEventArgs args)
        {
            if (args.Key == Key.Down || args.Key == Key.Up)// нажатие на кнопки
            {
                index += args.Key == Key.Up ? 1 : props.Length - 1;// реагирует на нажатие и меняет цвета
                index %= props.Length;
                SetTitleAndBackground();// вызов метода SetTitleAndBackground
            }
            base.OnKeyDown(args);
        }
        void SetTitleAndBackground()// создание метода SetTitleAndBackground, задающего цвет окну
        {
            Title = "Flip Through the Brushes - " + props[index].Name;
            Background = (Brush)props[index].GetValue(null, null);
        }
    }
}