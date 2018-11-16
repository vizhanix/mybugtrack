using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAssignmentBugTrack.Tester
{
    public partial class BugReport : Form
    {
        int id;
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

       


        public BugReport()
        {
            InitializeComponent();
        }

        MySqlConnection myconn = new MySqlConnection("Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none");

        private void BugReport_Load(object sender, EventArgs e)
        {          

           
            string query = "SELECT * FROM tbl_addbugs";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, myconn);
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
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

            

        }

        private void button1_Click(object sender, EventArgs e)
        {

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



            command.CommandText = "UPDATE tbl_addbugs SET product_id = '" + combotext + "'" + ", reporter = '" + reporter + "'" + ",description ='"+ description + "'" + ",date ='" + theDate + "' ,startline = '" + startline + "' ,endline = '" + endline + "' ,method = '" + method + "', class = '" + theclass + "' ,code='" + code + "' ,status = '" + status + "' WHERE id = " + id  ;

            myconn.Open();
            command.ExecuteNonQuery();

            MessageBox.Show("BUGS HAVE SUCCESSFULLY UPDATED");

            this.Close();


        }
    }
}
