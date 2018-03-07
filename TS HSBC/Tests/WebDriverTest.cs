using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using TS_HSBC.PageObjects;

namespace TS_HSBC.Tests
{
    [TestFixture]
    class WebDriverTest : TestBase
    {

        public WebDriverTest() : base()
        {

        }

        [SetUp]
        public void Init()
        {
            Initialize();
        }


        [Test]
        public void LoginAndCreateRepository()
        {
            GoTo().GoToLoginPage().LogIn().StartCreatingNewRepository().CreateSimpleRepository();
        }

        [Test]
        public void LoginAndDeleteRepository()
        {
            LoginAndCreateRepository();//precdonditions
            UpperMenu.SignOut();

            GoTo().GoToLoginPage().LogIn().OpenRepository().GoToSettings().DeleteRepository();
        }

        [Test]
        public void LoginAndEditReadmePullRequestAndMerge()
        {
            
            #region MyRegion
            LoginAndCreateRepository();
            UpperMenu.SignOut();
            #endregion //preconditions

            GoTo().GoToLoginPage().LogIn().OpenRepository()
                .OpenReadme().EditReadme().CommitToNewBranch()
                .CreatePullRequest().MergePullRequest(); 
        }
       
        [TearDown]
        public void Quit()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }

    }
}



