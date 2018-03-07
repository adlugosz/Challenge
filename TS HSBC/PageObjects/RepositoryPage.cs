using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TS_HSBC.PageObjects
{
    public class RepositoryPage:TestBase
    {
        public RepositoryPage GoToSettings()
        {
            Tab.ClickTabByName("Settings");
            Waiter.UntilElementIsPresent(By.CssSelector("nav.menu"), 10);
            return this;
        }

        public RepositoryPage GoToPullRequests()
        {
            Tab.ClickTabByName("Pull requests");
            return this;
        }

        public MainPage DeleteRepository()
        {
            
            string deleteButtonXPath = "//ul/li[4]/button";
            string modalDialogXPath = "//ul/li[4]/div[1]//div[@class='Box-body']";
            string inputXPath = "//ul/li[4]/div[1]//div[@class='Box-body']/form/p/input";
            IWebElement modalDialog = driver.FindElement(By.XPath(modalDialogXPath));          
            Waiter.UntilElementIsClickable(By.XPath(deleteButtonXPath),10);
            Clicker.Click(By.XPath(deleteButtonXPath));
            modalDialog.Click();
            Waiter.UntilElementIsPresent(By.XPath(inputXPath), 10);
            TextBox.SendToTextBox(By.XPath(inputXPath), repositoryName + Keys.Enter);
            Waiter.UntilElementIsClickable(By.XPath("//button[@aria-label='Dismiss this message']"),10);
            Assert.IsTrue(driver.PageSource.Contains("was successfully deleted."));
            return new MainPage();
        }

        public void NewPullRequest()
        {
            string newPullRequestXPath = "//div[@class='repository-content ']/div/div/a";
            Waiter.UntilElementIsClickable(By.XPath(newPullRequestXPath),10);
            Clicker.Click(By.XPath(newPullRequestXPath));
        }

        public RepositoryPage OpenReadme()
        {
            Waiter.UntilElementIsClickable(By.LinkText("README.md"),10);
            Clicker.Click(By.LinkText("README.md"));

            return this;
        }

        public RepositoryPage EditReadme()
        {
            string editButtonXPath = "//button[@aria-label='Edit this file']";
            string textXPath = "//div[@class='CodeMirror-lines']";
            Waiter.UntilElementIsClickable(By.XPath(editButtonXPath),10);
            Clicker.Click(By.XPath(editButtonXPath));
            Clicker.Click(By.XPath(textXPath));            
            action.SendKeys("abc").Perform();
         

            return this;
        }

        public RepositoryPage CommitToNewBranch()
        {
            Waiter.UntilElementIsPresent(By.XPath("//dd/div[2]/label/input"),10);
            Clicker.Click(By.XPath("//dd/div[2]/label/input"));
            Waiter.UntilElementIsClickable(By.Id("submit-file"), 5);
            Clicker.Click(By.Id("submit-file"));
            return this;
        }

        public RepositoryPage CreatePullRequest()
        {
            string CreatePullRequestButtonXPath = "//div[@class='form-actions']/button";
            Waiter.UntilElementIsClickable(By.XPath(CreatePullRequestButtonXPath),10);
            Clicker.Click(By.XPath(CreatePullRequestButtonXPath));
            return this;
        }

        public RepositoryPage MergePullRequest()
        {
            string mergeButtonXpath = "//div[@class='merge-message']//button";
            string confirmButtonXpath = "//*[@id='partial-pull-merging']/div[1]/form/div[2]/div[2]/div/div[1]/button";
            Waiter.UntilElementIsClickable(By.XPath(mergeButtonXpath),10);
            Clicker.Click(By.XPath(mergeButtonXpath));

            Waiter.UntilElementIsClickable(By.XPath(confirmButtonXpath), 10);
            Clicker.Click(By.XPath(confirmButtonXpath));
            Waiter.UntilElementIsPresent(By.XPath("//*[@id='partial-pull-merging']/form/div[2]/div/div/h4"),10);
            Assert.IsTrue(driver.PageSource.Contains("Pull request successfully merged and closed"));
            return this;
        }

    }
}
