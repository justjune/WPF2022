//---------------------------------------------- 
// DesignAButton.cs (c) 2006  by Charles  Petzold 
//----------------------------------------------
using System; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Input; 
using System.Windows.Media; 
using System.Windows.Media.Imaging; 

using System.Windows.Shapes; 
namespace Petzold.DesignAButton 
{     public class DesignAButton : Window  //класс, производный от Window  
    {         
        [STAThread]    //используется однопоточная модель   
        public static void  Main()         
        {             
            Application  app = new Application();  //создаем объект типа Application
            app.Run(new DesignAButton());    //вызов метода Run, котрый запускает цикл сообщений 
        }         
        public  DesignAButton()         
        {             
            Title = "Design a Button";  //определение текста заголовка окна

            // Создание объекта Button как содержимого окна
            Button  btn = new Button();  //этим классом представлена кнопка со свойством Content и событием Click           
            btn.HorizontalAlignment =  HorizontalAlignment.Center; //задали кнопке свойство HorizontalAlignment 
            btn.VerticalAlignment =  VerticalAlignment.Center;  //задали кнопке свойство VerticalAlignment 
            btn.Click += ButtonOnClick;             
            Content = btn;

            // Создание объекта StackPanel как содержимого  Button
            StackPanel stack =  new StackPanel();             
            btn.Content = stack;             
            
            // Добавление объекта Polyline к StackPanel.
            stack.Children.Add(ZigZag(10));             
            
            // Добавление объекта Image к StackPanel.
            Uri uri = new Uri("pack://application:,,,/Book_Image.jpg"); // создание объекта URI (в скобках синтаксис, позваляющий получить доступ к Book_Image.jpg, в файлах проекта)  
            BitmapImage  bitmap = new BitmapImage (uri);             
            Image img = new Image(); //создан элемент Image            
            img.Margin = new Thickness(0, 10, 0, 0);   //внешний отступ в 10 единиц у верхнего края       
            img.Source = bitmap;             
            img.Stretch = Stretch.None;             
            stack.Children.Add(img);  //включение в коллекцию Children

            // Добавление объекта  Label к StackPanel.
            Label lbl = new Label();             
            lbl.Content  = "_Read books!";             
            lbl.HorizontalContentAlignment =  HorizontalAlignment.Center;         
            stack.Children.Add(lbl);  //включение в коллекцию Children

            // Добавление объекта Polyline к StackPanel.
            stack.Children.Add(ZigZag(0));         
        }         
        Polyline ZigZag(int offset)         
        {             
            Polyline poly = new Polyline();             
            poly.Stroke = SystemColors .ControlTextBrush;             
            poly.Points = new PointCollection();             
            for (int x = 0; x <= 100; x += 10)                 
                poly.Points.Add(new Point(x, (x +  offset) % 20));             
            return  poly;         
        }         
        void ButtonOnClick(object sender,  RoutedEventArgs args)         
        {             
            MessageBox.Show("The button  has  been  clicked", Title);
        }     
    } 
} 
