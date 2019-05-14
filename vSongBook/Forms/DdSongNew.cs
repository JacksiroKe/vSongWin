using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace vSongBook
{
    public partial class DdSongNew : Form
    {
        private int songno = 0;

        string sqlQuery;
        AppDatabase appDB;
        //SQLiteDataReader reader;
        DataRowCollection dRowCol;
        private AppFunctions vsbf = new AppFunctions();
        private AppSettings settings = new AppSettings();
        
        public DdSongNew()
        {
            InitializeComponent();
            loadBooks();
        }
        
        private void DdSongNew_Load(object sender, EventArgs e)
        {
            try { lstSongResults.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { txtSongContent.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { grpSongContent.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
        }

        private void loadFeedback(string fbmessage, bool positive = true, bool timed = false, float interval = 1000)
        {
            jsFeedback.Interval = interval == 0 ? interval : jsFeedback.Interval;
            jsFeedback.IsPositive = positive;
            jsFeedback.IsTimed = timed;
            jsFeedback.Text = fbmessage;
            jsFeedback.Visible = true;
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
                loadFeedback("Oops! Sorry books listing failed: " + ex.Message, false, true);
            }
        }

        public void loadBookSongs(string code)
        {
            try
            {
                lstSongResults.Items.Clear();
                songno = 0;
                sqlQuery = "SELECT songid, number, title FROM songs WHERE book='" + code + "';";
                appDB = new AppDatabase();
                dRowCol = appDB.GetList(sqlQuery);

                foreach (DataRow row in dRowCol)
                {
                    songno = int.Parse(row["number"] + "");
                    lstSongResults.Items.Add(row["number"] + "# " + vsbf.textRender(row["title"].ToString()));
                    lstSongResults.SelectedIndex = 0;
                }
                grpSongResults.Text = lstSongResults.Items.Count + " " + lstBookcodes.Text + " songs found";
                txtNumber.Placeholder = (songno + 1).ToString();
                txtNumber.Text = (songno + 1).ToString();
            }
            catch (Exception ex)
            {
               loadFeedback("Oops! Sorry song listing failed: " + ex.Message, false, true);
            }
        }
        
        private void cmbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBookcodes.SelectedIndex = cmbBooks.SelectedIndex;
        }

        private void lstBookcodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadBookSongs(lstBookcodes.Text);
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            appDB = new AppDatabase();
            string newsong = appDB.QuickUpdate("books", "songs", "34", "code", "bebmb");
            //string newsong = appDB.NewSong(lstBookcodes.Text, txtNumber.Text, txtSongTitle.Text, txtSongContent.Text, txtSongKey.Text, "", "");
            if (newsong == "success")
            {
                loadFeedback(txtSongTitle.Text + " has been added successfully!", true, true);
                loadBooks();
                txtNumber.box.Clear();
                txtSongKey.box.Clear();
                txtSongTitle.box.Clear();
                txtSongContent.Clear();
                Close();
            }
            else loadFeedback("Unable to add a song: " + newsong, false);
        }

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            appDB = new AppDatabase();
            int selectedbook = lstBookcodes.SelectedIndex;
            string newsong = appDB.NewSong(lstBookcodes.Text, txtNumber.Text, txtSongTitle.Text, txtSongContent.Text, 
                txtSongKey.Text, "", "");
            if (newsong == "success")
            {
                loadFeedback(txtSongTitle.Text + " has been added successfully!", true, true);
                loadBooks();
                cmbBooks.SelectedIndex = selectedbook;
                txtNumber.box.Clear();
                txtSongKey.box.Clear();
                txtSongTitle.box.Clear();
                txtSongContent.Clear();
            }
            else loadFeedback("Unable to add a song: " + newsong, false);            
        }

    }
}
