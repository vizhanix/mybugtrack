


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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ICSharpCode.TextEditor.Document;
using System.IO;

//namespace of the project
namespace MyAssignmentBugTrack.Tester
{
    public partial class AddBug : Form
    {
        //variables declration field
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

        //constructor that takes string as its parameter
        public AddBug(string name)
        {
            InitializeComponent();
            //action to store  the passed name to this class variabe declared above
            this.name = name;
        }

        //default constructor
        public AddBug()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        //method of the form load
        private void AddBug_Load(object sender, EventArgs e)
        {
            //block of code to connect to the database and fetch or alter values
            //whenever necessary
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT * FROM tbl_products";
            myconn.Open();
            command.ExecuteNonQuery();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //fetch the data from the database and show names of the products in combobox
                comboBox1.Items.Add(reader.GetString("pname"));
                
            }

            //puts text of the textbox5 to the value ste in name variable
            textBox5.Text = name;

            //date time picker format declaration
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            //takes the value selected in the datetimepicker and stores to theDate variable
            theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

        }

        //this is the block of code to have syntax highlighting on the textEditorField
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

        //method written to do the tasks when the add bug button is clicked
        private void btn_addbug_Click(object sender, EventArgs e)
        {

            //block of code to read the image
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox8.Text, FileMode.Open , FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            //use of variables to get the input values and store in variables
            combotext = comboBox1.SelectedItem.ToString();
            description = textBox1.Text;
            startline = textBox2.Text;
            endline = textBox3.Text;
            method = textBox4.Text;
            theclass = textBox6.Text;
            code = textEditorControl1.Text;
            status = textBox7.Text;

            //block of code to connect to the database and fetch or alter the values associated
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "INSERT INTO tbl_addbugs (product_id,reporter,description,date,startline,endline,method,class,code,status,snapshot) VALUES " + "('" + combotext + "' ,'" + this.name + "' , '" + description + "','" + theDate + "','" + startline + "','" + endline  + "','" + method + "','" + theclass + "','" + code  + "','" + status + "',@IMG);";
            myconn.Open();

            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            command.ExecuteNonQuery();

            MessageBox.Show("BUG HAS SUCCESSFULLY BEEN ADDED!");

            this.Close();

        }

        //method used when the button clicked, show dialogbox to choose image file to oad to the database
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|Png Files(*.png)|*.png|All Files(*.*)|*.*";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                textBox8.Text = picPath;
                pictureBox1.ImageLocation = picPath;
            }
        }
    }
}
