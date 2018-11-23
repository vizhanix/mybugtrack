


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the unchangedimage page of the application                   *
 *		 which is named UnchangedImage for the admin role                         *
 *																		          *	
 *																				  *
 ************************************************************************************/

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
    public partial class UnchangedImage : Form
    {
        //variable declaration 
        int id;
        //constructor that has a parameter
        public UnchangedImage(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        //method that loads when the specific form is open during the execution of the program
        private void UnchangedImage_Load(object sender, EventArgs e)
        {
            //connection string that connects to the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT * FROM tbl_addbugs WHERE id ='" + id + "'";
            myconn.Open();  //connection open
            command.ExecuteNonQuery();

            MySqlDataReader reader = command.ExecuteReader();

            MessageBox.Show(id.ToString());

            //reader to read the binary image file
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
                    MessageBox.Show(ex.Message); //exception message
                }
            }
        }
    }
}
