


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the unchanged image page of the application which is named   *
 *		UnchangedImage for the tester role to see an image						  *
 *																				  *	
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

//namespace of the application
namespace MyAssignmentBugTrack.Tester
{
    public partial class UnchangedImage : Form
    {
         int id;

        //default constructor of the application
        public UnchangedImage()
        {
            InitializeComponent();
        }

        //constructor that has id (integer field) as its parameter
        public UnchangedImage(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        //method when the unchangedImage form loads
        private void UnchangedImage_Load(object sender, EventArgs e)
        {
            //connection string to connect to the database and fetchor alter the values whenever necessary
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
                    //code to retrive the imagefrom the database when the button is clicked
                    byte[] imgg = (byte[])(reader["snapshot"]);
                    if (imgg == null)
                        pictureBox1.Image = null;
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
