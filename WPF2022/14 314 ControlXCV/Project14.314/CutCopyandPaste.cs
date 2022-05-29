namespace Petzold.CutCopyAndPaste
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class CutCopyAndPaste : Window
    {
        #region Fields

        protected MenuItem itemCut, itemCopy, itemPaste, itemDelete;

        TextBlock text;

        #endregion Fields

        #region Constructors

        public CutCopyAndPaste()
        {
            Title = "Cut, Copy, and Paste";

            DockPanel dock = new DockPanel();
            Content = dock;

            Menu menu = new Menu();
            dock.Children.Add(menu);
            DockPanel.SetDock(menu, Dock.Top);

            text = new TextBlock();
            text.Text = "Глава 14, страница 314";
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.FontSize = 32;
            text.TextWrapping = TextWrapping.Wrap;
            dock.Children.Add(text);

            MenuItem itemEdit = new MenuItem();
            itemEdit.Header = "_Edit";
            itemEdit.SubmenuOpened += EditOnOpened;
            menu.Items.Add(itemEdit);

            itemCut = new MenuItem();
            itemCut.Header = "Cu_t";
            itemCut.Click += CutOnClick;
            itemEdit.Items.Add(itemCut);

            itemCopy = new MenuItem();
            itemCopy.Header = "_Copy";
            itemCopy.Click += CopyOnClick;
            itemEdit.Items.Add(itemCopy);

            itemPaste = new MenuItem();
            itemPaste.Header = "_Paste";
            itemPaste.Click += PasteOnClick;
            itemEdit.Items.Add(itemPaste);

            itemDelete = new MenuItem();
            itemDelete.Header = "_Delete";
            itemDelete.Click += DeleteOnClick;
            itemEdit.Items.Add(itemDelete);
        }

        #endregion Constructors

        #region Methods

        [STAThread]
        //public static void Main()
        //{
        //    Application app = new Application();
        //    app.Run(new CutCopyAndPaste());
        //}

        protected void CopyOnClick(object sender, RoutedEventArgs args)
        {
            if (text.Text != null && text.Text.Length > 0)
                Clipboard.SetText(text.Text);
        }

        protected void CutOnClick(object sender, RoutedEventArgs args)
        {
            CopyOnClick(sender, args);
            DeleteOnClick(sender, args);
        }

        protected void DeleteOnClick(object sender, RoutedEventArgs args)
        {
            text.Text = null;
        }

        protected void PasteOnClick(object sender, RoutedEventArgs args)
        {
            if (Clipboard.ContainsText())
                text.Text = Clipboard.GetText();
        }

        void EditOnOpened(object sender, RoutedEventArgs args)
        {
            itemCut.IsEnabled = itemCopy.IsEnabled = itemDelete.IsEnabled = (text.Text != null && text.Text.Length > 0);
            itemPaste.IsEnabled = Clipboard.ContainsText();
        }

        #endregion Methods
    }
}