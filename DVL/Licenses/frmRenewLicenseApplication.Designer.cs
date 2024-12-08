namespace DVL.Licenses
{
    partial class frmRenewLicenseApplication
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
            this.llbShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbApplicationInfo = new System.Windows.Forms.GroupBox();
            this.lbTotalFees = new System.Windows.Forms.Label();
            this.lbLicenseFees = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbOldLicenseID = new System.Windows.Forms.Label();
            this.lbRLLicenseID = new System.Windows.Forms.Label();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.lbApplicationFees = new System.Windows.Forms.Label();
            this.lbissueDate = new System.Windows.Forms.Label();
            this.lbExpirationDate = new System.Windows.Forms.Label();
            this.lbRLApplicationID = new System.Windows.Forms.Label();
            this.lbApplicationDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ucFilterAndFindDriverLicense1 = new DVL.UserControlls.ucFilterAndFindDriverLicense();
            this.llbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.gbApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // llbShowLicenseHistory
            // 
            this.llbShowLicenseHistory.AutoSize = true;
            this.llbShowLicenseHistory.Enabled = false;
            this.llbShowLicenseHistory.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.llbShowLicenseHistory.Location = new System.Drawing.Point(28, 1000);
            this.llbShowLicenseHistory.Name = "llbShowLicenseHistory";
            this.llbShowLicenseHistory.Size = new System.Drawing.Size(203, 21);
            this.llbShowLicenseHistory.TabIndex = 47;
            this.llbShowLicenseHistory.TabStop = true;
            this.llbShowLicenseHistory.Text = "Show Licenses History";
            this.llbShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicenseHistory_LinkClicked);
            // 
            // btnRenew
            // 
            this.btnRenew.BackColor = System.Drawing.SystemColors.Control;
            this.btnRenew.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRenew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenew.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenew.ForeColor = System.Drawing.Color.Black;
            this.btnRenew.Image = global::DVL.Properties.Resources.Renew_Driving_License_32;
            this.btnRenew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenew.Location = new System.Drawing.Point(890, 992);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(124, 36);
            this.btnRenew.TabIndex = 46;
            this.btnRenew.Text = "Renew";
            this.btnRenew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRenew.UseVisualStyleBackColor = false;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
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
            this.btnClose.Location = new System.Drawing.Point(750, 992);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 36);
            this.btnClose.TabIndex = 45;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Red;
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.ForeColor = System.Drawing.Color.White;
            this.btnX.Location = new System.Drawing.Point(970, 4);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(45, 36);
            this.btnX.TabIndex = 42;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 18);
            this.label1.TabIndex = 41;
            this.label1.Text = "Renew Local Driving License Applications";
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Controls.Add(this.lbTotalFees);
            this.gbApplicationInfo.Controls.Add(this.lbLicenseFees);
            this.gbApplicationInfo.Controls.Add(this.txtNotes);
            this.gbApplicationInfo.Controls.Add(this.label13);
            this.gbApplicationInfo.Controls.Add(this.label12);
            this.gbApplicationInfo.Controls.Add(this.label11);
            this.gbApplicationInfo.Controls.Add(this.lbOldLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lbRLLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lbCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.lbApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.lbissueDate);
            this.gbApplicationInfo.Controls.Add(this.lbExpirationDate);
            this.gbApplicationInfo.Controls.Add(this.lbRLApplicationID);
            this.gbApplicationInfo.Controls.Add(this.lbApplicationDate);
            this.gbApplicationInfo.Controls.Add(this.label10);
            this.gbApplicationInfo.Controls.Add(this.label9);
            this.gbApplicationInfo.Controls.Add(this.label8);
            this.gbApplicationInfo.Controls.Add(this.label7);
            this.gbApplicationInfo.Controls.Add(this.label6);
            this.gbApplicationInfo.Controls.Add(this.label5);
            this.gbApplicationInfo.Controls.Add(this.label4);
            this.gbApplicationInfo.Controls.Add(this.label2);
            this.gbApplicationInfo.Location = new System.Drawing.Point(12, 646);
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.Size = new System.Drawing.Size(1003, 340);
            this.gbApplicationInfo.TabIndex = 49;
            this.gbApplicationInfo.TabStop = false;
            this.gbApplicationInfo.Text = "ApplicationInfo";
            // 
            // lbTotalFees
            // 
            this.lbTotalFees.AutoSize = true;
            this.lbTotalFees.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalFees.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTotalFees.Location = new System.Drawing.Point(722, 212);
            this.lbTotalFees.Name = "lbTotalFees";
            this.lbTotalFees.Size = new System.Drawing.Size(60, 21);
            this.lbTotalFees.TabIndex = 52;
            this.lbTotalFees.Text = "?????";
            this.lbTotalFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbLicenseFees
            // 
            this.lbLicenseFees.AutoSize = true;
            this.lbLicenseFees.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseFees.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbLicenseFees.Location = new System.Drawing.Point(252, 212);
            this.lbLicenseFees.Name = "lbLicenseFees";
            this.lbLicenseFees.Size = new System.Drawing.Size(60, 21);
            this.lbLicenseFees.TabIndex = 51;
            this.lbLicenseFees.Text = "?????";
            this.lbLicenseFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(256, 259);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(584, 68);
            this.txtNotes.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Image = global::DVL.Properties.Resources.Notes_32;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Location = new System.Drawing.Point(16, 246);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(220, 45);
            this.label13.TabIndex = 26;
            this.label13.Text = "Notes:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Image = global::DVL.Properties.Resources.money_32___2;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Location = new System.Drawing.Point(485, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(220, 45);
            this.label12.TabIndex = 25;
            this.label12.Text = "Total Fees:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Image = global::DVL.Properties.Resources.money_32;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(16, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(220, 45);
            this.label11.TabIndex = 24;
            this.label11.Text = "License Fees:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbOldLicenseID
            // 
            this.lbOldLicenseID.AutoSize = true;
            this.lbOldLicenseID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOldLicenseID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbOldLicenseID.Location = new System.Drawing.Point(722, 77);
            this.lbOldLicenseID.Name = "lbOldLicenseID";
            this.lbOldLicenseID.Size = new System.Drawing.Size(60, 21);
            this.lbOldLicenseID.TabIndex = 23;
            this.lbOldLicenseID.Text = "?????";
            this.lbOldLicenseID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRLLicenseID
            // 
            this.lbRLLicenseID.AutoSize = true;
            this.lbRLLicenseID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRLLicenseID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbRLLicenseID.Location = new System.Drawing.Point(722, 32);
            this.lbRLLicenseID.Name = "lbRLLicenseID";
            this.lbRLLicenseID.Size = new System.Drawing.Size(60, 21);
            this.lbRLLicenseID.TabIndex = 22;
            this.lbRLLicenseID.Text = "?????";
            this.lbRLLicenseID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbCreatedBy.Location = new System.Drawing.Point(722, 167);
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
            this.lbApplicationFees.Location = new System.Drawing.Point(252, 167);
            this.lbApplicationFees.Name = "lbApplicationFees";
            this.lbApplicationFees.Size = new System.Drawing.Size(60, 21);
            this.lbApplicationFees.TabIndex = 21;
            this.lbApplicationFees.Text = "?????";
            this.lbApplicationFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbissueDate
            // 
            this.lbissueDate.AutoSize = true;
            this.lbissueDate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbissueDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbissueDate.Location = new System.Drawing.Point(252, 122);
            this.lbissueDate.Name = "lbissueDate";
            this.lbissueDate.Size = new System.Drawing.Size(118, 21);
            this.lbissueDate.TabIndex = 20;
            this.lbissueDate.Text = "00/00/0000";
            this.lbissueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbExpirationDate
            // 
            this.lbExpirationDate.AutoSize = true;
            this.lbExpirationDate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExpirationDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbExpirationDate.Location = new System.Drawing.Point(722, 122);
            this.lbExpirationDate.Name = "lbExpirationDate";
            this.lbExpirationDate.Size = new System.Drawing.Size(118, 21);
            this.lbExpirationDate.TabIndex = 20;
            this.lbExpirationDate.Text = "00/00/0000";
            this.lbExpirationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRLApplicationID
            // 
            this.lbRLApplicationID.AutoSize = true;
            this.lbRLApplicationID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRLApplicationID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbRLApplicationID.Location = new System.Drawing.Point(252, 32);
            this.lbRLApplicationID.Name = "lbRLApplicationID";
            this.lbRLApplicationID.Size = new System.Drawing.Size(60, 21);
            this.lbRLApplicationID.TabIndex = 19;
            this.lbRLApplicationID.Text = "?????";
            this.lbRLApplicationID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbApplicationDate
            // 
            this.lbApplicationDate.AutoSize = true;
            this.lbApplicationDate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbApplicationDate.Location = new System.Drawing.Point(252, 77);
            this.lbApplicationDate.Name = "lbApplicationDate";
            this.lbApplicationDate.Size = new System.Drawing.Size(118, 21);
            this.lbApplicationDate.TabIndex = 18;
            this.lbApplicationDate.Text = "00/00/0000";
            this.lbApplicationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Image = global::DVL.Properties.Resources.Calendar_32;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(485, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(220, 45);
            this.label10.TabIndex = 10;
            this.label10.Text = "Expiration Date:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = global::DVL.Properties.Resources.LocalDriving_License;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(485, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(220, 45);
            this.label9.TabIndex = 9;
            this.label9.Text = "Old License ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Image = global::DVL.Properties.Resources.User_32__2;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(485, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(220, 45);
            this.label8.TabIndex = 9;
            this.label8.Text = "Created By:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Image = global::DVL.Properties.Resources.Renew_Driving_License_32;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(485, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 45);
            this.label7.TabIndex = 8;
            this.label7.Text = "Renewed License ID:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Image = global::DVL.Properties.Resources.money_32;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(16, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 45);
            this.label6.TabIndex = 7;
            this.label6.Text = "Application Fees:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = global::DVL.Properties.Resources.Calendar_32;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(16, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 45);
            this.label5.TabIndex = 6;
            this.label5.Text = "Issue Date:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = global::DVL.Properties.Resources.Calendar_32;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(16, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 45);
            this.label4.TabIndex = 5;
            this.label4.Text = "Application Date:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::DVL.Properties.Resources.Number_32;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(16, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 45);
            this.label2.TabIndex = 4;
            this.label2.Text = "R.L.Application ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(304, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(419, 36);
            this.label3.TabIndex = 43;
            this.label3.Text = "Renew License Application";
            // 
            // ucFilterAndFindDriverLicense1
            // 
            this.ucFilterAndFindDriverLicense1.Location = new System.Drawing.Point(12, 86);
            this.ucFilterAndFindDriverLicense1.Name = "ucFilterAndFindDriverLicense1";
            this.ucFilterAndFindDriverLicense1.Size = new System.Drawing.Size(1005, 554);
            this.ucFilterAndFindDriverLicense1.TabIndex = 44;
            // 
            // llbShowLicenseInfo
            // 
            this.llbShowLicenseInfo.AutoSize = true;
            this.llbShowLicenseInfo.Enabled = false;
            this.llbShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.llbShowLicenseInfo.Location = new System.Drawing.Point(218, 1000);
            this.llbShowLicenseInfo.Name = "llbShowLicenseInfo";
            this.llbShowLicenseInfo.Size = new System.Drawing.Size(178, 21);
            this.llbShowLicenseInfo.TabIndex = 50;
            this.llbShowLicenseInfo.TabStop = true;
            this.llbShowLicenseInfo.Text = "Show Licenses Info";
            this.llbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicenseInfo_LinkClicked);
            // 
            // frmRenewLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1029, 1044);
            this.Controls.Add(this.llbShowLicenseInfo);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.llbShowLicenseHistory);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucFilterAndFindDriverLicense1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRenewLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRenewLicenseApplication";
            this.Load += new System.EventHandler(this.frmRenewLicenseApplication_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel llbShowLicenseHistory;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnClose;
        private UserControlls.ucFilterAndFindDriverLicense ucFilterAndFindDriverLicense1;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label lbOldLicenseID;
        private System.Windows.Forms.Label lbRLLicenseID;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label lbApplicationFees;
        private System.Windows.Forms.Label lbissueDate;
        private System.Windows.Forms.Label lbExpirationDate;
        private System.Windows.Forms.Label lbRLApplicationID;
        private System.Windows.Forms.Label lbApplicationDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbTotalFees;
        private System.Windows.Forms.Label lbLicenseFees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel llbShowLicenseInfo;
    }
}