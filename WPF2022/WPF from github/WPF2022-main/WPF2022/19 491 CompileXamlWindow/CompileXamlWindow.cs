//-------------------------------------------------- 
// CompileXamlWindow.cs (c) 2006 by Charles Petzold 
//-------------------------------------------------- 

using System; 
using System.Reflection; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.CompileXamlWindow 
{
    public partial class CompileXamlWindow : Window 
    {
        [STAThread]
        public static void Main() 
        {
            Application app = new Application();
            app.Run(new CompileXamlWindow()); 
        }
        public CompileXamlWindow() 
        {
            // вызов метода для подключения 
            // обработчиков событий и инициализации полей. 
            InitializeComponent(); 
            // заполнение ListBox'a названиями кистей. 
            foreach (PropertyInfo prop in typeof (Brushes).GetProperties())
                lstbox.Items.Add(prop.Name); 
        } 
        // Обработчик нажатия кнопки выводит MessageBox. 
        void ButtonOnClick(object sender,  RoutedEventArgs args) 
        {
            Button btn = sender as Button; 
            MessageBox.Show("The button labled '"  + btn.Content + "' has been clicked.");
        } 
        // обработчик ListBox'a заменяет свойство Fill объекта Ellipse
        // эллипс заполняется цветом, который выбран в листбоксе
        void ListBoxOnSelection(object sender,  SelectionChangedEventArgs args) 
        {
            ListBox lstbox = sender as ListBox;  
            string strItem = lstbox.SelectedItem  as string; 
            PropertyInfo prop = typeof(Brushes).GetProperty(strItem);
            elips.Fill = (Brush)prop.GetValue(null , null); 
        }
    }
}



/// ------------------------- XAML КОД -----------------------///
/// <Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" // пространство имен wpf
///xmlns: x = "http://schemas.microsoft.com/winfx/2006/xaml" // пространство имен XAML-специфических элементов и атрибутов
///        x: Class = "Petzold.CompileXamlWindow.CompileXamlWindow" // при компиляции файла совместится XAML-файл с описанным выше классом С# x:Class = "namespace.classname"
///        Title = "Compile XAML Window" SizeToContent = "WidthAndHeight" ResizeMode = "CanMinimize" >    
///        < StackPanel > // Content окна
///            < Button HorizontalAlignment = "Center" Margin = "24" Click = "ButtonOnClick" > Click the Button</Button> // объект-кнопка, с заданными размерами 
///                     <Ellipse Name = "elips" Width= "200" Height= "100" Margin= "24" Stroke= "Black" />         // эллипс
///                     < ListBox Name= "lstbox"  Width= "150" Height= "150" Margin= "24"  SelectionChanged= "ListBoxOnSelection" />      // лист-бокс
///                 </ StackPanel > // все 3 объекта выше помещены в stackpanel
///             </ Window >