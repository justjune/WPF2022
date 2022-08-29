using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.MeetTheDockers 
{ 
    public class MeetTheDockers : Window 
    {
        [STAThread] 
        public static void Main() 
        { 
            Application app = new Application(); 
            app.Run(new MeetTheDockers()); 
        }
        public MeetTheDockers() 
        { 
            Title = "Meet the Dockers"; 
            DockPanel dock = new DockPanel(); 
            Content = dock;             
            // Создание меню            
            Menu menu = new Menu();             
            MenuItem item = new MenuItem();             
            item.Header = "Menu";            
            menu.Items.Add(item);            
            // Размещение меню у верхнего края панели            
            DockPanel.SetDock(menu, Dock.Top);             
            dock.Children.Add(menu);            
            // Создание панели инструментов             
            ToolBar tool = new ToolBar();            
            tool.Header = "Toolbar";            
            // Размещение панели инструментов у верхнего края           
            DockPanel.SetDock(tool, Dock.Top);             
            dock.Children.Add(tool);             
            // Создание строки состояния             
            StatusBar status = new StatusBar();             
            StatusBarItem statitem = new  StatusBarItem();             
            statitem.Content = "Status";             
            status.Items.Add(statitem);             
            // Размещение строки состояния у нижнего края панели             
            DockPanel.SetDock(status, Dock.Bottom);             
            dock.Children.Add(status);            
            // Создание списка             
            ListBox lstbox = new ListBox();             
            lstbox.Items.Add("List Box Item");            
            // Размещение списка у левого края панели          
            DockPanel.SetDock(lstbox, Dock.Left);           
            dock.Children.Add(lstbox);            
            // Создание текстового поля            
            TextBox txtbox = new TextBox();       
            txtbox.AcceptsReturn = true;           
            // Размещение текстового поля и передача фокуса
            dock.Children.Add(txtbox);            
            txtbox.Focus();       
        }    
    }
} 