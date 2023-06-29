using System;
using System.Windows;
using System.Windows.Input;
namespace Petzold.ThrowWindowParty
{
    class ThrowWindowParty : Application
    {
        [STAThread] // запускает в одном потоке
        public static void Main()
        {
            ThrowWindowParty app = new ThrowWindowParty(); //создание объекта приложения
            app.Run(); //запуск приложения
        }
        protected override void OnStartup(StartupEventArgs args)
        {

            //метод выполняется при запуске приложения
            Window winMain = new Window(); //создается окно
            winMain.Title = "Main Window";  //добавляется название окна
            winMain.MouseDown += WindowOnMouseDown; //добавление события нажатие на кнопку мыши
            winMain.Show(); // отображение окна
            //в данном цикле происходить добавление еще 2 окон
            //а так же добавление к этим окнам названий
            //и их отображение на экране
            for (int i = 0; i < 2; i++)
            {
                Window win = new Window();
                win.Title = "Extra Window No. " + (i + 1);
                win.Show();
            }
        }
        void WindowOnMouseDown(object sender, MouseButtonEventArgs args)
        {
            //создает окно добавляет ему название и отображает в виде диалогового окна
            Window win = new Window();
            win.Title = "Modal Dialog Box";
            win.ShowDialog();
        }
    }
}