


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the add bug page of the application                          *
 *		 which is named AddDevBug for the developer role                          *
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
using ICSharpCode.TextEditor.Document;
using System.IO;
using System.Windows.Forms;

//namespace of the project
namespace MyAssignmentBugTrack.Developer
{
    public partial class AddDevBug : Form
    {
        //variable declatations
        string name = "";
        string combotext = "";
        string theDate = "";
        string description = "";
        string startline = "";
        string endline = "";
        string method = "";
        string theclass = "";
        string code = "";
        string status = "";

        //parameterized constructor
        public AddDevBug(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        /*method that runs to add the data to datagridview by fetching the data from the database*/
        private void AddDevBug_Load(object sender, EventArgs e)
        {
            //connection string which connects to the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT * FROM tbl_products";
            myconn.Open(); //connection open
            command.ExecuteNonQuery();

            MySqlDataReader reader = command.ExecuteReader();

            //code that appends database pname fields to the combobox
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString("pname"));

            }

            textBox1.Text = name;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        /*text editor to add code to the form and for the syntax hoghlighting*/
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


        //method which runs when button2 is clicked to insert the bug
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox8.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            combotext = comboBox1.SelectedItem.ToString();
            
            description = textBox2.Text;
            startline = textBox3.Text;
            endline = textBox4.Text;
            method = textBox5.Text;
            theclass = textBox6.Text;
            code = textEditorControl1.Text;
            status = textBox7.Text;


            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "INSERT INTO tbl_addbugs (product_id,reporter,description,date,startline,endline,method,class,code,status,snapshot) VALUES " + "('" + combotext + "' ,'" + this.name + "' , '" + description + "','" + theDate + "','" + startline + "','" + endline + "','" + method + "','" + theclass + "','" + code + "','" + status + "',@IMG);";
            myconn.Open();

            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            command.ExecuteNonQuery();

            MessageBox.Show("BUG HAS SUCCESSFULLY BEEN ADDED!"); //success message

            this.Close(); //connection close


        }

        //method that runs when button1 is clicked to open a filedialogbox to choose an image to save to the database
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
    }
}
