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
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ImageTheButton());
        }
        public ImageTheButton()
        {
            Title = "Image the Button";
            Uri uri = new Uri("https://polinov.ru/upload/medialibrary/e0b/e0b635aa3e458bcd784a9298fd5fe7e0.jpg");
                BitmapImage bitmap = new BitmapImage(uri);
            Image img = new Image();
            img.Source = bitmap;
            img.Stretch = Stretch.None;
            Button btn = new Button();
            btn.Content = img;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            Content = btn;
        }
    }
}
