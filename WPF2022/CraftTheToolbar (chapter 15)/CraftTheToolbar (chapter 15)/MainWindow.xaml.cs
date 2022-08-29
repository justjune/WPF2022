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
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

namespace CraftTheToolbar__chapter_15_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            //Window win = new Window();
           // win.Title = "Say Hello";
            //win.Show();
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Title = "CraftTheToolbar";
            RoutedUICommand[] comm = {
                ApplicationCommands.New,
                ApplicationCommands.Open,
                ApplicationCommands.Save,
                ApplicationCommands.Print,
                ApplicationCommands.Cut,
                ApplicationCommands.Copy,
                ApplicationCommands.Paste,
                ApplicationCommands.Delete
            };

            //Create DockPanel as content of window.
            DockPanel dock = new DockPanel();
            dock.LastChildFill = false; Content = dock;
            // Create Toolbar docked at top of window.
            ToolBar toolbar = new ToolBar();
            dock.Children.Add(toolbar);
            DockPanel.SetDock(toolbar, Dock.Top);
            // Create the Toolbar buttons.
            for (int i = 0; i < 8; i++)
            {
                //if (i == 4) toolbar.Items.Add(new Separator());
                // Create the Button.
                Button btn = new Button();
                btn.Command = comm[i];
                toolbar.Items.Add(btn);
                ToolTip tip = new ToolTip();
                tip.Content = comm[i].Text;
                btn.ToolTip = tip;
                CommandBindings.Add(new CommandBinding(comm[i], ToolBarButtonOnClick));
            }
        }
        void ToolBarButtonOnClick(object sender, ExecutedRoutedEventArgs args)
        {
            RoutedUICommand comm = args.Command as RoutedUICommand;
            MessageBox.Show(comm.Name + " command not yet  implemented", Title);
        }
    }
}


