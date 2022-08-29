//--------------------------------------------- 
// SpanTheCells.cs (c) 2006 by Charles Petzold 
//---------------------------------------------
using System;//подключение
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.SpanTheCells // пограмма создает текстовые поля (5) и кнопки (2)
{
    public class SpanTheCells : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SpanTheCells()); //запуск       
        }
        public SpanTheCells()
        {
            Title = "Span the Cells";  // имя окна           
            SizeToContent = SizeToContent.WidthAndHeight; //отвечает за ширину и высоту           
            // Создание объекта Grid              
            Grid grid = new Grid();        
            grid.Margin = new Thickness(5);  // отвечает за расстояние до границ окна           
            Content = grid; //экземпляр класса Grid задается свойству Content окна          
            
            // Set row definitions (определение строк)             
            for (int i = 0; i < 6; i++)   //кол-во строк          
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = GridLength.Auto;// высота       
                grid.RowDefinitions.Add(rowdef);
            }

            // Set column definitions(определение столбцов).             
            for (int i = 0; i < 4; i++)   
            {
                ColumnDefinition coldef = new ColumnDefinition();
                if (i == 1)
                    coldef.Width = new GridLength(100, GridUnitType.Star);
                else
                    coldef.Width = GridLength.Auto;// ширина столбца           
                grid.ColumnDefinitions.Add(coldef);//добавление столбца             
            }
            // Создание надписей и текстовых полей             
            string[] astrLabel = { "_First name:",  "_Last name:",
                "_Credit card  number:",
                "_Other  personal stuff:" };
            for (int i = 0; i < astrLabel.Length; i++)  // i от 0 до кол-ва элементов в astrLabel           
            {
                Label lbl = new Label();// создание надписи        
                lbl.Content = astrLabel[i];                
                lbl.VerticalContentAlignment = VerticalAlignment.Center; // положение в окне (по центру)             
                grid.Children.Add(lbl); //добавляет в коллекцию Children             
                Grid.SetRow(lbl, i);                
                Grid.SetColumn(lbl, 0);                
                TextBox txtbox = new TextBox();// создание текстовых полей                 
                txtbox.Margin = new Thickness(5); // внешние отступы               
                grid.Children.Add(txtbox); //добавляет в коллекцию Children                 
                Grid.SetRow(txtbox, i);                 
                Grid.SetColumn(txtbox, 1);
                Grid.SetColumnSpan(txtbox, 3);
            }
            // Create buttons (создание кнопок)          
            Button btn = new Button(); //создаем             
            btn.Content = "Submit";         
            btn.Margin = new Thickness(5);        
            btn.IsDefault = true;
            btn.Click += delegate { Close(); };  // при нажатии закрывает
            grid.Children.Add(btn);
            Grid.SetRow(btn, 5);// номер строки в которой будет кнопка - 5        
            Grid.SetColumn(btn, 2);        // номер столбца  - 2    
            btn = new Button();     // создаем вторую       
            btn.Content = "Cancel";             
            btn.Margin = new Thickness(5);           
            btn.IsCancel = true;
            btn.Click += delegate { Close(); };  // при нажатии закрывает           
            grid.Children.Add(btn);
            Grid.SetRow(btn, 5);   // номер строки в которой будет кнопка - 5          
            Grid.SetColumn(btn, 3);     // номер столбца  - 2
                                        // 
            // Set focus to first text box(передача фокуса первому текстовому полю).             
            grid.Children[1].Focus();
        }
    }
}