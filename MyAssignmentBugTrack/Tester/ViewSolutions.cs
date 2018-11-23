


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the view solutions page of the application which is named    *
 *		ViewSolutions for the tester role to see solutions list					  *
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

//project namespace
namespace MyAssignmentBugTrack.Tester
{
    public partial class ViewSolutions : Form
    {

        //variable declaration
        int id;

        //default constructor
        public ViewSolutions()
        {
            InitializeComponent();
        }

        //database connection string
        MySqlConnection myconn = new MySqlConnection("Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none");

        //method that runs when the mein form loads
        private void ViewSolutions_Load(object sender, EventArgs e)
        {
            //code that connects to the database for fetching or altering the database data
            string query = "SELECT id,bug_id,description,date,code FROM tbl_solutions";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, myconn);
            //code to fill the datagridview with the data in the database
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        //method to take action when the wors in the datagridview are clicked
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textEditorControl1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        //method to take action when the button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            SolutionImage f = new SolutionImage(id);
            f.Show();
        }
































        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
