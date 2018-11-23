


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the bug report page of the application                       *
 *		 which is named BugDevReport for the developer role                       *
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

namespace MyAssignmentBugTrack.Developer
{
    public partial class BugDevReport : Form
    {
        //variable declaration field
        int id, count = 0;
        string reporter = "";
        string combotext = "";
        string theDate;
        string description = "";
        string startline = "";
        string endline = "";
        string method = "";
        string theclass = "";
        string code = "";
        string status = "";

        //default constructor
        public BugDevReport()
        {
            InitializeComponent();
        }

        //connection string that connects to the database
        MySqlConnection myconn = new MySqlConnection("Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none");

        private void BugDevReport_Load(object sender, EventArgs e)
        {
            //sql query and the code to connect to the database and display the fetched data in datagridview
            string query = "SELECT id,product_id,reporter,description,date,startline,endline,method,class,code,status FROM tbl_addbugs";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, myconn);
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        /*method that runs when a row of the datagridview is clicked*/
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //connection string to connect to the database to fetch or manipulate the data on the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT * FROM tbl_products";
            myconn.Open();          //connection open
            command.ExecuteNonQuery();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read() && count < 1)
            {
                comboBox1.Items.Add(reader.GetString("pname"));

            }

            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString(); //startline
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString(); //endline
            textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString(); //method
            textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString(); //class
            textBox7.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString(); //status
            // textBox1.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textEditorControl1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString(); //code

            count++;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        /*button1 clicked to run this method which opens a file dialog box to choose an image file to upload in the database*/
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|Png Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                textBox8.Text = picPath;
                pictureBox1.ImageLocation = picPath;
            }
        }

        /*method that runs when button2 is clicked to see the unchanged image of that particular bug*/
        private void button2_Click(object sender, EventArgs e)
        {
            UnchangedImage f = new UnchangedImage(id);
            f.Show();
        }

        //method that runs when button3 is clicked in the form to read images and the input data to update the data in the database
        private void button3_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox8.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            combotext = comboBox1.SelectedItem.ToString(); //done
            reporter = textBox1.Text; //done
            description = textBox2.Text; //done
            theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd"); //done
            startline = textBox3.Text;
            endline = textBox5.Text;
            method = textBox4.Text;
            theclass = textBox6.Text;
            code = textEditorControl1.Text;
            status = textBox7.Text;

            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();



            command.CommandText = "UPDATE tbl_addbugs SET product_id = '" + combotext + "'" + ", reporter = '" + reporter + "'" + ",description ='" + description + "'" + ",date ='" + theDate + "' ,startline = '" + startline + "' ,endline = '" + endline + "' ,method = '" + method + "', class = '" + theclass + "' ,code='" + code + "' ,status = '" + status + "',snapshot = @IMG WHERE id = " + id;

            myconn.Open(); //connection open

            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            command.ExecuteNonQuery();

            MessageBox.Show("BUGS HAVE SUCCESSFULLY UPDATED");

            this.Close();               //connection close
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BugSolution f = new BugSolution(id);
            f.Show();

        }

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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

      

      
    }
}
