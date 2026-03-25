namespace Camps.Forms
{
    partial class ContractsControl
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
            this.GvContracts = new System.Windows.Forms.DataGridView();
            this.BtnSaveToCSV = new System.Windows.Forms.Button();
            this.BtnExecSql = new System.Windows.Forms.Button();
            this.Rt_sql = new System.Windows.Forms.RichTextBox();
            this.BtnSaveXls = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GvContracts)).BeginInit();
            this.SuspendLayout();
            // 
            // GvContracts
            // 
            this.GvContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvContracts.Location = new System.Drawing.Point(3, 66);
            this.GvContracts.Name = "GvContracts";
            this.GvContracts.Size = new System.Drawing.Size(783, 267);
            this.GvContracts.TabIndex = 0;
            this.GvContracts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvContracts_CellContentClick);
            // 
            // BtnSaveToCSV
            // 
            this.BtnSaveToCSV.Location = new System.Drawing.Point(3, 37);
            this.BtnSaveToCSV.Name = "BtnSaveToCSV";
            this.BtnSaveToCSV.Size = new System.Drawing.Size(99, 23);
            this.BtnSaveToCSV.TabIndex = 1;
            this.BtnSaveToCSV.Text = "Save to CSV";
            this.BtnSaveToCSV.UseVisualStyleBackColor = true;
            this.BtnSaveToCSV.Click += new System.EventHandler(this.BtnSaveToCSV_Click);
            // 
            // BtnExecSql
            // 
            this.BtnExecSql.Location = new System.Drawing.Point(377, 37);
            this.BtnExecSql.Name = "BtnExecSql";
            this.BtnExecSql.Size = new System.Drawing.Size(99, 23);
            this.BtnExecSql.TabIndex = 2;
            this.BtnExecSql.Text = "Get SQL data";
            this.BtnExecSql.UseVisualStyleBackColor = true;
            this.BtnExecSql.Click += new System.EventHandler(this.BtnExecSql_Click);
            // 
            // Rt_sql
            // 
            this.Rt_sql.Location = new System.Drawing.Point(482, 3);
            this.Rt_sql.Name = "Rt_sql";
            this.Rt_sql.Size = new System.Drawing.Size(304, 57);
            this.Rt_sql.TabIndex = 3;
            this.Rt_sql.Text = "";
            // 
            // BtnSaveXls
            // 
            this.BtnSaveXls.Location = new System.Drawing.Point(3, 8);
            this.BtnSaveXls.Name = "BtnSaveXls";
            this.BtnSaveXls.Size = new System.Drawing.Size(99, 23);
            this.BtnSaveXls.TabIndex = 4;
            this.BtnSaveXls.Text = "Save to XLS";
            this.BtnSaveXls.UseVisualStyleBackColor = true;
            // 
            // ContractsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnSaveXls);
            this.Controls.Add(this.Rt_sql);
            this.Controls.Add(this.BtnExecSql);
            this.Controls.Add(this.BtnSaveToCSV);
            this.Controls.Add(this.GvContracts);
            this.Name = "ContractsControl";
            this.Size = new System.Drawing.Size(789, 336);
            ((System.ComponentModel.ISupportInitialize)(this.GvContracts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GvContracts;
        private System.Windows.Forms.Button BtnSaveToCSV;
        private System.Windows.Forms.Button BtnExecSql;
        private System.Windows.Forms.RichTextBox Rt_sql;
        private System.Windows.Forms.Button BtnSaveXls;
    }
}
