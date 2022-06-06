using System; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Input; 
using System.Windows.Media; 
using System.Globalization;
namespace Petzold.GetMedieval
{
    public class MedievalButton : Control
    {
        // Just two private fields.
        FormattedText formtxt;
        bool isMouseReallyOver;
        // Static readonly fields.
        public static readonly DependencyProperty TextProperty;
        public static readonly RoutedEvent KnockEvent;
        public static readonly RoutedEvent PreviewKnockEvent;
        // Static constructor.
        static MedievalButton()
        {
            // Register dependency property.
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MedievalButton), new FrameworkPropertyMetadata(" ", FrameworkPropertyMetadataOptions.AffectsMeasure));
            // Register routed events.
            KnockEvent = EventManager.RegisterRoutedEvent("Knock", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MedievalButton));
            PreviewKnockEvent = EventManager.RegisterRoutedEvent("PreviewKnock", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(MedievalButton));
        }
        // Public interface to dependency property.
        public string Text
        {
            set { SetValue(TextProperty, value == null ? " " : value); }
            get { return (string)GetValue(TextProperty); }
        }
        // Public interface to routed events.
        public event RoutedEventHandler Knock
        {
            add { AddHandler(KnockEvent, value); }
            remove { RemoveHandler(KnockEvent, value); }
        }
        public event RoutedEventHandler PreviewKnock
        {
            add { AddHandler(PreviewKnockEvent, value); }
            remove { RemoveHandler(PreviewKnockEvent, value); }
        }
        // MeasureOverride called whenever the size of  the button might change.
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            formtxt = new FormattedText(Text, CultureInfo.CurrentCulture, FlowDirection, new Typeface(FontFamily, FontStyle, FontWeight, FontStretch), FontSize, Foreground);
            // Take account of Padding when  calculating the size.
            Size sizeDesired = new Size(Math.Max(48, formtxt.Width) + 4, formtxt.Height + 4);
            sizeDesired.Width += Padding.Left + Padding.Right;
            sizeDesired.Height += Padding.Top + Padding.Bottom;
            return sizeDesired;
        }
        // OnRender called to redraw the button.
        protected override void OnRender(DrawingContext dc)
        {
            // Determine background color.
            Brush brushBackground = SystemColors.ControlBrush;
            if (isMouseReallyOver && IsMouseCaptured)
                brushBackground = SystemColors.ControlDarkBrush;
            // Determine pen width.
            Pen pen = new Pen(Foreground, IsMouseOver ? 2 : 1);
            // Draw filled rounded rectangle.
            dc.DrawRoundedRectangle(brushBackground, pen, new Rect(new Point(0, 0), RenderSize), 4, 4);
            // Determine foreground color.
            formtxt.SetForegroundBrush(IsEnabled ? Foreground : SystemColors.ControlDarkBrush);
            // Determine start point of text.
            Point ptText = new Point(2, 2);
            switch (HorizontalContentAlignment)
            {
                case HorizontalAlignment.Left:
                    ptText.X += Padding.Left;
                    break;
                case HorizontalAlignment.Right:
                    ptText.X += RenderSize.Width - formtxt.Width - Padding.Right;
                    break;
                case HorizontalAlignment.Center:
                case HorizontalAlignment.Stretch:
                    ptText.X += (RenderSize.Width - formtxt.Width - Padding.Left - Padding.Right) / 2;
                    break;
            }
            switch (VerticalContentAlignment)
            {
                case VerticalAlignment.Top:
                    ptText.Y += Padding.Top;
                    break;
                case VerticalAlignment.Bottom:
                    ptText.Y += RenderSize.Height - formtxt.Height - Padding.Bottom;
                    break;
                case VerticalAlignment.Center:
                case VerticalAlignment.Stretch:
                    ptText.Y += (RenderSize.Height - formtxt.Height - Padding.Top - Padding.Bottom) / 2;
                    break;
            }
            // Draw the text.
            dc.DrawText(formtxt, ptText);
        }
        // Mouse events that affect the visual  look of the button.
        protected override void OnMouseEnter(MouseEventArgs args)
        {
            base.OnMouseEnter(args);
            InvalidateVisual();
        }
        protected override void OnMouseLeave(MouseEventArgs args)
        {
            base.OnMouseLeave(args);
            InvalidateVisual();
        }
        protected override void OnMouseMove(MouseEventArgs args)
        {
            base.OnMouseMove(args);
            // Determine if mouse has really moved  inside or out.
            Point pt = args.GetPosition(this);
            bool isReallyOverNow = (pt.X >= 0 && pt.X < ActualWidth && pt.Y >= 0 && pt.Y < ActualHeight);
            if (isReallyOverNow != isMouseReallyOver)
            {
                isMouseReallyOver = isReallyOverNow;
                InvalidateVisual();
            }
        }
        // This is the start of how 'Knock' events  are triggered.
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs args)
        {
            base.OnMouseLeftButtonDown(args);
            CaptureMouse();
            InvalidateVisual();
            args.Handled = true;
        }
        // This event actually triggers the  'Knock' event.
    }
}
namespace Petzold.GetMedieval 
{     
    public class GetMedieval : Window     
    {         
        [STAThread]         
        public static void Main()         
        {             
            Application app = new Application();             
            app.Run(new GetMedieval());         
        }         
        public GetMedieval()         
        {             
            Title = "Get Medieval";             
            MedievalButton btn = new MedievalButton();             
            btn.Text = "Click this button";             
            btn.FontSize = 24;             
            btn.HorizontalAlignment =  HorizontalAlignment.Center;             
            btn.VerticalAlignment =  VerticalAlignment.Center;             
            btn.Padding = new Thickness(5, 20, 5, 20);             
            btn.Knock += ButtonOnKnock;             
            Content = btn;         
        }         
        void ButtonOnKnock(object sender,  RoutedEventArgs args)         
        {             
            MedievalButton btn = args.Source as  MedievalButton;             
            MessageBox.Show("The button labeled  \"" + btn.Text +"\" has been knocked." , Title);         
        }     
    } 
}