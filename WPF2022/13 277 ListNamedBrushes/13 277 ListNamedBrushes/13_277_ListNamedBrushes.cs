using System; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Input; 
using System.Windows.Media;
using System.Reflection;

namespace Petzold.ListNamedBrushes 
{     
    public class NamedBrush     
    {         
        static NamedBrush[] nbrushes;         
        Brush brush;         
        string str;         
        // Static constructor.
        static NamedBrush()         
        {             
            PropertyInfo[] props = typeof(Brushes) .GetProperties();             
            nbrushes = new NamedBrush[props.Length];             
            for (int i = 0; i < props.Length; i++)                 
                nbrushes[i] = new NamedBrush (props[i].Name,(Brush)props[i].GetValue(null, null));         
        }         
        // Private constructor.
        private NamedBrush(string str, Brush brush)         
        {             
            this.str = str;             
            this.brush = brush;         
        }         
        // Static read-only property.
        public static NamedBrush[] All         
        {             
            get { return nbrushes; }         
        }         
        // Read-only properties.
        public Brush Brush         
        {             
            get { return brush; }         
        }         
        public string Name         
        {             
            get             
            {                 
                string strSpaced = str[0].ToString();                 
                for (int i = 1; i < str.Length; i++)                     
                    strSpaced += (char.IsUpper (str[i]) ? " " : "") + str[i] .ToString();                 
                return strSpaced;             
            }         
        }         
        // Override of ToString method.
        public override string ToString()         
        {             
            return str;         
        }     
    } 
} 
namespace Petzold.ListNamedBrushes 
{     
    public class ListNamedBrushes : Window     
    {         
        [STAThread]         
        public static void Main()         
        {             
            Application app = new Application();             
            app.Run(new ListNamedBrushes());         
        }         
        public ListNamedBrushes()         
        {             
            Title = "List Named Brushes";             
            //Create ListBox as content of window.
            ListBox lstbox = new ListBox();             
            lstbox.Width = 150;             
            lstbox.Height = 150;             
            Content = lstbox;             
            // Set the items and the property paths.
            lstbox.ItemsSource = NamedBrush.All;             
            lstbox.DisplayMemberPath = "Name";             
            lstbox.SelectedValuePath = "Brush";             
            // Bind the SelectedValue to window  Background.
            lstbox.SetBinding(ListBox .SelectedValueProperty, "Background");             
            lstbox.DataContext = this;         
        }     
    } 
}