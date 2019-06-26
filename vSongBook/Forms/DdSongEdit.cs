using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace vSongBook
{
    public partial class DdSongEdit : Form
    {
        //private int songno = 0;

        string sqlQuery;
        AppDatabase appDB;
        SQLiteDataReader reader;
        DataRowCollection dRowCol;
        private AppFunctions vsbf = new AppFunctions();
        private AppSettings settings = new AppSettings();
        //bool setsong;
        public DdSongEdit()
        {
            InitializeComponent();
            //setsong = true;
            loadBooks();
        }
        
        private void DdSongEdit_Load(object sender, EventArgs e)
        {
            try { lstSongResults.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { txtSongContent.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { grpSongContent.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
        }

        private void LoadFeedback(string fbmessage, bool positive = true, bool timed = false, float interval = 1000)
        {
            asFeedback.Interval = interval == 0 ? interval : asFeedback.Interval;
            asFeedback.IsPositive = positive;
            asFeedback.IsTimed = timed;
            asFeedback.Text = fbmessage;
            asFeedback.Visible = true;
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
                LoadFeedback("Oops! Sorry, books listing failed: " + ex.Message, false);
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
                grpSongResults.Text = lstSongResults.Items.Count + " " + lstBookcodes.Text + " songs found";
            }
            catch (Exception ex)
            {
                LoadFeedback("Oops! Sorry, songs listing failed: " + ex.Message, false);
            }
        }

        public void loadSingleSong(int songid)
        {
            try
            {
                txtSongContent.Clear();
                sqlQuery = "SELECT * FROM songs WHERE songid=" + songid + ";";
                appDB = new AppDatabase();
                reader = appDB.GetSingle(sqlQuery);
                while (reader.Read())
                {
                    txtNumber.Text = reader["number"].ToString();
                    txtSongKey.Text = reader["key"].ToString();
                    txtSongTitle.Text = vsbf.songRender(reader["title"].ToString());
                    txtSongContent.Text = vsbf.songRender(reader["content"].ToString());
                }
                appDB.SQLClose();
            }
            catch (Exception ex)
            {
                LoadFeedback("Oops! Sorry song viewing failed: " + ex.Message, false, true);
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            appDB = new AppDatabase();
            string editsong = appDB.EditSong(int.Parse(lstSongids.Text), lstBookcodes.Text, txtNumber.Text, txtSongTitle.Text,
                txtSongContent.Text, txtSongKey.Text, "", "");
            if (editsong == "success")
            {
                appDB.SongsUpdate(lstBookcodes.Text, lstSongResults.Items.Count);
                LoadFeedback(txtSongTitle.Text + " has been updated successfully!", true, true);
            }
            else LoadFeedback("Unable to edit the song: " + editsong, false);
            this.Close();
        }

        private void btnSaveOnly_Click(object sender, EventArgs e)
        {
            appDB = new AppDatabase();
            string editsong = appDB.EditSong(int.Parse(lstSongids.Text), lstBookcodes.Text, txtNumber.Text, 
                txtSongTitle.Text, txtSongContent.Text, txtSongKey.Text, "", "");
            if (editsong == "success")
            {
                appDB.SongsUpdate(lstBookcodes.Text, lstSongResults.Items.Count);
                LoadFeedback(txtSongTitle.Text + " has been updated successfully!", true, true);
            }
            else LoadFeedback("Unable to edit the song: " + editsong, false);
        }

        private void tsbtnLast_Click(object sender, EventArgs e)
        {
            try
            {
                lstSongResults.SelectedIndex = lstSongResults.SelectedIndex - 1;
            }
            catch (Exception)
            {
                LoadFeedback("Oops! Sorry, there no song before the current song ...", false, true);
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
                LoadFeedback("Oops! Sorry, there no song after the current song ...", false, true);
            }
        }

    }
}
