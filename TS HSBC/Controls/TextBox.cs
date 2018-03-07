using OpenQA.Selenium;

namespace TS_HSBC
{
    class TextBox : TestBase
    {
        static public void SendToTextboxById(string a_id, string a_text)
        {
            driver.FindElement(By.Id(a_id)).SendKeys(a_text);
        }

        static public void SendToTextBox(By by, string text)
        {
            driver.FindElement(by).SendKeys(text);
        }
    }
}
