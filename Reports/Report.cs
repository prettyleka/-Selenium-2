using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TikTak.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TikTak.DriverManager;


namespace SeleniumProject.Reports

{
    public static class GenerateReport

    {

        private static ExtentHtmlReporter htmlReporter;

        private static ExtentReports extent;

        private static ExtentTest testsSuite;

        [ThreadStatic]

        private static ExtentTest test;

        private static ExtentTest subTest;

        public static string currentReportFolder;

        private static string reportPath;



        private static ExtentTest TestsSuite

        {

            get

            {

                if (testsSuite == null)

                {

                    testsSuite = Extent.CreateTest("unknown");

                }

                return testsSuite;

            }

            set

            {

                testsSuite = value;

            }

        }



        private static ExtentTest Test

        {

            get

            {

                if (test == null)

                {

                    test = TestsSuite;

                }

                return test;

            }

            set

            {

                test = value;

            }

        }



        private static ExtentTest SubTest

        {

            get

            {

                if (subTest == null)

                {

                    subTest = Test;

                }

                return subTest;

            }

            set

            {

                subTest = value;

            }

        }



        private static ExtentReports Extent

        {

            get

            {

                if (extent == null)

                {

                    //string reportFolder = Configuration.ReportPath + DateTime.Today.ToString("dd-MM-yyyy");

                    //if (!Directory.Exists(reportFolder))

                    //{

                    //    Directory.CreateDirectory(reportFolder);

                    //}



                    InitReport();

                }

                return extent;

            }

            set

            {

                extent = value;

            }

        }



        public static object Browser { get; private set; }

        /// <summary>

        /// Initialize the report= create the folder, define parameters

        /// </summary>

        public static void InitReport()
        {

            string directoryPerRunning_Name = "Automation_Report" + DateTime.Now.ToString("d-M-yyyy") + Guid.NewGuid().ToString().Substring(new Random().Next(1, 4), 4) + DateTime.Now.ToString("HHmmss");
            reportPath = Configuration.ReportPath + DateTime.Now.ToString("d-M-yyyy") + "\\" + directoryPerRunning_Name;
            //currentReportFolder = Configuration.ReportPath + DateTime.Today.ToString("dd-MM-yyyy") + "\\AutomationReport_" + DateTime.Now.ToString("HH-mm-ss");   currentReportFolder + "\\report.html"
            htmlReporter = new ExtentHtmlReporter(reportPath + "\\index" + ".html");

            // htmlReporter = new ExtentHtmlReporter(@"\\Bll-keshev1\keshev_dat\TIKBMSIM\Bdikot\Automation\LeumiTradeReports\19-9-2019\Automation_Report19-9-201930af092711" + "\\index" + ".html");

            // Create an object of Extent Reports

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("Host Name", System.Environment.MachineName);

            // extent.AddSystemInfo("Environment", "Production");

            extent.AddSystemInfo("User Name", System.Security.Principal.WindowsIdentity.GetCurrent().Name);

            htmlReporter.Config.DocumentTitle = "TODO ReportTitle";

            // Name of the report

            htmlReporter.Config.ReportName = "TODO ReportName";

            // Dark Theme

            htmlReporter.Config.Theme = Theme.Standard;

        }



        /// <summary>

        /// Starts a tests set

        /// </summary>

        /// <param name="suiteName">the name of the set</param>

        public static void StartTestsSuite(string suiteName)

        {

            Test = null;

            SubTest = null;

            testsSuite = Extent.CreateTest(suiteName);

        }



        /// <summary>

        /// Ends the set of the tests

        /// </summary>

        public static void EndtestsSuite()

        {

            testsSuite = null;

        }



        /// <summary>

        /// Start a new test for the report, if there is no open suit the suit name will be as the test name

        /// </summary>

        /// <param name="testName">the name of the new test</param>

        public static void StartTest(string testName)

        {

            SubTest = null;

            if (testsSuite == null)

                Test = Extent.CreateTest(testName);

            //else

            Test = TestsSuite.CreateNode(testName);

        }



        public static void AddStep(string stepName, Dictionary<string, Status> steps)

        {

            StartStep(stepName);



            foreach (KeyValuePair<string, Status> step in steps)

            {

                SubStep(step.Value, step.Key);

            }

        }



        /// <summary>

        /// Start a child test in the open test

        /// </summary>

        /// <param name="subTestName"></param>

        private static void StartStep(string stepName)

        {

            if (Test == null)

                SubTest = TestsSuite.CreateNode(stepName);

            else

                SubTest = Test.CreateNode(stepName);

        }



        /// <summary>

        /// Reports a log row to the report

        /// </summary>

        /// <param name="status"></param>

        /// <param name="details"></param>

        /// <param name="addScreenshot"></param>

        private static void SubStep(Status status, string details, bool breakIfFail = false, bool addScreenshot = true)

        {

            if (!addScreenshot || DriverManager.Driver == null)

            {

                SubTest.Log(status, details);

            }

            else

            {

                SubTest.Log(status, details + "</td><td width='12%'><a href=\"" + Capture() + "\" target=_blank> screenshot </a></td> ");

            }

            if (breakIfFail && (status == Status.Fail || status == Status.Error))

            {

                //Debugger.Break();

                throw new Exception("Step fail");

            }



            Extent.Flush();

        }





        ///// <summary>

        ///// Reports a log row to the report according to the bool value

        ///// </summary>

        ///// <param name="success"></param>

        ///// <param name="details"></param>

        ///// <param name="addScreenshot"></param>

        //public static void Log(bool success, string details, bool addScreenshot = true)

        //{

        //    Status Status;

        //    if (success)

        //    {

        //        Status = Status.Pass;

        //    }

        //    else

        //    {

        //        Status = Status.Fail;

        //        Debugger.Break();

        //    }



        //    Log(Status, details, addScreenshot);

        //}



        public static void AssignCategory(string categoryName)

        {

            test.AssignCategory(categoryName);

        }



        /// To capture the screenshot for extent report and return actual file path

        private static string Capture()

        {

            string localpath = "";

            try

            {

                ITakesScreenshot ts = (ITakesScreenshot)DriverManager.Driver;

                Screenshot screenshot = ts.GetScreenshot();

                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");

                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Defect_Screenshots\\");

                //string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Defect_Screenshots\\" + screenShotName + ".png"; + ".png"   \screenshots

                string finalpth = reportPath + @"\screenshot" + DateTime.Now.ToString("dd_MM_yy__hh_mm_ss") + ".png";

                localpath = new Uri(finalpth).LocalPath;

                screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);

            }

            catch (Exception e)

            {

                throw (e);

            }

            return localpath;

        }



    }

}