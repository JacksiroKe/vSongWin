namespace vSongBook
{
    partial class CcBookList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CcBookList));
            this.asFeedback = new AnisiControls.AsFeedback();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.grpBookResults = new System.Windows.Forms.GroupBox();
            this.lstBooks = new System.Windows.Forms.ListBox();
            this.lstBookids = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grpNotes = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtBookCode = new AnisiControls.AsTextbox();
            this.txtBookTitle = new AnisiControls.AsTextbox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblActions = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblTop = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.grpBookResults.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.grpNotes.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tblTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // asFeedback
            // 
            this.asFeedback.BackColor = System.Drawing.Color.LightGreen;
            this.asFeedback.Dock = System.Windows.Forms.DockStyle.Top;
            this.asFeedback.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.asFeedback.ForeColor = System.Drawing.Color.Black;
            this.asFeedback.Interval = 2500F;
            this.asFeedback.IsPositive = true;
            this.asFeedback.IsTimed = false;
            this.asFeedback.Location = new System.Drawing.Point(5, 5);
            this.asFeedback.Name = "asFeedback";
            this.asFeedback.Size = new System.Drawing.Size(973, 50);
            this.asFeedback.TabIndex = 4;
            this.asFeedback.Text = "vSongBook Feedback";
            this.asFeedback.Visible = false;
            // 
            // splitMain
            // 
            this.splitMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.IsSplitterFixed = true;
            this.splitMain.Location = new System.Drawing.Point(5, 55);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.grpBookResults);
            this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitMain.Size = new System.Drawing.Size(973, 431);
            this.splitMain.SplitterDistance = 328;
            this.splitMain.TabIndex = 5;
            // 
            // grpBookResults
            // 
            this.grpBookResults.Controls.Add(this.lstBooks);
            this.grpBookResults.Controls.Add(this.lstBookids);
            this.grpBookResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBookResults.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBookResults.Location = new System.Drawing.Point(5, 5);
            this.grpBookResults.Name = "grpBookResults";
            this.grpBookResults.Padding = new System.Windows.Forms.Padding(5);
            this.grpBookResults.Size = new System.Drawing.Size(316, 419);
            this.grpBookResults.TabIndex = 1;
            this.grpBookResults.TabStop = false;
            this.grpBookResults.Text = " 0 books exist currently";
            // 
            // lstBooks
            // 
            this.lstBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBooks.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBooks.FormattingEnabled = true;
            this.lstBooks.ItemHeight = 22;
            this.lstBooks.Location = new System.Drawing.Point(5, 21);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(306, 393);
            this.lstBooks.TabIndex = 0;
            this.lstBooks.SelectedIndexChanged += new System.EventHandler(this.lstBooks_SelectedIndexChanged);
            // 
            // lstBookids
            // 
            this.lstBookids.FormattingEnabled = true;
            this.lstBookids.ItemHeight = 18;
            this.lstBookids.Location = new System.Drawing.Point(36, 61);
            this.lstBookids.Name = "lstBookids";
            this.lstBookids.Size = new System.Drawing.Size(144, 184);
            this.lstBookids.TabIndex = 0;
            this.lstBookids.SelectedIndexChanged += new System.EventHandler(this.lstBookids_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(639, 429);
            this.tableLayoutPanel3.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 63);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(633, 363);
            this.panel3.TabIndex = 15;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.grpNotes, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtBookCode, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtBookTitle, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblInfo, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(621, 351);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // grpNotes
            // 
            this.grpNotes.Controls.Add(this.txtNotes);
            this.grpNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNotes.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNotes.Location = new System.Drawing.Point(3, 123);
            this.grpNotes.Name = "grpNotes";
            this.grpNotes.Padding = new System.Windows.Forms.Padding(5);
            this.grpNotes.Size = new System.Drawing.Size(615, 86);
            this.grpNotes.TabIndex = 12;
            this.grpNotes.TabStop = false;
            this.grpNotes.Text = " Book Notes (Optional): ";
            // 
            // txtNotes
            // 
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(5, 24);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(10);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(605, 57);
            this.txtNotes.TabIndex = 3;
            // 
            // txtBookCode
            // 
            this.txtBookCode.BackColor = System.Drawing.Color.Transparent;
            this.txtBookCode.Background = System.Drawing.Color.White;
            this.txtBookCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBookCode.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookCode.ForeColor = System.Drawing.Color.Black;
            this.txtBookCode.IsSearch = false;
            this.txtBookCode.Location = new System.Drawing.Point(5, 65);
            this.txtBookCode.Margin = new System.Windows.Forms.Padding(5);
            this.txtBookCode.Name = "txtBookCode";
            this.txtBookCode.Placeholder = "Code of the Book";
            this.txtBookCode.ShowIcon = false;
            this.txtBookCode.Size = new System.Drawing.Size(611, 50);
            this.txtBookCode.TabIndex = 2;
            this.txtBookCode.Text = "Code of the Book";
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.BackColor = System.Drawing.Color.Transparent;
            this.txtBookTitle.Background = System.Drawing.Color.White;
            this.txtBookTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBookTitle.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookTitle.ForeColor = System.Drawing.Color.Black;
            this.txtBookTitle.IsSearch = false;
            this.txtBookTitle.Location = new System.Drawing.Point(5, 5);
            this.txtBookTitle.Margin = new System.Windows.Forms.Padding(5);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Placeholder = "Title of the Book";
            this.txtBookTitle.ShowIcon = false;
            this.txtBookTitle.Size = new System.Drawing.Size(611, 50);
            this.txtBookTitle.TabIndex = 1;
            this.txtBookTitle.Text = "Title of the Book";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(3, 212);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(20, 27);
            this.lblInfo.TabIndex = 14;
            this.lblInfo.Text = ".";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 60);
            this.panel1.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblActions, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(637, 58);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblActions.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActions.Location = new System.Drawing.Point(77, 5);
            this.lblActions.Name = "lblActions";
            this.lblActions.Size = new System.Drawing.Size(75, 48);
            this.lblActions.TabIndex = 0;
            this.lblActions.Text = "ACTIONS";
            this.lblActions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tblTop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(155, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 48);
            this.panel2.TabIndex = 1;
            // 
            // tblTop
            // 
            this.tblTop.ColumnCount = 4;
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblTop.Controls.Add(this.btnUpdate, 3, 0);
            this.tblTop.Controls.Add(this.btnDelete, 2, 0);
            this.tblTop.Controls.Add(this.btnSaveNew, 1, 0);
            this.tblTop.Controls.Add(this.btnAddNew, 0, 0);
            this.tblTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTop.Location = new System.Drawing.Point(0, 0);
            this.tblTop.Margin = new System.Windows.Forms.Padding(0);
            this.tblTop.Name = "tblTop";
            this.tblTop.RowCount = 1;
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTop.Size = new System.Drawing.Size(475, 46);
            this.tblTop.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(357, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 42);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "&UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(239, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 42);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveNew.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNew.Location = new System.Drawing.Point(121, 3);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(112, 42);
            this.btnSaveNew.TabIndex = 5;
            this.btnSaveNew.Text = "SAVE &New";
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddNew.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(3, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(112, 42);
            this.btnAddNew.TabIndex = 4;
            this.btnAddNew.Text = "ADD &New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // CcBookList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.asFeedback);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "CcBookList";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Books List";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.CcBookList_Load);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.grpBookResults.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.grpNotes.ResumeLayout(false);
            this.grpNotes.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tblTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private AnisiControls.AsFeedback asFeedback;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.GroupBox grpBookResults;
        private System.Windows.Forms.ListBox lstBooks;
        private System.Windows.Forms.ListBox lstBookids;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox grpNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private AnisiControls.AsTextbox txtBookCode;
        private AnisiControls.AsTextbox txtBookTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblActions;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tblTop;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Button btnAddNew;
    }
}