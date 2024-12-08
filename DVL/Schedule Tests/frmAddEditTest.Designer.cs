namespace DVL.Schedule_Tests
{
    partial class frmAddEditTest
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
            this.btnX = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbTestType = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbRetakeTestInfo = new System.Windows.Forms.GroupBox();
            this.lbRTestAppID = new System.Windows.Forms.Label();
            this.lbTotalFees = new System.Windows.Forms.Label();
            this.lbRAppFees = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lbName = new System.Windows.Forms.Label();
            this.lbFees = new System.Windows.Forms.Label();
            this.lbDClass = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTestType = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbTestType.SuspendLayout();
            this.gbRetakeTestInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Red;
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.ForeColor = System.Drawing.Color.White;
            this.btnX.Location = new System.Drawing.Point(687, -1);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(45, 36);
            this.btnX.TabIndex = 21;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
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
            this.btnClose.Location = new System.Drawing.Point(318, 782);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 36);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbTestType
            // 
            this.gbTestType.Controls.Add(this.btnSave);
            this.gbTestType.Controls.Add(this.gbRetakeTestInfo);
            this.gbTestType.Controls.Add(this.dtpDate);
            this.gbTestType.Controls.Add(this.lbName);
            this.gbTestType.Controls.Add(this.lbFees);
            this.gbTestType.Controls.Add(this.lbDClass);
            this.gbTestType.Controls.Add(this.lbID);
            this.gbTestType.Controls.Add(this.label7);
            this.gbTestType.Controls.Add(this.label6);
            this.gbTestType.Controls.Add(this.label4);
            this.gbTestType.Controls.Add(this.label2);
            this.gbTestType.Controls.Add(this.label3);
            this.gbTestType.Controls.Add(this.lbTestType);
            this.gbTestType.Controls.Add(this.pictureBox1);
            this.gbTestType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTestType.Location = new System.Drawing.Point(3, 41);
            this.gbTestType.Name = "gbTestType";
            this.gbTestType.Size = new System.Drawing.Size(729, 725);
            this.gbTestType.TabIndex = 24;
            this.gbTestType.TabStop = false;
            this.gbTestType.Text = "TestType";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::DVL.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(613, 669);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 36);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbRetakeTestInfo
            // 
            this.gbRetakeTestInfo.Controls.Add(this.lbRTestAppID);
            this.gbRetakeTestInfo.Controls.Add(this.lbTotalFees);
            this.gbRetakeTestInfo.Controls.Add(this.lbRAppFees);
            this.gbRetakeTestInfo.Controls.Add(this.label10);
            this.gbRetakeTestInfo.Controls.Add(this.label9);
            this.gbRetakeTestInfo.Controls.Add(this.label8);
            this.gbRetakeTestInfo.Enabled = false;
            this.gbRetakeTestInfo.Location = new System.Drawing.Point(9, 527);
            this.gbRetakeTestInfo.Name = "gbRetakeTestInfo";
            this.gbRetakeTestInfo.Size = new System.Drawing.Size(720, 130);
            this.gbRetakeTestInfo.TabIndex = 37;
            this.gbRetakeTestInfo.TabStop = false;
            this.gbRetakeTestInfo.Text = "Retake Test Info";
            // 
            // lbRTestAppID
            // 
            this.lbRTestAppID.AutoSize = true;
            this.lbRTestAppID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRTestAppID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbRTestAppID.Location = new System.Drawing.Point(233, 91);
            this.lbRTestAppID.Name = "lbRTestAppID";
            this.lbRTestAppID.Size = new System.Drawing.Size(40, 21);
            this.lbRTestAppID.TabIndex = 41;
            this.lbRTestAppID.Text = "???";
            this.lbRTestAppID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTotalFees
            // 
            this.lbTotalFees.AutoSize = true;
            this.lbTotalFees.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalFees.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTotalFees.Location = new System.Drawing.Point(600, 46);
            this.lbTotalFees.Name = "lbTotalFees";
            this.lbTotalFees.Size = new System.Drawing.Size(21, 21);
            this.lbTotalFees.TabIndex = 41;
            this.lbTotalFees.Text = "0";
            this.lbTotalFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRAppFees
            // 
            this.lbRAppFees.AutoSize = true;
            this.lbRAppFees.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRAppFees.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbRAppFees.Location = new System.Drawing.Point(233, 46);
            this.lbRAppFees.Name = "lbRAppFees";
            this.lbRAppFees.Size = new System.Drawing.Size(21, 21);
            this.lbRAppFees.TabIndex = 38;
            this.lbRAppFees.Text = "0";
            this.lbRAppFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Image = global::DVL.Properties.Resources.money_32___2;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(420, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 45);
            this.label10.TabIndex = 40;
            this.label10.Text = "Total Fees:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = global::DVL.Properties.Resources.Number_32;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(17, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 45);
            this.label9.TabIndex = 39;
            this.label9.Text = "R Test App ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Image = global::DVL.Properties.Resources.money_32;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(17, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 45);
            this.label8.TabIndex = 38;
            this.label8.Text = "R.App Fees:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(246, 399);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(199, 26);
            this.dtpDate.TabIndex = 36;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbName.Location = new System.Drawing.Point(242, 333);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(40, 21);
            this.lbName.TabIndex = 34;
            this.lbName.Text = "???";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFees
            // 
            this.lbFees.AutoSize = true;
            this.lbFees.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFees.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbFees.Location = new System.Drawing.Point(242, 473);
            this.lbFees.Name = "lbFees";
            this.lbFees.Size = new System.Drawing.Size(21, 21);
            this.lbFees.TabIndex = 34;
            this.lbFees.Text = "0";
            this.lbFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDClass
            // 
            this.lbDClass.AutoSize = true;
            this.lbDClass.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDClass.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbDClass.Location = new System.Drawing.Point(242, 263);
            this.lbDClass.Name = "lbDClass";
            this.lbDClass.Size = new System.Drawing.Size(40, 21);
            this.lbDClass.TabIndex = 33;
            this.lbDClass.Text = "???";
            this.lbDClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbID.Location = new System.Drawing.Point(242, 193);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(40, 21);
            this.lbID.TabIndex = 32;
            this.lbID.Text = "???";
            this.lbID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Image = global::DVL.Properties.Resources.money_32;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(26, 461);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 45);
            this.label7.TabIndex = 31;
            this.label7.Text = "Fees:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Image = global::DVL.Properties.Resources.Calendar_32;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(26, 391);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 45);
            this.label6.TabIndex = 30;
            this.label6.Text = "Date:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = global::DVL.Properties.Resources.Person_32;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(26, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 45);
            this.label4.TabIndex = 28;
            this.label4.Text = "Name:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::DVL.Properties.Resources.License_Type_32;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(26, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 45);
            this.label2.TabIndex = 27;
            this.label2.Text = "D. Class";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::DVL.Properties.Resources.Number_32;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(26, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 45);
            this.label3.TabIndex = 26;
            this.label3.Text = "D.L.App ID:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTestType
            // 
            this.lbTestType.AutoSize = true;
            this.lbTestType.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold);
            this.lbTestType.Location = new System.Drawing.Point(289, 120);
            this.lbTestType.Name = "lbTestType";
            this.lbTestType.Size = new System.Drawing.Size(156, 35);
            this.lbTestType.TabIndex = 25;
            this.lbTestType.Text = "Type Test";
            this.lbTestType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(261, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Schedule Test";
            // 
            // frmAddEditTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 830);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbTestType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddTest";
            this.Load += new System.EventHandler(this.frmAddTest_Load);
            this.gbTestType.ResumeLayout(false);
            this.gbTestType.PerformLayout();
            this.gbRetakeTestInfo.ResumeLayout(false);
            this.gbRetakeTestInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbTestType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTestType;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbFees;
        private System.Windows.Forms.Label lbDClass;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.GroupBox gbRetakeTestInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbRTestAppID;
        private System.Windows.Forms.Label lbTotalFees;
        private System.Windows.Forms.Label lbRAppFees;
        private System.Windows.Forms.Button btnSave;
    }
}