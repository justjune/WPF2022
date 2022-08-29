using System;
using System.Windows;
using System.Windows.Input;

namespace Petzold.InheritTheApp
{
    class InheritTheApp : Application    //Класс, производный от Application.
    {
        [STAThread]
        public static void Main(string[] args)
        {
            InheritTheApp app = new InheritTheApp();

            Window win = new Window();             //Создание окна.
            win.Title = "Inherit the App";         //Заголовок окна.    
            win.Show();                            //Отображение на экране.
        }
        protected override void OnSessionEnding(SessionEndingCancelEventArgs args) //Метод, указывающий, что пользователь завершил сеанс.        
        {
            base.OnSessionEnding(args);

            MessageBoxResult result =
               MessageBox.Show("Do you want to  save your data?",   //Отображает окно сообщения.                          
                  MainWindow.Title,                       //Главное окно приложения.
                  MessageBoxButton.YesNoCancel,           //Задает кнопки, отображаемые в окне сообщения.                      
                  MessageBoxImage.Question,              //Задает значок, который отображается в окне.
                  MessageBoxResult.Yes);                  //Указывает кнопку в окне сообщения,нажатую пользователем.
            args.Cancel = (result == MessageBoxResult.Cancel);       //Отмена события.  
        }
    }
}
app.Run();                   //Запустить цикл сообщений для приложения.
        }         
        protected override void OnStartup(StartupEventArgs args)       //Метод, формирующий событие запуска.   
{
    base.OnStartup(args);
