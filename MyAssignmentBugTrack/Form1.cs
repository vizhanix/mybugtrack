


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the login page of the application which is named 			  *
 *		form1																	  *
 *																				  *	
 *																				  *
 ************************************************************************************/

 

using MyAssignmentBugTrack.Admin;
using MyAssignmentBugTrack.Programmer;
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
    public partial class Form1 : Form
    {

        //constructor
        public Form1()
        {
            InitializeComponent();
        }

        //method for the form load
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //method for the picturebox load 
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// This is the method when the login button is clicked the data that user has entered
        /// will be stored in a variable and is passed in an sql query to fetch the data from the database
        /// whether the two, provided and the retrived values match or not. if match login will take user to the 
        /// homepage as per the user role or there will be an error message thrown 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
     

        //method for the button click
        private void btn_login_Click(object sender, EventArgs e)
        {
            string email = txtbox_email.Text;
            string password = txtbox_pass.Text;
            string comboboxtext = comboBox1.Text;

            /*
             * connection string to connect to the database
             * whenever required to fetch values from the database
             */

            string connectString = "Data Source=localhost;Database = bugtrackapp ;User Id= root;Password=;SslMode=none";
            MySqlConnection myconn = new MySqlConnection(connectString);
            MySqlCommand command = myconn.CreateCommand();
            command.CommandText = "select id,name,role,password from tbl_users where email ='" + email + "' and password = '" + password + "'";
            try
            {
                myconn.Open(); //opening of the connection
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message); //error message when there is some error
            }

            //MySqldataReader class in order to read the values
            //from the fetched query above 

            MySqlDataReader reader = command.ExecuteReader();

            string roletype = "";
            string name = "";
           // string pass = "";           
           
            while (reader.Read())
            {
                name = reader["name"].ToString();
                roletype = reader["role"].ToString();
              //  pass = reader.GetString("password");
            }

            
            //validatioin if condition if the name field is empty
            if (name == "")
            {
                MessageBox.Show("Please chech your login credentials");              
            }         

            /*if contition to check whether the user role selected, and the stored data in the 
             database matches or not */
            if (comboboxtext == "admin" && roletype == "admin")
            {
                MessageBox.Show("Logged in as : " + comboboxtext);
                AdminHome f = new AdminHome(name);
                this.Hide();
                f.Show();


            }
            /*if contition to check whether the user role selected, and the stored data in the 
            database matches or not */
            else if (comboboxtext == "tester" && roletype == "tester")
            {
                MessageBox.Show("Logged in as : " + comboboxtext);
                TesterHome f = new TesterHome(name);
                this.Hide();
                f.Show();
            }
            /*if contition to check whether the user role selected, and the stored data in the 
            database matches or not */
            else if (comboboxtext == "developer" && roletype == "developer")
            {
                MessageBox.Show("Logged in as : " + comboboxtext);
                ProgHomePage f = new ProgHomePage(name);
                this.Hide();
                f.Show();
                    
            }
            else
            {
                MessageBox.Show("No Records Found!!");
            }
        }

        /*To method to display the regester form when the button is clicked*/
        private void btn_regester_Click(object sender, EventArgs e)
        {
            RegesterForm regfrm = new RegesterForm();
            this.Hide();
            regfrm.Show();
         
        }
    }
}
