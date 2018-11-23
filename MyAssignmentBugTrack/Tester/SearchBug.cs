


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the search bug page of the application which is named    	  *
 *		SearchBug for the tester role to search the bugs						  *
 *																				  *	
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

//namespace for the project
namespace MyAssignmentBugTrack.Tester
{
    public partial class SearchBug : Form
    {
        //default constructor
        public SearchBug()
        {
            InitializeComponent();
        }

        //variable declaration 
        string searchVal = "";

        //connection string to use whenever there is need to connect to the databsae
        MySqlConnection myconn = new MySqlConnection("Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none");

        private void SearchBug_Load(object sender, EventArgs e)
        {
            

           
        }

        //method which when the button is clicked, the results are displatyed in the datadridview
        private void button1_Click(object sender, EventArgs e)
        {
            searchVal = textBox1.Text;
            MessageBox.Show(searchVal);


            string query = "SELECT * FROM tbl_addbugs WHERE reporter='" + searchVal + "'";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, myconn);
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }
    }
}
