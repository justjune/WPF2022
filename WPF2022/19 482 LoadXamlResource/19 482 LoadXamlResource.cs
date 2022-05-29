using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
namespace Petzold.FormattedDigita1Clock
{ 
public class ClockTicker2 : INotifyPropertyChanged
{ 
    // Событие, необходимое для интерфейса INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    // Открытое свойство
    public DateTime DateTime
    {
        get { return DateTime.Now; }
    }
    // Установка таймера в конструкторе
    public ClockTicker2()
    {
        DispatcherTimer timer =
        new DispatcherTimer();
        timer.Tick += TimerOnTick;
        timer.Interval =
        TimeSpan.FromSeconds(1);
        timer.Start();
    }
    // Обработчик собьпил таймера инициирует событие PropertyChanged
    void TimerOnTick(object sender, EventArgs args)
    {
            if (PropertyChanged != null)
                PropertyChanged(this,new PropertyChangedEventArgs("DateTime"));
}
}
}
