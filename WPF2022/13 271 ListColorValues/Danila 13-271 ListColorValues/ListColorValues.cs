namespace Petzold.ListColorValues
{
    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    class ListColorValues : Window
    {

        public ListColorValues()
        {
            Title = "List Color Values";
            // Создание объекта ListBox как содержимого окна
            ListBox lstbox = new ListBox();
            lstbox.Width = 150;
            lstbox.Height = 150;
            lstbox.SelectionChanged += ListBoxOnSelectionChanged;
            Content = lstbox;
            // Заполнение ListBox объектами Color
            PropertyInfo[] props = typeof(Colors).GetProperties();
            foreach (PropertyInfo prop in props)
                lstbox.Items.Add(prop.GetValue(null, null));
        }


        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ListColorValues());
        }

        void ListBoxOnSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            ListBox lstbox = sender as ListBox;
            if (lstbox.SelectedIndex != -1)
            {
                Color clr = (Color)lstbox.SelectedItem;
                Background = new SolidColorBrush(clr);
            }
        }
    }
}