//----------------------------------------------
// SimpleEllipse.cs (c) 2006 by Charles Petzold 
//----------------------------------------------
using System;
using System.Windows;
using System.Windows.Media; 
namespace Petzold.RenderTheGraphic
{  
    class SimpleEllipse : FrameworkElement  
    {      
        protected override void OnRender (DrawingContext dc)  
        {
            //Аргументы DrawEllipse сохраняются, а потом рисуются
            dc.DrawEllipse(Brushes.Blue, new Pen (Brushes.Red, 24),//Свойство RenderSize определяется перед вызовом OnRender на основании высоты и ширины  
                new Point(RenderSize.Width / 2,  RenderSize.Height / 2),    
                RenderSize.Width / 2, RenderSize .Height / 2); 
        }  
    }
}