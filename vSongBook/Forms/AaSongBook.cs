using System;
using System.Data;
using System.Drawing;
using System.Data.SQLite;
using System.Windows.Forms;
using EasyTabs;

namespace vSongBook
{
    public partial class AaSongBook : Form
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
        public static AppTabs tabbedApp = new AppTabs();

        public AaSongBook()
        {
            InitializeComponent();
            //cmbLanguage.Text = vsb_lang = settings.Language;
            LanguageStrings();
            LoadBooks();
            LoadLanguages();
        }

        public void LoadLanguages()
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
                //LoadFeedback(langs.As_Lang(vsb_lang, "error_songs_listing") + " " + ex.Message, false);
            }
        }

        private void LanguageStrings()
        {
            grpCriteria.Text = langs.As_Lang(vsb_lang, "search_criteria");
            lblSearchAll.Text = langs.As_Lang(vsb_lang, "search_all_songbooks");
            grpSongResults.Text = langs.As_Lang(vsb_lang, "songs_found");
            txtSearch.Text = langs.As_Lang(vsb_lang, "search_for_songs");
        }

        private void AaSongBook_Resize(object sender, EventArgs e)
        {
            //InitializeComponent();
            //loadBooks();
        }

        private void LoadFeedback(string fbmessage, bool positive = true, bool timed = false, float interval = 1000)
        {
            asFeedback.Interval = interval == 0 ? interval : asFeedback.Interval;
            asFeedback.IsPositive = positive;
            asFeedback.IsTimed = timed;
            asFeedback.Text = fbmessage;
            asFeedback.Visible = true;
        }

        private void AaSongBook_Load(object sender, EventArgs e)
        {
            btnSearchAll.IsOn = settings.SearchAllBooks;
            tsbtnBold.Checked = settings.FontBoldPreview;
            previewsize = settings.FontSizePreview;

            try { lstSongResults.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); } 
            catch (Exception) { }
            try { txtSongContent.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, settings.FontBoldPreview ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); } 
            catch (Exception) { }

        }

        private void BtnSearchAll_Click(object sender, EventArgs e)
        {
            settings.SearchAllBooks = btnSearchAll.IsOn;
            SeachForSongs(txtSearch.Text, btnSearchAll.IsOn);
        }
                
        private void GrpCriteria_Enter(object sender, EventArgs e)
        {
            if (btnSearchAll.IsOn) btnSearchAll.IsOn = false;
            else btnSearchAll.IsOn = true;
            settings.SearchAllBooks = btnSearchAll.IsOn;
            SeachForSongs(txtSearch.Text, btnSearchAll.IsOn);
        }
        
        private void LblSearchAll_Enter(object sender, EventArgs e)
        {
            if (btnSearchAll.IsOn) btnSearchAll.IsOn = false;
            else btnSearchAll.IsOn = true;
            settings.SearchAllBooks = btnSearchAll.IsOn;
            SeachForSongs(txtSearch.Text, btnSearchAll.IsOn);
        }
        private void LblSearchAll_Click(object sender, EventArgs e)
        {
            if (btnSearchAll.IsOn) btnSearchAll.IsOn = false;
            else btnSearchAll.IsOn = true;
            settings.SearchAllBooks = btnSearchAll.IsOn;
            SeachForSongs(txtSearch.Text, btnSearchAll.IsOn);
        }

        private void CmbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBookcodes.SelectedIndex = cmbBooks.SelectedIndex;
        }

        private void LstBookcodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBookSongs(lstBookcodes.Text);
        }

        private void LstSongResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstSongids.SelectedIndex = lstSongResults.SelectedIndex;
        }

        private void LstSongids_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSingleSong(Int32.Parse(lstSongids.Text));
        }

        private void LstSongResults_KeyDown(object sender, KeyEventArgs e)
        {
            LoadSingleSong(Int32.Parse(lstSongids.Text));
            ProjectSong();
        }

        public void LoadBooks()
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
                LoadFeedback(langs.As_Lang(vsb_lang, "error_books_listing") + " " + ex.Message, false);
            }
        }

        public void LoadBookSongs(string code)
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
                LoadFeedback(langs.As_Lang(vsb_lang, "error_songs_listing") + " " + ex.Message, false);
            }
        }
                
        public void LoadSingleSong(int songid)
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
                LoadFeedback(langs.As_Lang(vsb_lang, "error_songs_viewing") + " " + ex.Message, false, true);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                        SeachForSongs(txtSearch.Text, btnSearchAll.IsOn);
                    break;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void ProjectSong()
        {
            try
            {
                settings.CurrentSong = Int32.Parse(lstSongids.Text);
                DdProject project = new DdProject();
                project.Show();
            }
            catch (Exception)
            {
                LoadFeedback(langs.As_Lang(vsb_lang, "error_unknown"), false, true);
            }
        }

        private void TsbtnProject_Click(object sender, EventArgs e)
        {
            ProjectSong();
        }

        private void TsbtnLast_Click(object sender, EventArgs e)
        {
            try
            {
                lstSongResults.SelectedIndex = lstSongResults.SelectedIndex - 1;
            }
            catch (Exception)
            {
                LoadFeedback(langs.As_Lang(vsb_lang, "error_previous_songs"), false, true);
            }
        }

        private void TsbtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                lstSongResults.SelectedIndex = lstSongResults.SelectedIndex + 1;
            }
            catch (Exception)
            {
                LoadFeedback(langs.As_Lang(vsb_lang, "error_next_songs"), false, true);
            }
        }

        private void TsbtnSmaller_Click(object sender, EventArgs e)
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
                    LoadFeedback(langs.As_Lang(vsb_lang, "error_smaller_font"), false, true);
                }
            }
        }

        private void TsbtnBigger_Click(object sender, EventArgs e)
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
                    LoadFeedback(langs.As_Lang(vsb_lang, "error_bigger_font"), false, true);
                }
            }
        }

        private void TsbtnFont_Click(object sender, EventArgs e)
        {

        }

        private void TsbtnBold_Click(object sender, EventArgs e)
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
                LoadFeedback(langs.As_Lang(vsb_lang, "error_unknown"));
            }
        }
        private void TsbtnCopy_Click(object sender, EventArgs e)
        {
            txtSongContent.Copy();
            //txtSongContent.SelectedText;
        }

        private void TsbtnSelect_Click(object sender, EventArgs e)
        {
            txtSongContent.SelectAll();
        }

        private void TsbtnPrint_Click(object sender, EventArgs e)
        {
            LoadFeedback(langs.As_Lang(vsb_lang, "error_feature_unavailable"));
        }

        private void TxtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.TextLength >= 1) btnClear.Visible = true;
            else btnClear.Visible = false;
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    try
                    {
                        SeachForSongs(txtSearch.Text, btnSearchAll.IsOn);
                    }
                    catch (Exception)
                    {
                        //do nothing at all
                    }
                    break;
            }
        }

        public void SeachForSongs(string searchstr, bool criteria)
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
                    LoadFeedback(langs.As_Lang(vsb_lang, "error_song_searching") + ex.Message, false);
                }
            }

        }

        private void TxtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void TxtSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void TsbtnSettings_Click(object sender, EventArgs e)
        {
            var dlg_window = new EeSettings();
            dlg_window.ShowDialog();
        }

        private void TsbtnSongBooks_Click(object sender, EventArgs e)
        {
            var dlg_window = new CcBookList();
            dlg_window.ShowDialog();
        }

        private void TsbtnNewSong_Click(object sender, EventArgs e)
        {
            var dlg_window = new DdSongNew();
            dlg_window.ShowDialog();
        }

        private void TsbtnEdit_Click(object sender, EventArgs e)
        {
            settings.SelectedBook = cmbBooks.SelectedIndex;
            settings.SelectedSong = Int32.Parse(lstSongids.Text);

            var dlg_window = new DdSongEdit();
            dlg_window.ShowDialog();
        }

    }
}
