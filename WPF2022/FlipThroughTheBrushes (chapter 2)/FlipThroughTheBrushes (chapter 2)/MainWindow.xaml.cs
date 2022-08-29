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
using System.Reflection;

namespace FlipThroughTheBrushes__chapter_2_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int index = 0; PropertyInfo[] props;
        public MainWindow()
        {
           
            props = typeof(Brushes).GetProperties(BindingFlags.Public | BindingFlags.Static);
            SetTitleAndBackground();
            InitializeComponent();
        }
        public void FlipThroughTheBrushes()
        {
            props = typeof(Brushes).GetProperties(BindingFlags.Public | BindingFlags.Static);
            SetTitleAndBackground();
        }
        protected override void OnKeyDown(KeyEventArgs args)
        {
            if (args.Key == Key.Down || args.Key == Key.Up)
            {
                index += args.Key == Key.Up ? 1 : props.Length - 1;
                index %= props.Length; SetTitleAndBackground();
            }
            base.OnKeyDown(args);
        }
        void SetTitleAndBackground()
        {
            Title = "Flip Through the Brushes - " + props[index].Name;
            Background = (Brush)props[index].GetValue(null, null);
        }
    }
}


