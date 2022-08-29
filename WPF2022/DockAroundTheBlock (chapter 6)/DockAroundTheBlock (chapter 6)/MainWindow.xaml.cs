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

namespace DockAroundTheBlock__chapter_6_
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
            Title = "Dock Around the Block";
            DockPanel dock = new DockPanel();
            Content = dock;
            for (int i = 0; i < 17; i++)
            {
                Button btn = new Button();
                btn.Content = "Button No. " + (i + 1);
                dock.Children.Add(btn);
                btn.SetValue(DockPanel.DockProperty, (Dock)(i % 4));
            }
        }
    }
}
/*using System; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Input; 
using System.Windows.Media; 
namespace Petzold.DockAroundTheBlock { 
    class DockAroundTheBlock : Window { 
        [STAThread] public static void Main() {
            Application app = new Application(); 
            app.Run(new DockAroundTheBlock()); 
        }
        public DockAroundTheBlock() { 
            Title = "Dock Around the Block";
            DockPanel dock = new DockPanel(); 
            Content = dock; 
            for (int i = 0; i < 17; i++) { 
                Button btn = new Button();
                btn.Content = "Button No. " + (i + 1); 
                dock.Children.Add(btn); 
                btn.SetValue(DockPanel.DockProperty, (Dock)(i % 4)); 
            } 
        } 
    } 
}*/