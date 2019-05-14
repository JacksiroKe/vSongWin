using System;
using System.Data;
using System.Drawing;
using System.Data.SQLite;
using System.Windows.Forms;
using EasyTabs;

namespace vSongBook
{
    public partial class CcSongView : Form
    {
        string sqlQuery;
        AppDatabase appDB;
        SQLiteDataReader reader;
        DataRowCollection dRowCol;
        private AppFunctions vsbf = new AppFunctions();
        private AppSettings settings = new AppSettings();
        AppLanguage langs = new AppLanguage();
        int previewsize = 0;
        string vsb_lang = "English";

        public CcSongView()
        {
            InitializeComponent();
            cmbLanguage.Text = vsb_lang = settings.Language;
            LanguageStrings();
            loadBooks();
            loadLanguages();
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
            grpCriteria.Text = langs.As_Lang(vsb_lang, "search_criteria");
            lblSearchAll.Text = langs.As_Lang(vsb_lang, "search_all_songbooks");
            grpSongResults.Text = langs.As_Lang(vsb_lang, "songs_found");
            txtSearch.Text = langs.As_Lang(vsb_lang, "search_for_songs");
        }

        private void CcSongView_Resize(object sender, EventArgs e)
        {
            //InitializeComponent();
            //loadBooks();
        }

        private void loadFeedback(string fbmessage, bool positive = true, bool timed = false, float interval = 1000)
        {
            jsFeedback.Interval = interval == 0 ? interval : jsFeedback.Interval;
            jsFeedback.IsPositive = positive;
            jsFeedback.IsTimed = timed;
            jsFeedback.Text = fbmessage;
            jsFeedback.Visible = true;
        }

        private void CcSongView_Load(object sender, EventArgs e)
        {
            btnSearchAll.IsOn = settings.SearchAllBooks;
            tsbtnBold.Checked = settings.FontBoldPreview;
            previewsize = settings.FontSizePreview;

            try { lstSongResults.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); } 
            catch (Exception) { }
            try { txtSongContent.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, settings.FontBoldPreview ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); } 
            catch (Exception) { }

        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            settings.SearchAllBooks = btnSearchAll.IsOn;
            seachForSongs(txtSearch.Text, btnSearchAll.IsOn);
        }
                
        private void grpCriteria_Enter(object sender, EventArgs e)
        {
            if (btnSearchAll.IsOn) btnSearchAll.IsOn = false;
            else btnSearchAll.IsOn = true;
            settings.SearchAllBooks = btnSearchAll.IsOn;
            seachForSongs(txtSearch.Text, btnSearchAll.IsOn);
        }
        
        private void lblSearchAll_Enter(object sender, EventArgs e)
        {
            if (btnSearchAll.IsOn) btnSearchAll.IsOn = false;
            else btnSearchAll.IsOn = true;
            settings.SearchAllBooks = btnSearchAll.IsOn;
            seachForSongs(txtSearch.Text, btnSearchAll.IsOn);
        }
        private void lblSearchAll_Click(object sender, EventArgs e)
        {
            if (btnSearchAll.IsOn) btnSearchAll.IsOn = false;
            else btnSearchAll.IsOn = true;
            settings.SearchAllBooks = btnSearchAll.IsOn;
            seachForSongs(txtSearch.Text, btnSearchAll.IsOn);
        }

        private void cmbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBookcodes.SelectedIndex = cmbBooks.SelectedIndex;
        }

        private void lstBookcodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadBookSongs(lstBookcodes.Text);
        }

        private void lstSongResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstSongids.SelectedIndex = lstSongResults.SelectedIndex;
        }

        private void lstSongids_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSingleSong(Int32.Parse(lstSongids.Text));
        }

        private void lstSongResults_KeyDown(object sender, KeyEventArgs e)
        {
            loadSingleSong(Int32.Parse(lstSongids.Text));
            projectSong();
        }

        public void loadBooks()
        {
            try
            {
                cmbBooks.Items.Clear();
                lstBookcodes.Items.Clear();
                sqlQuery = "SELECT * FROM books WHERE state=1;";
                appDB = new AppDatabase();
                dRowCol = appDB.GetList(sqlQuery);
                
                foreach (DataRow row in dRowCol)
                {
                    cmbBooks.Items.Add(row["title"] + " (" + row["songs"] + ")");
                    lstBookcodes.Items.Add(row["code"]);
                    cmbBooks.SelectedIndex = 0;
                    lstBookcodes.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                loadFeedback(langs.As_Lang(vsb_lang, "error_books_listing") + " " + ex.Message, false);
            }
        }

        public void loadBookSongs(string code)
        {
            try
            {
                lstSongResults.Items.Clear();
                lstSongids.Items.Clear();

                sqlQuery = "SELECT songid, number, title FROM songs WHERE book='" + code + "';";
                appDB = new AppDatabase();
                dRowCol = appDB.GetList(sqlQuery);

                foreach (DataRow row in dRowCol)
                {
                    lstSongResults.Items.Add(row["number"] + "# " + vsbf.textRender(row["title"].ToString()));
                    lstSongids.Items.Add(row["songid"]);
                    lstSongResults.SelectedIndex = 0;
                    lstSongids.SelectedIndex = 0;
                }
                string[] valuestrings = { lstSongResults.Items.Count.ToString(), lstBookcodes.Text};
                grpSongResults.Text = langs.As_Lang_Arr(langs.As_Lang(vsb_lang, "songs_found"), valuestrings);
            }
            catch (Exception ex)
            {
                loadFeedback(langs.As_Lang(vsb_lang, "error_songs_listing") + " " + ex.Message, false);
            }
        }
                
        public void loadSingleSong(int songid)
        {
            try
            {
                txtSongContent.Clear();
                sqlQuery = "SELECT *, books.title AS songbook FROM songs LEFT JOIN books ON songs.book = books.code WHERE songid=" + songid + ";";
                appDB = new AppDatabase();
                reader = appDB.GetSingle(sqlQuery);
                while (reader.Read())
                {
                    txtSongTitle.Text = reader["number"].ToString() + "# " + vsbf.textRender(reader["title"].ToString()) + 
                        " | " + reader["songbook"].ToString();
                    txtSongContent.Text = vsbf.songRender(reader["content"].ToString());
                    txtSongDetails.Text = "Key: " + reader["key"].ToString() + " © " + reader["author"].ToString() + "\r\n" +
                        reader["notes"].ToString() + "\r\nLast Updated: " + reader["updated"].ToString();
                }
                appDB.SQLClose();
            }
            catch (Exception ex)
            {
                loadFeedback(langs.As_Lang(vsb_lang, "error_songs_viewing") + " " + ex.Message, false, true);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                        seachForSongs(txtSearch.Text, btnSearchAll.IsOn);
                    break;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void projectSong()
        {
            try
            {
                settings.CurrentSong = Int32.Parse(lstSongids.Text);
                DdProject project = new DdProject();
                project.Show();
            }
            catch (Exception)
            {
                loadFeedback(langs.As_Lang(vsb_lang, "error_unknown"), false, true);
            }
        }

        private void tsbtnProject_Click(object sender, EventArgs e)
        {
            projectSong();
        }

        private void tsbtnLast_Click(object sender, EventArgs e)
        {
            try
            {
                lstSongResults.SelectedIndex = lstSongResults.SelectedIndex - 1;
            }
            catch (Exception)
            {
                loadFeedback(langs.As_Lang(vsb_lang, "error_previous_songs"), false, true);
            }
        }

        private void tsbtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                lstSongResults.SelectedIndex = lstSongResults.SelectedIndex + 1;
            }
            catch (Exception)
            {
                loadFeedback(langs.As_Lang(vsb_lang, "error_next_songs"), false, true);
            }
        }

        private void tsbtnSmaller_Click(object sender, EventArgs e)
        {
            if (previewsize >= 10)
            {
                try
                {
                    previewsize = previewsize - 2;
                    settings.FontSizePreview = previewsize;
                    txtSongContent.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, settings.FontBoldPreview ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
                catch (Exception)
                {
                    loadFeedback(langs.As_Lang(vsb_lang, "error_smaller_font"), false, true);
                }
            }
        }

        private void tsbtnBigger_Click(object sender, EventArgs e)
        {
            if (previewsize <= 50)
            {
                try
                {
                    previewsize = previewsize + 2;
                    settings.FontSizePreview = previewsize;
                    txtSongContent.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, settings.FontBoldPreview ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
                catch (Exception)
                {
                    loadFeedback(langs.As_Lang(vsb_lang, "error_bigger_font"), false, true);
                }
            }
        }

        private void tsbtnFont_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnBold_Click(object sender, EventArgs e)
        {
            try
            {
                if (tsbtnBold.Checked == true)
                {
                    settings.FontBoldPreview = false;
                    tsbtnBold.Checked = false;
                }
                else if (tsbtnBold.Checked == false)
                {
                    settings.FontBoldPreview = true;
                    tsbtnBold.Checked = true;
                }
                txtSongContent.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, tsbtnBold.Checked ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception)
            {
                loadFeedback(langs.As_Lang(vsb_lang, "error_unknown"));
            }
        }
        private void tsbtnCopy_Click(object sender, EventArgs e)
        {
            txtSongContent.Copy();
            //txtSongContent.SelectedText;
        }

        private void tsbtnSelect_Click(object sender, EventArgs e)
        {
            txtSongContent.SelectAll();
        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            loadFeedback(langs.As_Lang(vsb_lang, "error_feature_unavailable"));
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.TextLength >= 1) btnClear.Visible = true;
            else btnClear.Visible = false;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    try
                    {
                        seachForSongs(txtSearch.Text, btnSearchAll.IsOn);
                    }
                    catch (Exception)
                    {
                        //do nothing at all
                    }
                    break;
            }
        }
        public void seachForSongs(string searchstr, bool criteria)
        {
            if (txtSearch.Text != langs.As_Lang(vsb_lang, "search_for_songs"))
            {
                try
                {
                    lstSongResults.Items.Clear();
                    lstSongids.Items.Clear();

                    string searchcriteria = "";
                    if (!criteria) searchcriteria = " AND book='" + lstBookcodes.Text + "'";

                    if (searchstr.Length < 5)
                    {
                        sqlQuery = "SELECT songid, number, title FROM songs " +
                            "WHERE number=" + int.Parse(searchstr) + searchcriteria + ";";
                    }
                    else
                    {
                        sqlQuery = "SELECT songid, number, title FROM songs " +
                            "WHERE title LIKE '%" + searchstr + "%' " + searchcriteria +
                            "OR content LIKE '%" + searchstr + searchcriteria + "%';";
                    }

                    appDB = new AppDatabase();
                    dRowCol = appDB.GetList(sqlQuery);

                    foreach (DataRow row in dRowCol)
                    {
                        lstSongResults.Items.Add(row["number"] + "# " + row["title"]);
                        lstSongids.Items.Add(row["songid"]);
                        lstSongResults.SelectedIndex = 0;
                        lstSongids.SelectedIndex = 0;
                    }
                    string[] valuestrings = { lstSongResults.Items.Count.ToString(), searchstr };
                    grpSongResults.Text = langs.As_Lang_Arr(langs.As_Lang(vsb_lang, "songs_found_with"), valuestrings);
                    lstSongResults.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    loadFeedback(langs.As_Lang(vsb_lang, "error_song_searching") + ex.Message, false);
                }
            }

        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void txtSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void pbxSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void tsbtnSettings_Click(object sender, EventArgs e)
        {
            AppStart.tabbedApp.Tabs.Add(new TitleBarTab(AppStart.tabbedApp)
            {
                Content = new EeSettings { Text = langs.As_Lang(vsb_lang, "settings_title") }
            });
            //AppStart.tabbedApp.SelectedTabIndex = 0;
        }

        private void tsbtnSongBooks_Click(object sender, EventArgs e)
        {
            AppStart.tabbedApp.Tabs.Add(new TitleBarTab(AppStart.tabbedApp)
            {
                Content = new CcBookList { Text = langs.As_Lang(vsb_lang, "title_songbooks_list") }
            });
        }

        private void tsbtnNewSong_Click(object sender, EventArgs e)
        {
            AppStart.tabbedApp.Tabs.Add(new TitleBarTab(AppStart.tabbedApp)
            {
                Content = new DdSongNew { Text = langs.As_Lang(vsb_lang, "title_new_song") }
            });
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            settings.SelectedBook = cmbBooks.SelectedIndex;
            settings.SelectedSong = Int32.Parse(lstSongids.Text);

            AppStart.tabbedApp.Tabs.Add(new TitleBarTab(AppStart.tabbedApp)
            {
                Content = new DdSongEdit { Text = lstSongResults.Text }
            });
            //AppStart.tabbedApp.SelectedTabIndex = 0;
        }

    }
}
