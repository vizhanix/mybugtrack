


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the adminsolutionsreport page of the application             *
 *		 which is named AdminSolutionReport for the admin role                    *
 *																		          *	
 *																				  *
 ************************************************************************************/

using ICSharpCode.TextEditor.Document;
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
    public partial class AdminSolutionsReport : Form
    {
        //variables declaration field
        int id;
        string bugid;
        string theDate;
        string solutiondescription = "";
        string code = "";
        byte[] imageBt = null;

        //default constructor
        public AdminSolutionsReport()
        {
            InitializeComponent();
        }

        //database connection string
        MySqlConnection myconn = new MySqlConnection("Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none");

        //method which runs after the form is loaded during the execution of the application 
        private void AdminSolutionsReport_Load(object sender, EventArgs e)
        {
            //database conenction string to connecto to the database
            string query = "SELECT id,bug_id,description,date,code FROM tbl_solutions";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, myconn);
            //code that fills the datagridview after fetching data from the database
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        //method which displays the data in the row to the respective textfields once it is clicked
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textEditorControl1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        //method which goes to the unchangedImageSoln form when the button3 is clicked
        private void button3_Click(object sender, EventArgs e)
        {
            UnchangedImageSoln f = new UnchangedImageSoln(id);
            f.Show();
        }

        //method that opens file dialog to choose image to upload it in the database
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|Png Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                textBox3.Text = picPath;
                pictureBox1.ImageLocation = picPath;
            }
        }

        //method that runs when button2 is clicked to update the information

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //code that reads the binary data from the database to retrieve the image stored
                imageBt = null;
                FileStream fstream = new FileStream(this.textBox3.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //exception message display
            }


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            bugid = textBox1.Text.ToString();
            solutiondescription = textBox2.Text; //done
            theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            code = textEditorControl1.Text;

            //connection string to connect to the databse to manipulate the information in the datbaase
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();



            command.CommandText = "UPDATE tbl_solutions SET bug_id = '" + bugid + "'" + ", description = '" + solutiondescription + "'" + ",date ='" + theDate + "'" + ",code ='" + code + "',snapshot = @IMG WHERE id = " + id;

            myconn.Open();

            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            command.ExecuteNonQuery();

            MessageBox.Show("BUGS HAVE SUCCESSFULLY UPDATED");

            this.Close(); //close the connection
        }


        /*method to open a dialogbox for the option to choose image file to 
         store it in the database*/

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|Png Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                textBox3.Text = picPath;
                pictureBox1.ImageLocation = picPath;
            }
        }


        //method that opens an image that is not changed
        private void button3_Click_1(object sender, EventArgs e)
        {
            UnchangedImageSoln f = new UnchangedImageSoln(id);
            f.Show();
        }

        /*method that updates the newely entered data from the admin to correct some error during the previous entry*/
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                imageBt = null;
                FileStream fstream = new FileStream(this.textBox3.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            bugid = textBox1.Text.ToString();
            solutiondescription = textBox2.Text; //done
            theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            code = textEditorControl1.Text;

            //connection string to connect to the databse
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();


            //query statement to update the database fields
            command.CommandText = "UPDATE tbl_solutions SET bug_id = '" + bugid + "'" + ", description = '" + solutiondescription + "'" + ",date ='" + theDate + "'" + ",code ='" + code + "',snapshot = @IMG WHERE id = " + id;

            myconn.Open();

            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            command.ExecuteNonQuery();

            MessageBox.Show("BUGS HAVE SUCCESSFULLY UPDATED"); //success message

            this.Close(); //connection close line
        }

        //method that delets the solution that is in the database after clicking one of the rows of the datagridview
        private void button4_Click(object sender, EventArgs e)
        {

            //connection string to connect to the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();

            command.CommandText = "DELETE FROM tbl_solutions WHERE id = " + id; //query

            myconn.Open(); //connection open

            command.ExecuteNonQuery();

            MessageBox.Show("SOLUTION SUCCESSFULLY DELETED"); //connection open

            this.Close(); //connection close
        }

        //texteditor for keeping the source code anf for the syntax highlighting
        private void textEditorControl1_Load(object sender, EventArgs e)
        {
            string dric = Application.StartupPath;
            FileSyntaxModeProvider fsmp;
            if (Directory.Exists(dric))
            {
                fsmp = new FileSyntaxModeProvider(dric);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
                textEditorControl1.SetHighlighting("C#");
            }
        }
    }
}
