//------------------------------------------------ 
// ToggleTheButton.cs (c) 2006 by Charles Petzold 
//------------------------------------------------
using System; 
using System.Windows; 
using System.Windows.Controls;
using System.Windows.Controls.Primitives; 
using System.Windows.Input; 
using System.Windows.Media; 
namespace Petzold.ToggleTheButton 
{    
    public class ToggleTheButton : Window 
    {     
        [STAThread]  
        public static void Main()  
        {      
            Application app = new Application();
            app.Run(new ToggleTheButton()); 
        } 
        public ToggleTheButton() 
        {
            Title = "Toggle the Button"; 
            ToggleButton btn = new ToggleButton();
            btn.Content = "Can _Resize";   
            //Местоположение кнопки внутри контейнера
            btn.HorizontalAlignment =  HorizontalAlignment.Center;
            btn.VerticalAlignment =  VerticalAlignment.Center;
            btn.IsChecked = (ResizeMode ==  ResizeMode.CanResize);
            //Для обозначения включения и выключения
            btn.Checked += ButtonOnChecked;   
            btn.Unchecked += ButtonOnChecked; 
            Content = btn; 
        }     
        void ButtonOnChecked(object sender,  RoutedEventArgs args)    
        {
            //Кнопка используется приложением для переключения свойства
            //ResizeMode между значениями ResizeMode.CanResize и ResizeMode.NoResize
            ToggleButton btn = sender as ToggleButton;
            ResizeMode = (bool)btn.IsChecked ? ResizeMode .CanResize :
                                               ResizeMode.NoResize;    
        } 
    }  
} 