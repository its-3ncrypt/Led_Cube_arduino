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
            this.tabs = new System.Windows.Forms.TabControl();
            this.Effecten = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.Effecten_Box = new System.Windows.Forms.CheckedListBox();
            this.Generator = new System.Windows.Forms.TabPage();
            this.Menu.SuspendLayout();
            this.tabs.SuspendLayout();
            this.Effecten.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effectenToolStripMenuItem,
            this.generatorToolStripMenuItem});
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
            // tabs
            // 
            this.tabs.Controls.Add(this.Effecten);
            this.tabs.Controls.Add(this.Generator);
            this.tabs.Location = new System.Drawing.Point(13, 28);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(787, 410);
            this.tabs.TabIndex = 1;
            // 
            // Effecten
            // 
            this.Effecten.Controls.Add(this.label1);
            this.Effecten.Controls.Add(this.Effecten_Box);
            this.Effecten.Location = new System.Drawing.Point(4, 22);
            this.Effecten.Name = "Effecten";
            this.Effecten.Padding = new System.Windows.Forms.Padding(3);
            this.Effecten.Size = new System.Drawing.Size(779, 384);
            this.Effecten.TabIndex = 0;
            this.Effecten.Text = "Effecten";
            this.Effecten.UseVisualStyleBackColor = true;
            this.Effecten.Click += new System.EventHandler(this.Effecten_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Effecten";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Effecten_Box
            // 
            this.Effecten_Box.FormattingEnabled = true;
            this.Effecten_Box.Items.AddRange(new object[] {
            "Effect 1",
            "Effect 2",
            "Effect 3",
            "Effect 4",
            "Effect 5",
            "Effect 6",
            "Effect 7",
            "Effect 8",
            "Effect 9",
            "Effect 10"});
            this.Effecten_Box.Location = new System.Drawing.Point(6, 26);
            this.Effecten_Box.Name = "Effecten_Box";
            this.Effecten_Box.Size = new System.Drawing.Size(120, 349);
            this.Effecten_Box.TabIndex = 0;
            this.Effecten_Box.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // Generator
            // 
            this.Generator.Location = new System.Drawing.Point(4, 22);
            this.Generator.Name = "Generator";
            this.Generator.Padding = new System.Windows.Forms.Padding(3);
            this.Generator.Size = new System.Drawing.Size(779, 384);
            this.Generator.TabIndex = 1;
            this.Generator.Text = "Effecten Generator";
            this.Generator.UseVisualStyleBackColor = true;
            this.Generator.Click += new System.EventHandler(this.Generator_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "Form1";
            this.Text = "Led Cube Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.Effecten.ResumeLayout(false);
            this.Effecten.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem effectenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatorToolStripMenuItem;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage Effecten;
        private System.Windows.Forms.TabPage Generator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox Effecten_Box;
    }
}

