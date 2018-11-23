


/************************************************************************************
 ************************************************************************************
 *										  										  *
 *		              				                                              *
 *				 BUG TRACKING APPLICATION 	 Author: Mixon Tandukar 		      *
 *				    						         						      * 				
 *						      Date: 2018/23/11  								  *		
 *																				  *
 *																				  *
 *		This form is the programmer home page of the application                  *
 *		 which is named ProgHomePage for the developer role                       *
 *																		          *	
 *																				  *
 ************************************************************************************/
using MyAssignmentBugTrack.Developer;
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
namespace MyAssignmentBugTrack.Programmer
{
    public partial class ProgHomePage : Form
    {
        string name = "";

        //parameterized constructor
        public ProgHomePage(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        //method that runs when report bug menu strip is clicked 
        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDevBug f = new AddDevBug(name);
            f.MdiParent = this;
            f.Show();
        }

        //method that runs when logout menu strip is clicked 
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Have Successfully Logged Out");
            Application.Restart();
        }

        //method that runs when view bug menu strip is clicked 
        private void viewBugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugDevReport f = new BugDevReport();
            f.MdiParent = this;
            f.Show();
        }

        //method that runs when search a bug menu strip is clicked 
        private void searchABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBug f = new SearchBug();
            f.MdiParent = this;
            f.Show();
        }

        /*    private void addBugSolutionToolStripMenuItem_Click(object sender, EventArgs e)
            {

            }*/


        /// <summary>
        /// This is the form method that loads the form for the deveoper that is the homepage for the developer user role.
        /// the devloper can report a bug, search a bug, view solutions provided, view bugs report, connect to the version control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ProgHomePage_Load(object sender, EventArgs e)
        {

        }

        //method that runs when view solutions menu strip is clicked 
        private void viewSolutionsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolutionsReport f = new SolutionsReport();
            f.MdiParent = this;
            f.Show();
        }

        //method that runs when version control menu strip is clicked 
        private void versionControlSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
    }
}
