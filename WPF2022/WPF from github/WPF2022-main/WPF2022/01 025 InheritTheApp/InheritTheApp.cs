using System;
using System.Windows;

namespace Petzold.InheritTheApp
{
    class InheritTheApp : Application
    {
        [STAThread]

        public static void Main()
        {
            InheritTheApp app = new InheritTheApp();
            app.Run();
        }
        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);

            Window win = new Window
            {
                Title = "Inherit the App"
            };
            win.Show();
        }

        /* событие SessionEnding происходит, когда пользователь завершает сеанс Windows,
        выходя из системы или завершая работу операционной системы.
        */
        protected override void OnSessionEnding(SessionEndingCancelEventArgs args)
        {
            base.OnSessionEnding(args);
            Console.WriteLine("hi");

            MessageBoxResult result = MessageBox.Show(
                "Do you want to  save your data?",
                MainWindow.Title,
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question,
                MessageBoxResult.Yes
            );

            args.Cancel = result == MessageBoxResult.Cancel;
        }
    }
}
