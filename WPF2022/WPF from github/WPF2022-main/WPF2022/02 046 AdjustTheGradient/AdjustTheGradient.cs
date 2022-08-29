//-------------------------------------------------- 
// AdjustTheGradient.cs (c) 2006 by Charles Petzold 
//--------------------------------------------------
// hacked by egor_dolgoshein
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace Petzold.AdjustTheGradient
{
    class AdjustTheGradient : Window // класс-наследник от класса window
    {
        LinearGradientBrush brush; // LinearGradientBrush закрашивает область линейным градиентом
        [STAThread] // используется один поток
        public static void Main()
        {
            Application app = new Application(); // создаем объект типа Application
            app.Run(new AdjustTheGradient()); // запуск 
        }
        public AdjustTheGradient()
        {
            Title = "Adjust the Gradient"; // название окна
            SizeChanged += WindowOnSizeChanged; // размеры окна
            brush = new LinearGradientBrush(Colors.Red, Colors.Blue, 0); // создание объекта "кисть" (аргументы - начальный цвет, конечный цвет, угол) // первые два аргумента - это диапазон цвета градиента
            brush.MappingMode = BrushMappingMode.Absolute; // MappingMode - это способ интерпретации координат, BrushMappingMode - непосредственно сама система координат, 
                                                           // Absolute говорит, что она является абсолютной (система координат не относительно ограничивающего прямоугольника)
            Background = brush; // значение кисти, которая используется для заливки фона
        }
        void WindowOnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            double width = ActualWidth - 2 * SystemParameters.ResizeFrameVerticalBorderWidth; // ширина - это ширина окна минус удвоенная ширина вертикальной рамки окна
            double height = ActualHeight - 2 * SystemParameters.ResizeFrameHorizontalBorderHeight - SystemParameters.CaptionHeight; // аналогично с шириной, но также вычитается высота заголовка
            Point ptCenter = new Point(width / 2, height / 2); // координаты цетра окна (полуширина, полувысота)
            Vector vectDiag = new Vector(width, -height); // диагональ от левого нижнего угла до правого верхнего
            Vector vectPerp = new Vector(vectDiag.Y, -vectDiag.X); // перпендикуляр к диагонали ( в скобках замена x->y и y->(-x) ) **угол получается действительно 90 градусов**
            vectPerp.Normalize(); // нормализация вектора (вектор -> орт)
            vectPerp *= width * height / vectDiag.Length; // расстояние от середины окна до точек начала и конца градиента
            brush.StartPoint = ptCenter + vectPerp; // начальная координата градиента
            brush.EndPoint = ptCenter - vectPerp; // конечная координата градиента
        }
    }
}