using EasyTabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vSongBook
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static AppTabs tabbedApp;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            tabbedApp = new AppTabs();
            tabbedApp.Tabs.Add(new TitleBarTab(tabbedApp)
            {
                Content = new AaSongBook { Text = "vSongBook Search" }
            });

            tabbedApp.SelectedTabIndex = 0;

            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(tabbedApp);

            Application.Run(applicationContext);

            //Application.Run(new EeSettings());
        }
    }
}
