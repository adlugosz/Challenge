using OpenQA.Selenium;

namespace TS_HSBC
{
    class Clicker : TestBase
    {
        public static void Click(By a_by)
        {
            driver.FindElement(a_by).Click();
        }
    }
}
