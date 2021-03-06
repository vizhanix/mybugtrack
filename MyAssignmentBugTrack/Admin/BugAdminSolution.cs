﻿


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the bug admin solutions page of the application              *
 *		 which is named BugAdminSolution for the admin role                       *
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
    public partial class BugAdminSolution : Form
    {
        //variables declaration
        int id;
        string description = "", code = "", theDate = "";

        /*method that opens a dialog box to choose image file to upload it in
         the database*/

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

        /*method that runs when button2 is clicked to insert the inputted values to the database*/
        private void button2_Click(object sender, EventArgs e)
        {
            //code that reads the image binary file
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox3.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);


            //variables that takes the data in the respective fields
            code = textEditorControl1.Text;
            description = textBox2.Text;

            //connection string that connects to the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "INSERT INTO tbl_solutions (bug_id,description,date,code,snapshot) VALUES " + "('" + id + "' ,'" + description + "','" + theDate + "','" + code + "'" + ",@IMG);";
            myconn.Open();

            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            command.ExecuteNonQuery();

            MessageBox.Show("BUG SOLUTION HAS SUCCESSFULLY BEEN ADDED!"); //success message

            this.Close(); //connection close
        }


        /*texteditor method that runs to highlight the syntax of the c# code that 
         is inserted during the application runtime*/
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

        //constructor with parameter that takes id 
        public BugAdminSolution(int id)
        {
            InitializeComponent();
            this.id = id;
        }


        private void BugAdminSolution_Load(object sender, EventArgs e)
        {
            textBox1.Text = id.ToString();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }
    }
}
