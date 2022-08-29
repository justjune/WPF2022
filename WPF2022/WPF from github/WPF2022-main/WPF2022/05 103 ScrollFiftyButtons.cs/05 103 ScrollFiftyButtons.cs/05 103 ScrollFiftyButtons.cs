 using System; 
using System.Windows;
using System.Windows.Controls; 
using System.Windows.Input; 
using System.Windows.Media; 
namespace Petzold.ScrollFiftyButtons
{
    class ScrollFiftyButtons : Window     //класс-наследник от класса window 
    {
        [STAThread] //использует один поток 
        public static void Main()
        {
            Application app = new Application();  //создаем объект типа Aplication
            app.Run(new ScrollFiftyButtons()); //запуск
        }
        public ScrollFiftyButtons()     
        {
            Title = "Scroll Fifty Buttons"; //названик окна
            SizeToContent = SizeToContent.Width; //конструктор размера окна
            AddHandler(Button.ClickEvent,
                       new RoutedEventHandler(ButtonOnClick));

           ScrollViewer scroll = new ScrollViewer();  //класс управляющий видимостью вертикальной и горизонтальной полос прокрутки
            Content = scroll; //прокрука
            StackPanel stack = new StackPanel();  //метод компановки, располагает все элементы в ряд (по умолчанию по вертикали)

           // Viewbox view = new Viewbox(); //класс,принимающий единственный дочерний элемент
           // Content = view;  
           // view.Child = stack;  

            stack.Margin = new Thickness(5); //внешние отступы для самой панели широной в 5 аппаратно-независимых единиц (около 1/20 дюйма)
            scroll.Content = stack;
            for (int i = 0; i < 50; i++) //цикл, перебирающий элементы от 0 до 50, шагом +1
            {
                Button btn = new Button();   //в .btn классы предназаченные для использования с Button (Button - обычная кнопка)
                btn.Name = "Button" + (i + 1);  //имя кнопки "Button + порядковый номер"
                btn.Content = btn.Name + " says  'Click me'";  //кнопка с вложенным элементом 
                btn.Margin = new Thickness(5);  //внешние отступы широной в 5 аппаратно-независимых единиц (около 1/20 дюйма)
                stack.Children.Add(btn);  
            }
        }
        void ButtonOnClick(object sender, RoutedEventArgs args) 
       { 
            Button btn = args.Source as Button;  //обработчик проверяет, отличен ли результат от null
            if (btn != null) 
            MessageBox.Show(btn.Name + " has  been clicked",  //отображает окно сообщение с текстом "номер + has been clicked", "Button Click"
                "Button Click"); 
        }
    }
}
