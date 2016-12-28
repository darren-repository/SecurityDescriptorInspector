namespace SecurityDescriptorInspector
{
    partial class frmMain
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
            this.pnlFileSystem = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvFolders = new System.Windows.Forms.TreeView();
            this.livFiles = new System.Windows.Forms.ListView();
            this.txtSecurity = new System.Windows.Forms.TextBox();
            this.pnlFileSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFileSystem
            // 
            this.pnlFileSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFileSystem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFileSystem.Controls.Add(this.splitContainer1);
            this.pnlFileSystem.Location = new System.Drawing.Point(12, 112);
            this.pnlFileSystem.Name = "pnlFileSystem";
            this.pnlFileSystem.Size = new System.Drawing.Size(973, 372);
            this.pnlFileSystem.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvFolders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.livFiles);
            this.splitContainer1.Size = new System.Drawing.Size(969, 368);
            this.splitContainer1.SplitterDistance = 349;
            this.splitContainer1.TabIndex = 0;
            // 
            // trvFolders
            // 
            this.trvFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvFolders.Location = new System.Drawing.Point(3, 3);
            this.trvFolders.Name = "trvFolders";
            this.trvFolders.Size = new System.Drawing.Size(343, 362);
            this.trvFolders.TabIndex = 0;
            this.trvFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvFolders_BeforeExpand);
            this.trvFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvFolders_AfterSelect);
            // 
            // livFiles
            // 
            this.livFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.livFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livFiles.Location = new System.Drawing.Point(3, 3);
            this.livFiles.MultiSelect = false;
            this.livFiles.Name = "livFiles";
            this.livFiles.Size = new System.Drawing.Size(610, 362);
            this.livFiles.TabIndex = 0;
            this.livFiles.UseCompatibleStateImageBehavior = false;
            this.livFiles.View = System.Windows.Forms.View.List;
            this.livFiles.SelectedIndexChanged += new System.EventHandler(this.livFiles_SelectedIndexChanged);
            // 
            // txtSecurity
            // 
            this.txtSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecurity.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtSecurity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSecurity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecurity.ForeColor = System.Drawing.SystemColors.Info;
            this.txtSecurity.Location = new System.Drawing.Point(12, 12);
            this.txtSecurity.Multiline = true;
            this.txtSecurity.Name = "txtSecurity";
            this.txtSecurity.ReadOnly = true;
            this.txtSecurity.Size = new System.Drawing.Size(971, 94);
            this.txtSecurity.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 496);
            this.Controls.Add(this.txtSecurity);
            this.Controls.Add(this.pnlFileSystem);
            this.Name = "frmMain";
            this.Text = "Security Descriptor Inspector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlFileSystem.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFileSystem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvFolders;
        private System.Windows.Forms.ListView livFiles;
        private System.Windows.Forms.TextBox txtSecurity;
    }
}

