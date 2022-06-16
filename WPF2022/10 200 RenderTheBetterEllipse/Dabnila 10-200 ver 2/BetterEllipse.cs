namespace Petzold.RenderTheBetterEllipse
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    public class BetterEllipse : FrameworkElement
    {
        // Зависимые свойства
        public static readonly DependencyProperty FillProperty;
        public static readonly DependencyProperty StrokeProperty;



        static BetterEllipse()
        {
            FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(BetterEllipse),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
            StrokeProperty = DependencyProperty.Register("Stroke", typeof(Pen), typeof(BetterEllipse),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));
        }

         
        // Открытые интерфейсы к зависимым свойствам
        public Brush Fill
        {
            set { SetValue(FillProperty, value); }
            get { return (Brush)GetValue(FillProperty); }
        }

        public Pen Stroke
        {
            set { SetValue(StrokeProperty, value); }
            get { return (Pen)GetValue(StrokeProperty); }
        }

        // Переопределение MeasureOverride
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            Size sizeDesired = base.MeasureOverride(sizeAvailable);

            if (Stroke != null)
            {
                sizeDesired = new Size(Stroke.Thickness, Stroke.Thickness);
            }

            return sizeDesired;
        }
        // Переопределение OnRender
        protected override void OnRender(DrawingContext dc)
        {
            Size size = RenderSize;
            // Регулировка размера воспроизведения с учетом толщины Реп
            if (Stroke != null)
            {
                size.Width = Math.Max(0, size.Width - Stroke.Thickness);
                size.Height = Math.Max(0, size.Height - Stroke.Thickness);
            }
            // Рисование эллипса
            dc.DrawEllipse(Fill, Stroke, new Point(RenderSize.Width / 2, RenderSize.Height / 2),
                size.Width / 2, size.Height / 2);
        }

    }
}