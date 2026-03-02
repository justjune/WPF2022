//--------------------------------------------
// RadialPanel.cs (c) 2006 by Charles Petzold
//-------------------------------------------

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.CircleTheButtons
{
    public class RadialPanel : Panel
    {
        // Зависимое свойство.
        public static readonly DependencyProperty OrientationProperty;

        // Приватные поля.
        bool showPieLines;
        double angleEach;       // угол для каждого элемента
        Size sizeLargest;       // размер самого большого элемента
        double radius;          // радиус окружности
        double outerEdgeFromCenter;
        double innerEdgeFromCenter;

        // Статический конструктор для создания зависимого свойства Orientation.
        static RadialPanel()
        {
            OrientationProperty =
                DependencyProperty.Register("Orientation",
                                            typeof(RadialPanelOrientation),
                                            typeof(RadialPanel),
                                            new FrameworkPropertyMetadata(RadialPanelOrientation.ByWidth,
                                                                          FrameworkPropertyMetadataOptions.AffectsMeasure));
        }

        // Свойство Orientation.
        public RadialPanelOrientation Orientation
        {
            set { SetValue(OrientationProperty, value); }
            get { return (RadialPanelOrientation)GetValue(OrientationProperty); }
        }

        // Свойство ShowPieLines.
        public bool ShowPieLines
        {
            set
            {
                if (value != showPieLines)
                    InvalidateVisual();

                showPieLines = value;
            }
            get
            {
                return showPieLines;
            }
        }

        // Переопределение метода MeasureOverride.
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            if (InternalChildren.Count == 0)
                return new Size(0, 0);

            angleEach = 360.0 / InternalChildren.Count;
            sizeLargest = new Size(0, 0);

            foreach (UIElement child in InternalChildren)
            {
                // Вызов метода Measure для каждого дочернего элемента...
                child.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));

                // ...а затем проверка свойства DesiredSize дочернего элемента.
                sizeLargest.Width = Math.Max(sizeLargest.Width, child.DesiredSize.Width);
                sizeLargest.Height = Math.Max(sizeLargest.Height, child.DesiredSize.Height);
            }

            if (Orientation == RadialPanelOrientation.ByWidth)
            {
                // Рассчет расстояния от центра до границ элемента.
                innerEdgeFromCenter = sizeLargest.Width / 2 /
                                      Math.Tan(Math.PI * angleEach / 360);

                outerEdgeFromCenter = innerEdgeFromCenter + sizeLargest.Height;

                // Рассчет радиуса окружности на основе размера самого большого элемента.
                radius = Math.Sqrt(Math.Pow(sizeLargest.Width / 2, 2) +
                                   Math.Pow(outerEdgeFromCenter, 2));
            }
            else
            {
                // Рассчет расстояния от центра до границ элемента.
                innerEdgeFromCenter = sizeLargest.Height / 2 /
                                      Math.Tan(Math.PI * angleEach / 360);

                outerEdgeFromCenter = innerEdgeFromCenter + sizeLargest.Width;

                // Рассчет радиуса окружности на основе размера самого большого элемента.
                radius = Math.Sqrt(Math.Pow(sizeLargest.Height / 2, 2) +
                                   Math.Pow(outerEdgeFromCenter, 2));
            }

            // Возвращение размера окружности.
            return new Size(2 * radius, 2 * radius);
        }

        // Переопределение метода ArrangeOverride.
        protected override Size ArrangeOverride(Size sizeFinal)
        {
            double angleChild = 0;
            Point ptCenter = new Point(sizeFinal.Width / 2, sizeFinal.Height / 2);

            double multiplier = Math.Min(sizeFinal.Width / (2 * radius),
                                          sizeFinal.Height / (2 * radius));

            foreach (UIElement child in InternalChildren)
            {
                // Сброс свойства RenderTransform.
                child.RenderTransform = Transform.Identity;

                if (Orientation == RadialPanelOrientation.ByWidth)
                {
                    // Размещение элемента сверху.
                    child.Arrange(
                        new Rect(ptCenter.X - multiplier * sizeLargest.Width / 2,
                                 ptCenter.Y - multiplier * outerEdgeFromCenter,
                                 multiplier * sizeLargest.Width,
                                 multiplier * sizeLargest.Height));
                }
                else
                {
                    // Размещение элемента справа.
                    child.Arrange(
                        new Rect(ptCenter.X + multiplier * innerEdgeFromCenter,
                                 ptCenter.Y - multiplier * sizeLargest.Height / 2,
                                 multiplier * sizeLargest.Width,
                                 multiplier * sizeLargest.Height));
                }

                // Вращение элемента вокруг центра (относительно элемента).
                Point pt = TranslatePoint(ptCenter, child);
                child.RenderTransform =
                    new RotateTransform(angleChild, pt.X, pt.Y);

                // Увеличение угла.
                angleChild += angleEach;
            }

            return sizeFinal;
        }

        // Переопределение метода OnRender для отображения дополнительных линий-секторов.
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            if (ShowPieLines)
            {
                Point ptCenter = new Point(RenderSize.Width / 2, RenderSize.Height / 2);

                double multiplier = Math.Min(RenderSize.Width / (2 * radius),
                                              RenderSize.Height / (2 * radius));

                Pen pen = new Pen(SystemColors.WindowTextBrush, 1);
                pen.DashStyle = DashStyles.Dash;

                // Отображение окружности.
                dc.DrawEllipse(null, pen, ptCenter, multiplier * radius,
                                               multiplier * radius);

                // Инициализация угла.
                double angleChild = -angleEach / 2;

                if (Orientation == RadialPanelOrientation.ByWidth)
                    angleChild += 90;

                // Перебор каждого дочернего элемента для рисования радиальных линий из центра.
                foreach (UIElement child in InternalChildren)
                {
                    dc.DrawLine(pen, ptCenter,
                        new Point(ptCenter.X + multiplier * radius *
                                   Math.Cos(2 * Math.PI * angleChild / 360),
                                  ptCenter.Y + multiplier * radius *
                                   Math.Sin(2 * Math.PI * angleChild / 360)));

                    angleChild += angleEach;
                }
            }
        }
    }
}
//Класс RadialPanel есть свойства и методы:
//Orientation - свойство, которое определяет ориентацию расположения элементов внутри панели
//(RadialPanelOrientation.ByWidth или RadialPanelOrientation.ByHeight).
//ShowPieLines - свойство, которое определяет, должны ли отображаться дополнительные линии-секторы.
//MeasureOverride - переопределенный метод, который выполняет измерение размеров панели и ее дочерних элементов.
//ArrangeOverride - переопределенный метод, который размещает дочерние элементы внутри панели в круговом порядке.
//OnRender - переопределенный метод, который рисует дополнительные линии-секторы, если
//ShowPieLines установлено в true.
//Этот код представляет основу для создания пользовательской панели, которая располагает элементы в круговом порядке. 
