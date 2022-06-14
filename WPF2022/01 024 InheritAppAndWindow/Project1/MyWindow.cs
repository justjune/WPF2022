using System;
using System.Windows;
using System.Windows.Input;

namespace Petzold.InheritAppAndWindow

{
    public class MyWindow : Window
    {
        public MyWindow()
        {
            //инициализация сводится к заданию свойства Title.
            Title = "Inherit App & Window";
        }
        protected override void OnMouseDown(MouseButtonEventArgs args)
        {
            /*метод OnMouseDown является
            методом экземпляра, он может передать ключевое слово this методу GetPosition
            для указания объекта Window*/
            base.OnMouseDown(args);
            string strMessage =
            string.Format("Window clicked with {0} button at point ({1})",
            args.ChangedButton, args.GetPosition(this));

            MessageBox.Show(strMessage, Title);
        }
    }
}
