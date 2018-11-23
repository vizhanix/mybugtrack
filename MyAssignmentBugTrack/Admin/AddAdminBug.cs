


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the add bugs page of the application which is named          *
 *		AddAdminBug for the admin role to see an add bugs                         *
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

//namespace of the project
namespace MyAssignmentBugTrack.Admin
{
    public partial class AddAdminBug : Form
    {
        //variable declarations field
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

        //default constructor
        public AddAdminBug()
        {
            InitializeComponent();
        }

        //constructor that takes parameters
        public AddAdminBug(string name)
        {
            InitializeComponent();
            this.name = name;
        }


        //method that loads when the appropriate form gets load while executing the program
        private void AddAdminBug_Load(object sender, EventArgs e)
        {
            //connection string to connect to the database and manupulate data in the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT * FROM tbl_products";
            myconn.Open();
            command.ExecuteNonQuery();

            MySqlDataReader reader = command.ExecuteReader();

            //loop when after the data is collected from the database is to set to combobox
            while (reader.Read())
            {
                //code to add the dynamic data to the combobox for options to select
                comboBox1.Items.Add(reader.GetString("pname"));

            }

            textBox1.Text = name;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        //method  for the syntax highlighting 
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

        //method to read the image and save the provided data to the database as in adding bugs
        private void button2_Click(object sender, EventArgs e)
        {
            //code to read the byte file type image from the database
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

            //connection string which is used to connect to the database and manupulate the contents in the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "INSERT INTO tbl_addbugs (product_id,reporter,description,date,startline,endline,method,class,code,status,snapshot) VALUES " + "('" + combotext + "' ,'" + this.name + "' , '" + description + "','" + theDate + "','" + startline + "','" + endline + "','" + method + "','" + theclass + "','" + code + "','" + status + "',@IMG);";
            myconn.Open();

            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            command.ExecuteNonQuery();

            MessageBox.Show("BUG HAS SUCCESSFULLY BEEN ADDED!"); //success message

            this.Close();

        }

        //method to open a dialog option box when the button is clicked to give admin the choice to upload the image file
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
