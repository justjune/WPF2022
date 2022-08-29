using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Petzold.ImageTheButton
{
    public class ImageTheButton : Window
    {
        [STAThread] // использование одного потока
        public static void Main()
        {
            Application app = new Application();  // создание объекта типа Application
            app.Run(new ImageTheButton()); // запуск
        }
        public ImageTheButton()
        {
            Title = "Image the Button"; // название кнопки
            // важно, чтобы в свойствах файла Button-Image.jpg поле "действие при сборке" было установленно на resource
            Uri uri = new Uri("pack://application:,,,/Button-Image.jpg"); // создание объекта URI (в скобках синтаксис, позваляющий получить доступ к Button-Image.jpg, в файлах проекта)
            BitmapImage bitmap = new BitmapImage(uri);                    // изображение кнопки, переданное в URI, передается в объект типа "РастровоеИзображение"
            Image img = new Image();                                      // представляет элемемнтуправление, отображающий изображение
            img.Source = bitmap;                                          // получит или задаст тип ImageSource для изображения
            img.Stretch = Stretch.None;                                   // Stretch описывает способ изменения размеров содержимого для заполнения выделенного ему пространства
            Button btn = new Button();                                    // объект типа Button
            btn.Content = img;                                            // присваиваем img свйоству Content "кнопки"
            btn.HorizontalAlignment = HorizontalAlignment.Center;         // HorizontalAlignment Указывает, где должен отображаться элемент на горизонтальной оси относительно выделенного раздела макета родительского элемента
            btn.VerticalAlignment = VerticalAlignment.Center;             // аналогично, но для вертикальной оси
            Content = btn;    //экземпляр класса Button задается свойству Content окна                                            
        }
    }
}
