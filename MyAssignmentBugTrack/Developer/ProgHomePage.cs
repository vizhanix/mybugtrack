using MyAssignmentBugTrack.Developer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAssignmentBugTrack.Programmer
{
    public partial class ProgHomePage : Form
    {
        string name = "";

        public ProgHomePage(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDevBug f = new AddDevBug(name);
            f.MdiParent = this;
            f.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Have Successfully Logged Out");
            Application.Restart();
        }

        private void viewBugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugDevReport f = new BugDevReport();
            f.MdiParent = this;
            f.Show();
        }

        private void searchABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBug f = new SearchBug();
            f.MdiParent = this;
            f.Show();
        }

    /*    private void addBugSolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }*/

        private void ProgHomePage_Load(object sender, EventArgs e)
        {

        }
    }
}
