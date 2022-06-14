namespace Petzold.ControlXCV
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    /*Программа определяет и инициализирует четыре объекта KeyGesture; кроме
    того, она должна задать соответствующую строку свойству InputGestureText 
    каждого объекта Menultem. (К сожалению, сам класс KeyGesture не предоставляет эту
    информацию методом ToString или иным способом.)
    Метод OnPreviewKeyDown сначала устанавливает флаг Handled аргументов 
    события, а затем сбрасывает его, если клавиша не совпадает ни с одной из 
    определенных комбинаций.*/
    public class ControlXCV : Petzold.CutCopyAndPaste.CutCopyAndPaste
    {
        #region Fields

        KeyGesture gestCopy = new KeyGesture(Key.C, ModifierKeys.Control);
        KeyGesture gestCut = new KeyGesture(Key.X, ModifierKeys.Control);
        KeyGesture gestDelete = new KeyGesture(Key.Delete);
        KeyGesture gestPaste = new KeyGesture(Key.V, ModifierKeys.Control);

        #endregion Fields

        #region Constructors

        public ControlXCV()
        {
            Title = "Control X, C, and V";

            itemCut.InputGestureText = "Ctrl+X";
            itemCopy.InputGestureText = "Ctrl+C";
            itemPaste.InputGestureText = "Ctrl+V";
            itemDelete.InputGestureText = "Delete";
        }

        #endregion Constructors

        #region Methods

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ControlXCV());
        }

        protected override void OnPreviewKeyDown(KeyEventArgs args)
        {
            base.OnKeyDown(args);
            args.Handled = true;

            if (gestCut.Matches(null, args))
                CutOnClick(this, args);
            else if (gestCopy.Matches(null, args))
                CopyOnClick(this, args);
            else if (gestPaste.Matches(null, args))
                PasteOnClick(this, args);
            else if (gestDelete.Matches(null, args))
                DeleteOnClick(this, args);
            else
                args.Handled = false;
        }

        #endregion Methods
    }
}