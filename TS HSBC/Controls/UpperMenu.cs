using OpenQA.Selenium;

namespace TS_HSBC
{
    public class UpperMenu:TestBase
    {
        private static string AddElementXPath = "//summary[@aria-label='Create new…']";
        private static string ProfileMenuXPath = "//summary[@aria-label='View profile and more']";
        private static string PrefixOfElementsToSelect = "//*[@id='user-links']/li[2]/details/ul/a"; //must add the index at the end f.ex. [1]

        public static void CreateRepository()
        {
            Waiter.UntilElementIsClickable(By.XPath(AddElementXPath), 5);
            driver.FindElement(By.XPath(AddElementXPath)).Click();
            driver.FindElement(By.XPath(PrefixOfElementsToSelect + "[1]")).Click();
        }

        public static void SignOut()
        {
            Waiter.UntilElementIsClickable(By.XPath(ProfileMenuXPath), 5);
            driver.FindElement(By.XPath(ProfileMenuXPath)).Click();
            driver.FindElement(By.CssSelector("button[type='submit'")).Click();
        }

        public static void SignIn()
        {
            Waiter.UntilElementIsClickable(By.LinkText("Sign in"), 10);
            Clicker.Click(By.LinkText("Sign in"));
        }
    }

}
