using NUnit.Framework;
using NUnit.Framework.Interfaces;
using static NLog.LogManager;
using Framework.Selenium;
using Framework;
using Royale.PageObjects;

namespace Royale.Tests.Base
{
    public abstract class TestBase
    {
        private static readonly NLog.Logger logger = GetCurrentClassLogger();

        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            FW.Init();
        }
        
        [SetUp]
        public virtual void BeforeEach()
        {
            Driver.Init();
            BasePage.Init();
            Driver.Current.Url = $"{FW.Config.Test.Url}/cards";
            
            ConsentBanner consentBanner = new ConsentBanner();
            consentBanner.ContinueBtnClick();
        }

        [TearDown]
        public virtual void AfterEach()
        {
            var result = TestContext.CurrentContext.Result.Outcome.Status;
            //var testParams = TestContext.Parameters.Names;
            var currentTestName = TestContext.CurrentContext.Test.MethodName;
            //var testParamsList = "";

/*             foreach(var param in testParams)
            {
                testParamsList += $"{param} ";
            }

            testParamsList += $"Nos. of test params: {testParams.Count.ToString()}";

            logger.Info($"Current test params: {testParamsList}"); */

            if(result == TestStatus.Failed)
            {
                Driver.TakeScreenshot(currentTestName);
            }

            Driver.Quit();

            logger.Info($"Completed test teardown");
        }
    }
}