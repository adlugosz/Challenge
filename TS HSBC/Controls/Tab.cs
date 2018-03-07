using OpenQA.Selenium;

namespace TS_HSBC
{
    class Tab
    {
        public static void ClickTabByName(string tabName)
        {
            By tabSelector=null;

            if(tabName=="Settings")
            {
                tabSelector = By.CssSelector("nav > a:nth-child(7)");
            }
            else if(tabName=="Pull requests")
            {
                tabSelector = By.CssSelector("nav > span:nth-child(3) > a > span:nth-child(2)");
            }
            
            Waiter.UntilElementIsClickable(tabSelector,5);
            Clicker.Click(tabSelector);       

        }
    }
}