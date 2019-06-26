using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace vSongBook
{
    public partial class CcBookList : Form
    {
        string sqlQuery;
        AppDatabase appDB;
        SQLiteDataReader reader;
        DataRowCollection dRowCol;
        private AppFunctions vsbf = new AppFunctions();
        private AppSettings settings = new AppSettings();
        public CcBookList()
        {
            InitializeComponent();
            
        }

        private void CcBookList_Load(object sender, EventArgs e)
        {
            loadBooks();
        }

        private void LoadFeedback(string fbmessage, bool positive = true, bool timed = false, float interval = 1000)
        {
            asFeedback.Interval = interval == 0 ? interval : asFeedback.Interval;
            asFeedback.IsPositive = positive;
            asFeedback.IsTimed = timed;
            asFeedback.Text = fbmessage;
            asFeedback.Visible = true;
        }

        public void loadBooks()
        {
            try
            {
                lstBooks.Items.Clear();
                lstBookids.Items.Clear();
                sqlQuery = "SELECT * FROM books;";
                appDB = new AppDatabase();
                dRowCol = appDB.GetList(sqlQuery);

                foreach (DataRow row in dRowCol)
                {
                    lstBooks.Items.Add(row["title"] + " (" + row["songs"] + ")");
                    lstBookids.Items.Add(row["bookid"]);
                    lstBooks.SelectedIndex = 0;
                    lstBookids.SelectedIndex = 0;
                }
                grpBookResults.Text = lstBooks.Items.Count + " books exist currently";
            }
            catch (Exception ex)
            {
                LoadFeedback("Oops! Sorry, books listing failed: " + ex.Message, false);
            }
        }
        
        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBookids.SelectedIndex = lstBooks.SelectedIndex;
        }

        private void lstBookids_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadBookDetails(lstBookids.Text);
        }

        public void loadBookDetails(string bookid)
        {
            try
            {
                txtNotes.Clear();
                sqlQuery = "SELECT * FROM books WHERE bookid=" + bookid + ";";
                appDB = new AppDatabase();
                reader = appDB.GetSingle(sqlQuery);
                while (reader.Read())
                {
                    txtBookTitle.Text = reader["title"].ToString();
                    txtBookCode.Text = reader["code"].ToString();
                    txtNotes.Text = reader["notes"].ToString();
                    lblInfo.Text = reader["songs"].ToString() + " songs";
                }
                appDB.SQLClose();
            }
            catch (Exception ex)
            {
                LoadFeedback("Oops! Sorry book viewing failed: " + ex.Message, false, true);
            }
        }
        
        private void clearFields()
        {
            txtBookCode.box.Clear();
            txtBookTitle.box.Clear();
            txtNotes.Clear();
            lblInfo.Text = "";
            txtBookTitle.Focus();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            appDB = new AppDatabase();
            string newbook = appDB.AddNewBook(txtBookTitle.Text, txtBookCode.Text, txtNotes.Text);
            if (newbook == "success")
            {
                LoadFeedback("A new book " + txtBookTitle.Text + "has been added successfully!", true, true);
                loadBooks();
                clearFields();
            }
            else LoadFeedback("Unable to add a book: " + newbook, false);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            appDB = new AppDatabase();
            string editbook = appDB.EditBook(lstBookids.Text, txtBookTitle.Text, txtBookCode.Text, txtNotes.Text);
            if (editbook == "success")
            {
                LoadFeedback(txtBookTitle.Text + " has been updated successfully!", true, true);
                loadBooks();
            }
            else LoadFeedback("Unable to edit a book: " + editbook, false);
            loadBooks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LoadFeedback("Are you sure you want to delete this book?", true);
            loadBooks();
        }

    }
}
