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
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.effectenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geavanceerdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effectenToolStripMenuItem,
            this.generatorToolStripMenuItem,
            this.geavanceerdToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(800, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // effectenToolStripMenuItem
            // 
            this.effectenToolStripMenuItem.Name = "effectenToolStripMenuItem";
            this.effectenToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.effectenToolStripMenuItem.Text = "Menu";
            this.effectenToolStripMenuItem.Click += new System.EventHandler(this.effectenToolStripMenuItem_Click);
            // 
            // generatorToolStripMenuItem
            // 
            this.generatorToolStripMenuItem.Name = "generatorToolStripMenuItem";
            this.generatorToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.generatorToolStripMenuItem.Text = "Verbind";
            this.generatorToolStripMenuItem.Click += new System.EventHandler(this.generatorToolStripMenuItem_Click);
            // 
            // geavanceerdToolStripMenuItem
            // 
            this.geavanceerdToolStripMenuItem.Name = "geavanceerdToolStripMenuItem";
            this.geavanceerdToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.geavanceerdToolStripMenuItem.Text = "Geavanceerd";
            this.geavanceerdToolStripMenuItem.Click += new System.EventHandler(this.geavanceerdToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem effectenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geavanceerdToolStripMenuItem;
    }
}

