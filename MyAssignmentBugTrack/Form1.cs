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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string email = txtbox_email.Text;
            string password = txtbox_pass.Text;
            string comboboxtext = comboBox1.Text;

            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "select id,name,role from tbl_users where email ='" + email + "' and password = '" + password + "'";
            try
            {
                myconn.Open();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            MySqlDataReader reader = command.ExecuteReader();

            string roletype = "";
            string name = "";
           
            while (reader.Read())
            {
                name = reader["name"].ToString();
                roletype = reader["role"].ToString();
            }
            if (name == "")
            {
                MessageBox.Show("Please chech your login credentials");
            }
            if(comboboxtext == "admin" && roletype == "admin")
            {
               
               

            }
            else if(comboboxtext == "tester" && roletype == "tester")
            {
                MessageBox.Show("Logged in as : " + comboboxtext);
                TesterHome f = new TesterHome(name);
                this.Hide();
                f.Show();
            }
            else if(comboboxtext == "developer" && roletype == "developer")
            {
               
            }
            else
            {
                MessageBox.Show("No Records Found!!");
            }
        }

        private void btn_regester_Click(object sender, EventArgs e)
        {
            RegesterForm regfrm = new RegesterForm();
            this.Hide();
            regfrm.Show();
         
        }
    }
}
