
//--------------------------------------------------- 
// ExploreDirectories.cs (c) 2006 by Charles Petzold 
//--------------------------------------------------- 
using System; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Input; 
using System.Windows.Media; 
namespace Petzold.ExploreDirectories 
{     
    public class ExploreDirectories : Window     
    {         
        [STAThread]         
        public static void Main()         
        {             
            Application app = new Application();// создаем окошко             
            app.Run(new ExploreDirectories());         
        }         public ExploreDirectories()         
        {             Title = "Explore Directories";// заголовок окна             
            ScrollViewer scroll = new ScrollViewer();// содержимое окна             
            Content = scroll;             
            WrapPanel wrap = new WrapPanel();             
            scroll.Content = wrap;             
            wrap.Children.Add(new  FileSystemInfoButton());         
        }     
    } 
} 