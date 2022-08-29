//------------------------------------------- 
// ShowMyFace.cs (c) 2006 by Charles Petzold 
//-------------------------------------------

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Petzold.ShowMyFace
{
    class ShowMyFace : Window //класс, производный от Window
    {
        [STAThread] //используется однопоточная модель
        public static void Main()
        {
            Application app = new Application(); //создаем объект типа Application
            app.Run(new ShowMyFace()); //вызов метода Run, котрый запускает цикл сообщений
        }
        public ShowMyFace()
        {
            Title = "Show My Face"; //определение текста заголовка окна
            Uri uri = new Uri("http://www.charlespetzold.com/PetzoldTattoo.jpg"); //Создаём объект Uri, указывающий расположение растрового изображения
            BitmapImage bitmap = new BitmapImage(uri); //передаём конструктору Bitmaplimage Uri        
            Image img = new Image(); //создан элемент Image
            img.Source = bitmap;     //вывод изображения
            Content = img; //экземпляр класса Image задается свойству Content окна
        }
    }
}

//hacked by Polina2002