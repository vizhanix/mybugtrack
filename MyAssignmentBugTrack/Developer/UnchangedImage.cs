﻿using MySql.Data.MySqlClient;
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

namespace MyAssignmentBugTrack.Developer
{
    public partial class UnchangedImage : Form
    {
        int id;
        public UnchangedImage()
        {
            InitializeComponent();
        }

        public UnchangedImage(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void UnchangedImage_Load(object sender, EventArgs e)
        {
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT * FROM tbl_addbugs WHERE id ='" + id + "'";
            myconn.Open();
            command.ExecuteNonQuery();

            MySqlDataReader reader = command.ExecuteReader();

            MessageBox.Show(id.ToString());

            while (reader.Read())
            {
                try
                {
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
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
