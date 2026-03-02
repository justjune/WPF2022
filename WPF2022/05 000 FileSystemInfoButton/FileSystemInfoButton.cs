using System; 
using System.Diagnostics;       // Для Process  
using System.IO; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Input; 
using System.Windows.Media; 

namespace Petzold.ExploreDirectories 
{     
    public class FileSystemInfoButton : Button
    {
        FileSystemInfo info;

        // Параметрезированный конструктор для создания кнопки "My Documents" без аргументов.
        public FileSystemInfoButton()
            : this(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)))
        {
        }

        // Параметрезированный конструктор для создания кнопки на основе объекта FileSystemInfo.
        public FileSystemInfoButton(FileSystemInfo info)
        {
            this.info = info;//Присваивание значению переменной info текущего объекта FileSystemInfoButton.
            Content = info.Name;//Установка содержимого кнопки равным имени файла или директории.
            if (info is DirectoryInfo)
                FontWeight = FontWeights.Bold;//Если текущий объект info является директорией, то устанавливается жирное начертание шрифта для кнопки.
            Margin = new Thickness(10);//Установка отступа кнопки равным 10 пикселям со всех сторон.
        }

        // Параметрезированный конструктор для создания кнопки "Parent Directory" с указанием текста.
        public FileSystemInfoButton(FileSystemInfo info, string str)
            : this(info)
        {
            Content = str;
        }

        // Переопределение метода OnClick для выполнения дополнительных действий при нажатии кнопки.
        protected override void OnClick()
        {
            if (info is FileInfo)
            {
                // Если FileSystemInfo является файлом, запускаем его.
                Process.Start(info.FullName);
            }
            else if (info is DirectoryInfo)
            {
                // Если FileSystemInfo является директорией, обновляем заголовок главного окна, очищаем содержимое панели и добавляем новые кнопки для каждого элемента внутри директории.
                DirectoryInfo dir = info as DirectoryInfo;//Создание переменной dir, содержащей информацию о директории.
                Application.Current.MainWindow.Title = dir.FullName;//Установка заголовка главного окна приложения равным полному пути текущей директории.
                Panel pnl = Parent as Panel;//Создание переменной pnl, которая ссылается на родительскую панель, где располагается кнопка.
                pnl.Children.Clear();//Очистка содержимого панели путем удаления всех дочерних элементов.
                if (dir.Parent != null)
                    pnl.Children.Add(new FileSystemInfoButton(dir.Parent, ".."));//Добавление кнопки "Parent Directory" (с текстом "..") в панель, если текущая директория имеет родительскую директорию.
                foreach (FileSystemInfo inf in dir.GetFileSystemInfos())
                    pnl.Children.Add(new FileSystemInfoButton(inf));//Создание и добавление кнопок для каждого элемента (файлы и директории) в текущей директории в панель.
            }

            base.OnClick();//Вызов базовой реализации обработчика события клика кнопки.
        }     
    } 
}
