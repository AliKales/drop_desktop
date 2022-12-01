using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Drop
{
    internal class PageChanger
    {
        public static class MainWindowNavigation
        {
            public static void ChangePage(Page page)
            {
                var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                if (mainWindow != null)
                    mainWindow.Content = page;
            }
        }
    }
}
