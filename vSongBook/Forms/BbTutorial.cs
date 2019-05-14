using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace vSongBook
{
    public partial class BbTutorial : Form
    {
        AppFunctions vsbf = new AppFunctions();
        AppSettings settings = new AppSettings();
        AppLanguage langs = new AppLanguage();

        public BbTutorial()
        {
            InitializeComponent();
        }

        private void BbTutorial_Load(object sender, EventArgs e)
        {
            string AppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            webBrowser1.Url = new Uri(Path.Combine(AppDir, @"Help\English.html"));
        }
    }
}
