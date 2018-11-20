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

namespace MyAssignmentBugTrack.Admin
{
    public partial class AdminSolutionsReport : Form
    {

        int id;
        string bugid;
        string theDate;
        string solutiondescription = "";
        string code = "";
        byte[] imageBt = null;

        public AdminSolutionsReport()
        {
            InitializeComponent();
        }

        MySqlConnection myconn = new MySqlConnection("Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none");

        private void AdminSolutionsReport_Load(object sender, EventArgs e)
        {
            string query = "SELECT id,bug_id,description,date,code FROM tbl_solutions";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, myconn);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

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


            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();



            command.CommandText = "UPDATE tbl_solutions SET bug_id = '" + bugid + "'" + ", description = '" + solutiondescription + "'" + ",date ='" + theDate + "'" + ",code ='" + code + "',snapshot = @IMG WHERE id = " + id;

            myconn.Open();

            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            command.ExecuteNonQuery();

            MessageBox.Show("BUGS HAVE SUCCESSFULLY UPDATED");

            this.Close();
        }

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

        private void button3_Click_1(object sender, EventArgs e)
        {
            UnchangedImageSoln f = new UnchangedImageSoln(id);
            f.Show();
        }

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


            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();



            command.CommandText = "UPDATE tbl_solutions SET bug_id = '" + bugid + "'" + ", description = '" + solutiondescription + "'" + ",date ='" + theDate + "'" + ",code ='" + code + "',snapshot = @IMG WHERE id = " + id;

            myconn.Open();

            command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

            command.ExecuteNonQuery();

            MessageBox.Show("BUGS HAVE SUCCESSFULLY UPDATED");

            this.Close();
        }
    }
}
