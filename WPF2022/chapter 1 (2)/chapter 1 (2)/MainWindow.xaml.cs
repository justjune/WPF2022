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

namespace chapter_1__2_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Application app = new Application();
            Window win = new Window();
            win.Title = "Handle An Event";
            win.Show();
            win.MouseDown += WindowOnMouseDown;
            //app.Run(win);

            //InitializeComponent();
        }
        static void WindowOnMouseDown(object sender, MouseButtonEventArgs args)
        {
            Window win = sender as Window;
            string strMessage = string.Format("Window clicked with  {0} button at point ({1})", args.ChangedButton, args.GetPosition(win));
            MessageBox.Show(strMessage, win.Title);
        }
    }
}



