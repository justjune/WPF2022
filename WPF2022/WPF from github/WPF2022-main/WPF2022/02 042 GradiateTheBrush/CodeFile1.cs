using System;
using System.Windows;//пространства имен, включающего все основные классы,
                     //структуры, интерфейсы, в том числе и 
                     //классы Application и Window.
using System.Windows.Input;
using System.Windows.Media;//здесь определена структура Color, где инкапсулируется цвет,
                           //а также класс Colors

namespace Petzold.GradiateTheBrush { 
    public class GradiateTheBrush : Window {
        [STAThread]
        public static void Main() { 
            Application app = new Application();
            app.Run(new GradiateTheBrush()); //метод Run организует вызов Show для объекта GradiateTheBrush
        } 
        public GradiateTheBrush() {
            Title = "Gradiate the Brush"; //определяет текст заголовка окна
            LinearGradientBrush brush = new LinearGradientBrush(Colors.Red, Colors.Blue, new Point(0, 0), new Point(1, 1)); //конструктор, позволяющий окрасить
                                                                                                                            //левый верхний угол (0,0) в красный цвет,
                                                                                                                            //а правый нижний (1,1) в синий
                                                                                                                            //и соединить углы градиентской заливкой 
            Background = brush;
        } 
    } 
}