using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.SplitNine
{
    public class SplitNine : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application(); //создаение объекта приложения 
            app.Run(new SplitNine());  //запуск приложения
        }
        public SplitNine()
        {
            Title = "Split Nine";
            Grid grid = new Grid(); //создание контейнера для упаковки виджетов
            Content = grid; //добавление контейнера в окно 
            // Создание определений строй и столбцов
            //добаление 3 строк и 3 столбцов
            for (int i = 0; i < 3; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
            }
            // Создание 9 кнопок и добавление их в ячейки таблицы  
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                {
                    Button btn = new Button();
                    btn.Content = "Row " + y + "  and Column " + x;
                    grid.Children.Add(btn);
                    Grid.SetRow(btn, y);
                    Grid.SetColumn(btn, x);
                }
            //добавление пространства между строками и столбцами
            GridSplitter split = new GridSplitter();
            split.Width = 6;
            grid.Children.Add(split);
            Grid.SetRow(split, 1);
            Grid.SetColumn(split, 1);
        }
    }
}