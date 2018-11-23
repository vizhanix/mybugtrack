


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the charts page of the application                           *
 *		 which is named Chart1 for the admin role                                 *
 *																		          *	
 *																				  *
 ************************************************************************************/

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

//namespace of the project
namespace MyAssignmentBugTrack.Admin
{
    public partial class Chart1 : Form
    {
        //default constructor 
        public Chart1()
        {
            InitializeComponent();
        }

        //method that runs when the  form is loaded during the application execution
        private void Chart1_Load(object sender, EventArgs e)
        {
            //connection string to connect to the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM tbl_addbugs";
            myconn.Open(); //connection open

            int nobugs = Convert.ToInt32(command.ExecuteScalar()); //to get the data from count() in sql query

            command.ExecuteNonQuery();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                this.chart2.Series["Bugs"].Points.AddXY("",nobugs);

            }

            myconn.Close();

            string connectString1 = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn1 = new MySqlConnection(connectString1);
            MySqlCommand command1 = myconn.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM tbl_solutions";
            myconn.Open();

            int nobugs1 = Convert.ToInt32(command.ExecuteScalar());

            command.ExecuteNonQuery();

            MySqlDataReader reader1 = command.ExecuteReader();

            while (reader1.Read())
            {
                this.chart2.Series["Solutions"].Points.AddXY("", nobugs1);

            }

            myconn.Close();

            string connectString2 = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn2 = new MySqlConnection(connectString2);
            MySqlCommand command2 = myconn.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM tbl_products";
            myconn.Open();

            int nobugs2 = Convert.ToInt32(command.ExecuteScalar());

            command.ExecuteNonQuery();

            MySqlDataReader reader2 = command.ExecuteReader();

            while (reader2.Read())
            {
                this.chart2.Series["Products"].Points.AddXY("", nobugs2);

            }

            myconn.Close();









        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
