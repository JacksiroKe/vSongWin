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

            BtnTabletMode.IsOn = settings.ModeTablet;
            BtnSearchAll.IsOn = settings.SearchAllBooks;
            CmbLanguage.Text = lastLang = settings.Language;
            TxtAppUser.Text = settings.AppUser;

            LblFontPreview.Text = settings.FontSizePreview.ToString();
            TrkFontPreview.Value = settings.FontSizePreview;
            CmbFontPreview.SelectedIndex = vsbf.fontNo(settings.FontTypePreview);
            BtnFontPreview.IsOn = settings.FontBoldPreview;

            LblFontProject.Text = settings.FontSizeProject.ToString();
            TrkFontProject.Value = settings.FontSizeProject;
            CmbFontProject.SelectedIndex = vsbf.fontNo(settings.FontTypeProject);
            BtnFontProject.IsOn = settings.FontBoldProject;

            LblFontGeneral.Text = settings.FontSizeGeneral.ToString();
            TrkFontGeneral.Value = settings.FontSizeGeneral;
            CmbFontGeneral.SelectedIndex = vsbf.fontNo(settings.FontTypeGeneral);
            BtnFontGeneral.IsOn = settings.FontBoldGeneral;
            TsbtnPage1.Checked = true;

            LoadLanguages();
        }

        public void LoadLanguages()
        {
            try
            {
                CmbLanguage.Items.Clear();
                AppLanguage applang = new AppLanguage();
                DataRowCollection dRowCol = applang.langList();

                foreach (DataRow row in dRowCol)
                {
                    CmbLanguage.Items.Add(row["name"]);
                }
            }
            catch (Exception)
            {
                //LoadFeedback(langs.As_Lang(vsb_lang, "error_songs_listing") + " " + ex.Message, false);
            }
        }

        private void EeSettings_Load(object sender, EventArgs e)
        {
            ThemeView(settings.Theme);
            GrpTabletMode.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            LblTableModeDesc.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral - 5, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            GrpSearchAll.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            LblSearchAll.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral - 5, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            GrpLanguage.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            LblLanguage.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral - 5, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            CmbLanguage.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            GrpAppUser.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            TxtAppUser.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            GrpSampleText.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            GrpFontGeneral.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            CmbFontGeneral.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            GrpFontPreview.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            CmbFontPreview.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            GrpFontProject.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            CmbFontProject.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

        }
        
        private void LoadFeedback(string fbmessage, bool positive = true, bool timed = false, float interval = 1000)
        {
            AsFeedback.Interval = interval == 0 ? interval : AsFeedback.Interval;
            AsFeedback.IsPositive = positive;
            AsFeedback.IsTimed = timed;
            AsFeedback.Text = fbmessage;
            AsFeedback.Visible = true;
        }

        private void BtnTabletMode_Click(object sender, EventArgs e)
        {
            settings.ModeTablet = BtnTabletMode.IsOn;
        }

        private void GrpTabletMode_Enter(object sender, EventArgs e)
        {
            if (BtnTabletMode.IsOn) BtnTabletMode.IsOn = false;
            else BtnTabletMode.IsOn = true;
            settings.ModeTablet = BtnTabletMode.IsOn;
        }
        
        private void BtnSearchAll_Click(object sender, EventArgs e)
        {
            settings.SearchAllBooks = BtnSearchAll.IsOn;
        }

        private void GrpSearchAll_Enter(object sender, EventArgs e)
        {
            if (BtnSearchAll.IsOn) BtnSearchAll.IsOn = false;
            else BtnSearchAll.IsOn = true;
            settings.SearchAllBooks = BtnSearchAll.IsOn;
        }

        private void CmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbLanguage.Text == lastLang)
                {
                    //langChange = 0;
                }
                else
                {
                    settings.Language = CmbLanguage.Text;
                    //langChange = 1;
                    LoadFeedback("vSongBook will have to restart after you close this tab to implement your new preffered language!", true, false);
                }
            }
            catch (Exception) { }
        }

        private void TxtAppUser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtAppUser.Text.Length < 100)
                {
                    LblCharacters.Text = 100 - TxtAppUser.Text.Length + " characters remaining ...";
                }
                else
                {
                    LblCharacters.Text = "";
                }
                settings.AppUser= TxtAppUser.Text.Trim();
            }
            catch(Exception) { }
        }

        private void TxtAppUser_Click(object sender, EventArgs e)
        {

        }


        private void PbxFontGeneralSmaller_Click(object sender, EventArgs e)
        {
            try
            {
                TrkFontGeneral.Value = TrkFontGeneral.Value - TrkFontGeneral.SmallChange;
            }
            catch (Exception) { }
        }

        private void PbxFontGeneralBigger_Click(object sender, EventArgs e)
        {
            try
            {
                TrkFontGeneral.Value = TrkFontGeneral.Value + TrkFontGeneral.SmallChange;
            }
            catch (Exception) { }
        }

        private void TrkFontGeneral_Scroll(object sender, EventArgs e)
        {
            try
            {
                LblFontGeneral.Text = TrkFontGeneral.Value.ToString();
                settings.FontSizeGeneral = TrkFontGeneral.Value;
                TxtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, BtnFontGeneral.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void TrkFontGeneral_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LblFontGeneral.Text = TrkFontGeneral.Value.ToString();
                settings.FontSizeGeneral = TrkFontGeneral.Value;
                TxtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, BtnFontGeneral.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void CmbFontGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                settings.FontTypeGeneral = CmbFontGeneral.Text;
                TxtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, BtnFontGeneral.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void LblBoldGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                if (BtnFontGeneral.IsOn) BtnFontGeneral.IsOn = false;
                else BtnFontGeneral.IsOn = true;
                settings.FontBoldGeneral = BtnFontGeneral.IsOn;
                TxtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, BtnFontGeneral.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }
        private void btnFontGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                settings.FontBoldGeneral = BtnFontGeneral.IsOn;
                TxtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, BtnFontGeneral.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }


        private void PbxFontPreviewSmaller_Click(object sender, EventArgs e)
        {
            try
            {
                TrkFontPreview.Value = TrkFontPreview.Value - TrkFontPreview.SmallChange;
            }
            catch (Exception) { }
        }

        private void PbxFontPreviewBigger_Click(object sender, EventArgs e)
        {
            try
            {
                TrkFontPreview.Value = TrkFontPreview.Value + TrkFontPreview.SmallChange;
            }
            catch (Exception) { }
        }

        private void TrkFontPreview_Scroll(object sender, EventArgs e)
        {
            try
            {
                LblFontPreview.Text = TrkFontPreview.Value.ToString();
                settings.FontSizePreview = TrkFontPreview.Value;
                TxtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, BtnFontPreview.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void TrkFontPreview_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LblFontPreview.Text = TrkFontPreview.Value.ToString();
                settings.FontSizePreview = TrkFontPreview.Value;
                TxtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, BtnFontPreview.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void CmbFontPreview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LblBoldPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (BtnFontPreview.IsOn) BtnFontPreview.IsOn = false;
                else BtnFontPreview.IsOn = true;
                settings.FontBoldPreview = BtnFontPreview.IsOn;
                TxtSampleText.Font = new Font(settings.FontTypePreview, settings.FontSizePreview, BtnFontPreview.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void PbxFontProjectSmaller_Click(object sender, EventArgs e)
        {
            try
            {
                TrkFontProject.Value = TrkFontProject.Value - TrkFontProject.SmallChange;
            }
            catch (Exception) { }
        }

        private void PbxFontProjectBigger_Click(object sender, EventArgs e)
        {
            try
            {
                TrkFontProject.Value = TrkFontProject.Value + TrkFontProject.SmallChange;
            }
            catch (Exception) { }
        }

        private void TrkFontProject_Scroll(object sender, EventArgs e)
        {
            try
            {
                LblFontProject.Text = TrkFontProject.Value.ToString();
                settings.FontSizeProject = TrkFontProject.Value;
                TxtSampleText.Font = new Font(settings.FontTypeProject, settings.FontSizeProject, BtnFontProject.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void TrkFontProject_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LblFontProject.Text = TrkFontProject.Value.ToString();
                settings.FontSizeProject = TrkFontProject.Value;
                TxtSampleText.Font = new Font(settings.FontTypeProject, settings.FontSizeProject, BtnFontProject.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void CmbFontProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                settings.FontTypeProject = CmbFontProject.Text;
                TxtSampleText.Font = new Font(settings.FontTypeProject, settings.FontSizeProject, BtnFontProject.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }

        private void btnFontProject_Click(object sender, EventArgs e)
        {
            try
            {
                settings.FontBoldProject = BtnFontProject.IsOn;
                TxtSampleText.Font = new Font(settings.FontTypeProject, settings.FontSizeProject, BtnFontProject.IsOn ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception) { }
        }


        private void BtnTheme1_Click(object sender, EventArgs e)
        {
            ThemeView(1);
            settings.Theme = 1;
        }

        private void BtnTheme2_Click(object sender, EventArgs e)
        {
            ThemeView(2);
            settings.Theme = 2;
        }

        private void BtnTheme3_Click(object sender, EventArgs e)
        {
            ThemeView(3);
            settings.Theme = 3;
        }

        private void BtnTheme4_Click(object sender, EventArgs e)
        {
            ThemeView(4);
            settings.Theme = 4;
        }

        private void BtnTheme5_Click(object sender, EventArgs e)
        {
            ThemeView(5);
            settings.Theme = 5;
        }

        private void BtnTheme6_Click(object sender, EventArgs e)
        {
            ThemeView(6);
            settings.Theme = 6;
        }

        private void BtnTheme7_Click(object sender, EventArgs e)
        {
            ThemeView(7);
            settings.Theme = 7;
        }

        private void BtnTheme8_Click(object sender, EventArgs e)
        {
            ThemeView(8);
            settings.Theme = 8;
        }

        private void BtnTheme9_Click(object sender, EventArgs e)
        {

        }

        private void BtnTheme10_Click(object sender, EventArgs e)
        {

        }

        private void BtnTheme11_Click(object sender, EventArgs e)
        {

        }

        private void BtnTheme12_Click(object sender, EventArgs e)
        {

        }


        private void ThemeView(int theme)
        {
            switch (theme)
            {
                case 2:
                    GrpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    GrpTheme1.ForeColor = Color.Black;
                    GrpTheme2.ForeColor = Color.OrangeRed;
                    GrpTheme3.ForeColor = Color.Black;
                    GrpTheme4.ForeColor = Color.Black;
                    GrpTheme5.ForeColor = Color.Black;
                    GrpTheme6.ForeColor = Color.Black;
                    GrpTheme7.ForeColor = Color.Black;
                    GrpTheme8.ForeColor = Color.Black;
                    GrpTheme9.ForeColor = Color.Black;
                    GrpTheme10.ForeColor = Color.Black;
                    GrpTheme11.ForeColor = Color.Black;
                    GrpTheme12.ForeColor = Color.Black;

                    BtnTheme1.Radius = 5;
                    BtnTheme2.Radius = 90;
                    BtnTheme3.Radius = 5;
                    BtnTheme4.Radius = 5;
                    BtnTheme5.Radius = 5;
                    BtnTheme6.Radius = 5;
                    BtnTheme7.Radius = 5;
                    BtnTheme8.Radius = 5;
                    BtnTheme9.Radius = 5;
                    BtnTheme10.Radius = 5;
                    BtnTheme11.Radius = 5;
                    BtnTheme12.Radius = 5;

                    break;

                case 3:
                    GrpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    GrpTheme1.ForeColor = Color.Black;
                    GrpTheme2.ForeColor = Color.Black;
                    GrpTheme3.ForeColor = Color.OrangeRed;
                    GrpTheme4.ForeColor = Color.Black;
                    GrpTheme5.ForeColor = Color.Black;
                    GrpTheme6.ForeColor = Color.Black;
                    GrpTheme7.ForeColor = Color.Black;
                    GrpTheme8.ForeColor = Color.Black;
                    GrpTheme9.ForeColor = Color.Black;
                    GrpTheme10.ForeColor = Color.Black;
                    GrpTheme11.ForeColor = Color.Black;
                    GrpTheme12.ForeColor = Color.Black;

                    BtnTheme1.Radius = 5;
                    BtnTheme2.Radius = 5;
                    BtnTheme3.Radius = 90;
                    BtnTheme4.Radius = 5;
                    BtnTheme5.Radius = 5;
                    BtnTheme6.Radius = 5;
                    BtnTheme7.Radius = 5;
                    BtnTheme8.Radius = 5;
                    BtnTheme9.Radius = 5;
                    BtnTheme10.Radius = 5;
                    BtnTheme11.Radius = 5;
                    BtnTheme12.Radius = 5;

                    break;

                case 4:
                    GrpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));


                    GrpTheme1.ForeColor = Color.Black;
                    GrpTheme2.ForeColor = Color.Black;
                    GrpTheme3.ForeColor = Color.Black;
                    GrpTheme4.ForeColor = Color.OrangeRed;
                    GrpTheme5.ForeColor = Color.Black;
                    GrpTheme6.ForeColor = Color.Black;
                    GrpTheme7.ForeColor = Color.Black;
                    GrpTheme8.ForeColor = Color.Black;
                    GrpTheme9.ForeColor = Color.Black;
                    GrpTheme10.ForeColor = Color.Black;
                    GrpTheme11.ForeColor = Color.Black;
                    GrpTheme12.ForeColor = Color.Black;

                    BtnTheme1.Radius = 5;
                    BtnTheme2.Radius = 5;
                    BtnTheme3.Radius = 5;
                    BtnTheme4.Radius = 90;
                    BtnTheme5.Radius = 5;
                    BtnTheme6.Radius = 5;
                    BtnTheme7.Radius = 5;
                    BtnTheme8.Radius = 5;
                    BtnTheme9.Radius = 5;
                    BtnTheme10.Radius = 5;
                    BtnTheme11.Radius = 5;
                    BtnTheme12.Radius = 5;

                    break;

                case 5:
                    GrpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    GrpTheme1.ForeColor = Color.Black;
                    GrpTheme2.ForeColor = Color.Black;
                    GrpTheme3.ForeColor = Color.Black;
                    GrpTheme4.ForeColor = Color.Black;
                    GrpTheme5.ForeColor = Color.OrangeRed;
                    GrpTheme6.ForeColor = Color.Black;
                    GrpTheme7.ForeColor = Color.Black;
                    GrpTheme8.ForeColor = Color.Black;
                    GrpTheme9.ForeColor = Color.Black;
                    GrpTheme10.ForeColor = Color.Black;
                    GrpTheme11.ForeColor = Color.Black;
                    GrpTheme12.ForeColor = Color.Black;

                    BtnTheme1.Radius = 5;
                    BtnTheme2.Radius = 5;
                    BtnTheme3.Radius = 5;
                    BtnTheme4.Radius = 5;
                    BtnTheme5.Radius = 90;
                    BtnTheme6.Radius = 5;
                    BtnTheme7.Radius = 5;
                    BtnTheme8.Radius = 5;
                    BtnTheme9.Radius = 5;
                    BtnTheme10.Radius = 5;
                    BtnTheme11.Radius = 5;
                    BtnTheme12.Radius = 5;

                    break;

                case 6:
                    GrpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    GrpTheme1.ForeColor = Color.Black;
                    GrpTheme2.ForeColor = Color.Black;
                    GrpTheme3.ForeColor = Color.Black;
                    GrpTheme4.ForeColor = Color.Black;
                    GrpTheme5.ForeColor = Color.Black;
                    GrpTheme6.ForeColor = Color.OrangeRed;
                    GrpTheme7.ForeColor = Color.Black;
                    GrpTheme8.ForeColor = Color.Black;
                    GrpTheme9.ForeColor = Color.Black;
                    GrpTheme10.ForeColor = Color.Black;
                    GrpTheme11.ForeColor = Color.Black;
                    GrpTheme12.ForeColor = Color.Black;

                    BtnTheme1.Radius = 5;
                    BtnTheme2.Radius = 5;
                    BtnTheme3.Radius = 5;
                    BtnTheme4.Radius = 5;
                    BtnTheme5.Radius = 5;
                    BtnTheme6.Radius = 90;
                    BtnTheme7.Radius = 5;
                    BtnTheme8.Radius = 5;
                    BtnTheme9.Radius = 5;
                    BtnTheme10.Radius = 5;
                    BtnTheme11.Radius = 5;
                    BtnTheme12.Radius = 5;

                    break;

                case 7:
                    GrpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    GrpTheme1.ForeColor = Color.Black;
                    GrpTheme2.ForeColor = Color.Black;
                    GrpTheme3.ForeColor = Color.Black;
                    GrpTheme4.ForeColor = Color.Black;
                    GrpTheme5.ForeColor = Color.Black;
                    GrpTheme6.ForeColor = Color.Black;
                    GrpTheme7.ForeColor = Color.OrangeRed;
                    GrpTheme8.ForeColor = Color.Black;
                    GrpTheme9.ForeColor = Color.Black;
                    GrpTheme10.ForeColor = Color.Black;
                    GrpTheme11.ForeColor = Color.Black;
                    GrpTheme12.ForeColor = Color.Black;

                    BtnTheme1.Radius = 5;
                    BtnTheme2.Radius = 5;
                    BtnTheme3.Radius = 5;
                    BtnTheme4.Radius = 5;
                    BtnTheme5.Radius = 5;
                    BtnTheme6.Radius = 5;
                    BtnTheme7.Radius = 90;
                    BtnTheme8.Radius = 5;
                    BtnTheme9.Radius = 5;
                    BtnTheme10.Radius = 5;
                    BtnTheme11.Radius = 5;
                    BtnTheme12.Radius = 5;

                    break;

                case 8:
                    GrpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    GrpTheme1.ForeColor = Color.Black;
                    GrpTheme2.ForeColor = Color.Black;
                    GrpTheme3.ForeColor = Color.Black;
                    GrpTheme4.ForeColor = Color.Black;
                    GrpTheme5.ForeColor = Color.Black;
                    GrpTheme6.ForeColor = Color.Black;
                    GrpTheme7.ForeColor = Color.Black;
                    GrpTheme8.ForeColor = Color.OrangeRed;
                    GrpTheme9.ForeColor = Color.Black;
                    GrpTheme10.ForeColor = Color.Black;
                    GrpTheme11.ForeColor = Color.Black;
                    GrpTheme12.ForeColor = Color.Black;

                    BtnTheme1.Radius = 5;
                    BtnTheme2.Radius = 5;
                    BtnTheme3.Radius = 5;
                    BtnTheme4.Radius = 5;
                    BtnTheme5.Radius = 5;
                    BtnTheme6.Radius = 5;
                    BtnTheme7.Radius = 5;
                    BtnTheme8.Radius = 90;
                    BtnTheme9.Radius = 5;
                    BtnTheme10.Radius = 5;
                    BtnTheme11.Radius = 5;
                    BtnTheme12.Radius = 5;

                    break;

                case 9:
                    GrpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    GrpTheme1.ForeColor = Color.Black;
                    GrpTheme2.ForeColor = Color.Black;
                    GrpTheme3.ForeColor = Color.Black;
                    GrpTheme4.ForeColor = Color.Black;
                    GrpTheme5.ForeColor = Color.Black;
                    GrpTheme6.ForeColor = Color.Black;
                    GrpTheme7.ForeColor = Color.Black;
                    GrpTheme8.ForeColor = Color.Black;
                    GrpTheme9.ForeColor = Color.OrangeRed;
                    GrpTheme10.ForeColor = Color.Black;
                    GrpTheme11.ForeColor = Color.Black;
                    GrpTheme12.ForeColor = Color.Black;

                    BtnTheme1.Radius = 5;
                    BtnTheme2.Radius = 5;
                    BtnTheme3.Radius = 5;
                    BtnTheme4.Radius = 5;
                    BtnTheme5.Radius = 5;
                    BtnTheme6.Radius = 5;
                    BtnTheme7.Radius = 5;
                    BtnTheme8.Radius = 5;
                    BtnTheme9.Radius = 90;
                    BtnTheme10.Radius = 5;
                    BtnTheme11.Radius = 5;
                    BtnTheme12.Radius = 5;

                    break;

                case 10:
                    GrpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    GrpTheme1.ForeColor = Color.Black;
                    GrpTheme2.ForeColor = Color.Black;
                    GrpTheme3.ForeColor = Color.Black;
                    GrpTheme4.ForeColor = Color.Black;
                    GrpTheme5.ForeColor = Color.Black;
                    GrpTheme6.ForeColor = Color.Black;
                    GrpTheme7.ForeColor = Color.Black;
                    GrpTheme8.ForeColor = Color.Black;
                    GrpTheme9.ForeColor = Color.Black;
                    GrpTheme10.ForeColor = Color.OrangeRed;
                    GrpTheme11.ForeColor = Color.Black;
                    GrpTheme12.ForeColor = Color.Black;

                    BtnTheme1.Radius = 5;
                    BtnTheme2.Radius = 5;
                    BtnTheme3.Radius = 5;
                    BtnTheme4.Radius = 5;
                    BtnTheme5.Radius = 5;
                    BtnTheme6.Radius = 5;
                    BtnTheme7.Radius = 5;
                    BtnTheme8.Radius = 5;
                    BtnTheme9.Radius = 5;
                    BtnTheme10.Radius = 90;
                    BtnTheme11.Radius = 5;
                    BtnTheme12.Radius = 5;

                    break;

                case 11:
                    GrpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    GrpTheme1.ForeColor = Color.Black;
                    GrpTheme2.ForeColor = Color.Black;
                    GrpTheme3.ForeColor = Color.Black;
                    GrpTheme4.ForeColor = Color.Black;
                    GrpTheme5.ForeColor = Color.Black;
                    GrpTheme6.ForeColor = Color.Black;
                    GrpTheme7.ForeColor = Color.Black;
                    GrpTheme8.ForeColor = Color.Black;
                    GrpTheme9.ForeColor = Color.Black;
                    GrpTheme10.ForeColor = Color.Black;
                    GrpTheme11.ForeColor = Color.OrangeRed;
                    GrpTheme12.ForeColor = Color.Black;

                    BtnTheme1.Radius = 5;
                    BtnTheme2.Radius = 5;
                    BtnTheme3.Radius = 5;
                    BtnTheme4.Radius = 5;
                    BtnTheme5.Radius = 5;
                    BtnTheme6.Radius = 5;
                    BtnTheme7.Radius = 5;
                    BtnTheme8.Radius = 5;
                    BtnTheme9.Radius = 5;
                    BtnTheme10.Radius = 5;
                    BtnTheme11.Radius = 90;
                    BtnTheme12.Radius = 5;

                    break;

                case 12:
                    GrpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

                    GrpTheme1.ForeColor = Color.Black;
                    GrpTheme2.ForeColor = Color.Black;
                    GrpTheme3.ForeColor = Color.Black;
                    GrpTheme4.ForeColor = Color.Black;
                    GrpTheme5.ForeColor = Color.Black;
                    GrpTheme6.ForeColor = Color.Black;
                    GrpTheme7.ForeColor = Color.Black;
                    GrpTheme8.ForeColor = Color.Black;
                    GrpTheme9.ForeColor = Color.Black;
                    GrpTheme10.ForeColor = Color.Black;
                    GrpTheme11.ForeColor = Color.Black;
                    GrpTheme12.ForeColor = Color.OrangeRed;

                    BtnTheme1.Radius = 5;
                    BtnTheme2.Radius = 5;
                    BtnTheme3.Radius = 5;
                    BtnTheme4.Radius = 5;
                    BtnTheme5.Radius = 5;
                    BtnTheme6.Radius = 5;
                    BtnTheme7.Radius = 5;
                    BtnTheme8.Radius = 5;
                    BtnTheme9.Radius = 5;
                    BtnTheme10.Radius = 5;
                    BtnTheme11.Radius = 5;
                    BtnTheme12.Radius = 90;

                    break;

                default:
                    GrpTheme1.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme2.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme3.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme4.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme5.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme6.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme7.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme8.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme9.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme10.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme11.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    GrpTheme12.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    GrpTheme1.ForeColor = Color.OrangeRed;
                    GrpTheme2.ForeColor = Color.Black;
                    GrpTheme3.ForeColor = Color.Black;
                    GrpTheme4.ForeColor = Color.Black;
                    GrpTheme5.ForeColor = Color.Black;
                    GrpTheme6.ForeColor = Color.Black;
                    GrpTheme7.ForeColor = Color.Black;
                    GrpTheme8.ForeColor = Color.Black;
                    GrpTheme9.ForeColor = Color.Black;
                    GrpTheme10.ForeColor = Color.Black;
                    GrpTheme11.ForeColor = Color.Black;
                    GrpTheme12.ForeColor = Color.Black;

                    BtnTheme1.Radius = 90;
                    BtnTheme2.Radius = 5;
                    BtnTheme3.Radius = 5;
                    BtnTheme4.Radius = 5;
                    BtnTheme5.Radius = 5;
                    BtnTheme6.Radius = 5;
                    BtnTheme7.Radius = 5;
                    BtnTheme8.Radius = 5;
                    BtnTheme9.Radius = 5;
                    BtnTheme10.Radius = 5;
                    BtnTheme11.Radius = 5;
                    BtnTheme12.Radius = 5;

                    break;

            }
        }

        private void TsbtnPage1_Click(object sender, EventArgs e)
        {
            TsbtnPage1.Checked = true;
            TsbtnPage2.Checked = false;
            TsbtnPage3.Checked = false;
            TsbtnPage4.Checked = false;

            SettingsPage1.Visible = true;
            SettingsPage2.Visible = false;
            SettingsPage3.Visible = false;
        }

        private void TsbtnPage2_Click(object sender, EventArgs e)
        {
            TsbtnPage1.Checked = false;
            TsbtnPage2.Checked = true;
            TsbtnPage3.Checked = false;
            TsbtnPage4.Checked = false;

            SettingsPage1.Visible = false;
            SettingsPage2.Visible = true;
            SettingsPage3.Visible = false;

        }

        private void TsbtnPage3_Click(object sender, EventArgs e)
        {
            TsbtnPage1.Checked = false;
            TsbtnPage2.Checked = false;
            TsbtnPage3.Checked = true;
            TsbtnPage4.Checked = false;

            SettingsPage1.Visible = false;
            SettingsPage2.Visible = false;
            SettingsPage3.Visible = true;
        }

        private void TsbtnPage4_Click(object sender, EventArgs e)
        {
            TsbtnPage1.Checked = false;
            TsbtnPage2.Checked = false;
            TsbtnPage3.Checked = false;
            TsbtnPage4.Checked = true;

            SettingsPage1.Visible = true;
            SettingsPage2.Visible = false;
            SettingsPage3.Visible = false;

        }

    }
}
