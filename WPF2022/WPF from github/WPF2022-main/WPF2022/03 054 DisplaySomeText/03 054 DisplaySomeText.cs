using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;  //включает изображения, текст, аудио, видео

namespace Petzold.DisplaySomeText
{
    class DisplaySomeText : Window 
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();  //создает объект app класса Application 
            app.Run(new DisplaySomeText());  
        }

        public DisplaySomeText()   //метод класса DisplaySomeText
        {
            Title = "Display Some Text";  //заголовок окна
            Content = "Content can be simple text!"; //текст, который выводится на экран
            FontFamily = new FontFamily("Times New Roman");   //название шрифта, FontFamili - семейство связных гарнитур, гарнитура- разновидность семейств, например, Times New Roman
            FontSize = 32;  //размер шрифта
            FontStyle = FontStyles.Oblique;  //наклон символов вправо 
            FontWeight = FontWeights.Bold;   //полужирные написание
            Brush brush = new LinearGradientBrush(Colors.Black, Colors.White, new Point(0, 0), new Point(1, 1)); //закраска фона
            Background = brush;  //задний план - кисть
            Foreground = brush;  //передний план - кисть
        }
    }
}
