namespace DVL.Manage_Detain_License
{
    partial class frmReleaseDetainedLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReleaseDetainedLicense));
            this.lbBigTitle = new System.Windows.Forms.Label();
            this.lbLicenseID = new System.Windows.Forms.Label();
            this.btnX = new System.Windows.Forms.Button();
            this.lbSmallTitle = new System.Windows.Forms.Label();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.lbApplicationFees = new System.Windows.Forms.Label();
            this.lbDetainID = new System.Windows.Forms.Label();
            this.lbDetainDate = new System.Windows.Forms.Label();
            this.llbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llbShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.gbApplicationInfo = new System.Windows.Forms.GroupBox();
            this.lbApplicationID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbtotalFees = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbFineFees = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucFilterAndFindDriverLicense1 = new DVL.UserControlls.ucFilterAndFindDriverLicense();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.gbApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbBigTitle
            // 
            this.lbBigTitle.AutoSize = true;
            this.lbBigTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lbBigTitle.Location = new System.Drawing.Point(328, 28);
            this.lbBigTitle.Name = "lbBigTitle";
            this.lbBigTitle.Size = new System.Drawing.Size(399, 36);
            this.lbBigTitle.TabIndex = 58;
            this.lbBigTitle.Text = "Release Detained License";
            // 
            // lbLicenseID
            // 
            this.lbLicenseID.AutoSize = true;
            this.lbLicenseID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbLicenseID.Location = new System.Drawing.Point(739, 32);
            this.lbLicenseID.Name = "lbLicenseID";
            this.lbLicenseID.Size = new System.Drawing.Size(60, 21);
            this.lbLicenseID.TabIndex = 23;
            this.lbLicenseID.Text = "?????";
            this.lbLicenseID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Red;
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.ForeColor = System.Drawing.Color.White;
            this.btnX.Location = new System.Drawing.Point(1004, 1);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(45, 36);
            this.btnX.TabIndex = 57;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // lbSmallTitle
            // 
            this.lbSmallTitle.AutoSize = true;
            this.lbSmallTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbSmallTitle.Location = new System.Drawing.Point(3, 1);
            this.lbSmallTitle.Name = "lbSmallTitle";
            this.lbSmallTitle.Size = new System.Drawing.Size(200, 18);
            this.lbSmallTitle.TabIndex = 56;
            this.lbSmallTitle.Text = "Release Detained License";
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbCreatedBy.Location = new System.Drawing.Point(739, 74);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(60, 21);
            this.lbCreatedBy.TabIndex = 22;
            this.lbCreatedBy.Text = "?????";
            this.lbCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbApplicationFees
            // 
            this.lbApplicationFees.AutoSize = true;
            this.lbApplicationFees.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationFees.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbApplicationFees.Location = new System.Drawing.Point(265, 122);
            this.lbApplicationFees.Name = "lbApplicationFees";
            this.lbApplicationFees.Size = new System.Drawing.Size(60, 21);
            this.lbApplicationFees.TabIndex = 21;
            this.lbApplicationFees.Text = "?????";
            this.lbApplicationFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDetainID
            // 
            this.lbDetainID.AutoSize = true;
            this.lbDetainID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetainID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbDetainID.Location = new System.Drawing.Point(265, 32);
            this.lbDetainID.Name = "lbDetainID";
            this.lbDetainID.Size = new System.Drawing.Size(60, 21);
            this.lbDetainID.TabIndex = 19;
            this.lbDetainID.Text = "?????";
            this.lbDetainID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDetainDate
            // 
            this.lbDetainDate.AutoSize = true;
            this.lbDetainDate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetainDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbDetainDate.Location = new System.Drawing.Point(265, 77);
            this.lbDetainDate.Name = "lbDetainDate";
            this.lbDetainDate.Size = new System.Drawing.Size(118, 21);
            this.lbDetainDate.TabIndex = 18;
            this.lbDetainDate.Text = "00/00/0000";
            this.lbDetainDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // llbShowLicenseInfo
            // 
            this.llbShowLicenseInfo.AutoSize = true;
            this.llbShowLicenseInfo.Enabled = false;
            this.llbShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.llbShowLicenseInfo.Location = new System.Drawing.Point(227, 835);
            this.llbShowLicenseInfo.Name = "llbShowLicenseInfo";
            this.llbShowLicenseInfo.Size = new System.Drawing.Size(178, 21);
            this.llbShowLicenseInfo.TabIndex = 64;
            this.llbShowLicenseInfo.TabStop = true;
            this.llbShowLicenseInfo.Text = "Show Licenses Info";
            // 
            // llbShowLicenseHistory
            // 
            this.llbShowLicenseHistory.AutoSize = true;
            this.llbShowLicenseHistory.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.llbShowLicenseHistory.Location = new System.Drawing.Point(18, 835);
            this.llbShowLicenseHistory.Name = "llbShowLicenseHistory";
            this.llbShowLicenseHistory.Size = new System.Drawing.Size(203, 21);
            this.llbShowLicenseHistory.TabIndex = 63;
            this.llbShowLicenseHistory.TabStop = true;
            this.llbShowLicenseHistory.Text = "Show Licenses History";
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Controls.Add(this.lbApplicationID);
            this.gbApplicationInfo.Controls.Add(this.label11);
            this.gbApplicationInfo.Controls.Add(this.lbtotalFees);
            this.gbApplicationInfo.Controls.Add(this.label5);
            this.gbApplicationInfo.Controls.Add(this.lbFineFees);
            this.gbApplicationInfo.Controls.Add(this.label1);
            this.gbApplicationInfo.Controls.Add(this.lbLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lbCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.lbApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.lbDetainID);
            this.gbApplicationInfo.Controls.Add(this.lbDetainDate);
            this.gbApplicationInfo.Controls.Add(this.label9);
            this.gbApplicationInfo.Controls.Add(this.label8);
            this.gbApplicationInfo.Controls.Add(this.label6);
            this.gbApplicationInfo.Controls.Add(this.label4);
            this.gbApplicationInfo.Controls.Add(this.label2);
            this.gbApplicationInfo.Location = new System.Drawing.Point(22, 611);
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.Size = new System.Drawing.Size(1010, 211);
            this.gbApplicationInfo.TabIndex = 60;
            this.gbApplicationInfo.TabStop = false;
            this.gbApplicationInfo.Text = "ApplicationInfo";
            // 
            // lbApplicationID
            // 
            this.lbApplicationID.AutoSize = true;
            this.lbApplicationID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbApplicationID.Location = new System.Drawing.Point(739, 164);
            this.lbApplicationID.Name = "lbApplicationID";
            this.lbApplicationID.Size = new System.Drawing.Size(60, 21);
            this.lbApplicationID.TabIndex = 29;
            this.lbApplicationID.Text = "?????";
            this.lbApplicationID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(485, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(233, 45);
            this.label11.TabIndex = 28;
            this.label11.Text = "Application ID:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtotalFees
            // 
            this.lbtotalFees.AutoSize = true;
            this.lbtotalFees.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotalFees.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbtotalFees.Location = new System.Drawing.Point(265, 164);
            this.lbtotalFees.Name = "lbtotalFees";
            this.lbtotalFees.Size = new System.Drawing.Size(60, 21);
            this.lbtotalFees.TabIndex = 27;
            this.lbtotalFees.Text = "?????";
            this.lbtotalFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(16, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 39);
            this.label5.TabIndex = 26;
            this.label5.Text = "Total Fees:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFineFees
            // 
            this.lbFineFees.AutoSize = true;
            this.lbFineFees.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFineFees.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbFineFees.Location = new System.Drawing.Point(739, 122);
            this.lbFineFees.Name = "lbFineFees";
            this.lbFineFees.Size = new System.Drawing.Size(60, 21);
            this.lbFineFees.TabIndex = 25;
            this.lbFineFees.Text = "?????";
            this.lbFineFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(485, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 45);
            this.label1.TabIndex = 24;
            this.label1.Text = "Fine Fees:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(485, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(233, 45);
            this.label9.TabIndex = 9;
            this.label9.Text = "License ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(485, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(233, 39);
            this.label8.TabIndex = 9;
            this.label8.Text = "Created By:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(16, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 45);
            this.label6.TabIndex = 7;
            this.label6.Text = "Application Fees:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(16, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 45);
            this.label4.TabIndex = 5;
            this.label4.Text = "Detain Date:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(16, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 45);
            this.label2.TabIndex = 4;
            this.label2.Text = "Detain ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucFilterAndFindDriverLicense1
            // 
            this.ucFilterAndFindDriverLicense1.Location = new System.Drawing.Point(22, 81);
            this.ucFilterAndFindDriverLicense1.Name = "ucFilterAndFindDriverLicense1";
            this.ucFilterAndFindDriverLicense1.Size = new System.Drawing.Size(1010, 540);
            this.ucFilterAndFindDriverLicense1.TabIndex = 59;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::DVL.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(802, 828);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 34);
            this.btnClose.TabIndex = 61;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.BackColor = System.Drawing.SystemColors.Control;
            this.btnRelease.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelease.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.ForeColor = System.Drawing.Color.Black;
            this.btnRelease.Image = global::DVL.Properties.Resources.Release_Detained_License_32;
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelease.Location = new System.Drawing.Point(920, 828);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(112, 34);
            this.btnRelease.TabIndex = 62;
            this.btnRelease.Text = "Release";
            this.btnRelease.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRelease.UseVisualStyleBackColor = false;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // frmReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 874);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.lbBigTitle);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.lbSmallTitle);
            this.Controls.Add(this.llbShowLicenseInfo);
            this.Controls.Add(this.llbShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.ucFilterAndFindDriverLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReleaseDetainedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReleaseDetainedLicense";
            this.Load += new System.EventHandler(this.frmReleaseDetainedLicense_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbBigTitle;
        private System.Windows.Forms.Label lbLicenseID;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label lbSmallTitle;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label lbApplicationFees;
        private System.Windows.Forms.Label lbDetainID;
        private System.Windows.Forms.Label lbDetainDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel llbShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llbShowLicenseHistory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRelease;
        private UserControlls.ucFilterAndFindDriverLicense ucFilterAndFindDriverLicense1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbApplicationID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbtotalFees;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbFineFees;
    }
}