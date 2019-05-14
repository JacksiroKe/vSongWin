using System;
using System.Data;
using System.Windows.Forms;
using EasyTabs;

namespace vSongBook
{
    public partial class AppStart : Form
    {
        AppFunctions vsbf = new AppFunctions();
        AppSettings settings = new AppSettings();
        AppLanguage langs = new AppLanguage();
        public static AppTabs tabbedApp = new AppTabs();
        string vsb_lang = "English";
        
        public AppStart()
        {
            InitializeComponent();
            //settings.VsbVersion = "1.3.2.7";
            lblCopyright.Text = "© " + DateTime.Now.Year + " AppSmata";
            lblAppUser.Text = settings.AppUser;
            loadLanguages();
            cmbLanguage.Text = vsb_lang = settings.Language;
            LanguageStrings();
            txtAppUser.Text = settings.AppUser;
            tmrTimer0.Enabled = true;
            lblVersion.Text = "v" + settings.VsbVersion;
        }
        public void loadLanguages()
        {
            try
            {
                cmbLanguage.Items.Clear();
                AppLanguage applang = new AppLanguage();
                DataRowCollection dRowCol = applang.langList();

                foreach (DataRow row in dRowCol)
                {
                    cmbLanguage.Items.Add(row["name"]);
                }
            }
            catch (Exception)
            {
                //loadFeedback(langs.As_Lang(vsb_lang, "error_songs_listing") + " " + ex.Message, false);
            }
        }

        private void LanguageStrings()
        {
            grpJustaMinute.Text = langs.As_Lang(vsb_lang, "just_a_minute");
            lblLanguage.Text = langs.As_Lang(vsb_lang, "preffered_language");
            lblYourName.Text = langs.As_Lang(vsb_lang, "your_name_or_church");
            txtAppUser.Placeholder = langs.As_Lang(vsb_lang, "your_name");
        }

        private void tmrTimer0_Tick(object sender, EventArgs e)
        {
            pbxBackground.BackgroundImage = global::vSongBook.Properties.Resources.laptop2;
            tmrTimer0.Enabled = false;
            tmrTimer1.Enabled = true;
        }

        private void tmrTimer1_Tick(object sender, EventArgs e)
        {
            pbxBackground.BackgroundImage = global::vSongBook.Properties.Resources.laptop3;
            tmrTimer1.Enabled = false;
            tmrTimer2.Enabled = true;
        }

        private void tmrTimer2_Tick(object sender, EventArgs e)
        {
            pbxBackground.BackgroundImage = global::vSongBook.Properties.Resources.laptop4;
            tmrTimer2.Enabled = false;
            tmrTimer3.Enabled = true;
        }

        private void tmrTimer3_Tick(object sender, EventArgs e)
        {
            pbxBackground.BackgroundImage = global::vSongBook.Properties.Resources.laptop5;
            tmrTimer3.Enabled = false;
            pbxIcon.Visible = true;
            tmrName1.Enabled = true;
        }

        private void tmrName1_Tick(object sender, EventArgs e)
        {
            pbxName1.Visible = true;
            tmrName1.Enabled = false;
            tmrName2.Enabled = true;
        }

        private void tmrName2_Tick(object sender, EventArgs e)
        {
            pbxName2.Visible = true;
            tmrName2.Enabled = false;
            tmrName3.Enabled = true;
        }

        private void tmrName3_Tick(object sender, EventArgs e)
        {
            pbxName3.Visible = true;
            tmrName3.Enabled = false;
            tmrName4.Enabled = true;
        }

        private void tmrName4_Tick(object sender, EventArgs e)
        {
            pbxName4.Visible = true;
            tmrName4.Enabled = false;
            tmrName5.Enabled = true;
        }

        private void tmrName5_Tick(object sender, EventArgs e)
        {
            pbxName5.Visible = true;
            tmrName5.Enabled = false;
            tmrName6.Enabled = true;
        }

        private void tmrName6_Tick(object sender, EventArgs e)
        {
            pbxName6.Visible = true;
            tmrName6.Enabled = false;
            tmrName7.Enabled = true;
        }

        private void tmrName7_Tick(object sender, EventArgs e)
        {
            pbxName7.Visible = true;
            tmrName7.Enabled = false;
            tmrName8.Enabled = true;
        }

        private void tmrName8_Tick(object sender, EventArgs e)
        {
            pbxName8.Visible = true;
            tmrName8.Enabled = false;
            tmrName9.Enabled = true;
        }

        private void tmrName9_Tick(object sender, EventArgs e)
        {
            pbxName9.Visible = true;
            tmrName9.Enabled = false;
            tmrTimer4.Enabled = true;
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                settings.Language = cmbLanguage.Text;
            }
            catch (Exception) { }
        }

        private void txtAppUser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAppUser.Text.Length < 100)
                {
                    lblCharacters.Text = 100 - txtAppUser.Text.Length + " characters remaining ...";
                }
                else
                {
                    lblCharacters.Text = "";
                }

                settings.AppUser = txtAppUser.Text.Trim();
                settings.Installed = vsbf.dateToday();
            }
            catch (Exception) { }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            lblAppUser.Text = settings.AppUser;
            grpJustaMinute.Visible = false;
            tmrName1.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrTimer4_Tick(object sender, EventArgs e)
        {

            lblVersion.Visible = true;
            tmrTimer5.Enabled = false;
            if (lblAppUser.Text == "null")
            {
                pbxName1.Visible = false;
                pbxName2.Visible = false;
                pbxName3.Visible = false;
                pbxName4.Visible = false;
                pbxName5.Visible = false;
                pbxName6.Visible = false;
                pbxName7.Visible = false;
                pbxName8.Visible = false;
                pbxName9.Visible = false;
                lblVersion.Visible = false;
                grpJustaMinute.Visible = true;
            }
            else tmrTimer5.Enabled = true;
        }

        private void tmrTimer5_Tick(object sender, EventArgs e)
        {
            tblInfo.Visible = true;
            tmrName7.Enabled = false;
            tmrTimer6.Enabled = true;
        }

        private void tmrTimer6_Tick(object sender, EventArgs e)
        {
            lblAppUser.Visible = true;
            tmrName6.Enabled = false;
            tmrTimerMain.Enabled = true;
        }

        private void tmrTimerMain_Tick(object sender, EventArgs e)
        {
            tmrTimerMain.Enabled = false;
            lblLoaded.Text = "100%";
        }

        private void lblLoaded_TextChanged(object sender, EventArgs e)
        {
            /*if (settings.ShowHelpFirst)
            {
                tabbedApp.Tabs.Add(new TitleBarTab(tabbedApp)
                {
                    Content = new BbTutorial { Text = "Welcome to vSongBook" }
                });
            }*/
            tabbedApp.Tabs.Add(new TitleBarTab(tabbedApp)
            {
                Content = new CcSongView { Text = "Song Search 1" }
            });
            tabbedApp.SelectedTabIndex = 0;

            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(tabbedApp);
            tmrTabs.Enabled = true;
            this.Hide();
        }

        private void tmrTabs_Tick(object sender, EventArgs e)
        {
            if (AppStart.tabbedApp.Tabs.Count == 0) this.Close();
        }

        private void cmbLanguage_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                settings.Language = cmbLanguage.Text;
                vsb_lang = settings.Language;
                LanguageStrings();
            }
            catch (Exception) { }
        }
    }
}
