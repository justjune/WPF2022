using System;
using System.Windows;
using System.Windows.Controls; //тут находятся классы, реализующие классические элементы управления
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.ClickTheButton
{
    public class ClickTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ClickTheButton());
        }
        public ClickTheButton()
        {
            Title = "Нажатие кнопки"; //название окна
            Button btn = new Button(); //этим классом представлена кнопка со свойством Content и событием Click
            btn.Content = "Нажми меня!";  //свойству Content объекта Button задается текстовая строка
            btn.Click += ButtonOnClick;
            Content = btn; //сам объект Button задаётся свойству Content объекта Window
        }
        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("Кнопка была нажата", Title);//при нажатии отобразится окно сообщений с сообщением "Кнопка была нажата"
                                                         //и заголовком "Нажатие кнопки"
        }
    }
}
