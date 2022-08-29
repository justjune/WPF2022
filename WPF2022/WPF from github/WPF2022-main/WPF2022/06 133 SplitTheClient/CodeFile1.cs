using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
class SplitTheClient : Window
{
    [STAThread] 
    public static void Main() 
    { 
        Application app = new Application(); 
        app.Run(new SplitTheClient()); 
    }
    public SplitTheClient()
    {
        Title = "Split the Client";  
        
        // Панель Grid с вертикальной вешкой разбивки
        Grid grid1 = new Grid();         
        grid1.ColumnDefinitions.Add(new  ColumnDefinition());       //создаются три столбца 
        grid1.ColumnDefinitions.Add(new  ColumnDefinition());         
        grid1.ColumnDefinitions.Add(new  ColumnDefinition());         
        grid1.ColumnDefinitions[1].Width =  GridLength.Auto;        //для первой колонки(кнопки в дальнейшем) устанавливается автоматичесикй размер 
        Content = grid1;         //объект grid1 должен отображаться в клиентской области экрана

        // Кнопка слева от вертикальной вешки
        Button btn = new Button();         
        btn.Content = "Первая кнопочка";         
        grid1.Children.Add(btn);         //кнопка включается в коллекцию Children объекта grid1
        Grid.SetRow(btn, 0);             //кнопка добавляется в первую стороку и певый столбец
        Grid.SetColumn(btn, 0);         
        
        // Вертикальная вешка разбивки
        GridSplitter split = new GridSplitter();         
        split.ShowsPreview = true;          //отображается предварительный просмотр
        split.HorizontalAlignment =  HorizontalAlignment.Center;         
        split.VerticalAlignment =  VerticalAlignment.Stretch;         //вешка располагается по центру вертикально
        split.Width = 6;         //ограничение ширины
        grid1.Children.Add(split);         
        Grid.SetRow(split, 0);         
        Grid.SetColumn(split, 1);

        // Панель Grid с горизонтальной вешкой разбивки
        Grid grid2 = new Grid();         
        grid2.RowDefinitions.Add(new RowDefinition());      //в третьем столбце создаются три строки   
        grid2.RowDefinitions.Add(new RowDefinition());         
        grid2.RowDefinitions.Add(new RowDefinition());         
        grid2.RowDefinitions[1].Height =  GridLength.Auto;         
        grid1.Children.Add(grid2);         
        Grid.SetRow(grid2, 0);         
        Grid.SetColumn(grid2, 2);         
        
        // Кнопка над горизонтальной вешкой
        btn = new Button();         
        btn.Content = "Вторая кнопочка";        
        grid2.Children.Add(btn);         
        Grid.SetRow(btn, 0);        
        Grid.SetColumn(btn, 0);         
        
        // Горизонтальная вешка
        split = new GridSplitter();         
        split.ShowsPreview = true;         
        split.HorizontalAlignment =  HorizontalAlignment.Stretch;        //вешка располагается по центру горизонтально 
        split.VerticalAlignment =  VerticalAlignment.Center;         
        split.Height = 6;         
        grid2.Children.Add(split);         
        Grid.SetRow(split, 1);         
        Grid.SetColumn(split, 0);         
        
        // Кнопка под горизонтальной вешкой
        btn = new Button();         
        btn.Content = "Третья кнопочка";         
        grid2.Children.Add(btn);         
        Grid.SetRow(btn, 2);         
        Grid.SetColumn(btn, 0);     
    } 
} 
