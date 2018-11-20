namespace MyAssignmentBugTrack.Admin
{
    partial class AdminHome
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
            this.reportABugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBugReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSolutionsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchABugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionControlSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportABugToolStripMenuItem,
            this.viewBugReportToolStripMenuItem,
            this.viewSolutionsReportToolStripMenuItem,
            this.searchABugToolStripMenuItem,
            this.versionControlSystemToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.addProductToolStripMenuItem,
            this.logoutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(997, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportABugToolStripMenuItem
            // 
            this.reportABugToolStripMenuItem.Name = "reportABugToolStripMenuItem";
            this.reportABugToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.reportABugToolStripMenuItem.Text = "Report A Bug";
            this.reportABugToolStripMenuItem.Click += new System.EventHandler(this.reportABugToolStripMenuItem_Click);
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
            this.viewSolutionsReportToolStripMenuItem.Click += new System.EventHandler(this.viewSolutionsReportToolStripMenuItem_Click);
            // 
            // searchABugToolStripMenuItem
            // 
            this.searchABugToolStripMenuItem.Name = "searchABugToolStripMenuItem";
            this.searchABugToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.searchABugToolStripMenuItem.Text = "Search A Bug";
            this.searchABugToolStripMenuItem.Click += new System.EventHandler(this.searchABugToolStripMenuItem_Click);
            // 
            // versionControlSystemToolStripMenuItem
            // 
            this.versionControlSystemToolStripMenuItem.Name = "versionControlSystemToolStripMenuItem";
            this.versionControlSystemToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.versionControlSystemToolStripMenuItem.Text = "Version Control System";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.logoutToolStripMenuItem.Text = "Additional Features";
            // 
            // addProductToolStripMenuItem
            // 
            this.addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            this.addProductToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.addProductToolStripMenuItem.Text = "Add / Edit Products";
            this.addProductToolStripMenuItem.Click += new System.EventHandler(this.addProductToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem1
            // 
            this.logoutToolStripMenuItem1.Name = "logoutToolStripMenuItem1";
            this.logoutToolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem1.Text = "Logout";
            this.logoutToolStripMenuItem1.Click += new System.EventHandler(this.logoutToolStripMenuItem1_Click);
            // 
            // AdminHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyAssignmentBugTrack.Properties.Resources.untitled;
            this.ClientSize = new System.Drawing.Size(997, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminHome";
            this.Text = "AdminHome";
            this.Load += new System.EventHandler(this.AdminHome_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportABugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBugReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSolutionsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchABugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionControlSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addProductToolStripMenuItem;
    }
}