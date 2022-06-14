
using System;
using System.Windows;
using System.Windows.Input;

namespace Petzold.InheritAppAndWindow
/*Проект называется InheritAppAnd-Window —это имя также присвоено классу, содержащему только метод Main.
Метод Main создает объект типа MyApplication и вызывает для него метод Run.*/
{
    class InheritAppAndWindow
    {
        [STAThread]
        public static void Main()
        {
            MyApplication app = new MyApplication();
            app.Run();
        }
    }
}
