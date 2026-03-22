namespace Camps.Forms
{
    partial class CustomersControl
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
            this.GvSheetData = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GvParticipiants = new System.Windows.Forms.DataGridView();
            this.GvParentDetails = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CbParent = new System.Windows.Forms.ComboBox();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.TxtPhone = new System.Windows.Forms.TextBox();
            this.TxtParentSurname = new System.Windows.Forms.TextBox();
            this.TxtParentName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CbGender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbBirthYear = new System.Windows.Forms.ComboBox();
            this.CbCamp = new System.Windows.Forms.ComboBox();
            this.TxtChildSurname = new System.Windows.Forms.TextBox();
            this.LblCamp = new System.Windows.Forms.Label();
            this.TxtChildName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LblAddOtherParent = new System.Windows.Forms.Label();
            this.CbParent2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtParentSur2 = new System.Windows.Forms.TextBox();
            this.TxtParentName2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtPhone2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GvSheetData)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvParticipiants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvParentDetails)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GvSheetData
            // 
            this.GvSheetData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvSheetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvSheetData.Location = new System.Drawing.Point(0, 0);
            this.GvSheetData.Name = "GvSheetData";
            this.GvSheetData.Size = new System.Drawing.Size(1136, 81);
            this.GvSheetData.TabIndex = 0;
            this.GvSheetData.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GvSheetData_RowHeaderMouseClick);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1150, 330);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1142, 304);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Participiant information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GvParticipiants);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GvParentDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1136, 298);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 0;
            // 
            // GvParticipiants
            // 
            this.GvParticipiants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvParticipiants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvParticipiants.Location = new System.Drawing.Point(3, 3);
            this.GvParticipiants.Name = "GvParticipiants";
            this.GvParticipiants.Size = new System.Drawing.Size(1130, 188);
            this.GvParticipiants.TabIndex = 0;
            // 
            // GvParentDetails
            // 
            this.GvParentDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvParentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvParentDetails.Location = new System.Drawing.Point(3, 3);
            this.GvParentDetails.Name = "GvParentDetails";
            this.GvParentDetails.Size = new System.Drawing.Size(1130, 94);
            this.GvParentDetails.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1142, 304);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Incoming requests";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.GvSheetData);
            this.splitContainer2.Panel1.UseWaitCursor = true;
            this.splitContainer2.Panel1MinSize = 30;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label14);
            this.splitContainer2.Panel2.Controls.Add(this.TxtPhone2);
            this.splitContainer2.Panel2.Controls.Add(this.label12);
            this.splitContainer2.Panel2.Controls.Add(this.label13);
            this.splitContainer2.Panel2.Controls.Add(this.TxtParentSur2);
            this.splitContainer2.Panel2.Controls.Add(this.TxtParentName2);
            this.splitContainer2.Panel2.Controls.Add(this.label11);
            this.splitContainer2.Panel2.Controls.Add(this.CbParent2);
            this.splitContainer2.Panel2.Controls.Add(this.LblAddOtherParent);
            this.splitContainer2.Panel2.Controls.Add(this.BtnSave);
            this.splitContainer2.Panel2.Controls.Add(this.TxtEmail);
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Panel2.Controls.Add(this.label9);
            this.splitContainer2.Panel2.Controls.Add(this.label8);
            this.splitContainer2.Panel2.Controls.Add(this.label7);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.CbParent);
            this.splitContainer2.Panel2.Controls.Add(this.TxtAddress);
            this.splitContainer2.Panel2.Controls.Add(this.TxtPhone);
            this.splitContainer2.Panel2.Controls.Add(this.TxtParentSurname);
            this.splitContainer2.Panel2.Controls.Add(this.TxtParentName);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.CbGender);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.CbBirthYear);
            this.splitContainer2.Panel2.Controls.Add(this.CbCamp);
            this.splitContainer2.Panel2.Controls.Add(this.TxtChildSurname);
            this.splitContainer2.Panel2.Controls.Add(this.LblCamp);
            this.splitContainer2.Panel2.Controls.Add(this.TxtChildName);
            this.splitContainer2.Size = new System.Drawing.Size(1136, 298);
            this.splitContainer2.SplitterDistance = 81;
            this.splitContainer2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(616, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Parent surname";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Parent name";
            // 
            // CbParent
            // 
            this.CbParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CbParent.FormattingEnabled = true;
            this.CbParent.Location = new System.Drawing.Point(377, 52);
            this.CbParent.Name = "CbParent";
            this.CbParent.Size = new System.Drawing.Size(80, 21);
            this.CbParent.TabIndex = 15;
            // 
            // TxtAddress
            // 
            this.TxtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtAddress.Location = new System.Drawing.Point(377, 139);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(340, 20);
            this.TxtAddress.TabIndex = 14;
            // 
            // TxtPhone
            // 
            this.TxtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtPhone.Location = new System.Drawing.Point(377, 95);
            this.TxtPhone.Name = "TxtPhone";
            this.TxtPhone.Size = new System.Drawing.Size(129, 20);
            this.TxtPhone.TabIndex = 13;
            // 
            // TxtParentSurname
            // 
            this.TxtParentSurname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtParentSurname.Location = new System.Drawing.Point(619, 53);
            this.TxtParentSurname.Name = "TxtParentSurname";
            this.TxtParentSurname.Size = new System.Drawing.Size(125, 20);
            this.TxtParentSurname.TabIndex = 12;
            // 
            // TxtParentName
            // 
            this.TxtParentName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtParentName.Location = new System.Drawing.Point(474, 53);
            this.TxtParentName.Name = "TxtParentName";
            this.TxtParentName.Size = new System.Drawing.Size(125, 20);
            this.TxtParentName.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Birth year";
            // 
            // CbGender
            // 
            this.CbGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CbGender.FormattingEnabled = true;
            this.CbGender.Location = new System.Drawing.Point(15, 182);
            this.CbGender.Name = "CbGender";
            this.CbGender.Size = new System.Drawing.Size(73, 21);
            this.CbGender.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Gender";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Childs surname";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Childs name";
            // 
            // CbBirthYear
            // 
            this.CbBirthYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CbBirthYear.FormattingEnabled = true;
            this.CbBirthYear.Location = new System.Drawing.Point(103, 182);
            this.CbBirthYear.Name = "CbBirthYear";
            this.CbBirthYear.Size = new System.Drawing.Size(73, 21);
            this.CbBirthYear.TabIndex = 5;
            // 
            // CbCamp
            // 
            this.CbCamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CbCamp.FormattingEnabled = true;
            this.CbCamp.Location = new System.Drawing.Point(15, 53);
            this.CbCamp.Name = "CbCamp";
            this.CbCamp.Size = new System.Drawing.Size(161, 21);
            this.CbCamp.TabIndex = 4;
            // 
            // TxtChildSurname
            // 
            this.TxtChildSurname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtChildSurname.Location = new System.Drawing.Point(147, 139);
            this.TxtChildSurname.Name = "TxtChildSurname";
            this.TxtChildSurname.Size = new System.Drawing.Size(126, 20);
            this.TxtChildSurname.TabIndex = 2;
            // 
            // LblCamp
            // 
            this.LblCamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblCamp.AutoSize = true;
            this.LblCamp.Location = new System.Drawing.Point(12, 37);
            this.LblCamp.Name = "LblCamp";
            this.LblCamp.Size = new System.Drawing.Size(75, 13);
            this.LblCamp.TabIndex = 1;
            this.LblCamp.Text = "Select a camp";
            // 
            // TxtChildName
            // 
            this.TxtChildName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtChildName.Location = new System.Drawing.Point(15, 139);
            this.TxtChildName.Name = "TxtChildName";
            this.TxtChildName.Size = new System.Drawing.Size(126, 20);
            this.TxtChildName.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(374, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Parent";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(520, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Email";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(374, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Phone";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(374, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Address";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtEmail.Location = new System.Drawing.Point(523, 95);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(221, 20);
            this.TxtEmail.TabIndex = 23;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSave.Location = new System.Drawing.Point(443, 180);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(224, 23);
            this.BtnSave.TabIndex = 24;
            this.BtnSave.Text = "Open contract";
            this.BtnSave.UseVisualStyleBackColor = true;
            // 
            // LblAddOtherParent
            // 
            this.LblAddOtherParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblAddOtherParent.AutoSize = true;
            this.LblAddOtherParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAddOtherParent.Location = new System.Drawing.Point(723, 139);
            this.LblAddOtherParent.Name = "LblAddOtherParent";
            this.LblAddOtherParent.Size = new System.Drawing.Size(21, 24);
            this.LblAddOtherParent.TabIndex = 25;
            this.LblAddOtherParent.Text = "+";
            // 
            // CbParent2
            // 
            this.CbParent2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CbParent2.FormattingEnabled = true;
            this.CbParent2.Location = new System.Drawing.Point(839, 52);
            this.CbParent2.Name = "CbParent2";
            this.CbParent2.Size = new System.Drawing.Size(80, 21);
            this.CbParent2.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(836, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Parent";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(981, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Parent surname";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(836, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Parent name";
            // 
            // TxtParentSur2
            // 
            this.TxtParentSur2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtParentSur2.Location = new System.Drawing.Point(984, 95);
            this.TxtParentSur2.Name = "TxtParentSur2";
            this.TxtParentSur2.Size = new System.Drawing.Size(125, 20);
            this.TxtParentSur2.TabIndex = 29;
            // 
            // TxtParentName2
            // 
            this.TxtParentName2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtParentName2.Location = new System.Drawing.Point(839, 95);
            this.TxtParentName2.Name = "TxtParentName2";
            this.TxtParentName2.Size = new System.Drawing.Size(125, 20);
            this.TxtParentName2.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(836, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Phone";
            // 
            // TxtPhone2
            // 
            this.TxtPhone2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtPhone2.Location = new System.Drawing.Point(839, 139);
            this.TxtPhone2.Name = "TxtPhone2";
            this.TxtPhone2.Size = new System.Drawing.Size(129, 20);
            this.TxtPhone2.TabIndex = 32;
            // 
            // CustomersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.tabControl);
            this.Name = "CustomersControl";
            this.Size = new System.Drawing.Size(1156, 336);
            ((System.ComponentModel.ISupportInitialize)(this.GvSheetData)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GvParticipiants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvParentDetails)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GvSheetData;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView GvParticipiants;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView GvParentDetails;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox CbBirthYear;
        private System.Windows.Forms.ComboBox CbCamp;
        private System.Windows.Forms.TextBox TxtChildSurname;
        private System.Windows.Forms.Label LblCamp;
        private System.Windows.Forms.TextBox TxtChildName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbGender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TextBox TxtPhone;
        private System.Windows.Forms.TextBox TxtParentSurname;
        private System.Windows.Forms.TextBox TxtParentName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbParent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label LblAddOtherParent;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtPhone2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtParentSur2;
        private System.Windows.Forms.TextBox TxtParentName2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox CbParent2;
    }
}
