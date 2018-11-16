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

namespace MyAssignmentBugTrack.Tester
{
    public partial class AddBug : Form
    {
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

        public AddBug(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        public AddBug()
        {
           
        
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void AddBug_Load(object sender, EventArgs e)
        {
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT * FROM tbl_products";
            myconn.Open();
            command.ExecuteNonQuery();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString("pname"));
                
            }

            textBox5.Text = name;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

        }

        public string getDate()
        {
            return theDate;
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

        private void btn_addbug_Click(object sender, EventArgs e)
        {
            combotext = comboBox1.SelectedItem.ToString();

            /*
            string connectString1 = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn1 = new MySqlConnection(connectString1);
            MySqlCommand command1 = myconn1.CreateCommand();
            command1.CommandText = "SELECT id FROM tbl_products WHERE pname = '" + combotext + "'";
            myconn1.Open();
            command1.ExecuteNonQuery();

            MySqlDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                comboboxid =  reader1.GetInt32("id");

            }
            */


            description = textBox1.Text;
            startline = textBox2.Text;
            endline = textBox3.Text;
            method = textBox4.Text;
            theclass = textBox6.Text;
            code = textEditorControl1.Text;
            status = textBox7.Text;


            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "INSERT INTO tbl_addbugs (product_id,reporter,description,date,startline,endline,method,class,code,status) VALUES " + "( ' " + combotext + " ' , '" + this.name + "' , '" + description + "','" + theDate + "','" + startline + "','" + endline  + "','" + method + "','" + theclass + "','" + code  + "','" + status + "'"+  ");";
            myconn.Open();
            command.ExecuteNonQuery();

            MessageBox.Show("BUG HAS SUCCESSFULLY BEEN ADDED!");

            this.Close();

        }
    }
}
