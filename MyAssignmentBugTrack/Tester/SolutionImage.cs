


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the solution image page of the application which is named    *
 *		SolutionImage for the tester role to see an image						  *
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

namespace MyAssignmentBugTrack.Tester
{
    public partial class SolutionImage : Form
    {
        //variables declaration
        int id;

        //constructor which takes id as parameter
        public SolutionImage(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        //method which runs when the form is loaded during the execution of the program
        private void SolutionImage_Load(object sender, EventArgs e)
        {
            //block of code to to connect to the database and 
            //change the values whenever necessary 
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT * FROM tbl_solutions WHERE id ='" + id + "'";
            myconn.Open();
            command.ExecuteNonQuery();

            MySqlDataReader reader = command.ExecuteReader();

            MessageBox.Show(id.ToString());

            while (reader.Read())
            {
                try
                {
                    //code which retrieves the image that is saved in the database
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
