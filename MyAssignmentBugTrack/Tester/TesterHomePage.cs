


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the home page of tester of  the application which is named   *
 *		TesterHomePage for the tester role                  					  *
 *																				  *	
 *																				  *
 ************************************************************************************/

using MyAssignmentBugTrack.Tester;
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

//namespace of the application
namespace MyAssignmentBugTrack
{
    public partial class TesterHome : Form
    {

        //variable declaration
        private string name;
        
        //constructor with the name as its parameter
        public TesterHome(string name)
        {
            InitializeComponent();
            this.name = name;
            
        }

        /// <summary>
        /// This is the form method that loads the form for the tester that is the homepage for the tester user role.
        /// the tester can report a bug, search a bug, view solutions provided, view bugs report, connect to the version control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        //method for the actions when a field in the menustrip is clicked
        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddBug class load when one of the menustrip is clicked
            AddBug f = new AddBug(name);
            f.MdiParent = this;
            f.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //logout functionality when logout in the menustrip is clicked
            MessageBox.Show("You Have Successfully Logged Out");
            Application.Restart();

        }


        //-------****** View Bugs Report Method ******--------
        private void viewProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugReport f = new BugReport();
            f.MdiParent = this;
            f.Show();
        }

        private void searchBugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBug f = new SearchBug();
            f.MdiParent = this;
            f.Show();
        }

        private void viewSolutionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSolutions f = new ViewSolutions();
            f.MdiParent = this;
            f.Show();
        }

        //this is the method that calls the github repo in which the project is stored
        private void versionControlSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            int count = 0;
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://github.com/login");

            var title_field1 = driver.FindElementByName("login");
            var title_field2 = driver.FindElementByName("password");


            if ((title_field1 != null || title_field2 != null ) && count == 0)
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

            if(count == 1)
            {
                driver.Navigate().GoToUrl("https://github.com/vizhanix/mybugtrack");
            }

        }
    }
}
