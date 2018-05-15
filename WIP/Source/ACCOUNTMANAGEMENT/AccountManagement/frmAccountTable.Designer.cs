namespace AccountManagement
{
    partial class frmAccountTable
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
            this.dgvAccountTbl = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTbl)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAccountTbl
            // 
            this.dgvAccountTbl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAccountTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountTbl.Location = new System.Drawing.Point(71, 21);
            this.dgvAccountTbl.MultiSelect = false;
            this.dgvAccountTbl.Name = "dgvAccountTbl";
            this.dgvAccountTbl.ReadOnly = true;
            this.dgvAccountTbl.RowHeadersVisible = false;
            this.dgvAccountTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccountTbl.Size = new System.Drawing.Size(532, 254);
            this.dgvAccountTbl.TabIndex = 101;
            // 
            // frmAccountTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 340);
            this.Controls.Add(this.dgvAccountTbl);
            this.MaximizeBox = false;
            this.Name = "frmAccountTable";
            this.Text = "Account Table";
            this.Load += new System.EventHandler(this.frmAccountTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTbl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvAccountTbl;
    }
}