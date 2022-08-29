//------------------------------------------------- 
// SetSpaceProperty.cs (c) 2006 by Charles Petzold 
//-------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.SetSpaceProperty //программа создает 6 кнопок на которых символы разделяются одним пробелом
{
    public class SetSpaceProperty : SpaceWindow // класс производный от SpaceWindow
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SetSpaceProperty());//запуск
        }
        public SetSpaceProperty()
        {
            Title = "Set Space Property";//имя окна
            SizeToContent = SizeToContent.WidthAndHeight;//отвечает за ширину и высоту
            ResizeMode = ResizeMode.CanMinimize;//задает режим изменения размеров окна, принимает значение - окно можно только свернуть
            int[] iSpaces = { 0, 1, 2 };

            //создание панели Grid
            Grid grid = new Grid();
            Content = grid;

            //определение строк 
            for (int i = 0; i < 2; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;//высота строки
                grid.RowDefinitions.Add(row); //добавление строки
            }
            //определение столбцов
            for (int i = 0; i < iSpaces.Length; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = GridLength.Auto; //ширина столбца
                grid.ColumnDefinitions.Add(col); //добавление столбца    
            }
            //создание 6 кнопок
            for (int i = 0; i < iSpaces.Length; i++)
            {
                SpaceButton btn = new SpaceButton(); //создаем объект для отображения текста разделенного пробелами
                btn.Text = "Set window Space to " + iSpaces[i]; //три кнопки в верхней строке задают свойство Space объекта Window равным 0,1 или 2 единицам
                btn.Tag = iSpaces[i];
                btn.HorizontalAlignment = HorizontalAlignment.Center;//положение в окне по горизонтали - по центру
                btn.VerticalAlignment = VerticalAlignment.Center; //положение в окне по вертикали - по центру
                btn.Click += WindowPropertyOnClick;
                grid.Children.Add(btn);//добавляет в коллекцию Children 
                Grid.SetRow(btn, 0);//номер строки в которой будет кнопка - 0  
                Grid.SetColumn(btn, i); //номер столбца

                btn = new SpaceButton();
                btn.Text = "Set button Space to " + iSpaces[i]; //три кнопки в нижней строке изменяют свойство Space конкретной нажатой кнопки
                btn.Tag = iSpaces[i];
                btn.HorizontalAlignment = HorizontalAlignment.Center; //горизонтальное выравнивание по центру  
                btn.VerticalAlignment = VerticalAlignment.Center; //вертикальное выравнивание по центру
                btn.Click += ButtonPropertyOnClick;
                grid.Children.Add(btn); //добавляет в коллекцию Children 
                Grid.SetRow(btn, 1);//номер строки в которой будет кнопка - 1
                Grid.SetColumn(btn, i);  //номер столбца
            }
        }
        void WindowPropertyOnClick(object sender, RoutedEventArgs args) // щелчок на кнопке верхней строки изменяет все кнопки в соответствии с новым значением Space заданным для окна 
        {
            SpaceButton btn = args.Source as SpaceButton;
            Space = (int)btn.Tag;
        }
        void ButtonPropertyOnClick(object sender, RoutedEventArgs args) //при щелчке на кнопке нижней строки изменяется только эта кнопка и остается неизменной 
        {
            SpaceButton btn = args.Source as SpaceButton;
            btn.Space = (int)btn.Tag;
        }
    }
}