namespace MyAssignmentBugTrack.Programmer
{
    partial class ProgHomePage
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
            this.reportBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBugReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSolutionsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchABugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportBugToolStripMenuItem,
            this.viewBugReportToolStripMenuItem,
            this.viewSolutionsReportToolStripMenuItem,
            this.searchABugToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportBugToolStripMenuItem
            // 
            this.reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            this.reportBugToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.reportBugToolStripMenuItem.Text = "Report a Bug";
            this.reportBugToolStripMenuItem.Click += new System.EventHandler(this.reportBugToolStripMenuItem_Click);
            // 
            // viewBugReportToolStripMenuItem
            // 
            this.viewBugReportToolStripMenuItem.Name = "viewBugReportToolStripMenuItem";
            this.viewBugReportToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.viewBugReportToolStripMenuItem.Text = "View Bugs Report";
            this.viewBugReportToolStripMenuItem.Click += new System.EventHandler(this.viewBugReportToolStripMenuItem_Click);
            // 
            // viewSolutionsReportToolStripMenuItem
            // 
            this.viewSolutionsReportToolStripMenuItem.Name = "viewSolutionsReportToolStripMenuItem";
            this.viewSolutionsReportToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.viewSolutionsReportToolStripMenuItem.Text = "View Solutions Report";
            // 
            // searchABugToolStripMenuItem
            // 
            this.searchABugToolStripMenuItem.Name = "searchABugToolStripMenuItem";
            this.searchABugToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.searchABugToolStripMenuItem.Text = "Search a Bug";
            this.searchABugToolStripMenuItem.Click += new System.EventHandler(this.searchABugToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // ProgHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyAssignmentBugTrack.Properties.Resources.untitled;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProgHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgHomePage";
            this.Load += new System.EventHandler(this.ProgHomePage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportBugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBugReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSolutionsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchABugToolStripMenuItem;
    }
}