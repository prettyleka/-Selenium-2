using AventStack.ExtentReports.Configuration;
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace TikTak.Configuration

{
    public class Configuration
    {
        public static string Password
        {
            get { return ConfigurationManager.AppSettings["password"]; }
        }

        public static string UserName
        {
            get { return ConfigurationManager.AppSettings["userName"]; }
        }
        public static string ReportPath
        {
            get { return ConfigurationManager.AppSettings["reportPath"]; }
        }
        public static string LinkToFile
        {
            get { return ConfigurationManager.AppSettings["linkToFile"]; }
        }
    }
}