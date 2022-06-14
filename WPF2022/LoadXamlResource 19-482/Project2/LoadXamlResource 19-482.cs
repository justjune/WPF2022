namespace Petzold.LoadXamlResource
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml;

    public class LoadXamlResource : Window
    {
        #region Constructors

        public LoadXamlResource()
        {
            Title = "Load Xaml Resource";

            StreamReader sr = new StreamReader("LoadXamlResource.xml");
            XmlTextReader xmlreader = new XmlTextReader(sr);
            FrameworkElement el = XamlReader.Load(xmlreader) as FrameworkElement;
            Content = el;

            Button btn = el.FindName("MyButton") as Button;
            if (btn != null)
                btn.Click += ButtonOnClick;
        }

        #endregion Constructors

        #region Methods

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new LoadXamlResource());
        }

        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("The button labeled '" + (args.Source as Button).Content + "' has been clicked");
        }

        #endregion Methods
    }
}