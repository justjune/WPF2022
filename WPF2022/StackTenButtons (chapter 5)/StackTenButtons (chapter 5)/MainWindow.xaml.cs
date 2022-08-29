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

namespace StackTenButtons__chapter_5_
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
            Title = "Stack Ten Buttons";
            StackPanel stack = new StackPanel();
            Content = stack; Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button();
                btn.Name = ((char)('A' + i)).ToString();
                btn.FontSize += rand.Next(10);
                btn.Content = "Button " + btn.Name + " says 'Click me'";
                btn.Click += ButtonOnClick; stack.Children.Add(btn);
            }
            void ButtonOnClick(object sender, RoutedEventArgs args)
            {
                Button btn = args.Source as Button;
                MessageBox.Show("Button " + btn.Name + " has been clicked", "Button Click");
            }
        }
    }
}


