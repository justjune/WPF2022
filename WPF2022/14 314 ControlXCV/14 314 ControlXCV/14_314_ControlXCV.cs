using System; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Input; 
using System.Windows.Media; 
namespace Petzold.CutCopyAndPaste 
{     
    public class CutCopyAndPaste : Window     
    {         
        TextBlock text;         
        protected MenuItem itemCut, itemCopy,  itemPaste, itemDelete;         
       
        public CutCopyAndPaste()         
        {             
            Title = "Cut, Copy, and Paste";             
            // Create DockPanel.
            DockPanel dock = new DockPanel();             
            Content = dock;             
            // Create Menu docked at top.
            Menu menu = new Menu();             
            dock.Children.Add(menu);             
            DockPanel.SetDock(menu, Dock.Top);             
            // Create TextBlock filling the rest.
            text = new TextBlock();             
            text.Text = "Sample clipboard text";             
            text.HorizontalAlignment =  HorizontalAlignment.Center;             
            text.VerticalAlignment =  VerticalAlignment.Center;             
            text.FontSize = 32;             
            text.TextWrapping = TextWrapping.Wrap;             
            dock.Children.Add(text);             
            // Create Edit menu.
            MenuItem itemEdit = new MenuItem();             
            itemEdit.Header = "_Edit";             
            itemEdit.SubmenuOpened += EditOnOpened;             
            menu.Items.Add(itemEdit);             
            // Create items on Edit menu.
            itemCut = new MenuItem();             
            itemCut.Header = "Cu_t";             
            itemCut.Click += CutOnClick;             
                    
        }         
        void EditOnOpened(object sender,  RoutedEventArgs args)         
        {             
            itemCut.IsEnabled = itemCopy.IsEnabled = itemDelete.IsEnabled = text.Text !=  null && text.Text.Length > 0;             
            itemPaste.IsEnabled = Clipboard .ContainsText();         
        }         
        protected void CutOnClick(object sender,  RoutedEventArgs args)         
        {             
            CopyOnClick(sender, args);             
            DeleteOnClick(sender, args);         
        }         
        protected void CopyOnClick(object sender,  RoutedEventArgs args)         
        {             
            if (text.Text != null && text.Text. Length > 0)                 
                Clipboard.SetText(text.Text);         
        }         
        protected void PasteOnClick(object sender,  RoutedEventArgs args)         
        {             
            if (Clipboard.ContainsText())                 
                text.Text = Clipboard.GetText();         
        }         
        protected void DeleteOnClick(object sender , RoutedEventArgs args)         
        {             
            text.Text = null;         
        }     
    } 
}
namespace Petzold.ControlXCV 
{     
    public class ControlXCV : Petzold .CutCopyAndPaste.CutCopyAndPaste     
    {         
        KeyGesture gestCut = new KeyGesture(Key.X,  ModifierKeys.Control);         
        KeyGesture gestCopy = new KeyGesture(Key.C , ModifierKeys.Control);         
        KeyGesture gestPaste = new KeyGesture(Key .V, ModifierKeys.Control);         
        KeyGesture gestDelete = new KeyGesture(Key .Delete);         
        [STAThread]         
        public new static void Main()         
        {             
            Application app = new Application();             
            app.Run(new ControlXCV());         
        }         
        public ControlXCV()         
        {             
            Title = "Control X, C, and V";             
            itemCut.InputGestureText = "Ctrl+X";             
            itemCopy.InputGestureText = "Ctrl+C";             
            itemPaste.InputGestureText = "Ctrl+V";             
            itemDelete.InputGestureText = "Delete";         
        }         
        protected override void OnPreviewKeyDown (KeyEventArgs args)         
        {             
            base.OnKeyDown(args);             
            args.Handled = true;             
            if (gestCut.Matches(null, args))                 
                CutOnClick(this, args);             
            else if (gestCopy.Matches(null, args))                 
                CopyOnClick(this, args);             
            else if (gestPaste.Matches(null, args))                 
                PasteOnClick(this, args);             
            else if (gestDelete.Matches(null, args))                 
                DeleteOnClick(this, args);             
            else                 
                args.Handled = false;         
        }     
    } 
}