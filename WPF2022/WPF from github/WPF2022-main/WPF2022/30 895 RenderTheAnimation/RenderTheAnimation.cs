using System;
using System.Windows;
namespace Petzold.RenderTheAnimation 
{ 
    class RenderTheAnimation : Window 
    {
        [STAThread] // управление программой осуществляется одним главным потоком

        public static void Main() // точка входа выполняемой программы
        { 
            Application app = new Application(); // создание нового приложения
            app.Run(new RenderTheAnimation()); // запускает приложение 
        } 
        
        public RenderTheAnimation() { 
            Title = "Render the Animation"; // задаёт заголовок окна
            Content = new AnimatedCircle(); // экземпляр класса AnimatedCircle присвоивается содержимому окна 
        }
    }
}