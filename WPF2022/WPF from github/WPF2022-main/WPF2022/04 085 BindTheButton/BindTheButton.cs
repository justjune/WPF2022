using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Petzold.BindTheButton 
{     
    public class BindTheButton : Window     
    {         
        [STAThread]         
        public static void Main()         
        {             
            Application app = new Application();
            app.Run(new BindTheButton());
        }         
        public BindTheButton()         
        {             
            Title = "Bind the Button";

            ToggleButton btn = new ToggleButton
            {
                Content = "Make _Topmost",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            // TopMost: если данное свойство имеет значение true, то форма всегда будет находиться поверх других окон 
            // Path = "Topmost"
            btn.SetBinding(ToggleButton.IsCheckedProperty, "Topmost");


            /* мы присваеваем ссылку "this" свойству DataContext,
             что сообщает элементу ToggleButton о нашем желании установить в качестве контекста данных Window. 
             */

            btn.DataContext = this;

            Content = btn;

            ToolTip tip = new ToolTip();

            tip.Content = "Toggle the button on to make " + "the window topmost on the desktop";

            btn.ToolTip = tip;         
        }     
    } 
} 