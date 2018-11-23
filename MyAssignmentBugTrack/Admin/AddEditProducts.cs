


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the addedit products page of the application which is named  *
 *		AddEditProducts for the admin role to add, update and delete              *
 *		products																  *	
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
    public partial class AddEditProducts : Form
    {
        //variable declaration field
        string pname, pdesc;
        int id;

        //default constructor 
        public AddEditProducts()
        {
            InitializeComponent();
        }

        //method that specifies what to do when mouse clicks any row in the datagridview 
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //connection string to connecto to the database to fetch or manupulate the database data
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT * FROM tbl_products";
            myconn.Open();
            command.ExecuteNonQuery();

            //data being passed to variable after clicking any row of the datagridview to show in the
            //textboxes
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = id.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();           
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); //startline


        }

        //database connection string
        MySqlConnection myconn = new MySqlConnection("Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none");

        //method that runs when the form is open while running the application
        private void AddEditProducts_Load(object sender, EventArgs e)
        {
            //connection string to connect to the database to manupulate or fetch data frim the database
            string query = "SELECT id,pname,pdesc FROM tbl_products";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, myconn);
            //code to add data to the datagridview after fetching the data from the above code
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        //method to specify what actions to take after the button3 is clicked i.e. in this case to delete the selected field
        private void button3_Click(object sender, EventArgs e)
        {
            
            //connection string to connect to the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();

            command.CommandText = "DELETE FROM tbl_products WHERE id = " + id;

            myconn.Open();

            command.ExecuteNonQuery();

            MessageBox.Show("PRODUCTS SUCCESSFULLY DELETED"); //success message

            this.Close();
        }

        //method to specify what to do after button2 is clicked that is to update the data in the database
        private void button2_Click(object sender, EventArgs e)
        {
         //variables declaration to fetch data that is from the datagridview   
            pname = textBox2.Text;
            pdesc = textBox3.Text;


            //database connection string
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();

            command.CommandText = "UPDATE tbl_products SET pname = '" + pname + "'" + ", pdesc = '" + pdesc + "'  WHERE id = " + id;

            myconn.Open();

            command.ExecuteNonQuery();

            MessageBox.Show("PRODUCTS SUCCESSFULLY UPDATED"); //success message

            this.Close();
        }

        //method which when button1 is clicked the given data is inserted into the database
        private void button1_Click(object sender, EventArgs e)
        {
            //variables declaration
            pname = textBox2.Text;
            pdesc = textBox3.Text;

            //connection string to connect to the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "INSERT INTO tbl_products (pname,pdesc) VALUES " + "('" + pname + "' ,'" + pdesc + "'" + ");";
            myconn.Open();

            command.ExecuteNonQuery();

            MessageBox.Show("PRODUCTS SUCCESSFULLY ADDED!"); //success message

            this.Close();
        }
    }
}
