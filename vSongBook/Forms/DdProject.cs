using System;
using System.Drawing;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace vSongBook
{
    public partial class DdProject : Form
    {
        bool isBold = false, hasChorus = false;
        string[] songtemps, songstanzas, versechorus, versecounts;
        string sqlQuery, songtext, fontxt;
        int apptheme = 0, fontsize = 0, stanzas = 0, cur_stz = 0, last_stz = 0, fontno = 1;
        AppDatabase appDB;
        SQLiteDataReader reader;
        private AppFunctions vsbf = new AppFunctions();
        private AppSettings settings = new AppSettings();
        
        public DdProject()
        {
            InitializeComponent();
            apptheme = settings.Theme;
            fontsize = settings.FontSizeProject;
            fontno = vsbf.fontNo(settings.FontTypeProject);
            fontxt = settings.FontTypeProject;
            isBold = settings.FontBoldProject;
        }
        
        private void DdProject_Load(object sender, EventArgs e)
        {
            FontManager();
            ThemeView(apptheme);
            LoadSingleSong(settings.CurrentSong);
            txtCommandLine.Focus();
        }

        private void ThemeView(int theme)
        {
            switch (theme)
            {
                case 2:
                    lblSongTitle.ForeColor = Color.Black;
                    lblSongLabel.ForeColor = Color.Black;
                    lblSongno.ForeColor = Color.Black;
                    lblItem.ForeColor = Color.Black;
                    lblDetails.ForeColor = Color.Black;
                    lblVerses.ForeColor = Color.Black;
                    lblSongText.ForeColor = Color.Black;
                    lineTop.ForeColor = Color.Black;
                    lineDown.ForeColor = Color.Black;
                    BackColor = Color.White;
                    break;

                case 3:
                    lblSongTitle.ForeColor = Color.White;
                    lblSongLabel.ForeColor = Color.White;
                    lblSongno.ForeColor = Color.White;
                    lblItem.ForeColor = Color.White;
                    lblDetails.ForeColor = Color.White;
                    lblVerses.ForeColor = Color.White;
                    lblSongText.ForeColor = Color.White;
                    lineTop.ForeColor = Color.White;
                    lineDown.ForeColor = Color.White;
                    BackColor = Color.Blue;
                    break;

                case 4:
                    lblSongTitle.ForeColor = Color.Blue;
                    lblSongLabel.ForeColor = Color.Blue;
                    lblSongno.ForeColor = Color.Blue;
                    lblItem.ForeColor = Color.Blue;
                    lblDetails.ForeColor = Color.Blue;
                    lblVerses.ForeColor = Color.Blue;
                    lblSongText.ForeColor = Color.Blue;
                    lineTop.ForeColor = Color.Blue;
                    lineDown.ForeColor = Color.Blue;
                    BackColor = Color.White;
                    break;

                case 5:
                    lblSongTitle.ForeColor = Color.White;
                    lblSongLabel.ForeColor = Color.White;
                    lblSongno.ForeColor = Color.White;
                    lblItem.ForeColor = Color.White;
                    lblDetails.ForeColor = Color.White;
                    lblVerses.ForeColor = Color.White;
                    lblSongText.ForeColor = Color.White;
                    lineTop.ForeColor = Color.White;
                    lineDown.ForeColor = Color.White;
                    BackColor = Color.Green;
                    break;

                case 6:
                    lblSongTitle.ForeColor = Color.Green;
                    lblSongLabel.ForeColor = Color.Green;
                    lblSongno.ForeColor = Color.Green;
                    lblItem.ForeColor = Color.Green;
                    lblDetails.ForeColor = Color.Green;
                    lblVerses.ForeColor = Color.Green;
                    lblSongText.ForeColor = Color.Green;
                    lineTop.ForeColor = Color.Green;
                    lineDown.ForeColor = Color.Green;
                    BackColor = Color.White;
                    break;

                case 7:
                    lblSongTitle.ForeColor = Color.White;
                    lblSongLabel.ForeColor = Color.White;
                    lblSongno.ForeColor = Color.White;
                    lblItem.ForeColor = Color.White;
                    lblDetails.ForeColor = Color.White;
                    lblVerses.ForeColor = Color.White;
                    lblSongText.ForeColor = Color.White;
                    lineTop.ForeColor = Color.White;
                    lineDown.ForeColor = Color.White;
                    BackColor = Color.Orange;
                    break;

                case 8:
                    lblSongTitle.ForeColor = Color.Orange;
                    lblSongLabel.ForeColor = Color.Orange;
                    lblSongno.ForeColor = Color.Orange;
                    lblItem.ForeColor = Color.Orange;
                    lblDetails.ForeColor = Color.Orange;
                    lblVerses.ForeColor = Color.Orange;
                    lblSongText.ForeColor = Color.Orange;
                    lineTop.ForeColor = Color.Orange;
                    lineDown.ForeColor = Color.Orange;
                    BackColor = Color.White;
                    break;

                case 9:
                    lblSongTitle.ForeColor = Color.White;
                    lblSongLabel.ForeColor = Color.White;
                    lblSongno.ForeColor = Color.White;
                    lblItem.ForeColor = Color.White;
                    lblDetails.ForeColor = Color.White;
                    lblVerses.ForeColor = Color.White;
                    lblSongText.ForeColor = Color.White;
                    lineTop.ForeColor = Color.White;
                    lineDown.ForeColor = Color.White;
                    BackColor = Color.Black;
                    break;

                case 10:
                    lblSongTitle.ForeColor = Color.Black;
                    lblSongLabel.ForeColor = Color.Black;
                    lblSongno.ForeColor = Color.Black;
                    lblItem.ForeColor = Color.Black;
                    lblDetails.ForeColor = Color.Black;
                    lblVerses.ForeColor = Color.Black;
                    lblSongText.ForeColor = Color.Black;
                    lineTop.ForeColor = Color.Black;
                    lineDown.ForeColor = Color.Black;
                    BackColor = Color.White;
                    break;

                case 11:
                    lblSongTitle.ForeColor = Color.White;
                    lblSongLabel.ForeColor = Color.White;
                    lblSongno.ForeColor = Color.White;
                    lblItem.ForeColor = Color.White;
                    lblDetails.ForeColor = Color.White;
                    lblVerses.ForeColor = Color.White;
                    lblSongText.ForeColor = Color.White;
                    lineTop.ForeColor = Color.White;
                    lineDown.ForeColor = Color.White;
                    BackColor = Color.Black;
                    break;

                case 12:
                    lblSongTitle.ForeColor = Color.Black;
                    lblSongLabel.ForeColor = Color.Black;
                    lblSongno.ForeColor = Color.Black;
                    lblItem.ForeColor = Color.Black;
                    lblDetails.ForeColor = Color.Black;
                    lblVerses.ForeColor = Color.Black;
                    lblSongText.ForeColor = Color.Black;
                    lineTop.ForeColor = Color.Black;
                    lineDown.ForeColor = Color.Black;
                    BackColor = Color.White;
                    break;

                default:
                    lblSongTitle.ForeColor = Color.White;
                    lblSongLabel.ForeColor = Color.White;
                    lblSongno.ForeColor = Color.White;
                    lblItem.ForeColor = Color.White;
                    lblDetails.ForeColor = Color.White;
                    lblVerses.ForeColor = Color.White;
                    lblSongText.ForeColor = Color.White;
                    lineTop.ForeColor = Color.White;
                    lineDown.ForeColor = Color.White;
                    BackColor = Color.Black;
                    break;

            }
        }
        
        private void FontManager()
        {
            lblSongTitle.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral + 5, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblSongLabel.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral + 3, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblSongno.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral + 3, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblItem.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral + 3, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblDetails.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral + 3, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblVerses.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral + 3, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblSongText.Font = new Font(fontxt, fontsize, isBold ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            txtCommandLine.Select();
        }

        public void LoadSingleSong(int songid)
        {
            try
            {
                string temptext = "", tempverse = "", tempcount = "";
                cur_stz = 0;
                sqlQuery = "SELECT *, books.title AS songbook FROM songs LEFT JOIN books ON songs.book = books.code WHERE songid=" + songid + ";";
                appDB = new AppDatabase();
                reader = appDB.GetSingle(sqlQuery);
                while (reader.Read())
                {
                    lblSongno.Text = "#" + reader["number"].ToString();
                    lblSongTitle.Text = reader["number"].ToString() + "# " + vsbf.textRender(reader["title"].ToString()) + " " + reader["key"].ToString().Replace("-", "");
                    lblDetails.Text = reader["songbook"].ToString();
                    songtext = reader["content"].ToString();
                }
                appDB.SQLClose();
                
                if (Regex.Matches(songtext, "CHORUS").Count == 1)
                {
                    songtemps = songtext.Split('|');
                    int tempscount = songtemps.Length - 1;
                    string chorustr = songtemps[1].Replace("CHORUS$", "");
                    temptext = songtemps[0] + "#" + chorustr;
                    tempverse = "VERSE#CHORUS";
                    tempcount = "1 of " + tempscount + "# ";
                    for (int i = 2; i < tempscount + 1; i++)
                    {
                        temptext = temptext + "#" + songtemps[i] + "#" + chorustr;
                        tempverse = tempverse + "#VERSE#CHORUS";
                        tempcount = tempcount + "#" + i + " of " + tempscount + "# ";
                    }
                    songstanzas = temptext.Split('#');
                    hasChorus = true;
                }
                else
                {
                    songstanzas = songtext.Split('|');
                    tempverse = "VERSE";
                    tempcount = "1 of " + songstanzas.Length;
                    for (int i = 2; i < songstanzas.Length; i++)
                    {
                        tempverse = tempverse + "#VERSE";
                        tempcount = tempcount + "#" + (i - 1) + " of " + songstanzas.Length;
                    }
                    hasChorus = false;
                }

                versechorus = tempverse.Split('#');
                versecounts = tempcount.Split('#');
                stanzas = songstanzas.Length;

                pbxDown.Visible = true;

                lblSongText.Text = vsbf.songRender(songstanzas[cur_stz]);
                lblItem.Text = versechorus[cur_stz];
                lblVerses.Text = versecounts[cur_stz];
                //lblDetails.Text = stanzas.ToString();
            }
            catch (Exception ex)
            {
                lblSongTitle.Text = "Song projection failed";
                lblSongText.Text = "Oops! Song projection failed due to: " + ex.Message;
            }
        }

        private void PreviousStanza()
        {
            try
            {
                cur_stz = cur_stz - 1;
                lblSongText.Text = vsbf.songRender(songstanzas[cur_stz]);
                lblItem.Text = versechorus[cur_stz];
                lblVerses.Text = versecounts[cur_stz];
                if (cur_stz == 0) pbxUp.Visible = false;
                else pbxUp.Visible = true;
                if (cur_stz == (stanzas - 1)) pbxDown.Visible = false;
                else pbxDown.Visible = true;
                last_stz = cur_stz;
            }
            catch (Exception)
            {
                cur_stz = 0;
                lineTop.BackColor = Color.Red;
                tmrLinerr.Enabled = true;
            }
        }

        private void NextStanza()
        {
            try
            {
                cur_stz = cur_stz + 1;
                lblSongText.Text = vsbf.songRender(songstanzas[cur_stz]);
                lblItem.Text = versechorus[cur_stz];
                lblVerses.Text = versecounts[cur_stz];
                if (cur_stz == 0) pbxUp.Visible = false;
                else pbxUp.Visible = true;
                if (cur_stz == (stanzas - 1)) pbxDown.Visible = false;
                else pbxDown.Visible = true;
            }
            catch (Exception)
            {
                cur_stz = 0;
                lineDown.BackColor = Color.Red;
                tmrLinerr.Enabled = true;
            }
        }

        private void LoadStanza(int stanzano)
        {
            try
            {
                cur_stz = stanzano;
                lblSongText.Text = vsbf.songRender(songstanzas[cur_stz]);
                lblItem.Text = versechorus[cur_stz];
                lblVerses.Text = versecounts[cur_stz];
                if (cur_stz == 0) pbxUp.Visible = false;
                else pbxUp.Visible = true;
                if (cur_stz == (stanzas - 1)) pbxDown.Visible = false;
                else pbxDown.Visible = true;
            }
            catch (Exception)
            {
                cur_stz = 0;
                lineTop.BackColor = Color.Red;
                lineDown.BackColor = Color.Red;
                tmrLinerr.Enabled = true;
            }
        }

        private void txtCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    PreviousStanza();
                    break;
                case Keys.Down:
                    NextStanza();
                    break;
                case Keys.Subtract:
                    if (fontsize >= 10)
                    {
                        try
                        {
                            fontsize = fontsize - 3;
                            settings.FontSizeProject = fontsize;
                            lblSongText.Font = new Font(settings.FontTypeProject, settings.FontSizeProject, settings.FontBoldProject ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.Add:
                    if (fontsize >= 50)
                    {
                        try
                        {
                            fontsize = fontsize + 3;
                            settings.FontSizeProject = fontsize;
                            lblSongText.Font = new Font(settings.FontTypeProject, settings.FontSizeProject, settings.FontBoldProject ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.Left:

                    break;

                case Keys.Right:

                    break;

                case Keys.Oemcomma:
                    if (fontsize >= 10)
                    {
                        try
                        {
                            fontsize = fontsize - 2;
                            settings.FontSizeProject = fontsize;
                            try { lblSongText.Font = new Font(fontxt, fontsize, settings.FontBoldProject ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                            catch (Exception) { }
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.OemPeriod:
                    if (fontsize <= 90)
                    {
                        try
                        {
                            fontsize = fontsize + 2;
                            settings.FontSizeProject = fontsize;
                            try { lblSongText.Font = new Font(fontxt, fontsize, settings.FontBoldProject ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                            catch (Exception) { }
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.M:
                    if (apptheme >= 0)
                    {
                        try
                        {
                            apptheme = apptheme - 1;
                            ThemeView(apptheme);
                            settings.Theme = apptheme;
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.N:
                    if (apptheme <= 8)
                    {
                        try
                        {
                            apptheme = apptheme + 1;
                            ThemeView(apptheme);
                            settings.Theme = apptheme;
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.Z:
                    if (fontno >= 0)
                    {
                        try
                        {
                            fontno = fontno - 1;
                            settings.FontTypeProject = vsbf.fonTxt(fontno);
                            lblSongText.Font = new Font(fontxt, fontsize, settings.FontBoldProject ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.X:
                    if (fontno <= 11)
                    {
                        try
                        {
                            fontno = fontno + 1;
                            settings.FontTypeProject = vsbf.fonTxt(fontno);
                            lblSongText.Font = new Font(fontxt, fontsize, isBold ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); 
                        }
                        catch (Exception) { }
                    }
                    break;
                case Keys.NumPad1:
                case Keys.D1:
                    LoadStanza(0);
                    break;

                case Keys.NumPad2:
                case Keys.D2:
                    if (stanzas >= 2)
                    {
                        if (hasChorus) LoadStanza(2);
                        else if (!hasChorus && stanzas > 2) LoadStanza(1);
                    }
                    break;

                case Keys.NumPad3:
                case Keys.D3:
                    if (stanzas >= 4)
                    {
                        if (hasChorus) LoadStanza(4);
                        else if (!hasChorus && stanzas > 3) LoadStanza(2);
                    }
                    break;

                case Keys.NumPad4:
                case Keys.D4:
                    if (stanzas >= 6)
                    {
                        if (hasChorus) LoadStanza(6);
                        else if (!hasChorus && stanzas > 4) LoadStanza(3);
                    }
                    break;

                case Keys.NumPad5:
                case Keys.D5:
                    if (stanzas >= 8)
                    {
                        if (hasChorus) LoadStanza(8);
                        else if (!hasChorus && stanzas > 5) LoadStanza(4);
                    }
                    break;

                case Keys.NumPad6:
                case Keys.D6:
                    if (stanzas >= 10)
                    {
                        if (hasChorus) LoadStanza(10);
                        else if (!hasChorus && stanzas > 6) LoadStanza(5);
                    }
                    break;

                case Keys.NumPad7:
                case Keys.D7:
                    if (stanzas >= 12)
                    {
                        if (hasChorus) LoadStanza(12);
                        else if (!hasChorus && stanzas > 7) LoadStanza(6);
                    }
                    break;

                case Keys.NumPad8:
                case Keys.D8:
                    if (stanzas >= 14)
                    {
                        if (hasChorus) LoadStanza(14);
                        else if (!hasChorus && stanzas > 8) LoadStanza(7);
                    }
                    break;

                case Keys.NumPad9:
                case Keys.D9:
                    if (stanzas >= 16)
                    {
                        if (hasChorus) LoadStanza(16);
                        else if (!hasChorus && stanzas > 9) LoadStanza(8);
                    }
                    break;

                case Keys.C:
                    if (stanzas > 2 && hasChorus) LoadStanza(1);
                    break;

                case Keys.Home:
                    LoadStanza(0);
                    break;

                case Keys.End:
                    if (hasChorus) LoadStanza(stanzas - 2);
                    else LoadStanza(stanzas - 1);
                    break;

                case Keys.V:

                    break;

                case Keys.B:
                    try
                    {
                        if (isBold == true)
                        {
                            settings.FontBoldProject = false;
                            isBold = false;
                        }
                        else if (isBold == false)
                        {
                            settings.FontBoldProject = true;
                            isBold = true;
                        }
                        try { lblSongText.Font = new Font(fontxt, fontsize, isBold ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                        catch (Exception) { }
                    }
                    catch (Exception) { }
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }
      
        private void tblMain_Paint(object sender, PaintEventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void lblSongLabel_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void lblSongno_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void tblBottom_Paint(object sender, PaintEventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void lblSongText_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void lblVerse_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void lblSongTitle_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void pbxUp_Click(object sender, EventArgs e)
        {
            PreviousStanza();
        }

        private void pbxDown_Click(object sender, EventArgs e)
        {
            NextStanza();
        }

        private void lineTop_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void lineDown_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void grpMain_Enter(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void tmrLinerr_Tick(object sender, EventArgs e)
        {
            lineTop.BackColor = Color.White;
            lineDown.BackColor = Color.White;
            tmrLinerr.Enabled = false;
        }

        private void lblSongText_Click_1(object sender, EventArgs e)
        {

        }


    }
}
