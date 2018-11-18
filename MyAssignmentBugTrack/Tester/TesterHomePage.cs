using MyAssignmentBugTrack.Tester;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAssignmentBugTrack
{
    public partial class TesterHome : Form
    {
        private string name;
        

        public TesterHome(string name)
        {
            InitializeComponent();
            this.name = name;
            
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBug f = new AddBug(name);
            f.MdiParent = this;
            f.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Have Successfully Logged Out");
            Application.Restart();

        }


        //-------****** View Bugs Report Method ******--------
        private void viewProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugReport f = new BugReport();
            f.MdiParent = this;
            f.Show();
        }

        private void searchBugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBug f = new SearchBug();
            f.MdiParent = this;
            f.Show();
        }
    }
}
