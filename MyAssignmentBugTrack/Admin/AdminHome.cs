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

namespace MyAssignmentBugTrack.Admin
{
    public partial class AdminHome : Form
    {
        string name = "";

        public AdminHome()
        {
            InitializeComponent();
        }

        public AdminHome(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Add admin bug*/
            AddAdminBug f = new AddAdminBug(name);  
            f.MdiParent = this;
            f.Show();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void viewBugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*View Bugs Report*/
            BugAdminReport f = new BugAdminReport();
            f.MdiParent = this;
            f.Show();
        }

        private void viewSolutionsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*View Solutions Report*/
            AdminSolutionsReport f = new AdminSolutionsReport();
            f.MdiParent = this;
            f.Show();
        }

        private void searchABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Search A Bug*/
            SearchBug f = new SearchBug();
            f.MdiParent = this;
            f.Show();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*Logout*/
            MessageBox.Show("You Have Successfully Logged Out");
            Application.Restart();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditProducts f = new AddEditProducts();
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
