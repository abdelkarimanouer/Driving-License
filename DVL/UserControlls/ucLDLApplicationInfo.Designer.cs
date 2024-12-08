namespace DVL.UserControlls
{
    partial class ucLDLApplicationInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucApplicationBasicInfo1 = new DVL.UserControlls.ucApplicationBasicInfo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPassedTests = new System.Windows.Forms.Label();
            this.lbClassName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDLAppID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucApplicationBasicInfo1
            // 
            this.ucApplicationBasicInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucApplicationBasicInfo1.Location = new System.Drawing.Point(0, 139);
            this.ucApplicationBasicInfo1.Name = "ucApplicationBasicInfo1";
            this.ucApplicationBasicInfo1.Size = new System.Drawing.Size(903, 255);
            this.ucApplicationBasicInfo1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPassedTests);
            this.groupBox1.Controls.Add(this.lbClassName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbDLAppID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(903, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driving License Application Info";
            // 
            // lbPassedTests
            // 
            this.lbPassedTests.AutoSize = true;
            this.lbPassedTests.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassedTests.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbPassedTests.Location = new System.Drawing.Point(540, 83);
            this.lbPassedTests.Name = "lbPassedTests";
            this.lbPassedTests.Size = new System.Drawing.Size(21, 21);
            this.lbPassedTests.TabIndex = 11;
            this.lbPassedTests.Text = "0";
            this.lbPassedTests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbClassName
            // 
            this.lbClassName.AutoSize = true;
            this.lbClassName.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClassName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbClassName.Location = new System.Drawing.Point(540, 38);
            this.lbClassName.Name = "lbClassName";
            this.lbClassName.Size = new System.Drawing.Size(40, 21);
            this.lbClassName.TabIndex = 12;
            this.lbClassName.Text = "???";
            this.lbClassName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(555, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "/ 3";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::DVL.Properties.Resources.PassedTests_32;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(347, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 45);
            this.label3.TabIndex = 9;
            this.label3.Text = "Passed Tests:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::DVL.Properties.Resources.License_Type_32;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(304, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 45);
            this.label2.TabIndex = 8;
            this.label2.Text = "Applied for License:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDLAppID
            // 
            this.lbDLAppID.AutoSize = true;
            this.lbDLAppID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDLAppID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbDLAppID.Location = new System.Drawing.Point(198, 38);
            this.lbDLAppID.Name = "lbDLAppID";
            this.lbDLAppID.Size = new System.Drawing.Size(40, 21);
            this.lbDLAppID.TabIndex = 7;
            this.lbDLAppID.Text = "???";
            this.lbDLAppID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::DVL.Properties.Resources.Number_32;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 45);
            this.label1.TabIndex = 6;
            this.label1.Text = "D.L.App ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucLDLApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucApplicationBasicInfo1);
            this.Name = "ucLDLApplicationInfo";
            this.Size = new System.Drawing.Size(903, 394);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucApplicationBasicInfo ucApplicationBasicInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbDLAppID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPassedTests;
        private System.Windows.Forms.Label lbClassName;
        private System.Windows.Forms.Label label4;
    }
}
