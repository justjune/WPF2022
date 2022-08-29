using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace MeetTheDockers__chapter_6_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Title = "Meet the Dockers";
            DockPanel dock = new DockPanel();
            Content = dock;
            Menu menu = new Menu();
            MenuItem item = new MenuItem();
            item.Header = "Menu";
            menu.Items.Add(item);
            DockPanel.SetDock(menu, Dock.Top);
            dock.Children.Add(menu);
            ToolBar tool = new ToolBar();
            tool.Header = "Toolbar";
            DockPanel.SetDock(tool, Dock.Top);
            dock.Children.Add(tool);
            StatusBar status = new StatusBar();
            StatusBarItem statitem = new StatusBarItem();
            statitem.Content = "Status";
            status.Items.Add(statitem);
            DockPanel.SetDock(status, Dock.Bottom);
            dock.Children.Add(status);
            ListBox lstbox = new ListBox();
            lstbox.Items.Add("List Box Item");
            DockPanel.SetDock(lstbox, Dock.Left);
            dock.Children.Add(lstbox);
            TextBox txtbox = new TextBox();
            txtbox.AcceptsReturn = true;
            dock.Children.Add(txtbox);
            txtbox.Focus();
        }
    }
}
