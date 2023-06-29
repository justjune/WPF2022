//--------------------------------------------- 
// EditSomeText.cs (c) 2006 by Charles Petzold 
//--------------------------------------------- 
using System;
using System.ComponentModel;

// for  CancelEventArgs 

using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.EditSomeText
{
    class EditSomeText : Window
    {
        static string strFileName = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "Petzold\\EditSomeText\\EditSomeText.txt"); //статическое поле класса в котором будет храниться абсолютный путь к файлу EditSomeText.txt     
        TextBox txtbox;
        [STAThread] //запуск в одном потоке
        public static void Main()
        {
            Application app = new Application();  //создание объекта приложения
            app.Run(new EditSomeText()); // запуск приложения, а так же передает данные о приложении в данном случае объект класса RecordKeystrokes   
        }
        public EditSomeText()
        {
            Title = "Edit Some Text"; //добавление названия окна        
            // Create the text box.             
            txtbox = new TextBox(); //создание текствого поля
            txtbox.AcceptsReturn = true; // используется при нажатии на enter добавляет новую строку          
            txtbox.TextWrapping = TextWrapping.Wrap; //включает перенос текста (если текст выходит за ширину он переносится на новую строку)
            txtbox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto; // добавление вертикального скролла          
            txtbox.KeyDown += TextBoxOnKeyDown; // добавление собития нажатия на кнопку клавиатуры
            Content = txtbox; //добавление на экран текстового поля
            // Load the text file.             
            try
            {
                txtbox.Text = File.ReadAllText(strFileName); //загрузка текста с файла             
            }
            catch
            {
            }
            // Set the text box caret and input focus.             
            txtbox.CaretIndex = txtbox.Text.Length; //установка курсора в конец вставленной строки    
            txtbox.Focus(); //установка фокуса на поле ввода 
        }
        protected override void OnClosing(CancelEventArgs args)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strFileName)); //получение названия директории по пути      
                File.WriteAllText(strFileName, txtbox.Text); //запись текст в файл из поля ввода текста
            }
            catch (Exception exc)
            {
                //обработка исключения вызванного ошибкой записи или сохранения в файл
                MessageBoxResult result =
                    MessageBox.Show("File could  not be saved: " + exc.Message +
                    "\nClose  program anyway?", Title,
                    MessageBoxButton.YesNo, //отображение кнопок да нет                                      
                    MessageBoxImage.Exclamation); //будет содержать восклицательный знак в треугольнике                 
                args.Cancel = (result == MessageBoxResult.No); //закрытие если нажата кнопка нет             
            }
        }
        void TextBoxOnKeyDown(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.F5)
            {
                txtbox.SelectedText = DateTime.Now.ToString();  // заменяет выделленный текст на текущую дату                
                txtbox.CaretIndex = txtbox.SelectionStart +
                    txtbox.SelectionLength; //установка курсора на конец выделенного текста            
            }
        }
    }
}