namespace Aansturingsprogramma
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.basisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geavanceerdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systeemtechnischToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.basisToolStripMenuItem,
            this.geavanceerdToolStripMenuItem,
            this.systeemtechnischToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(914, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Effect 1",
            "Effect 2"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 27);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(162, 274);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // basisToolStripMenuItem
            // 
            this.basisToolStripMenuItem.Name = "basisToolStripMenuItem";
            this.basisToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.basisToolStripMenuItem.Text = "Basis";
            // 
            // geavanceerdToolStripMenuItem
            // 
            this.geavanceerdToolStripMenuItem.Name = "geavanceerdToolStripMenuItem";
            this.geavanceerdToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.geavanceerdToolStripMenuItem.Text = "Geavanceerd";
            this.geavanceerdToolStripMenuItem.Click += new System.EventHandler(this.geavanceerdToolStripMenuItem_Click);
            // 
            // systeemtechnischToolStripMenuItem
            // 
            this.systeemtechnischToolStripMenuItem.Name = "systeemtechnischToolStripMenuItem";
            this.systeemtechnischToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.systeemtechnischToolStripMenuItem.Text = "Systeemtechnisch";
            this.systeemtechnischToolStripMenuItem.Click += new System.EventHandler(this.systeemtechnischToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 517);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ToolStripMenuItem basisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geavanceerdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systeemtechnischToolStripMenuItem;
    }
}

