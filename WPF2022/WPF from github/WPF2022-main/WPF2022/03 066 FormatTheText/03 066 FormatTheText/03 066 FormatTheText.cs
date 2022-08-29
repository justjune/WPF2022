
//---------------------------------------------- 
//FormatTheText.cs (c) 2006 by Charles Petzold 
//---------------------------------------------- 
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Documents;

namespace Petzold.FormatTheText
{
    class FormatTheText : Window// создаем класс FormatTheText типа Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();// создаем объект app класса Application
            app.Run(new FormatTheText());
        }
        public FormatTheText()// метод класса FormatTheText
        {
            Title = "Format the Text";
            TextBlock txt = new TextBlock();
            txt.FontSize = 32;// размер выводимого текста
            txt.Inlines.Add("This is some ");
            txt.Inlines.Add(new Italic(new Run("italic")));
            txt.Inlines.Add(" text, and this is some ");
            txt.Inlines.Add(new Bold(new Run("bold")));
            txt.Inlines.Add(" text, and let's cap it off with some ");
            txt.Inlines.Add(new Bold(new Italic(new Run("bold italic"))));
            txt.Inlines.Add(" text.");
            txt.TextWrapping = TextWrapping.Wrap;
            Content = txt;
        }
    }
}
