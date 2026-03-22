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
            // ContractsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GvContracts);
            this.Name = "ContractsControl";
            this.Size = new System.Drawing.Size(789, 336);
            ((System.ComponentModel.ISupportInitialize)(this.GvContracts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GvContracts;
    }
}
