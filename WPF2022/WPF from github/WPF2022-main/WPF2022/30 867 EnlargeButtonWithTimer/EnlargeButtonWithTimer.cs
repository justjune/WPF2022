using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Petzold.EnlargeButtonWithTimer { 
    public class EnlargeButtonWithTimer : Window 
    {
        // исходный размер шрифта кнопки 12 
        const double initFontSize = 12; 
        // максимальный размер шрифта кнопки 48
        const double maxFontSize = 48; 

        Button btn;

        [STAThread]
        public static void Main() 
        { 
            Application app = new Application();
            app.Run(new EnlargeButtonWithTimer());
        } 
        public EnlargeButtonWithTimer() 
        { 
            Title = "Enlarge Button with Timer";

            btn = new Button
            {
                Content = "Expanding Button",
                FontSize = initFontSize,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            btn.Click += ButtonOnClick; Content = btn;
        } 
        void ButtonOnClick(object sender, RoutedEventArgs args) 
        {
            /*при щелчке создает объект DispatcherTimer, который 
             *каждую десятую долю секунды 
             *генерирует события Tick*/
            DispatcherTimer tmr = new DispatcherTimer();

            tmr.Interval = TimeSpan.FromSeconds(0.1);

            tmr.Tick += TimerOnTick; tmr.Start();
        } 
        void TimerOnTick(object sender, EventArgs args) 
        {
            // увеличивает FontSize на 2 едицины каждую 0.1 секунды
            btn.FontSize += 2;
            // если размер кнопки достигает 48 единиц
            if (btn.FontSize >= maxFontSize) 
            {
                // кнопка восстанавливается в исходном размере
                btn.FontSize = initFontSize;
                // таймер останавливается
                (sender as DispatcherTimer).Stop();
            } 
        } 
    }
}