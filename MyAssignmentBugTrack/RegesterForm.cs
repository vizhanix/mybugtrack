


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the regester page of the application which is named		  *
 *		RegesterForm															  *
 *																				  *	
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
using System.Windows.Forms;

//name of the project
namespace MyAssignmentBugTrack
{
    public partial class RegesterForm : Form
    {
        //variables declaration field
        string regname = "";
        string regpassword = "";
        string regemail = "";
        string regrole = "";
        int status = 1;

        //constructor
        public RegesterForm()
        {
            InitializeComponent();
        }

        //click event method when the button gets clicked
        //inorder to validate or pass values to the database

            /// <summary>
            /// This is the method then regestration button is clicked, the values passed are stored in a variable.
            /// beforehand the fields are checked whether they are blank or filled, then the process of storing the data to variales takes place
            /// then the data is forwarded to the database to be stored and to be used in the application according to the provided values.
            /// this how the regestration process will take place
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>

        private void btn_regsubmit_Click(object sender, EventArgs e)
        {

            //more variabes declarations
            int count = 0;
            regname = txtbox_name.Text;
            regemail = txtbox_email.Text;
            regpassword = txtbox_pass.Text;
            regrole = comboBox1.Text;

            //condition check whether fields are empty or not
            if (regname == "" || regemail == "" || regpassword == "" || regrole == "")
            {
                MessageBox.Show("Fields can't be empty");
                count++;
            }
            
            if (count == 0)
            {
                //the lines of code to connect to the database and tfetch the data 
                //whenever necessary
                string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
                MySqlConnection myconn = new MySqlConnection(connectString);
                MySqlCommand command = myconn.CreateCommand();
                command.CommandText = "INSERT INTO tbl_users (name, email, password, role, status) VALUES " + "( ' " + regname + " ' , '" + regemail + "' , '" + regpassword + "','" + regrole + "'," + status + ");";
                myconn.Open();

                command.ExecuteNonQuery();

                this.Close();

                Form1 frm = new Form1();
                frm.Show();


            }
        }
    }
}
