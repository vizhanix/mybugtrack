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

namespace MyAssignmentBugTrack.Programmer
{
    public partial class ProgHomePage : Form
    {
        string name = "";

        public ProgHomePage(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDevBug f = new AddDevBug(name);
            f.MdiParent = this;
            f.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Have Successfully Logged Out");
            Application.Restart();
        }

        private void viewBugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugDevReport f = new BugDevReport();
            f.MdiParent = this;
            f.Show();
        }

        private void searchABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBug f = new SearchBug();
            f.MdiParent = this;
            f.Show();
        }

    /*    private void addBugSolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }*/

        private void ProgHomePage_Load(object sender, EventArgs e)
        {

        }

        private void viewSolutionsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolutionsReport f = new SolutionsReport();
            f.MdiParent = this;
            f.Show();
        }

        private void versionControlSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://github.com/login");

            var title_field1 = driver.FindElementByName("login");
            var title_field2 = driver.FindElementByName("password");


            if (title_field1 != null || title_field2 != null)
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
            }
        }
    }
}
