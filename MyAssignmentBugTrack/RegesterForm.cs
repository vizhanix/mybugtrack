using MySql.Data.MySqlClient;
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
    public partial class RegesterForm : Form
    {

        string regname = "";
        string regpassword = "";
        string regemail = "";
        string regrole = "";
        int status = 1;


        public RegesterForm()
        {
            InitializeComponent();
        }

        private void btn_regsubmit_Click(object sender, EventArgs e)
        {
            regname = txtbox_name.Text;
            regemail = txtbox_email.Text;
            regpassword = txtbox_pass.Text;
            regrole = comboBox1.Text;

          string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "INSERT INTO tbl_users (name, email, password, role, status) VALUES " + "( ' " + regname + " ' , '" + regemail + "' , '" + regpassword + "','" + regrole + "'," + status + ");";
            myconn.Open();



            

            command.ExecuteNonQuery();
           
            
            MessageBox.Show(regname + " -- " + regemail + " -- " + regpassword + " -- " + regrole + " -- " + status);

            this.Close();

            Form1 frm = new Form1();
            frm.Show();










        }
    }
}
