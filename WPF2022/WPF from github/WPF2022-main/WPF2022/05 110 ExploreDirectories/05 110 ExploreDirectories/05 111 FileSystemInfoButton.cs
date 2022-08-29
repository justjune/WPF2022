//----------------------------------------------------- 
// FileSystemInfoButton.cs (c) 2006 by Charles Petzold 
//----------------------------------------------------- 
using System; using System.Diagnostics;       
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.ExploreDirectories
{     
    public class FileSystemInfoButton : Button     
    {         FileSystemInfo info;                  
        public FileSystemInfoButton()// конструктор создает кнопку для каталога                
            :             
            this(new DirectoryInfo(                 
                Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments)))         
        {         
        }                      
        public FileSystemInfoButton(FileSystemInfo  info)// конструктор создает кнопку для каталога или файла     
        {             
            this.info = info;             
            Content = info.Name;             
            if (info is DirectoryInfo)                 
                FontWeight = FontWeights.Bold;             
            Margin = new Thickness(10);         }             
        public FileSystemInfoButton(FileSystemInfo  info, string str)// создает кнопку для вовращения к родительскому каталогу             
            :             
            this(info)         
        {             
            Content = str;         
        }                 
        protected override void OnClick()         
        {             
            if (info is FileInfo)             
            {                 
                Process.Start(info.FullName);// метод для запуска приложения             
            }             
            else if (info is DirectoryInfo)             
            {                 
                DirectoryInfo dir = info as  DirectoryInfo;                 
                Application.Current.MainWindow .Title = dir.FullName;// имя каталога отобржается в заголовке окна                 
                Panel pnl = Parent as Panel;                 
                pnl.Children.Clear();                 
                if (dir.Parent != null)                     
                    pnl.Children.Add(new  FileSystemInfoButton(dir.Parent, ".."));// создание кнопки перехода на верхний уровень, если каталог не является корневым              
                foreach (FileSystemInfo inf in dir .GetFileSystemInfos())                     
                    pnl.Children.Add(new  FileSystemInfoButton(inf));             
            }             base.OnClick();         
        }     
    } 
} 