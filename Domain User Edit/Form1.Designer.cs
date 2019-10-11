namespace Domain_User_Edit
{
    partial class Form1
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnGetUser = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.chkbxUnlock = new System.Windows.Forms.CheckBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblChangePassword = new System.Windows.Forms.Label();
            this.lblChangePassword2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblIsLocked = new System.Windows.Forms.Label();
            this.lnklblHelp = new System.Windows.Forms.LinkLabel();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tssMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // btnGetUser
            // 
            this.btnGetUser.Location = new System.Drawing.Point(118, 10);
            this.btnGetUser.Name = "btnGetUser";
            this.btnGetUser.Size = new System.Drawing.Size(75, 23);
            this.btnGetUser.TabIndex = 1;
            this.btnGetUser.Text = "Get user";
            this.btnGetUser.UseVisualStyleBackColor = true;
            this.btnGetUser.Click += new System.EventHandler(this.btnGetUser_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 35);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(65, 13);
            this.lblUser.TabIndex = 10;
            this.lblUser.Text = "lblUsername";
            // 
            // chkbxUnlock
            // 
            this.chkbxUnlock.AutoSize = true;
            this.chkbxUnlock.Checked = true;
            this.chkbxUnlock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxUnlock.Enabled = false;
            this.chkbxUnlock.Location = new System.Drawing.Point(12, 51);
            this.chkbxUnlock.Name = "chkbxUnlock";
            this.chkbxUnlock.Size = new System.Drawing.Size(83, 17);
            this.chkbxUnlock.TabIndex = 2;
            this.chkbxUnlock.Text = "Unlock user";
            this.chkbxUnlock.UseVisualStyleBackColor = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Enabled = false;
            this.txtNewPassword.Location = new System.Drawing.Point(12, 74);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(100, 20);
            this.txtNewPassword.TabIndex = 4;
            // 
            // lblChangePassword
            // 
            this.lblChangePassword.AutoSize = true;
            this.lblChangePassword.Location = new System.Drawing.Point(118, 74);
            this.lblChangePassword.Name = "lblChangePassword";
            this.lblChangePassword.Size = new System.Drawing.Size(77, 13);
            this.lblChangePassword.TabIndex = 5;
            this.lblChangePassword.Text = "New password";
            // 
            // lblChangePassword2
            // 
            this.lblChangePassword2.AutoSize = true;
            this.lblChangePassword2.Location = new System.Drawing.Point(118, 87);
            this.lblChangePassword2.Name = "lblChangePassword2";
            this.lblChangePassword2.Size = new System.Drawing.Size(137, 13);
            this.lblChangePassword2.TabIndex = 6;
            this.lblChangePassword2.Text = "(leave blank to not change)";
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(12, 100);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(83, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Run changes";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblIsLocked
            // 
            this.lblIsLocked.AutoSize = true;
            this.lblIsLocked.Location = new System.Drawing.Point(118, 52);
            this.lblIsLocked.Name = "lblIsLocked";
            this.lblIsLocked.Size = new System.Drawing.Size(61, 13);
            this.lblIsLocked.TabIndex = 9;
            this.lblIsLocked.Text = "lblIsLocked";
            // 
            // lnklblHelp
            // 
            this.lnklblHelp.AutoSize = true;
            this.lnklblHelp.LinkColor = System.Drawing.Color.Black;
            this.lnklblHelp.Location = new System.Drawing.Point(242, 9);
            this.lnklblHelp.Name = "lnklblHelp";
            this.lnklblHelp.Size = new System.Drawing.Size(13, 13);
            this.lnklblHelp.TabIndex = 10;
            this.lnklblHelp.TabStop = true;
            this.lnklblHelp.Text = "?";
            this.lnklblHelp.Click += new System.EventHandler(this.lnklblHelp_Click);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssMain});
            this.ssMain.Location = new System.Drawing.Point(0, 129);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(259, 22);
            this.ssMain.SizingGrip = false;
            this.ssMain.TabIndex = 12;
            this.ssMain.Text = "statusStrip1";
            // 
            // tssMain
            // 
            this.tssMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssMain.Name = "tssMain";
            this.tssMain.Size = new System.Drawing.Size(48, 17);
            this.tssMain.Text = "tssMain";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 151);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.lnklblHelp);
            this.Controls.Add(this.lblIsLocked);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblChangePassword2);
            this.Controls.Add(this.lblChangePassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.chkbxUnlock);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnGetUser);
            this.Controls.Add(this.txtUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Domain User Edit";
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnGetUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.CheckBox chkbxUnlock;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblChangePassword;
        private System.Windows.Forms.Label lblChangePassword2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblIsLocked;
        private System.Windows.Forms.LinkLabel lnklblHelp;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel tssMain;
    }
}

