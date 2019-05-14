using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vSongBook
{
    public partial class EeSettings : Form
    {
        AppFunctions vsbf = new AppFunctions();
        AppSettings settings = new AppSettings();
        //int langChange = 0;
        string lastLang = "";

        public EeSettings()
        {
            InitializeComponent();
            btnTabletMode.IsOn = settings.ModeTablet;
            btnSearchAll.IsOn = settings.SearchAllBooks;
            cmbLanguage.Text = lastLang = settings.Language;
            txtAppUser.Text = settings.AppUser;

            lblFontPreview.Text = settings.FontSizePreview.ToString();
            trkFontPreview.Value = settings.FontSizePreview;
            cmbFontPreview.SelectedIndex = vsbf.fontNo(settings.FontTypePreview);
            btnFontPreview.IsOn = settings.FontBoldPreview;

            lblFontProject.Text = settings.FontSizeProject.ToString();
            trkFontProject.Value = settings.FontSizeProject;
            cmbFontProject.SelectedIndex = vsbf.fontNo(settings.FontTypeProject);
            btnFontProject.IsOn = settings.FontBoldProject;

            lblFontGeneral.Text = settings.FontSizeGeneral.ToString();
            trkFontGeneral.Value = settings.FontSizeGeneral;
            cmbFontGeneral.SelectedIndex = vsbf.fontNo(settings.FontTypeGeneral);
            btnFontGeneral.IsOn = settings.FontBoldGeneral;
            tsbtnPage1.Checked = true;
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

        private void EeSettings_Load(object sender, EventArgs e)
        {
            themeView(settings.Theme);
            try { grpTabletMode.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { lblTableModeDesc.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral - 5, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { grpSearchAll.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { lblSearchAll.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral - 5, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { grpLanguage.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { lblLanguage.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral - 5, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { cmbLanguage.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { grpAppUser.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { txtAppUser.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { grpSampleText.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { grpFontGeneral.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { cmbFontGeneral.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { grpFontPreview.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { cmbFontPreview.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { grpFontProject.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { cmbFontProject.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
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

        private void btnTabletMode_Click(object sender, EventArgs e)
        {
            settings.ModeTablet = btnTabletMode.IsOn;
        }

        private void grpTabletMode_Enter(object sender, EventArgs e)
        {
            if (btnTabletMode.IsOn) btnTabletMode.IsOn = false;
            else btnTabletMode.IsOn = true;
            settings.ModeTablet = btnTabletMode.IsOn;
        }
        
        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            settings.SearchAllBooks = btnSearchAll.IsOn;
        }

        private void grpSearchAll_Enter(object sender, EventArgs e)
        {
            if (btnSearchAll.IsOn) btnSearchAll.IsOn = false;
            else btnSearchAll.IsOn = true;
            settings.SearchAllBooks = btnSearchAll.IsOn;
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbLanguage.Text == lastLang)
                {
                    //langChange = 0;
                }
                else
                {
                    settings.Language = cmbLanguage.Text;
                    //langChange = 1;
                    loadFeedback("vSongBook will have to restart after you close this tab to implement your new preffered language!", true, false);
                }
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
                settings.AppUser= txtAppUser.Text.Trim();
            }
            catch(Exception) { }
        }

        private void txtAppUser_Click(object sender, EventArgs e)
        {

        }


        private void pbxFontGeneralSmaller_Click(object sender, EventArgs e)
        {
            try
            {
                trkFontGeneral.Value = trkFontGeneral.Value - trkFontGeneral.SmallChange;
            }
            catch (Exception) { }
        }

        private void pbxFontGeneralBigger_Click(object sender, EventArgs e)
        {
            try
            {
                trkFontGeneral.Value = trkFontGeneral.Value + trkFontGeneral.SmallChange;
            }
            catch (Exception) { }
        }

        private void trkFontGeneral_Scroll(object sender, EventArgs e)
        {
            try
            {
                lblFontGeneral.Text = trkFontGeneral.Value.ToString();
                settings.FontSizeGeneral = trkFontGeneral.Value;
                txtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, btnFontGeneral.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void trkFontGeneral_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblFontGeneral.Text = trkFontGeneral.Value.ToString();
                settings.FontSizeGeneral = trkFontGeneral.Value;
                txtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, btnFontGeneral.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void cmbFontGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                settings.FontTypeGeneral = cmbFontGeneral.Text;
                txtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, btnFontGeneral.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void lblBoldGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnFontGeneral.IsOn) btnFontGeneral.IsOn = false;
                else btnFontGeneral.IsOn = true;
                settings.FontBoldGeneral = btnFontGeneral.IsOn;
                txtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, btnFontGeneral.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }
        private void btnFontGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                settings.FontBoldGeneral = btnFontGeneral.IsOn;
                txtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, btnFontGeneral.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }


        private void pbxFontPreviewSmaller_Click(object sender, EventArgs e)
        {
            try
            {
                trkFontPreview.Value = trkFontPreview.Value - trkFontPreview.SmallChange;
            }
            catch (Exception) { }
        }

        private void pbxFontPreviewBigger_Click(object sender, EventArgs e)
        {
            try
            {
                trkFontPreview.Value = trkFontPreview.Value + trkFontPreview.SmallChange;
            }
            catch (Exception) { }
        }

        private void trkFontPreview_Scroll(object sender, EventArgs e)
        {
            try
            {
                lblFontPreview.Text = trkFontPreview.Value.ToString();
                settings.FontSizePreview = trkFontPreview.Value;
                txtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, btnFontPreview.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void trkFontPreview_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblFontPreview.Text = trkFontPreview.Value.ToString();
                settings.FontSizePreview = trkFontPreview.Value;
                txtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, btnFontPreview.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void cmbFontPreview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblBoldPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnFontPreview.IsOn) btnFontPreview.IsOn = false;
                else btnFontPreview.IsOn = true;
                settings.FontBoldPreview = btnFontPreview.IsOn;
                txtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, btnFontPreview.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void pbxFontProjectSmaller_Click(object sender, EventArgs e)
        {
            try
            {
                trkFontProject.Value = trkFontProject.Value - trkFontProject.SmallChange;
            }
            catch (Exception) { }
        }

        private void pbxFontProjectBigger_Click(object sender, EventArgs e)
        {
            try
            {
                trkFontProject.Value = trkFontProject.Value + trkFontProject.SmallChange;
            }
            catch (Exception) { }
        }

        private void trkFontProject_Scroll(object sender, EventArgs e)
        {
            try
            {
                lblFontProject.Text = trkFontProject.Value.ToString();
                settings.FontSizeProject = trkFontProject.Value;
                txtSampleText.Font = new Font(settings.FontTypeProject, settings.FontSizeProject, btnFontProject.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void trkFontProject_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblFontProject.Text = trkFontProject.Value.ToString();
                settings.FontSizeProject = trkFontProject.Value;
                txtSampleText.Font = new Font(settings.FontTypeProject, settings.FontSizeProject, btnFontProject.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void cmbFontProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                settings.FontTypeProject = cmbFontProject.Text;
                txtSampleText.Font = new Font(settings.FontTypeProject, settings.FontSizeProject, btnFontProject.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void btnFontProject_Click(object sender, EventArgs e)
        {
            try
            {
                settings.FontBoldProject = btnFontProject.IsOn;
                txtSampleText.Font = new Font(settings.FontTypeProject, settings.FontSizeProject, btnFontProject.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }


        private void btnTheme1_Click(object sender, EventArgs e)
        {
            themeView(1);
            settings.Theme = 1;
        }

        private void btnTheme2_Click(object sender, EventArgs e)
        {
            themeView(2);
            settings.Theme = 2;
        }

        private void btnTheme3_Click(object sender, EventArgs e)
        {
            themeView(3);
            settings.Theme = 3;
        }

        private void btnTheme4_Click(object sender, EventArgs e)
        {
            themeView(4);
            settings.Theme = 4;
        }

        private void btnTheme5_Click(object sender, EventArgs e)
        {
            themeView(5);
            settings.Theme = 5;
        }

        private void btnTheme6_Click(object sender, EventArgs e)
        {
            themeView(6);
            settings.Theme = 6;
        }

        private void btnTheme7_Click(object sender, EventArgs e)
        {
            themeView(7);
            settings.Theme = 7;
        }

        private void btnTheme8_Click(object sender, EventArgs e)
        {
            themeView(8);
            settings.Theme = 8;
        }

        private void btnTheme9_Click(object sender, EventArgs e)
        {

        }

        private void btnTheme10_Click(object sender, EventArgs e)
        {

        }

        private void btnTheme11_Click(object sender, EventArgs e)
        {

        }

        private void btnTheme12_Click(object sender, EventArgs e)
        {

        }

        private void themeView(int theme)
        {
            switch (theme)
            {
                case 2:
                    try { grpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }

                    grpTheme1.ForeColor = Color.Black;
                    grpTheme2.ForeColor = Color.OrangeRed;
                    grpTheme3.ForeColor = Color.Black;
                    grpTheme4.ForeColor = Color.Black;
                    grpTheme5.ForeColor = Color.Black;
                    grpTheme6.ForeColor = Color.Black;
                    grpTheme7.ForeColor = Color.Black;
                    grpTheme8.ForeColor = Color.Black;
                    grpTheme9.ForeColor = Color.Black;
                    grpTheme10.ForeColor = Color.Black;
                    grpTheme11.ForeColor = Color.Black;
                    grpTheme12.ForeColor = Color.Black;

                    btnTheme1.Radius = 5;
                    btnTheme2.Radius = 95;
                    btnTheme3.Radius = 5;
                    btnTheme4.Radius = 5;
                    btnTheme5.Radius = 5;
                    btnTheme6.Radius = 5;
                    btnTheme7.Radius = 5;
                    btnTheme8.Radius = 5;
                    btnTheme9.Radius = 5;
                    btnTheme10.Radius = 5;
                    btnTheme11.Radius = 5;
                    btnTheme12.Radius = 5;

                    break;
                case 3:
                    try { grpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    
                    grpTheme1.ForeColor = Color.Black;
                    grpTheme2.ForeColor = Color.Black;
                    grpTheme3.ForeColor = Color.OrangeRed;
                    grpTheme4.ForeColor = Color.Black;
                    grpTheme5.ForeColor = Color.Black;
                    grpTheme6.ForeColor = Color.Black;
                    grpTheme7.ForeColor = Color.Black;
                    grpTheme8.ForeColor = Color.Black;
                    grpTheme9.ForeColor = Color.Black;
                    grpTheme10.ForeColor = Color.Black;
                    grpTheme11.ForeColor = Color.Black;
                    grpTheme12.ForeColor = Color.Black;

                    btnTheme1.Radius = 5;
                    btnTheme2.Radius = 5;
                    btnTheme3.Radius = 95;
                    btnTheme4.Radius = 5;
                    btnTheme5.Radius = 5;
                    btnTheme6.Radius = 5;
                    btnTheme7.Radius = 5;
                    btnTheme8.Radius = 5;
                    btnTheme9.Radius = 5;
                    btnTheme10.Radius = 5;
                    btnTheme11.Radius = 5;
                    btnTheme12.Radius = 5;

                    break;
                case 4:
                    try { grpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    
                    
                    grpTheme1.ForeColor = Color.Black;
                    grpTheme2.ForeColor = Color.Black;
                    grpTheme3.ForeColor = Color.Black;
                    grpTheme4.ForeColor = Color.OrangeRed;
                    grpTheme5.ForeColor = Color.Black;
                    grpTheme6.ForeColor = Color.Black;
                    grpTheme7.ForeColor = Color.Black;
                    grpTheme8.ForeColor = Color.Black;
                    grpTheme9.ForeColor = Color.Black;
                    grpTheme10.ForeColor = Color.Black;
                    grpTheme11.ForeColor = Color.Black;
                    grpTheme12.ForeColor = Color.Black;

                    btnTheme1.Radius = 5;
                    btnTheme2.Radius = 5;
                    btnTheme3.Radius = 5;
                    btnTheme4.Radius = 95;
                    btnTheme5.Radius = 5;
                    btnTheme6.Radius = 5;
                    btnTheme7.Radius = 5;
                    btnTheme8.Radius = 5;
                    btnTheme9.Radius = 5;
                    btnTheme10.Radius = 5;
                    btnTheme11.Radius = 5;
                    btnTheme12.Radius = 5;

                    break;
                case 5:
                    try { grpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    
                    grpTheme1.ForeColor = Color.Black;
                    grpTheme2.ForeColor = Color.Black;
                    grpTheme3.ForeColor = Color.Black;
                    grpTheme4.ForeColor = Color.Black;
                    grpTheme5.ForeColor = Color.OrangeRed;
                    grpTheme6.ForeColor = Color.Black;
                    grpTheme7.ForeColor = Color.Black;
                    grpTheme8.ForeColor = Color.Black;
                    grpTheme9.ForeColor = Color.Black;
                    grpTheme10.ForeColor = Color.Black;
                    grpTheme11.ForeColor = Color.Black;
                    grpTheme12.ForeColor = Color.Black;

                    btnTheme1.Radius = 5;
                    btnTheme2.Radius = 5;
                    btnTheme3.Radius = 5;
                    btnTheme4.Radius = 5;
                    btnTheme5.Radius = 95;
                    btnTheme6.Radius = 5;
                    btnTheme7.Radius = 5;
                    btnTheme8.Radius = 5;
                    btnTheme9.Radius = 5;
                    btnTheme10.Radius = 5;
                    btnTheme11.Radius = 5;
                    btnTheme12.Radius = 5;

                    break;
                case 6:
                    try { grpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    
                    grpTheme1.ForeColor = Color.Black;
                    grpTheme2.ForeColor = Color.Black;
                    grpTheme3.ForeColor = Color.Black;
                    grpTheme4.ForeColor = Color.Black;
                    grpTheme5.ForeColor = Color.Black;
                    grpTheme6.ForeColor = Color.OrangeRed;
                    grpTheme7.ForeColor = Color.Black;
                    grpTheme8.ForeColor = Color.Black;
                    grpTheme9.ForeColor = Color.Black;
                    grpTheme10.ForeColor = Color.Black;
                    grpTheme11.ForeColor = Color.Black;
                    grpTheme12.ForeColor = Color.Black;

                    btnTheme1.Radius = 5;
                    btnTheme2.Radius = 5;
                    btnTheme3.Radius = 5;
                    btnTheme4.Radius = 5;
                    btnTheme5.Radius = 5;
                    btnTheme6.Radius = 95;
                    btnTheme7.Radius = 5;
                    btnTheme8.Radius = 5;
                    btnTheme9.Radius = 5;
                    btnTheme10.Radius = 5;
                    btnTheme11.Radius = 5;
                    btnTheme12.Radius = 5;

                    break;
                case 7:
                    try { grpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    
                    grpTheme1.ForeColor = Color.Black;
                    grpTheme2.ForeColor = Color.Black;
                    grpTheme3.ForeColor = Color.Black;
                    grpTheme4.ForeColor = Color.Black;
                    grpTheme5.ForeColor = Color.Black;
                    grpTheme6.ForeColor = Color.Black;
                    grpTheme7.ForeColor = Color.OrangeRed;
                    grpTheme8.ForeColor = Color.Black;
                    grpTheme9.ForeColor = Color.Black;
                    grpTheme10.ForeColor = Color.Black;
                    grpTheme11.ForeColor = Color.Black;
                    grpTheme12.ForeColor = Color.Black;

                    btnTheme1.Radius = 5;
                    btnTheme2.Radius = 5;
                    btnTheme3.Radius = 5;
                    btnTheme4.Radius = 5;
                    btnTheme5.Radius = 5;
                    btnTheme6.Radius = 5;
                    btnTheme7.Radius = 95;
                    btnTheme8.Radius = 5;
                    btnTheme9.Radius = 5;
                    btnTheme10.Radius = 5;
                    btnTheme11.Radius = 5;
                    btnTheme12.Radius = 5;

                    break;
                case 8:
                    try { grpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    
                    grpTheme1.ForeColor = Color.Black;
                    grpTheme2.ForeColor = Color.Black;
                    grpTheme3.ForeColor = Color.Black;
                    grpTheme4.ForeColor = Color.Black;
                    grpTheme5.ForeColor = Color.Black;
                    grpTheme6.ForeColor = Color.Black;
                    grpTheme7.ForeColor = Color.Black;
                    grpTheme8.ForeColor = Color.OrangeRed;
                    grpTheme9.ForeColor = Color.Black;
                    grpTheme10.ForeColor = Color.Black;
                    grpTheme11.ForeColor = Color.Black;
                    grpTheme12.ForeColor = Color.Black;

                    btnTheme1.Radius = 5;
                    btnTheme2.Radius = 5;
                    btnTheme3.Radius = 5;
                    btnTheme4.Radius = 5;
                    btnTheme5.Radius = 5;
                    btnTheme6.Radius = 5;
                    btnTheme7.Radius = 5;
                    btnTheme8.Radius = 95;
                    btnTheme9.Radius = 5;
                    btnTheme10.Radius = 5;
                    btnTheme11.Radius = 5;
                    btnTheme12.Radius = 5;

                    break;
                case 9:
                    try { grpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    
                    grpTheme1.ForeColor = Color.Black;
                    grpTheme2.ForeColor = Color.Black;
                    grpTheme3.ForeColor = Color.Black;
                    grpTheme4.ForeColor = Color.Black;
                    grpTheme5.ForeColor = Color.Black;
                    grpTheme6.ForeColor = Color.Black;
                    grpTheme7.ForeColor = Color.Black;
                    grpTheme8.ForeColor = Color.Black;
                    grpTheme9.ForeColor = Color.OrangeRed;
                    grpTheme10.ForeColor = Color.Black;
                    grpTheme11.ForeColor = Color.Black;
                    grpTheme12.ForeColor = Color.Black;

                    btnTheme1.Radius = 5;
                    btnTheme2.Radius = 5;
                    btnTheme3.Radius = 5;
                    btnTheme4.Radius = 5;
                    btnTheme5.Radius = 5;
                    btnTheme6.Radius = 5;
                    btnTheme7.Radius = 5;
                    btnTheme8.Radius = 5;
                    btnTheme9.Radius = 95;
                    btnTheme10.Radius = 5;
                    btnTheme11.Radius = 5;
                    btnTheme12.Radius = 5;

                    break;
                case 10:
                    try { grpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    
                    grpTheme1.ForeColor = Color.Black;
                    grpTheme2.ForeColor = Color.Black;
                    grpTheme3.ForeColor = Color.Black;
                    grpTheme4.ForeColor = Color.Black;
                    grpTheme5.ForeColor = Color.Black;
                    grpTheme6.ForeColor = Color.Black;
                    grpTheme7.ForeColor = Color.Black;
                    grpTheme8.ForeColor = Color.Black;
                    grpTheme9.ForeColor = Color.Black;
                    grpTheme10.ForeColor = Color.OrangeRed;
                    grpTheme11.ForeColor = Color.Black;
                    grpTheme12.ForeColor = Color.Black;

                    btnTheme1.Radius = 5;
                    btnTheme2.Radius = 5;
                    btnTheme3.Radius = 5;
                    btnTheme4.Radius = 5;
                    btnTheme5.Radius = 5;
                    btnTheme6.Radius = 5;
                    btnTheme7.Radius = 5;
                    btnTheme8.Radius = 5;
                    btnTheme9.Radius = 5;
                    btnTheme10.Radius = 95;
                    btnTheme11.Radius = 5;
                    btnTheme12.Radius = 5;

                    break;
                case 11:
                    try { grpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    
                    grpTheme1.ForeColor = Color.Black;
                    grpTheme2.ForeColor = Color.Black;
                    grpTheme3.ForeColor = Color.Black;
                    grpTheme4.ForeColor = Color.Black;
                    grpTheme5.ForeColor = Color.Black;
                    grpTheme6.ForeColor = Color.Black;
                    grpTheme7.ForeColor = Color.Black;
                    grpTheme8.ForeColor = Color.Black;
                    grpTheme9.ForeColor = Color.Black;
                    grpTheme10.ForeColor = Color.Black;
                    grpTheme11.ForeColor = Color.OrangeRed;
                    grpTheme12.ForeColor = Color.Black;

                    btnTheme1.Radius = 5;
                    btnTheme2.Radius = 95;
                    btnTheme3.Radius = 5;
                    btnTheme4.Radius = 5;
                    btnTheme5.Radius = 5;
                    btnTheme6.Radius = 5;
                    btnTheme7.Radius = 5;
                    btnTheme8.Radius = 5;
                    btnTheme9.Radius = 5;
                    btnTheme10.Radius = 5;
                    btnTheme11.Radius = 95;
                    btnTheme12.Radius = 5;

                    break;
                case 12:
                    try { grpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    
                    grpTheme1.ForeColor = Color.Black;
                    grpTheme2.ForeColor = Color.Black;
                    grpTheme3.ForeColor = Color.Black;
                    grpTheme4.ForeColor = Color.Black;
                    grpTheme5.ForeColor = Color.Black;
                    grpTheme6.ForeColor = Color.Black;
                    grpTheme7.ForeColor = Color.Black;
                    grpTheme8.ForeColor = Color.Black;
                    grpTheme9.ForeColor = Color.Black;
                    grpTheme10.ForeColor = Color.Black;
                    grpTheme11.ForeColor = Color.Black;
                    grpTheme12.ForeColor = Color.OrangeRed;

                    btnTheme1.Radius = 5;
                    btnTheme2.Radius = 5;
                    btnTheme3.Radius = 5;
                    btnTheme4.Radius = 5;
                    btnTheme5.Radius = 5;
                    btnTheme6.Radius = 5;
                    btnTheme7.Radius = 5;
                    btnTheme8.Radius = 5;
                    btnTheme9.Radius = 5;
                    btnTheme10.Radius = 5;
                    btnTheme11.Radius = 5;
                    btnTheme12.Radius = 95;

                    break;
                default:
                    try { grpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    try { grpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                    catch (Exception) { }
                    
                    grpTheme1.ForeColor = Color.OrangeRed;
                    grpTheme2.ForeColor = Color.Black;
                    grpTheme3.ForeColor = Color.Black;
                    grpTheme4.ForeColor = Color.Black;
                    grpTheme5.ForeColor = Color.Black;
                    grpTheme6.ForeColor = Color.Black;
                    grpTheme7.ForeColor = Color.Black;
                    grpTheme8.ForeColor = Color.Black;
                    grpTheme9.ForeColor = Color.Black;
                    grpTheme10.ForeColor = Color.Black;
                    grpTheme11.ForeColor = Color.Black;
                    grpTheme12.ForeColor = Color.Black;

                    btnTheme1.Radius = 95;
                    btnTheme2.Radius = 5;
                    btnTheme3.Radius = 5;
                    btnTheme4.Radius = 5;
                    btnTheme5.Radius = 5;
                    btnTheme6.Radius = 5;
                    btnTheme7.Radius = 5;
                    btnTheme8.Radius = 5;
                    btnTheme9.Radius = 5;
                    btnTheme10.Radius = 5;
                    btnTheme11.Radius = 5;
                    btnTheme12.Radius = 5;

                    break;
            }
        }


        private void tsbtnPage1_Click(object sender, EventArgs e)
        {
            tsbtnPage1.Checked = true;
            tsbtnPage2.Checked = false;
            tsbtnPage3.Checked = false;
            tsbtnPage4.Checked = false;

            settingsPage1.Visible = true;
            settingsPage2.Visible = false;
            settingsPage3.Visible = false;
        }

        private void tsbtnPage2_Click(object sender, EventArgs e)
        {
            tsbtnPage1.Checked = false;
            tsbtnPage2.Checked = true;
            tsbtnPage3.Checked = false;
            tsbtnPage4.Checked = false;

            settingsPage1.Visible = false;
            settingsPage2.Visible = true;
            settingsPage3.Visible = false;

        }

        private void tsbtnPage3_Click(object sender, EventArgs e)
        {
            tsbtnPage1.Checked = false;
            tsbtnPage2.Checked = false;
            tsbtnPage3.Checked = true;
            tsbtnPage4.Checked = false;

            settingsPage1.Visible = false;
            settingsPage2.Visible = false;
            settingsPage3.Visible = true;
        }

        private void tsbtnPage4_Click(object sender, EventArgs e)
        {
            tsbtnPage1.Checked = false;
            tsbtnPage2.Checked = false;
            tsbtnPage3.Checked = false;
            tsbtnPage4.Checked = true;

            settingsPage1.Visible = false;
            settingsPage1.Visible = false;
            settingsPage1.Visible = false;

        }

        private void EeSettings_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
