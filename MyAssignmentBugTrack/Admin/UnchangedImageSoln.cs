using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace of the project
namespace MyAssignmentBugTrack.Admin
{
    public partial class UnchangedImageSoln : Form
    {
        //variable declaration
        int id = 0;

        //constructor with a parameter
        public UnchangedImageSoln(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void UnchangedImageSoln_Load(object sender, EventArgs e)
        {
            //connection string that connects to the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT * FROM tbl_solutions WHERE id ='" + id + "'";
            myconn.Open(); //connection open
            command.ExecuteNonQuery();

            MySqlDataReader reader = command.ExecuteReader();

            MessageBox.Show(id.ToString());

            while (reader.Read())
            {
                try
                {
                    //image read code
                    byte[] imgg = (byte[])(reader["snapshot"]);
                    if (imgg == null)
                        pictureBox1.Image = null;
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); //exception message
                }
            }
        }
    }
}
