using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace Petzold.LoadEmbeddedXaml
{
    public class LoadEmbeddedXaml : Window
    {
        [STAThread]
        public static void Main()
        {
            // Создание и запуск приложения WPF.
            Application app = new Application();
            app.Run(new LoadEmbeddedXaml());
        }

        public LoadEmbeddedXaml()
        {
            // Задание заголовка окна.
            Title = "Load Embedded Xaml";

            // Задание строки XAML для создания кнопки.
            string strXaml =
                "<Button xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'" +
                "         Foreground='LightSeaGreen' FontSize='24pt'>" +
                "    Click me!" +
                "</Button>";

            // Создание объектов для чтения XAML из строки.
            StringReader strreader = new StringReader(strXaml);
            XmlTextReader xmlreader = new XmlTextReader(strreader);

            // Загрузка XAML и создание объекта кнопки.
            object obj = XamlReader.Load(xmlreader);

            // Установка созданного объекта кнопки в качестве содержимого окна.
            Content = obj;
        }
    }
}
