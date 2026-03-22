namespace Camps.Forms
{
    partial class AddCamp
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
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.TxtZipcode = new System.Windows.Forms.TextBox();
            this.Txtname = new System.Windows.Forms.TextBox();
            this.CbCountry = new System.Windows.Forms.ComboBox();
            this.GbAddress = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CbCity = new System.Windows.Forms.ComboBox();
            this.CbRegion = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.NumCapacity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDesc = new System.Windows.Forms.RichTextBox();
            this.TxtCampName = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.CbExisting = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LblEditAddress = new System.Windows.Forms.Label();
            this.TtEdit = new System.Windows.Forms.ToolTip(this.components);
            this.GbAddress.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtAddress
            // 
            this.TxtAddress.Location = new System.Drawing.Point(36, 164);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(163, 20);
            this.TxtAddress.TabIndex = 0;
            // 
            // TxtZipcode
            // 
            this.TxtZipcode.Location = new System.Drawing.Point(36, 203);
            this.TxtZipcode.Name = "TxtZipcode";
            this.TxtZipcode.Size = new System.Drawing.Size(163, 20);
            this.TxtZipcode.TabIndex = 3;
            // 
            // Txtname
            // 
            this.Txtname.Location = new System.Drawing.Point(31, 49);
            this.Txtname.Name = "Txtname";
            this.Txtname.Size = new System.Drawing.Size(213, 20);
            this.Txtname.TabIndex = 4;
            // 
            // CbCountry
            // 
            this.CbCountry.FormattingEnabled = true;
            this.CbCountry.Location = new System.Drawing.Point(36, 43);
            this.CbCountry.Name = "CbCountry";
            this.CbCountry.Size = new System.Drawing.Size(163, 21);
            this.CbCountry.TabIndex = 5;
            // 
            // GbAddress
            // 
            this.GbAddress.Controls.Add(this.label5);
            this.GbAddress.Controls.Add(this.label4);
            this.GbAddress.Controls.Add(this.label3);
            this.GbAddress.Controls.Add(this.TxtZipcode);
            this.GbAddress.Controls.Add(this.label2);
            this.GbAddress.Controls.Add(this.TxtAddress);
            this.GbAddress.Controls.Add(this.label1);
            this.GbAddress.Controls.Add(this.CbCity);
            this.GbAddress.Controls.Add(this.CbRegion);
            this.GbAddress.Controls.Add(this.CbCountry);
            this.GbAddress.Location = new System.Drawing.Point(21, 57);
            this.GbAddress.Name = "GbAddress";
            this.GbAddress.Size = new System.Drawing.Size(231, 255);
            this.GbAddress.TabIndex = 6;
            this.GbAddress.TabStop = false;
            this.GbAddress.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Zip code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "City";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Region";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Country";
            // 
            // CbCity
            // 
            this.CbCity.FormattingEnabled = true;
            this.CbCity.Location = new System.Drawing.Point(36, 122);
            this.CbCity.Name = "CbCity";
            this.CbCity.Size = new System.Drawing.Size(163, 21);
            this.CbCity.TabIndex = 7;
            // 
            // CbRegion
            // 
            this.CbRegion.FormattingEnabled = true;
            this.CbRegion.Location = new System.Drawing.Point(36, 82);
            this.CbRegion.Name = "CbRegion";
            this.CbRegion.Size = new System.Drawing.Size(163, 21);
            this.CbRegion.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.NumCapacity);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TxtDesc);
            this.groupBox2.Controls.Add(this.TxtCampName);
            this.groupBox2.Controls.Add(this.Txtname);
            this.groupBox2.Location = new System.Drawing.Point(272, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 288);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camp Information";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(109, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Capacity";
            // 
            // NumCapacity
            // 
            this.NumCapacity.Location = new System.Drawing.Point(163, 87);
            this.NumCapacity.Name = "NumCapacity";
            this.NumCapacity.Size = new System.Drawing.Size(81, 20);
            this.NumCapacity.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Descriptopn";
            // 
            // TxtDesc
            // 
            this.TxtDesc.Location = new System.Drawing.Point(31, 132);
            this.TxtDesc.Name = "TxtDesc";
            this.TxtDesc.Size = new System.Drawing.Size(213, 131);
            this.TxtDesc.TabIndex = 6;
            this.TxtDesc.Text = "";
            // 
            // TxtCampName
            // 
            this.TxtCampName.AutoSize = true;
            this.TxtCampName.Location = new System.Drawing.Point(28, 33);
            this.TxtCampName.Name = "TxtCampName";
            this.TxtCampName.Size = new System.Drawing.Size(63, 13);
            this.TxtCampName.TabIndex = 5;
            this.TxtCampName.Text = "Camp name";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(180, 329);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(183, 23);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // CbExisting
            // 
            this.CbExisting.FormattingEnabled = true;
            this.CbExisting.Location = new System.Drawing.Point(89, 30);
            this.CbExisting.Name = "CbExisting";
            this.CbExisting.Size = new System.Drawing.Size(163, 21);
            this.CbExisting.TabIndex = 14;
            this.CbExisting.SelectedIndexChanged += new System.EventHandler(this.CbExisting_SelectedIndexChanged);
            this.CbExisting.TextChanged += new System.EventHandler(this.CbExisting_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(86, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Choose address";
            // 
            // LblEditAddress
            // 
            this.LblEditAddress.AutoSize = true;
            this.LblEditAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEditAddress.Location = new System.Drawing.Point(58, 29);
            this.LblEditAddress.Name = "LblEditAddress";
            this.LblEditAddress.Size = new System.Drawing.Size(26, 18);
            this.LblEditAddress.TabIndex = 16;
            this.LblEditAddress.Text = "✏️";
            this.LblEditAddress.Click += new System.EventHandler(this.LblEditAddress_Click);
            // 
            // AddCamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 373);
            this.Controls.Add(this.LblEditAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.CbExisting);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GbAddress);
            this.Name = "AddCamp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCamp";
            this.Load += new System.EventHandler(this.AddCamp_Load);
            this.GbAddress.ResumeLayout(false);
            this.GbAddress.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TextBox TxtZipcode;
        private System.Windows.Forms.TextBox Txtname;
        private System.Windows.Forms.ComboBox CbCountry;
        private System.Windows.Forms.GroupBox GbAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbCity;
        private System.Windows.Forms.ComboBox CbRegion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox TxtDesc;
        private System.Windows.Forms.Label TxtCampName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NumCapacity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CbExisting;
        private System.Windows.Forms.Label LblEditAddress;
        private System.Windows.Forms.ToolTip TtEdit;
    }
}