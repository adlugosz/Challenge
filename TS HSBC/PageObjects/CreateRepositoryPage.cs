using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS_HSBC.PageObjects
{
    public class CreateRepositoryPage:TestBase
    {
        string repoNametxtbxXpath = "//input[@name='repository[name]']";
        string createRepoButtonXpath = "//*[@id='new_repository']/div[4]/button";
        public void CreateSimpleRepository()
        {
            Waiter.UntilElementIsClickable(By.XPath(repoNametxtbxXpath), 10);
            TextBox.SendToTextBox(By.XPath(repoNametxtbxXpath), TestBase.repositoryName);
            Clicker.Click(By.Id("repository_auto_init"));
            Waiter.UntilElementIsClickable(By.XPath(createRepoButtonXpath), 10);
            Clicker.Click(By.XPath(createRepoButtonXpath));
            Assert.IsTrue(driver.PageSource.Contains("README.md"));// assertion to change because it's not nice
        }
    }
}
