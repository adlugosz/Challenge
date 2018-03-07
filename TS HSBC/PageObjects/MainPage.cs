using OpenQA.Selenium;
using NUnit.Framework;

namespace TS_HSBC.PageObjects
{
    public class MainPage:TestBase
    {    
        public LogInPage GoToLoginPage()
        {
            UpperMenu.SignIn();

            return new LogInPage();         
        }

        public CreateRepositoryPage StartCreatingNewRepository()
        {
            Waiter.UntilElementIsClickable(By.XPath("//summary[@aria-label='Create new…']"),5);
            UpperMenu.CreateRepository();
            Assert.IsTrue(driver.PageSource.Contains("Create a New Repository"));

            return new CreateRepositoryPage();
        }

        public RepositoryPage OpenRepository()
        {
            Clicker.Click(By.LinkText(repositoryName));

            return new RepositoryPage();
        }
    }
}
