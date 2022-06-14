using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Petzold.ShadowTheStylus
{
    /*
     Приполучении события StylusDown она создает два объекта типа Polyline и включает
    их в коллекцию дочерних объектов Canvas. (Класс Polyline, как и Ellipse, наследует
    от класса Shape.) Программа захватывает стилус и добавляет дополнительные
    точки в каждую ломаную при получении событий StylusMove. Построение 
    ломаных завершается событием StylusUp или нажатием клавиши Escape.
    Программа рисует вторую ломаную со смещением от первой; так в реальном
    времени имитируется эффект отбрасываемой тени. Обратите внимание: в 
    коллекцию Points ломаной переднего плана всегда заносятся координаты ptStylus,
    а в коллекцию ломаной тени заносится сумма координат ptStylus и vectShadow.
     */
    public class ShadowTheStylus : Window
    {
        // Определения констант
        static readonly SolidColorBrush brushStylus = Brushes.Blue;
        static readonly SolidColorBrush brushShadow = Brushes.LightBlue;
        static readonly double widthStroke = 96 / 2.54; // 1 см
        static readonly Vector vectShadow = new Vector(widthStroke / 4, widthStroke / 4);
        // Дополнительные поля для операций перемещения стилуса
        Canvas canv;
        Polyline polyStylus, polyShadow;
        bool isDrawing;


        public static void Main()
        {
            Application app = new Application();
            app.Run(new ShadowTheStylus());
        }
        public ShadowTheStylus()
        {

            Title = "Shadow the Stylus";
            // Создание панели Canvas для содержимого окна
            canv = new Canvas();
            Content = canv;
        }
        protected override void OnStylusDown(StylusDownEventArgs args)
        {
            base.OnStylusDown(args);
            Point ptStylus = args.GetPosition(canv);
            // Создание основного объекта Polyline
            // с закругленными концами отрезков
            polyStylus = new Polyline();
            polyStylus.Stroke = brushStylus;
            polyStylus.StrokeThickness = widthStroke;
            polyStylus.StrokeStartLineCap =
            PenLineCap.Round;
            polyStylus.StrokeEndLineCap = PenLineCap.Round;
            polyStylus.StrokeLineJoin = PenLineJoin.Round;
            polyShadow.Points = new PointCollection();
            polyShadow.Points.Add(ptStylus);
            // Создание объекта Polyline для имитации тени
            polyShadow = new Polyline();
            polyShadow.Stroke = brushShadow;
            polyShadow.StrokeThickness = widthStroke;
            polyShadow.StrokeStartLineCap = PenLineCap.Round;
            polyShadow.StrokeEndLineCap = PenLineCap.Round;
            polyShadow.StrokeLineJoin = PenLineJoin.Round;
            polyShadow.Points = new PointCollection();
            polyShadow.Points.Add(ptStylus + vectShadow);
            // Тень вставляется перед ломаными переднего плана
            canv.Children.Insert(canv.Children.Count / 2, polyShadow);
            // Основная ломаная добавляется последней
            canv.Children.Add(polyStylus);
            CaptureStylus();
            isDrawing = true;
            args.Handled = true;
        }

        protected override void OnStylusMove(StylusEventArgs args)
        {
            base.OnStylusMove(args);
            if (isDrawing)
            {
                Point ptStylus =
                args.GetPosition(canv);
                polyStylus.Points.Add(ptStylus);
                polyShadow.Points.Add(ptStylus + vectShadow);
                args.Handled =
                true;
            }
        }
        protected override void OnStylusUp(StylusEventArgs args)
        {
            base.OnStylusUp(args);
            if (isDrawing)
            {
                isDrawing =
                false;
                ReleaseStylusCapture();
                args.Handled =
                true;
            }
        }
        protected override void OnTextInput(TextCompositionEventArgs args)
        {
            base.OnTextInput(args);
            // Рисование завершается клавишей Escape
            if (isDrawing && args.Text.IndexOf('\x1B') != -1)
            {
                ReleaseStylusCapture();
                args.Handled = true;
            }
        }
        protected override void OnLostStylusCapture(StylusEventArgs args)
        {
            base.OnLostStylusCapture(args);
            // Аномальное завершение рисования: удаление ломаных
            if (isDrawing)
            {
                canv.Children.Remove(polyStylus);
                canv.Children.Remove(polyShadow);
                isDrawing = false;
            }
        }
    }
}