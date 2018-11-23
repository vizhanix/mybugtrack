


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
namespace MyAssignmentBugTrack.Developer
{
    public partial class BugSolution : Form
    {
        //variables declaration field
        int id;
        string description = "" , code = "", theDate = "";

        //default constructor
        public BugSolution()
        {
            InitializeComponent();
        }

        //parameterixed constructor that takes id 
        public BugSolution(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        /*text editor methhod for syntax highlighting and pasing the source code in */

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

        //button2 click to save the solution data to the database
        private void button2_Click(object sender, EventArgs e)
        {
            //image read code
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox3.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            code = textEditorControl1.Text;
            description = textBox2.Text;

           //connection string to connect to the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "INSERT INTO tbl_solutions (bug_id,description,date,code,snapshot) VALUES " + "('" + id + "' ,'" + description + "','" + theDate + "','" + code + "'" + ",@IMG);";
            myconn.Open();              //connection open

            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            command.ExecuteNonQuery();

            MessageBox.Show("BUG SOLUTION HAS SUCCESSFULLY BEEN ADDED!");           
                
            this.Close();                   //connection close
        }

        //button1 click and opens a file dialog box to choose image to save in the database
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //fields to intake when the method loads during the execution of the application
        private void BugSolution_Load(object sender, EventArgs e)
        {
            textBox1.Text = id.ToString();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }
    }
}
