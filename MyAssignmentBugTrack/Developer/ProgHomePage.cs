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
        public ProgHomePage()
        {
            InitializeComponent();
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDevBug f = new AddDevBug();
            f.MdiParent = this;
            f.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Have Successfully Logged Out");
            Application.Restart();
        }
    }
}
