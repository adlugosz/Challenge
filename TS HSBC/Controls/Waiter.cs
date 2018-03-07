using System;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace TS_HSBC
{
    class Waiter : TestBase
    {
        private static WebDriverWait wait;
        static public void UntilElementIsPresent(By a_by, int a_time)
        {
            myLogger.Log(NLog.LogLevel.Info, "Waiting for element to be present");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(a_time));
            wait.Until(ExpectedConditions.ElementIsVisible(a_by));
            myLogger.Log(NLog.LogLevel.Info, "Element is present");
        }

        public static void UntilElementIsClickable(By a_by, int a_time)
        {
            myLogger.Log(NLog.LogLevel.Info, "Waiting for element to be clickable");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(a_time));           
            wait.Until(ExpectedConditions.ElementToBeClickable(a_by));
            myLogger.Log(NLog.LogLevel.Info, "Element is clicable");
        }
     
    }
}
