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
    public partial class HomePage : Form
    {
        private string name;
        

        public HomePage(string name)
        {
            InitializeComponent();
            this.name = name;
            
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
