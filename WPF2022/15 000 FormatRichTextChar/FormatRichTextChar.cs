using Petzold.SelectColorFromGrid;      // для использования класса ColorGridBox
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Petzold.FormatRichText
{
    public partial class FormatRichText : Window
    {
        // Метод для добавления панели инструментов редактирования
        void AddEditToolBar(ToolBarTray tray, int band, int index)
        {
            // Создание панели инструментов
            ToolBar toolbar = new ToolBar();
            toolbar.Band = band;
            toolbar.BandIndex = index;
            tray.ToolBars.Add(toolbar);

            // Команды редактирования
            RoutedUICommand[] comm =
            {
                ApplicationCommands.Cut, ApplicationCommands.Copy,
                ApplicationCommands.Paste, ApplicationCommands.Delete,
                ApplicationCommands.Undo, ApplicationCommands.Redo
            };

            // Изображения для кнопок
            string[] strImages =
            {
                "CutHS.png", "CopyHS.png",
                "PasteHS.png", "DeleteHS.png",
                "Edit_UndoHS.png", "Edit_RedoHS.png"
            };

            for (int i = 0; i < 6; i++)
            {
                if (i == 4)
                    toolbar.Items.Add(new Separator());

                Button btn = new Button();
                btn.Command = comm[i];
                toolbar.Items.Add(btn);

                Image img = new Image();
                img.Source = new BitmapImage(new Uri("pack://application:,,/Images/" + strImages[i]));
                img.Stretch = Stretch.None;
                btn.Content = img;

                ToolTip tip = new ToolTip();
                tip.Content = comm[i].Text;
                btn.ToolTip = tip;
            }

            // Привязка команд
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Cut));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete, OnDelete, CanDelete));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Undo));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Redo));
        }

        // Метод проверки возможности удаления выделенного текста
        void CanDelete(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = !txtbox.Selection.IsEmpty;
        }

        // Метод удаления выделенного текста
        void OnDelete(object sender, ExecutedRoutedEventArgs args)
        {
            txtbox.Selection.Text = "";
        }
    }
}

namespace Petzold.FormatRichText
{
    public partial class FormatRichText : Window
    {
        RichTextBox txtbox;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FormatRichText());
        }

        public FormatRichText()
        {
            Title = "Форматирование текста";
            
            // Создание панели DockPanel в качестве содержимого окна.
            DockPanel dock = new DockPanel();
            Content = dock;
            
            // Создание панели инструментов ToolBarTray, расположенной вверху клиентской области.
            ToolBarTray tray = new ToolBarTray();
            dock.Children.Add(tray);
            DockPanel.SetDock(tray, Dock.Top);
            
            // Создание элемента RichTextBox.
            txtbox = new RichTextBox();
            txtbox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            
            // Вызов методов из других файлов.
            AddFileToolBar(tray, 0, 0);
            AddEditToolBar(tray, 1, 0);
            AddCharToolBar(tray, 2, 0);
            AddParaToolBar(tray, 2, 1);
            AddStatusBar(dock);
            
            // Заполнение оставшейся части клиентской области элементом RichTextBox и установка фокуса на него.
            dock.Children.Add(txtbox);
            txtbox.Focus();
        }
    }
}


namespace Petzold.SelectColorFromGrid
{
    class ColorGridBox : ListBox
    {
        // Добавляем свойство SelectedColor
        public Color SelectedColor
        {
            get { return (Color)SelectedItem; }
            set { SelectedItem = value; }
        }
        // Цвета для отображения
        string[] strColors =
        {
            "Black", "Brown", "DarkGreen", "MidnightBlue",
            "Navy", "DarkBlue", "Indigo", "DimGray",
            "DarkRed", "OrangeRed", "Olive", "Green",
            "Teal", "Blue", "SlateGray", "Gray",
            "Red", "Orange", "YellowGreen", "SeaGreen",
            "Aqua", "LightBlue", "Violet", "DarkGray",
            "Pink", "Gold", "Yellow", "Lime",
            "Turquoise", "SkyBlue", "Plum", "LightGray",
            "LightPink", "Tan", "LightYellow", "LightGreen",
            "LightCyan", "LightSkyBlue", "Lavender", "White"
        };

        public ColorGridBox()
        {
            // Определение шаблона ItemsPanel
            FrameworkElementFactory factoryUnigrid =
                new FrameworkElementFactory(typeof(UniformGrid));
            factoryUnigrid.SetValue(UniformGrid.ColumnsProperty, 8);
            ItemsPanel = new ItemsPanelTemplate(factoryUnigrid);

            // Добавление элементов в ListBox
            foreach (string strColor in strColors)
            {
                // Создание прямоугольника и добавление его в ListBox
                Rectangle rect = new Rectangle();
                rect.Width = 12;
                rect.Height = 12;
                rect.Margin = new Thickness(4);
                rect.Fill = (Brush)typeof(Brushes).GetProperty(strColor).GetValue(null, null);
                Items.Add(rect);

                // Создание всплывающей подсказки для прямоугольника
                ToolTip tip = new ToolTip();
                tip.Content = strColor;
                rect.ToolTip = tip;
            }

            // Указание, что свойство SelectedValue - это Fill прямоугольника
            SelectedValuePath = "Fill";
        }
    }
}


namespace Petzold.SelectColorFromGrid
{
    public class SelectColorFromGrid : Window
    {
        [STAThread]
        public static void Main()
        {
            // Создание и запуск объекта приложения
            Application app = new Application();
            app.Run(new SelectColorFromGrid());
        }
        
        public SelectColorFromGrid()
        {
            // Настройка окна
            Title = "Выбор цвета из сетки";
            SizeToContent = SizeToContent.WidthAndHeight;

            // Создание StackPanel в качестве содержимого окна
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            Content = stack;

            // Создание кнопки-заглушки для проверки перехода по вкладкам
            Button btn = new Button();
            btn.Content = "Кнопка-заглушка\nдля проверки перехода по вкладкам";
            btn.Margin = new Thickness(24);
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            stack.Children.Add(btn);

            // Создание элемента управления ColorGridBox
            ColorGridBox clrgrid = new ColorGridBox();
            clrgrid.Margin = new Thickness(24);
            clrgrid.HorizontalAlignment = HorizontalAlignment.Center;
            clrgrid.VerticalAlignment = VerticalAlignment.Center;
            stack.Children.Add(clrgrid);

            // Привязка фона окна к выбранному значению в ColorGridBox
            clrgrid.SetBinding(ColorGridBox.SelectedValueProperty, "Background");
            clrgrid.DataContext = this;

            // Создание еще одной кнопки-заглушки
            btn = new Button();
            btn.Content = "Кнопка-заглушка\nдля проверки перехода по вкладкам";
            btn.Margin = new Thickness(24);
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            stack.Children.Add(btn);
        }
    }
}


namespace Petzold.FormatRichText
{
    public partial class FormatRichText : Window
    {
        // Объявление переменных
        ComboBox comboFamily, comboSize;
        ToggleButton btnBold, btnItalic;
        ColorGridBox clrboxBackground, clrboxForeground;

        void AddCharToolBar(ToolBarTray tray, int band, int index)
        {
            // Создание и добавление ToolBar в ToolBarTray.
            ToolBar toolbar = new ToolBar();
            toolbar.Band = band;
            toolbar.BandIndex = index;
            tray.ToolBars.Add(toolbar);

            // Создание ComboBox для выбора шрифта.
            comboFamily = new ComboBox();
            comboFamily.Width = 144;
            comboFamily.ItemsSource = Fonts.SystemFontFamilies;
            comboFamily.SelectedItem = txtbox.FontFamily;
            comboFamily.SelectionChanged += FamilyComboOnSelection;
            toolbar.Items.Add(comboFamily);

            // Создание ComboBox для выбора размера шрифта.
            comboSize = new ComboBox();
            comboSize.Width = 48;
            comboSize.IsEditable = true;
            comboSize.Text = (0.75 * txtbox.FontSize).ToString();
            comboSize.ItemsSource = new double[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            comboSize.SelectionChanged += SizeComboOnSelection;
            comboSize.GotKeyboardFocus += SizeComboOnGotFocus;
            comboSize.LostKeyboardFocus += SizeComboOnLostFocus;
            comboSize.PreviewKeyDown += SizeComboOnKeyDown;
            toolbar.Items.Add(comboSize);

            // Создание кнопки Bold.
            btnBold = new ToggleButton();
            btnBold.Checked += BoldButtonOnChecked;
            btnBold.Unchecked += BoldButtonOnChecked;
            toolbar.Items.Add(btnBold);

            // Создание кнопки Italic.
            btnItalic = new ToggleButton();
            btnItalic.Checked += ItalicButtonOnChecked;
            btnItalic.Unchecked += ItalicButtonOnChecked;
            toolbar.Items.Add(btnItalic);

            // Создание меню для выбора цвета фона и цвета текста.
            Menu menu = new Menu();
            toolbar.Items.Add(menu);

            // Создание элемента меню для выбора цвета фона.
            MenuItem item = new MenuItem();
            menu.Items.Add(item);
            clrboxBackground = new ColorGridBox();
            clrboxBackground.SelectionChanged += BackgroundOnSelectionChanged;
            item.Items.Add(clrboxBackground);

            // Создание элемента меню для выбора цвета текста.
            item = new MenuItem();
            menu.Items.Add(item);
            clrboxForeground = new ColorGridBox();
            clrboxForeground.SelectionChanged += ForegroundOnSelectionChanged;
            item.Items.Add(clrboxForeground);

            // Установка обработчика события SelectionChanged для RichTextBox.
            txtbox.SelectionChanged += TextBoxOnSelectionChanged;
        }

        // Обработчик события SelectionChanged для RichTextBox.
        void TextBoxOnSelectionChanged(object sender, RoutedEventArgs args)
        {
            // Получение текущего FontFamily выделенного текста и установка его в ComboBox.
            object obj = txtbox.Selection.GetPropertyValue(FlowDocument.FontFamilyProperty);
            if (obj is FontFamily)
                comboFamily.SelectedItem = (FontFamily)obj;
            else
                comboFamily.SelectedIndex = -1;

            // Получение текущего FontSize выделенного текста и установка его в ComboBox.
            obj = txtbox.Selection.GetPropertyValue(FlowDocument.FontSizeProperty);
            if (obj is double)
                comboSize.Text = (0.75 * (double)obj).ToString();
            else
                comboSize.SelectedIndex = -1;

            // Получение текущего FontWeight выделенного текста и установка состояния кнопки Bold.
            obj = txtbox.Selection.GetPropertyValue(FlowDocument.FontWeightProperty);
            if (obj is FontWeight)
                btnBold.IsChecked = (FontWeight)obj == FontWeights.Bold;

            // Получение текущего FontStyle выделенного текста и установка состояния кнопки Italic.
            obj = txtbox.Selection.GetPropertyValue(FlowDocument.FontStyleProperty);
            if (obj is FontStyle)
                btnItalic.IsChecked = (FontStyle)obj == FontStyles.Italic;

            // Получение текущих цветов выделенного текста и установка их в ColorGridBox.
            obj = txtbox.Selection.GetPropertyValue(FlowDocument.BackgroundProperty);
            if (obj != null && obj is Brush)
                clrboxBackground.SelectedValue = (Brush)obj;

            obj = txtbox.Selection.GetPropertyValue(FlowDocument.ForegroundProperty);
            if (obj != null && obj is Brush)
                clrboxForeground.SelectedValue = (Brush)obj;
        }

        // Обработчик события SelectionChanged для ComboBox выбора FontFamily.
        void FamilyComboOnSelection(object sender, SelectionChangedEventArgs args)
        {
            ComboBox combo = args.Source as ComboBox;
            FontFamily family = combo.SelectedItem as FontFamily;
            if (family != null)
                txtbox.Selection.ApplyPropertyValue(FlowDocument.FontFamilyProperty, family);
            txtbox.Focus();
        }

        // Обработчики событий для ComboBox выбора размера шрифта.
        string strOriginal;
        void SizeComboOnGotFocus(object sender, KeyboardFocusChangedEventArgs args)
        {
            strOriginal = (sender as ComboBox).Text;
        }

        void SizeComboOnLostFocus(object sender, KeyboardFocusChangedEventArgs args)
        {
            double size;
            if (Double.TryParse((sender as ComboBox).Text, out size))
                txtbox.Selection.ApplyPropertyValue(FlowDocument.FontSizeProperty, size / 0.75);
            else
                (sender as ComboBox).Text = strOriginal;
        }

        void SizeComboOnKeyDown(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Escape)
            {
                (sender as ComboBox).Text = strOriginal;
                args.Handled = true;
                txtbox.Focus();
            }
            else if (args.Key == Key.Enter)
            {
                args.Handled = true;
                txtbox.Focus();
            }
        }

        void SizeComboOnSelection(object sender, SelectionChangedEventArgs args)
        {
            ComboBox combo = args.Source as ComboBox;
            if (combo.SelectedIndex != -1)
            {
                double size = (double)combo.SelectedValue;
                txtbox.Selection.ApplyPropertyValue(FlowDocument.FontSizeProperty, size / 0.75);
                txtbox.Focus();
            }
        }

        // Обработчик события Checked/Unchecked для кнопки Bold.
        void BoldButtonOnChecked(object sender, RoutedEventArgs args)
        {
            bool? isChecked = (sender as ToggleButton).IsChecked;
            if (isChecked.HasValue)
                txtbox.Selection.ApplyPropertyValue(FlowDocument.FontWeightProperty, isChecked.Value ? FontWeights.Bold : FontWeights.Normal);
            txtbox.Focus();
        }

        // Обработчик события Checked/Unchecked для кнопки Italic.
        void ItalicButtonOnChecked(object sender, RoutedEventArgs args)
        {
            bool? isChecked = (sender as ToggleButton).IsChecked;
            if (isChecked.HasValue)
                txtbox.Selection.ApplyPropertyValue(FlowDocument.FontStyleProperty, isChecked.Value ? FontStyles.Italic : FontStyles.Normal);
            txtbox.Focus();
        }

        // Обработчик события SelectionChanged для ColorGridBox выбора цвета фона.
        void BackgroundOnSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            Color clr = (sender as ColorGridBox).SelectedColor;
            if (clr != null)
                txtbox.Selection.ApplyPropertyValue(FlowDocument.BackgroundProperty, new SolidColorBrush(clr));
            txtbox.Focus();
        }

        // Обработчик события SelectionChanged для ColorGridBox выбора цвета текста.
        void ForegroundOnSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            Color clr = (sender as ColorGridBox).SelectedColor;
            if (clr != null)
                txtbox.Selection.ApplyPropertyValue(FlowDocument.ForegroundProperty, new SolidColorBrush(clr));
            txtbox.Focus();
        }
    }
}
