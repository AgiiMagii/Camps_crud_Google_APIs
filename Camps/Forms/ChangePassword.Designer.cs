namespace Camps.Forms
{
    partial class ChangePassword
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
            this.TxtNewPassword = new System.Windows.Forms.TextBox();
            this.TxtConfirmNew = new System.Windows.Forms.TextBox();
            this.BtnSavePass = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtNewPassword
            // 
            this.TxtNewPassword.Location = new System.Drawing.Point(48, 39);
            this.TxtNewPassword.Name = "TxtNewPassword";
            this.TxtNewPassword.Size = new System.Drawing.Size(163, 20);
            this.TxtNewPassword.TabIndex = 0;
            this.TxtNewPassword.UseSystemPasswordChar = true;
            // 
            // TxtConfirmNew
            // 
            this.TxtConfirmNew.Location = new System.Drawing.Point(48, 85);
            this.TxtConfirmNew.Name = "TxtConfirmNew";
            this.TxtConfirmNew.Size = new System.Drawing.Size(163, 20);
            this.TxtConfirmNew.TabIndex = 1;
            this.TxtConfirmNew.UseSystemPasswordChar = true;
            // 
            // BtnSavePass
            // 
            this.BtnSavePass.Location = new System.Drawing.Point(92, 128);
            this.BtnSavePass.Name = "BtnSavePass";
            this.BtnSavePass.Size = new System.Drawing.Size(75, 23);
            this.BtnSavePass.TabIndex = 2;
            this.BtnSavePass.Text = "Save";
            this.BtnSavePass.UseVisualStyleBackColor = true;
            this.BtnSavePass.Click += new System.EventHandler(this.BtnSavePass_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "New password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Confirm new password";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 167);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSavePass);
            this.Controls.Add(this.TxtConfirmNew);
            this.Controls.Add(this.TxtNewPassword);
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNewPassword;
        private System.Windows.Forms.TextBox TxtConfirmNew;
        private System.Windows.Forms.Button BtnSavePass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}