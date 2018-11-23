


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the programmer search bug page of the application            *
 *		 which is named SearchBug for the developer role                          *
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


//namespace of the [project
namespace MyAssignmentBugTrack.Developer
{
    public partial class SearchBug : Form
    {
        //default constructor
        public SearchBug()
        {
            InitializeComponent();
        }

        string searchVal = "";

        //connection string used to sonnect to the database
        MySqlConnection myconn = new MySqlConnection("Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none");

        private void SearchBug_Load(object sender, EventArgs e)
        {

        }

        //method runs when button1 is clicked to select data from the database and put on datagridview
        private void button1_Click(object sender, EventArgs e)
        {


            searchVal = textBox1.Text;
            MessageBox.Show(searchVal);

            //select query to search the value provided by the programmer
            string query = "SELECT * FROM tbl_addbugs WHERE reporter='" + searchVal + "'";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, myconn);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            //code that fills he datagird view table with the fetched data from the database
        }
    }
}
