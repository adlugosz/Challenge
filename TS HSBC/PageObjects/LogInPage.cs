using NUnit.Framework;
using OpenQA.Selenium;

namespace TS_HSBC.PageObjects
{
    public class LogInPage:TestBase
    {
        public LogInPage()
        {
            Assert.IsTrue(driver.PageSource.Contains("Sign in to GitHub · GitHub"));
        }

        public MainPage LogIn()
        {
            Waiter.UntilElementIsPresent(By.Id("login_field"), 10);
            TextBox.SendToTextboxById("login_field", userName);
            TextBox.SendToTextboxById("password", password);           
            Clicker.Click(By.XPath("//*[@type='submit']"));
            Assert.IsTrue(driver.PageSource.Contains("GitHub"));
            return new MainPage();
        }
    }
}
