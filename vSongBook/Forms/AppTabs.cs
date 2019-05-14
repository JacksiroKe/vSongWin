using EasyTabs;
namespace vSongBook
{
    public partial class AppTabs : TitleBarTabs
    {
        public AppTabs()
        {
            InitializeComponent();

            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
            Icon = vSongBook.Properties.Resources.appico;
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new CcSongView { Text = "Song Search " + (AppStart.tabbedApp.Tabs.Count + 1) }
            };
        }
    }
}
