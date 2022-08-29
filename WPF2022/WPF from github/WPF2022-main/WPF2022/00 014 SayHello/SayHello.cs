/*
 Program dependencies:   <-- Need to include to blank c# project
    System
    PresentationCore
    PresentationCoreFramework
    System.Windows 
    WindowsBase 
    System.Xaml
*/

// -----------------------------------------
// SayHello.cs (c) 2006 by Charles Petzold
// -----------------------------------------

using System;
using System.Windows;

namespace Petzold.SayHello
{
    class SayHello
    {
        [STAThread] // Program will use single-threaded model to run
        public static void Main()
        {
            Window win = new Window(); // Initializing the new object "window" 
            win.Title = "Say Hello"; // Make title for the window
            win.Show(); // Display that white box to user on desktop

            Application app = new Application();
            app.Run(); // Run the main event cycle that will keep the window open and track all user actions

            /*
              // Also the previous code can be simplified into:
              new Application().Run(new Window {Title = "Say Hello"});
            */
        }
    }
}