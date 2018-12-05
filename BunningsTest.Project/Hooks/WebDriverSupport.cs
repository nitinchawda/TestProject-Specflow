using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BunningsTest.Project.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace BunningsTest.Project.Hooks
{
    [Binding]
    public class WebDriverSupport
    {

        public static ChromeDriver driver;
        private static ExtentReports _extent;
        private static ExtentTest featureName;
        private static ExtentTest scenario;

        [BeforeScenario]
        public static void InitializeReport()
        {
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = _extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }
        [BeforeTestRun]
        public static void Setup()
        {
            var dir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")) + "\\";
            var fileName = UtilitySetup.ReportName;
            var htmlReporter = new ExtentHtmlReporter(dir + fileName);
            htmlReporter.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "extent-config.xml"));
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(UtilitySetup.BaseURL);
        }

        [AfterStep]
        public static void InsertReportingSteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException).Fail("Fail");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException).Fail("Fail");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message).Fail("Fail");
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException).Fail("Fail");
            }
        }

        [AfterTestRun]
        public static void TearDown()
        {
            driver.Close();
            driver.Quit();
            _extent.Flush();
        }

        [AfterScenario]
        public static void Dispose()
        {
            //driver.Dispose();
        }
    }
}
