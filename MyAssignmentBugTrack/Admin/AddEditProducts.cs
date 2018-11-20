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

namespace MyAssignmentBugTrack.Admin
{
    public partial class AddEditProducts : Form
    {
        string pname, pdesc;
        int id;

        public AddEditProducts()
        {
            InitializeComponent();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "SELECT * FROM tbl_products";
            myconn.Open();
            command.ExecuteNonQuery();


            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = id.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();           
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); //startline


        }

        MySqlConnection myconn = new MySqlConnection("Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none");

        private void AddEditProducts_Load(object sender, EventArgs e)
        {

            string query = "SELECT id,pname,pdesc FROM tbl_products";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, myconn);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();

            command.CommandText = "DELETE FROM tbl_products WHERE id = " + id;

            myconn.Open();

            command.ExecuteNonQuery();

            MessageBox.Show("PRODUCTS SUCCESSFULLY DELETED");

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            pname = textBox2.Text;
            pdesc = textBox3.Text;

            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();

            command.CommandText = "UPDATE tbl_products SET pname = '" + pname + "'" + ", pdesc = '" + pdesc + "'  WHERE id = " + id;

            myconn.Open();

            command.ExecuteNonQuery();

            MessageBox.Show("PRODUCTS SUCCESSFULLY UPDATED");

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pname = textBox2.Text;
            pdesc = textBox3.Text;

            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "INSERT INTO tbl_products (pname,pdesc) VALUES " + "('" + pname + "' ,'" + pdesc + "'" + ");";
            myconn.Open();

            command.ExecuteNonQuery();

            MessageBox.Show("PRODUCTS SUCCESSFULLY ADDED!");

            this.Close();
        }
    }
}
