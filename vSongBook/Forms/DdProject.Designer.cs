namespace vSongBook
{
    partial class DdProject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DdProject));
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.lineDown = new System.Windows.Forms.Label();
            this.lineTop = new System.Windows.Forms.Label();
            this.lblSongTitle = new System.Windows.Forms.Label();
            this.tblBottom = new System.Windows.Forms.TableLayoutPanel();
            this.lblSongLabel = new System.Windows.Forms.Label();
            this.lblSongno = new System.Windows.Forms.Label();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.pbxDown = new System.Windows.Forms.PictureBox();
            this.pbxUp = new System.Windows.Forms.PictureBox();
            this.lblVerses = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblSongText = new System.Windows.Forms.Label();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.tmrLinerr = new System.Windows.Forms.Timer(this.components);
            this.tblMain.SuspendLayout();
            this.tblBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUp)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.lineDown, 0, 3);
            this.tblMain.Controls.Add(this.lineTop, 0, 1);
            this.tblMain.Controls.Add(this.lblSongTitle, 0, 0);
            this.tblMain.Controls.Add(this.tblBottom, 0, 4);
            this.tblMain.Controls.Add(this.lblSongText, 0, 2);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.ForeColor = System.Drawing.Color.White;
            this.tblMain.Location = new System.Drawing.Point(10, 10);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 5;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.Size = new System.Drawing.Size(871, 447);
            this.tblMain.TabIndex = 2;
            this.tblMain.Paint += new System.Windows.Forms.PaintEventHandler(this.tblMain_Paint);
            // 
            // lineDown
            // 
            this.lineDown.AutoSize = true;
            this.lineDown.BackColor = System.Drawing.Color.White;
            this.lineDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineDown.Location = new System.Drawing.Point(3, 404);
            this.lineDown.Name = "lineDown";
            this.lineDown.Size = new System.Drawing.Size(865, 3);
            this.lineDown.TabIndex = 2;
            this.lineDown.Text = "...";
            this.lineDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lineDown.Click += new System.EventHandler(this.lineDown_Click);
            // 
            // lineTop
            // 
            this.lineTop.AutoSize = true;
            this.lineTop.BackColor = System.Drawing.Color.White;
            this.lineTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineTop.Location = new System.Drawing.Point(3, 50);
            this.lineTop.Name = "lineTop";
            this.lineTop.Size = new System.Drawing.Size(865, 3);
            this.lineTop.TabIndex = 1;
            this.lineTop.Text = "...";
            this.lineTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lineTop.Click += new System.EventHandler(this.lineTop_Click);
            // 
            // lblSongTitle
            // 
            this.lblSongTitle.AutoSize = true;
            this.lblSongTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSongTitle.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSongTitle.ForeColor = System.Drawing.Color.White;
            this.lblSongTitle.Location = new System.Drawing.Point(3, 0);
            this.lblSongTitle.Name = "lblSongTitle";
            this.lblSongTitle.Size = new System.Drawing.Size(865, 50);
            this.lblSongTitle.TabIndex = 4;
            this.lblSongTitle.Text = "Song Title";
            this.lblSongTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSongTitle.Click += new System.EventHandler(this.lblSongTitle_Click);
            // 
            // tblBottom
            // 
            this.tblBottom.ColumnCount = 8;
            this.tblBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblBottom.Controls.Add(this.lblSongLabel, 0, 0);
            this.tblBottom.Controls.Add(this.lblSongno, 2, 0);
            this.tblBottom.Controls.Add(this.txtCommandLine, 1, 0);
            this.tblBottom.Controls.Add(this.pbxDown, 7, 0);
            this.tblBottom.Controls.Add(this.pbxUp, 6, 0);
            this.tblBottom.Controls.Add(this.lblVerses, 5, 0);
            this.tblBottom.Controls.Add(this.lblItem, 4, 0);
            this.tblBottom.Controls.Add(this.lblDetails, 3, 0);
            this.tblBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBottom.Location = new System.Drawing.Point(3, 410);
            this.tblBottom.Name = "tblBottom";
            this.tblBottom.RowCount = 1;
            this.tblBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBottom.Size = new System.Drawing.Size(865, 34);
            this.tblBottom.TabIndex = 3;
            this.tblBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.tblBottom_Paint);
            // 
            // lblSongLabel
            // 
            this.lblSongLabel.AutoSize = true;
            this.lblSongLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSongLabel.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSongLabel.ForeColor = System.Drawing.Color.White;
            this.lblSongLabel.Location = new System.Drawing.Point(3, 0);
            this.lblSongLabel.Name = "lblSongLabel";
            this.lblSongLabel.Size = new System.Drawing.Size(94, 34);
            this.lblSongLabel.TabIndex = 6;
            this.lblSongLabel.Text = "Song";
            this.lblSongLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblSongLabel.Click += new System.EventHandler(this.lblSongLabel_Click);
            // 
            // lblSongno
            // 
            this.lblSongno.AutoSize = true;
            this.lblSongno.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSongno.ForeColor = System.Drawing.Color.White;
            this.lblSongno.Location = new System.Drawing.Point(108, 0);
            this.lblSongno.Name = "lblSongno";
            this.lblSongno.Size = new System.Drawing.Size(55, 29);
            this.lblSongno.TabIndex = 7;
            this.lblSongno.Text = "#01";
            this.lblSongno.Click += new System.EventHandler(this.lblSongno_Click);
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.BackColor = System.Drawing.Color.Black;
            this.txtCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCommandLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommandLine.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommandLine.ForeColor = System.Drawing.Color.Black;
            this.txtCommandLine.Location = new System.Drawing.Point(103, 3);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.Size = new System.Drawing.Size(1, 16);
            this.txtCommandLine.TabIndex = 0;
            this.txtCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommandLine_KeyDown);
            // 
            // pbxDown
            // 
            this.pbxDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxDown.Image = global::vSongBook.Properties.Resources.whitedown;
            this.pbxDown.Location = new System.Drawing.Point(828, 3);
            this.pbxDown.Name = "pbxDown";
            this.pbxDown.Size = new System.Drawing.Size(34, 28);
            this.pbxDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDown.TabIndex = 9;
            this.pbxDown.TabStop = false;
            this.pbxDown.Visible = false;
            this.pbxDown.Click += new System.EventHandler(this.pbxDown_Click);
            // 
            // pbxUp
            // 
            this.pbxUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxUp.Image = global::vSongBook.Properties.Resources.whiteup;
            this.pbxUp.Location = new System.Drawing.Point(788, 3);
            this.pbxUp.Name = "pbxUp";
            this.pbxUp.Size = new System.Drawing.Size(34, 28);
            this.pbxUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxUp.TabIndex = 10;
            this.pbxUp.TabStop = false;
            this.pbxUp.Visible = false;
            this.pbxUp.Click += new System.EventHandler(this.pbxUp_Click);
            // 
            // lblVerses
            // 
            this.lblVerses.AutoSize = true;
            this.lblVerses.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerses.ForeColor = System.Drawing.Color.White;
            this.lblVerses.Location = new System.Drawing.Point(588, 0);
            this.lblVerses.Name = "lblVerses";
            this.lblVerses.Size = new System.Drawing.Size(78, 29);
            this.lblVerses.TabIndex = 11;
            this.lblVerses.Text = "1 of 4";
            this.lblVerses.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.White;
            this.lblItem.Location = new System.Drawing.Point(388, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(194, 34);
            this.lblItem.TabIndex = 8;
            this.lblItem.Text = "Verse";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblItem.Click += new System.EventHandler(this.lblVerse_Click);
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.Location = new System.Drawing.Point(208, 0);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(120, 29);
            this.lblDetails.TabIndex = 12;
            this.lblDetails.Text = "Songbook";
            // 
            // lblSongText
            // 
            this.lblSongText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblSongText.AutoSize = true;
            this.lblSongText.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSongText.Location = new System.Drawing.Point(292, 53);
            this.lblSongText.Name = "lblSongText";
            this.lblSongText.Size = new System.Drawing.Size(286, 351);
            this.lblSongText.TabIndex = 5;
            this.lblSongText.Text = "Amazing Grace, how sweet the sound,\r\nThat saved a wretch like me,\r\nI once was los" +
    "t but now am found,\r\nWas blind but now I see.";
            this.lblSongText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSongText.Click += new System.EventHandler(this.lblSongText_Click);
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 60000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // tmrLinerr
            // 
            this.tmrLinerr.Interval = 3000;
            this.tmrLinerr.Tick += new System.EventHandler(this.tmrLinerr_Tick);
            // 
            // DdProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(891, 467);
            this.ControlBox = false;
            this.Controls.Add(this.tblMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DdProject";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "1";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DdProject_Load);
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.tblBottom.ResumeLayout(false);
            this.tblBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Label lineDown;
        private System.Windows.Forms.Label lineTop;
        private System.Windows.Forms.Label lblSongTitle;
        private System.Windows.Forms.TableLayoutPanel tblBottom;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblSongLabel;
        private System.Windows.Forms.Label lblSongno;
        private System.Windows.Forms.Timer tmrLinerr;
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Label lblSongText;
        private System.Windows.Forms.PictureBox pbxDown;
        private System.Windows.Forms.PictureBox pbxUp;
        private System.Windows.Forms.Label lblVerses;
        private System.Windows.Forms.Label lblDetails;
    }
}