


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the add bug page of the application which is named	    	  *
 *		AddBug for the tester role to add the bugs								  *
 *																				  *	
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

//name of the namespace of the project
namespace MyAssignmentBugTrack.Tester
{
    public partial class BugReport : Form
    {
        //variables declaration field
        int id,count = 0;
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
        byte[] imageBt = null;

        //default constructor 
        public BugReport()
        {
            InitializeComponent();
        }

        //connection string 
        MySqlConnection myconn = new MySqlConnection("Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none");

        //form load method
        private void BugReport_Load(object sender, EventArgs e)
        {    
            //block of code to connect to the database and fetch or alter the values saved in the database
            string query = "SELECT id,product_id,reporter,description,date,startline,endline,method,class,code,status FROM tbl_addbugs";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, myconn);

            //block of code to fill the gatagridview with the associated data from the database
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        //method to take action when the rows in the datagridview is clicked
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT * FROM tbl_products";
            myconn.Open();
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
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
             textBox7.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            // textBox1.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
             textEditorControl1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

            count++;

        }

        //method to show the dialogbox to give option to choose the image file to upload in the database
        private void button2_Click(object sender, EventArgs e)
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

        //method to show the unchanged image for a bug created
        private void button3_Click(object sender, EventArgs e)
        {
            UnchangedImage f = new UnchangedImage(id);
            f.Show();
        }

        //this is the method where syntax highlighting takes place
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

        //method for the button which when pressed, updated the database associated with the values
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                imageBt = null;
                FileStream fstream = new FileStream(this.textBox8.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            combotext = comboBox1.SelectedItem.ToString(); //done
            reporter = textBox1.Text; //done
            description = textBox2.Text; //done
            theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd"); //done
            startline = textBox3.Text;
            endline = textBox4.Text;
            method = textBox5.Text;
            theclass = textBox6.Text;
            code = textEditorControl1.Text;
            status = textBox7.Text;

            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();

            command.CommandText = "UPDATE tbl_addbugs SET product_id = '" + combotext + "'" + ", reporter = '" + reporter + "'" + ",description ='"+ description + "'" + ",date ='" + theDate + "' ,startline = '" + startline + "' ,endline = '" + endline + "' ,method = '" + method + "', class = '" + theclass + "' ,code='" + code + "' ,status = '" + status + "',snapshot = @IMG WHERE id = " + id  ;

            myconn.Open();

            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            command.ExecuteNonQuery();

            MessageBox.Show("BUGS HAVE SUCCESSFULLY UPDATED");

            this.Close();


        }
    }
}
