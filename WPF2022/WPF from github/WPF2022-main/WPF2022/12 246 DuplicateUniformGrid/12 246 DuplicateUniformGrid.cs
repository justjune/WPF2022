using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.DuplicateUniformGrid
{
    class UniformGridAlmost : Panel //добавили класс -- пример со стр. 244, 
                                    //чтобы можно было его использовать в нашем примере
    {
        // Открытые статистические зависимые свойства только для чтения.
        public static readonly DependencyProperty ColumnsProperty;
        // Статистический конструктор для создания зависимого свойства.
        static UniformGridAlmost()
        {
            ColumnsProperty =
            DependencyProperty.Register(
                    "Columns", typeof(int), typeof(UniformGridAlmost),
                    new FrameworkPropertyMetadata(1,
                    FrameworkPropertyMetadataOptions.AffectsMeasure));
        }
        // Свойство Columns.
        public int Columns
        {
            set { SetValue(ColumnsProperty, value); }
            get { return (int)GetValue(ColumnsProperty); }
        }
        // Свойство Rows, доступное только для чтения.
        public int Rows
        {
            get { return (InternalChildren.Count + Columns - 1) / Columns; }
        }
        // Переопределение MeasureOverride распределяет место.
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            // Вычисление размера дочернего элемента.
            Size sizeChild = new Size(sizeAvailable.Width / Columns,
            sizeAvailable.Height / Rows);
            // Переменные для накопления максимальных ширин и высот.
            double maxwidth = 0;
            double maxheight = 0;
            foreach (UIElement child in InternalChildren)
            {
                // Вызвать Measure для каждого дочернего объекта ...
                child.Measure(sizeChild);
                // ... а затем проверить свойство DesiredSize дочернего объекта.
                maxwidth = Math.Max(maxwidth, child.DesiredSize.Width);
                maxheight = Math.Max(maxheight, child.DesiredSize.Height);
            }
            // Теперь вычисляется желательный размер для самой решётки.
            return new Size(Columns * maxwidth, Rows * maxheight);
        }
        // Переопределение ArrangeOverride размещает дочерние объекты.
        protected override Size ArrangeOverride(Size sizeFinal)
        {
            // Вычисление размера дочерних объектов
            // для строк и столбцов одинакового размера.
            Size sizeChild = new Size(sizeFinal.Width / Columns,
            sizeFinal.Height / Rows);
            for (int index = 0; index < InternalChildren.Count; index++)
            {
                int row = index / Columns;
                int col = index % Columns;
                // Вычисление прямоугольника для каждого дочернего объекта
                // в границах sizeFinal...
                Rect rectChild =
                     new Rect(new Point(col * sizeChild.Width,
                      row * sizeChild.Height),
                      sizeChild);
                // ... и вызов Arrange для этого объекта.
                InternalChildren[index].Arrange(rectChild);
            }
            return sizeFinal;
        }
    }

    public class DuplicateUniformGrid : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DuplicateUniformGrid());
        }
        public DuplicateUniformGrid()
        {
            Title = "Duplicate Uniform Grid";
            // Создание объекта UniformGridAlmost как содержимого окна.
            UniformGridAlmost unigrid = new UniformGridAlmost();
            unigrid.Columns = 5;
            Content = unigrid;

            // Заполнение UniformGridAlmost кнопками случайного размера.
            Random rand = new Random();
            for (int index = 0; index < 48; index++)
            {
                Button btn = new Button();   //в .btn классы предназначены для использования Button (обычная кнопка)          
                btn.Name = "Button" + index; //имя кнопки "Button + индекс"       
                btn.Content = btn.Name;
                btn.FontSize += rand.Next(10); //размер шрифта         
                unigrid.Children.Add(btn);
            }
            AddHandler(Button.ClickEvent, //связывает событие с обработчиком событий во время выполнения
                new RoutedEventHandler(ButtonOnClick));  //перенаправление события
        }
        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            Button btn = args.Source as Button;
            MessageBox.Show(btn.Name + " has  been clicked", Title);    //отображает окно сообщение с текстом "номер + has been clicked" 
        }
    }
}
