using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
/*Программа ScrollCustomColors создает две панели Grid. Первая (gridMain)
предназначена исключительно для реализации вертикальной вешки разбивки.
Первая ячейка содержит вторую панель Grid (просто grid), на которой 
размещены шесть надписей и три полосы прокрутки. Центральная ячейка GridMain
содержит объект GridSplitter, а последняя —
панель StackPanel, предназначенную
исключительно для отображения цвета фона.
Исходный размер окна устанавливается равным 500 аппаратно-независимым
единицам. При определении трех столбцов gridMain ячейке с полосами 
прокрутки и надписями назначается ширина 200 единиц, а ширина ячейки с панелью
StackPanel определяется в режиме GridUnitType.Star.
При увеличении или уменьшении окна изменяется только ширина панели
StackPanel.*/
class ColorScroll : Window

{
    ScrollBar[] scrolls = new ScrollBar[3];
    TextBlock[] txtValue = new TextBlock[3];
    Panel pnlColor;

    [STAThread]
    public static void Main()
    {
        Application app = new Application();
        app.Run(new ColorScroll());
    }
    public ColorScroll()
    {
        Title = "Color Scroll";
        Width = 500;
        Height = 300;

        //
        Grid gridMain = new Grid();
        Content = gridMain;
        // 

        ColumnDefinition coldef = new ColumnDefinition();
        coldef.Width = new GridLength(200, GridUnitType.Pixel);
        gridMain.ColumnDefinitions.Add(coldef);

        coldef = new ColumnDefinition();
        coldef.Width = GridLength.Auto;
        gridMain.ColumnDefinitions.Add(coldef);

        coldef = new ColumnDefinition();
        coldef.Width = new GridLength(100, GridUnitType.Star);
        gridMain.ColumnDefinitions.Add(coldef);

        // 
        GridSplitter split = new GridSplitter();
        split.HorizontalAlignment = HorizontalAlignment.Center;
        split.VerticalAlignment = VerticalAlignment.Stretch;
        split.Width = 6;
        gridMain.Children.Add(split);
        Grid.SetRow(split, 0);
        Grid.SetColumn(split, 1);

        // 
        pnlColor = new StackPanel();
        pnlColor.Background = new SolidColorBrush(SystemColors.WindowColor);
        gridMain.Children.Add(pnlColor);
        Grid.SetRow(pnlColor, 0);
        Grid.SetColumn(pnlColor, 2);

        // 
        Grid grid = new Grid();
        gridMain.Children.Add(grid);
        Grid.SetRow(grid, 0);
        Grid.SetColumn(grid, 0);

        // 
        RowDefinition rowdef = new RowDefinition();
        rowdef.Height = GridLength.Auto;
        grid.RowDefinitions.Add(rowdef);

        rowdef = new RowDefinition();
        rowdef.Height = new GridLength(100, GridUnitType.Star);
        grid.RowDefinitions.Add(rowdef);

        rowdef = new RowDefinition();
        rowdef.Height = GridLength.Auto;
        grid.RowDefinitions.Add(rowdef);

        // 
        for (int i = 0; i < 3; i++)
        {
            coldef = new ColumnDefinition();
            coldef.Width = new GridLength(33, GridUnitType.Star);
            grid.ColumnDefinitions.Add(coldef);
        }

        for (int i = 0; i < 3; i++)
        {
            Label lbl = new Label();

            lbl.Content = new string[] { "Red", "Green", "Blue" }[i];
            lbl.HorizontalAlignment = HorizontalAlignment.Center;
            grid.Children.Add(lbl);
        }
    }
}