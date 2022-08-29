//--------------------------------------------- 
// LoadXamlFile.cs (c) 2006 by Charles Petzold 
//--------------------------------------------- 
using Microsoft.Win32; 
using System; 
using System.IO; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Markup; 
using System.Xml; 
namespace Petzold.LoadXamlFile 
{     
    public class LoadXamlFile : Window     
    {         
        Frame frame;         
        [STAThread]         
        public static void Main()         
        {             
            Application app = new Application();  // Создание приложения
            app.Run(new LoadXamlFile());         
        }         
        public LoadXamlFile()         
        {             
            Title = "Load XAML File";    // Заголовок для окна         
            DockPanel dock = new DockPanel();             
            Content = dock;                          
            Button btn = new Button();   // Создание кнопки для окна Open File       
            btn.Content = "Open File...";             
            btn.Margin = new Thickness(12);             
            btn.HorizontalAlignment =  HorizontalAlignment.Left;             
            btn.Click += ButtonOnClick;             
            dock.Children.Add(btn);           
            DockPanel.SetDock(btn, Dock.Top);                         
            frame = new Frame();             // Создание Frame для размещения кода 
            dock.Children.Add(frame);         
        }         
        void ButtonOnClick(object sender,  RoutedEventArgs args)         
        {             
            OpenFileDialog dlg = new OpenFileDialog();             
            dlg.Filter = "XAML Files (*.xaml)|* .xaml|All files (*.*)|*.*";             
            if ((bool)dlg.ShowDialog())             
            {                 
                try                 
                {                     // Чтение файла с помощью XmlTextReader                     
                    XmlTextReader xmlreader = new  XmlTextReader(dlg.FileName);                    
                    object obj = XamlReader.Load (xmlreader);    // Конвертируем XAML в object                              
                    if (obj is Window)    // Если объект типа Window, то вызвать метод Show                 
                    {                         
                        Window win = obj as Window;                        
                        win.Owner = this;                         
                        win.Show();                     
                    }                                         
                    else                         
                        frame.Content = obj;                 
                }                 
                catch (Exception exc)                 
                {                     
                    MessageBox.Show(exc.Message,  Title);            
                }             
            }         
        }     
    }  
} 
