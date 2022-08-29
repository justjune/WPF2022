using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Petzold.LoadXamlResource 
{ 
    public class LoadXamlResource : Window // создание класса LoadXamlResource, наследника Window
    {
        [STAThread] // атрибут, который показывает, что управление программой осуществляется одним главным потоком
        public static void Main() // точка входа выполняемой программы
        { 
            Application app = new Application(); // создание нового приложения 
            app.Run(new LoadXamlResource()); // запуск приложения
        }
        public LoadXamlResource() { 
            Title = "Load Xaml Resource";  // заголовок окна

            Uri uri = new Uri("/LoadXamlResource.xml", UriKind.Relative); // создание относительного uri

            Stream stream = Application.GetResourceStream(uri).Stream; // возвращает поток ресурса для файла данных ресурса, расположенного в указанном Uri
            FrameworkElement el = XamlReader.Load(stream) as FrameworkElement;  // cчитывает входные данные XAML и возвращает корень соответствующего дерева объектов
            Content = el;
            Button btn = el.FindName("MyButton") as Button;

            if (btn != null) btn.Click += ButtonOnClick;
        } 
        // обработчик события onClick 
        void ButtonOnClick(object sender, RoutedEventArgs args) 
        { 
            MessageBox.Show("The button labeled '" + (args.Source as Button).Content + "' has been clicked"); // вывод сообщения при нажатии на кнопку
        } 
    } 
}