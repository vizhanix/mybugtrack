


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the programmer solutions report page of the applications     *
 *		 which is named SolutionsReport for the developer role                    *
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

//amespace of the project
namespace MyAssignmentBugTrack.Developer
{
    public partial class SolutionsReport : Form
    {
        //variable declaration field
        int id;
        string bugid;
        string theDate;
        string solutiondescription = "";
        string code = "";
        byte[] imageBt = null;

        //default constructor
        public SolutionsReport()
        {
            InitializeComponent();
        }

        //database string to connect to the database
        MySqlConnection myconn = new MySqlConnection("Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none");

        //method which runs to fetch the data from the database to fill to datagridview
        private void SolutionsReport_Load(object sender, EventArgs e)
        {
            string query = "SELECT id,bug_id,description,date,code FROM tbl_solutions";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, myconn);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        //mouseclick event to show the data from that respective row o the fields in order to manipulate or delete
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());           
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textEditorControl1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UnchangedImageSoln f = new UnchangedImageSoln(id);
            f.Show();
        }

        //method when button1 clicked, pops a dialog box to choose an image to upload in the database
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

        //method that is run when button2 is clicked in the form to update the solutions
        private void button2_Click(object sender, EventArgs e)
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
       
            //string connection to connenct to the database
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();



            command.CommandText = "UPDATE tbl_solutions SET bug_id = '" + bugid + "'" + ", description = '" + solutiondescription + "'" + ",date ='" + theDate + "'" + ",code ='" + code + "',snapshot = @IMG WHERE id = " + id;

            myconn.Open();      //connection open

            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            command.ExecuteNonQuery();

            MessageBox.Show("BUGS HAVE SUCCESSFULLY UPDATED");

            this.Close(); //connection close
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
    }
}
