using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using NLog;
using TS_HSBC.PageObjects;
using OpenQA.Selenium.Interactions;

namespace TS_HSBC
{
    public class TestBase
    {
        public static IWebDriver driver;
        public static Actions action;
        protected static Logger myLogger;
        protected string url;
        public static string repositoryName;
        public static string userName;
        public static string password;

        public TestBase()
        {

        }
        protected TestBase Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);

            url = ConfigurationManager.AppSettings["Url"].ToString();

            myLogger = LogManager.GetCurrentClassLogger();
            myLogger.Info("Inicjalizacja");

            action = new Actions(driver);

            userName = "user1";
            password = "pass1";
            repositoryName = new Random().Next(1, 100).ToString();

            return this;
        }

        public MainPage  GoTo()
        {
            driver.Navigate().GoToUrl(url);          
            return new MainPage();
        }


    }
}
