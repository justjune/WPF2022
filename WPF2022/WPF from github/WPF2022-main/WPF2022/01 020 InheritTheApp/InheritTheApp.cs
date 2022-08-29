//---------------------------------------------- 
// InheritTheApp.cs (c) 2006 by Charles Petzold 
//----------------------------------------------
//Hacked by A.Kandrina
using System;
using System.Windows;
using System.Windows.Input;
namespace Petzold.InheritTheApp
{
    class InheritTheApp : Application //класс, производный от Application
    {
        [STAThread] //используется однопоточная модель
        public static void Main()
        {
            InheritTheApp app = new InheritTheApp(); //создаем объект типа InheritTheApp
            app.Run(); //вызов метода Run, котрый запускает цикл сообщений
        }
        protected override void OnStartup(StartupEventArgs args) //переопределение метода OnStartu
        {
            base.OnStartup(args); //вызов метода базового класса
            Window win = new Window(); //создание объекта типа Window
            win.Title = "Inherit the App"; //определение текста заголовка окна
            win.Show(); //отображение окна на экране
        }
        protected override void OnSessionEnding(SessionEndingCancelEventArgs args) //переопределение метода OnSessionEnding
        {
            base.OnSessionEnding(args); //вызов метода базового класса
            MessageBoxResult result = MessageBox.Show("Do you want to  save your data?", MainWindow.Title, 
            MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Yes); //вывод окна сообщения с кнопками Yes, No и Cancel
            args.Cancel = (result == MessageBoxResult.Cancel); //установление флага Cancel объекта SessionEndingCancelEventArgs
        }
    }
}
