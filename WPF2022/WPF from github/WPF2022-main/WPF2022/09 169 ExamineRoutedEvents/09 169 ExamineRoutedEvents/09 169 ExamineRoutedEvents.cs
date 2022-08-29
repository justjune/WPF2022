//---------------------------------------------------- 
// ExamineRoutedEvents.cs (c) 2006 by Charles Petzold 
//----------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.ExamineRoutedEvents
{
    public class ExamineRoutedEvents : Application
    {
        static readonly FontFamily fontfam = new FontFamily("Lucida Console");
        const string strFormat = "{0,-30} {1,-15}  {2,-15} {3,-15}";
        StackPanel stackOutput;
        DateTime dtLast;
        [STAThread]
        public static void Main()
        {
            ExamineRoutedEvents app = new ExamineRoutedEvents();
            app.Run();
        }
        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);
            
            Window win = new Window();// создаем окно
            win.Title = "Examine Routed Events";
            Grid grid = new Grid();// объект Grid - содержимое класса 
            win.Content = grid;
           
            RowDefinition rowdef = new RowDefinition();
            rowdef.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowdef);
            rowdef = new RowDefinition();
            rowdef.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowdef);
            rowdef = new RowDefinition();
            rowdef.Height = new GridLength(100, GridUnitType.Star);
            grid.RowDefinitions.Add(rowdef);
            
 Button btn = new Button();// создание объекта типа Button и его размещение в Grid
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.Margin = new Thickness(24);
            btn.Padding = new Thickness(24);
            grid.Children.Add(btn);
      
 TextBlock text = new TextBlock();
            text.FontSize = 24;
            text.Text = win.Title;
            btn.Content = text;
           
           TextBlock textHeadings = new TextBlock();
            textHeadings.FontFamily = fontfam;
            textHeadings.Inlines.Add(new Underline(new Run(String.Format(strFormat, "Routed Event", "sender", "Source", "OriginalSource"))));
            grid.Children.Add(textHeadings);
            Grid.SetRow(textHeadings, 1);
           
            ScrollViewer scroll = new ScrollViewer();
            grid.Children.Add(scroll);
            Grid.SetRow(scroll, 2);
            
            
            stackOutput = new StackPanel();// объект для вывода событий
            scroll.Content = stackOutput;
            
            UIElement[] els = { win, grid, btn, text };// обработчики событий
            foreach (UIElement el in els)
 {                 
 // для клавиатуры
 el.PreviewKeyDown +=  AllPurposeEventHandler;
        el.PreviewKeyUp +=  AllPurposeEventHandler;
 el.PreviewTextInput +=  AllPurposeEventHandler;
 el.KeyDown += AllPurposeEventHandler;
 el.KeyUp += AllPurposeEventHandler;
 el.TextInput +=  AllPurposeEventHandler;                 
// для мыши
 el.MouseDown +=  AllPurposeEventHandler;
        el.MouseUp += AllPurposeEventHandler;
 el.PreviewMouseDown +=  AllPurposeEventHandler;
 el.PreviewMouseUp +=  AllPurposeEventHandler;                 
// для стилуса
 el.StylusDown +=  AllPurposeEventHandler;
        el.StylusUp += AllPurposeEventHandler;
 el.PreviewStylusDown +=  AllPurposeEventHandler;
 el.PreviewStylusUp +=  AllPurposeEventHandler;                 

 el.AddHandler(Button.ClickEvent,
     new RoutedEventHandler(AllPurposeEventHandler));
 }

    win.Show();
 }
void AllPurposeEventHandler(object sender, RoutedEventArgs args)
{
// вывод пустой строки, если между событиями есть промежуток
 DateTime dtNow = DateTime.Now;
    if (dtNow - dtLast > TimeSpan.FromMilliseconds(100))
        stackOutput.Children.Add(new TextBlock(new Run(" ")));
    dtLast = dtNow;
            // вывод информации о событии
            TextBlock text = new TextBlock();
            text.FontFamily = fontfam;
            text.Text = String.Format(strFormat, args.RoutedEvent.Name, TypeWithoutNamespace(sender), TypeWithoutNamespace(args.Source), TypeWithoutNamespace(args.OriginalSource));
            stackOutput.Children.Add(text);
    (stackOutput.Parent as ScrollViewer).ScrollToBottom();
}
string TypeWithoutNamespace(object obj)
{
    string[] astr = obj.GetType().ToString().Split('.');
    return astr[astr.Length - 1];
}
 }
 } 

