using System;
using System.Windows;
using System.Windows.Input;

namespace Petzold.InheritAppAndWindow
/*Класс MyApplication, производный от Application, определяется следующим образом.В переопределении метода OnStartup класс создает объект типа MyWindow —
третьего класса проекта, производного от Window.*/
{
    class MyApplication : Application
    {
        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);

            MyWindow win = new MyWindow();
            win.Show();
        }
    }
}