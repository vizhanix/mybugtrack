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

namespace MyAssignmentBugTrack
{
    public partial class TesterHome : Form
    {
        private string name;
        

        public TesterHome(string name)
        {
            InitializeComponent();
            this.name = name;
            
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBug f = new AddBug(name);
            f.MdiParent = this;
            f.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
