


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the admin homnepage of the application which is named        *
 *		AdminHome for the admin role                                              *
 *																		          *	
 *																				  *
 ************************************************************************************/

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace of the project
namespace MyAssignmentBugTrack.Admin
{
    public partial class AdminHome : Form
    {
        //variable declaration
        string name = "";

        //default constructor
        public AdminHome()
        {
            InitializeComponent();
        }

        //parameterized constructor
        public AdminHome(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        //this is the method for the menustrip to choose the options for the application to go to addadminbug page
        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Add admin bug*/
            AddAdminBug f = new AddAdminBug(name);  
            f.MdiParent = this;
            f.Show();
        }

        /// <summary>
        /// This is the form method that loads the form for the admin that is the homepage for the admin user role.
        /// the admin can report a bug, search a bug, view solutions provided, view bugs report, connect to the version control, see total chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        //this is the method for the menustrip to choose the options for the application to go to bugadminreport page
        private void viewBugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*View Bugs Report*/
            BugAdminReport f = new BugAdminReport();
            f.MdiParent = this;
            f.Show();
        }

        //this is the method for the menustrip to choose the options for the application to go to adminsolutionsreport
        private void viewSolutionsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*View Solutions Report*/
            AdminSolutionsReport f = new AdminSolutionsReport();
            f.MdiParent = this;
            f.Show();
        }

        //this is the method for the menustrip to choose the options for the application to go to searchbug page
        private void searchABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Search A Bug*/
            SearchBug f = new SearchBug();
            f.MdiParent = this;
            f.Show();
        }

        //this is the method for the menustrip to choose the options for the application to logout
        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*Logout*/
            MessageBox.Show("You Have Successfully Logged Out");
            Application.Restart();
        }

        ////this is the method for the menustrip to choose the options for the application to go to addeditproducts page
        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditProducts f = new AddEditProducts();
            f.MdiParent = this;
            f.Show();
        }

        //this is the method for the menustrip to choose the options for the application to go to the version control page through Chrome web browser
        private void versionControlSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variables declaration
            int count = 0;
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://github.com/login");

            var title_field1 = driver.FindElementByName("login");
            var title_field2 = driver.FindElementByName("password");


            if ((title_field1 != null || title_field2 != null) && count == 0)
            {
                //Now perform actions on this element

                Actions actions = new Actions(driver);
                actions.MoveToElement(title_field1);
                actions.Click();
                actions.SendKeys("mixontandukar@gmail.com");

                actions.MoveToElement(title_field2);
                actions.Click();
                actions.SendKeys("Abcd1234@@,.");

                actions.Build().Perform();

                IWebElement element = driver.FindElementByName("commit");
                element.Click();

                count++;
            }

            if (count == 1)
            {
                driver.Navigate().GoToUrl("https://github.com/vizhanix/mybugtrack");
            }
        }

        //this is the method for the menustrip to choose the options for the application to go to charts 
        private void feature1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart1 f = new Chart1();
            f.MdiParent = this;
            f.Show();
        }
    }
}
