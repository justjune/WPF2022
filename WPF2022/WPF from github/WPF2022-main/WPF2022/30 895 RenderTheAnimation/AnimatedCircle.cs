using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
namespace Petzold.RenderTheAnimation { 
    class AnimatedCircle : FrameworkElement 
    { 
        protected override void OnRender(DrawingContext dc) // переопределяется метод OnRender
        {
            DoubleAnimation anima = new DoubleAnimation(); 
            anima.From = 0; // начальное значение,
            anima.To = 100; // конечное значение
            anima.Duration = new Duration(TimeSpan.FromSeconds(1)); // время анимации
            anima.AutoReverse = true; // Получает или задает значение, указывающее, воспроизводится ли временная шкала в обратном направлении после завершения прямой итерации.
            anima.RepeatBehavior = RepeatBehavior.Forever; // анимация продолжается бесконесное число раз
            AnimationClock clock = anima.CreateClock();
            dc.DrawEllipse(Brushes.Blue, new Pen(Brushes.Red, 3), new Point(125, 125), null, 0, clock, 0, clock); // рисует эллипс
        }
    }
}
