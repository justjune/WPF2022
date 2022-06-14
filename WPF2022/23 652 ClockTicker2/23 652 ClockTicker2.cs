using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
namespace Petzold.FormattedDigita1Clock
{ /*Класс ClockTicker2 является частью нового проекта FormattedDigitalClock, 
который не только использует альтернативный способ оповещения об изменениях
свойства DateTime, по и предоставляет автору кода XAML большую гибкость
при форматировании объекта DateTime.
Формат даты и времени в программе DigitalClock определялся вызовом 
ToString для объекта DateTime. Однако в классе DateTime определяется 
перегруженная версия метода ToString, которая получает дополнительный аргумент с 
форматной строкой и может выводить дату и время в разных форматах. Например,
в формате «Т>> выводит время с секундами, а в формате «t» -
время без секунд.*/
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
