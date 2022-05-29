using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.FormatTheButton
{
    public class FormatTheButton : Window
    {
        Run runButton;

        public static void Main()
        {
            Application app = new Application();
            app.Run(new FormatTheButton());
        }
        public FormatTheButton(MouseEventHandler ButtonOnMouseEnter, MouseEventHandler ButtonOnMouseLeave)
        {
            Title = "Format the Button";
            // Создание объекта Button, назначаемого содержимым окна
            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.MouseEnter += ButtonOnMouseEnter;
            btn.MouseLeave += ButtonOnMouseLeave;
            Content = btn;
            // Создание объекта TextBlock, назначаемого содержимым кнопки
            TextBlock txtblk = new TextBlock();
            txtblk.FontSize = 24;
            txtblk.TextAlignment = TextAlignment.Center;
            btn.Content = txtblk;
            // Добавление отформатированного текста к TextBlock
            txtblk.Inlines.Add(new Italic(new Run("Click")));
            txtblk.Inlines.Add(" the ");
            txtblk.Inlines.Add(runButton = new Run("button"));
            txtblk.Inlines.Add(new LineBreak());
            txtblk.Inlines.Add("to launch the ");
            txtblk.Inlines.Add(new Bold(new Run("rocket")));
        }

        public FormatTheButton()
        {
        }
    }
}