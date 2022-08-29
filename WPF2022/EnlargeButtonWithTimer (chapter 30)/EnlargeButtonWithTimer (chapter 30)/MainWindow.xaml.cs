using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace EnlargeButtonWithTimer__chapter_30_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const double initFontSize = 12;
        const double maxFontSize = 48;
        Button btn;
        
        public MainWindow()
        {
            
            InitializeComponent();
        }
        private void Button_Click(object sender, EventArgs args)
        {
            Title = "Enlarge Button with Timer";
            btn = new Button();
            btn.Content = "Expanding Button";
            btn.FontSize = initFontSize;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Click += ButtonOnClick; Content = btn;
        }
        
         void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            DispatcherTimer tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromSeconds(0.1);
            tmr.Tick += TimerOnTick; tmr.Start();
        }
         void TimerOnTick(object sender, EventArgs args)
        {
            btn.FontSize += 2;
            if (btn.FontSize >= maxFontSize)
            {
                btn.FontSize = initFontSize;
                (sender as DispatcherTimer).Stop();
            }
        }
        
    }
}

