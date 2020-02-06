using AventStack.ExtentReports;
using iTextSharp.tool.xml.html;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace TikTak.PagesAndComp.Components
{
    public static class IllnessJSONFunc
    {
        public static Status GetKeyFromJSON(string select, string from, string to, string startingHours, string endingHours, string activity)
        {
            string json = @"C:\Users\User\Desktop\source\repos\TikTak\NewIllnessDocument.json";
            JObject jsonString = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(json).ToString());        
            IList<string> keys = jsonString.Properties().Select(p => p.Name).ToList();
            char[] charsToTrim = { '\r', '\n', '/', ',', '[', ']', '"', '\'', ' '};


            string[] a = jsonString[keys[0]].ToString().Split(',').Select(item => item.Trim(charsToTrim)).ToArray();
            string[] b = jsonString[keys[1]].ToString().Split(',').Select(item => item.Trim(charsToTrim)).ToArray();
            string[] c = jsonString[keys[2]].ToString().Split(',').Select(item => item.Trim(charsToTrim)).ToArray();
            string[] d = jsonString[keys[3]].ToString().Split(',').Select(item => item.Trim(charsToTrim)).ToArray();
            string[] e = jsonString[keys[4]].ToString().Split(',').Select(item => item.Trim(charsToTrim)).ToArray();
            string[] f = jsonString[keys[5]].ToString().Split(',').Select(item => item.Trim(charsToTrim)).ToArray();
            string[] g = jsonString[keys[6]].ToString().Split(',').Select(item => item.Trim(charsToTrim)).ToArray();

            if (a.Contains(select))
            {
                SeleniumHelper.OnClick(By.XPath("//*[@class = 'dates-range-selection']//*[contains(text(), '" + select + "')]"));
            }
            if (b.Contains(from))
            {
                SeleniumHelper.InsertText(from, By.XPath("//div[@class='div-container dates-container']/div/*[contains(text(), 'מתאריך')]/parent::div//input"));
                Console.WriteLine("from");
            }
            if (c.Contains(to))
            {
              SeleniumHelper.InsertText(to, By.XPath("//div[@class='div-container dates-container']/div/*[contains(text(), 'עד תאריך')]/parent::div//input"));
                Console.WriteLine("to");
            }
            /*if (d.Contains(date))
            {
                SeleniumHelper.OnClick(By.XPath("//*[@class = 'mat-form-field-suffix ng-tns-c4-5 ng-star-inserted']//*[@class = 'mat-datepicker-toggle-default-icon ng-star-inserted']"));
                SeleniumHelper.OnClick(By.XPath("//*[@class = 'mat-calendar-content']//*[contains(text(), '"+date+"')]"));

            }*/
            if (e.Contains(endingHours))
            {
                SeleniumHelper.OnClick(By.XPath("//*[@class='div-container hours-container']/div/*[contains(text(), 'שעת התחלה')]/parent::div//input"));
                SeleniumHelper.InsertText(startingHours, By.XPath("//div[@class='div-container hours-container']/div/*[contains(text(), 'שעת התחלה')]/parent::div//input"));
                //SeleniumHelper.OnClick(By.XPath("//div[@class='div-container hours-container']/div/*[contains(text(), 'שעת התחלה')]/parent::div//input"));
            }
            if (f.Contains(startingHours))
            {
                SeleniumHelper.OnClick(By.XPath("//div[@class='div-container hours-container']/div/*[contains(text(), 'שעת סיום')]/parent::div//input"));
                SeleniumHelper.InsertText(endingHours, By.XPath("//div[@class='div-container hours-container']/div/*[contains(text(), 'שעת סיום')]/parent::div//input"));
                //SeleniumHelper.OnClick(By.XPath("//div[@class='div-container hours-container']/div/*[contains(text(), 'שעת סיום')]/parent::div//input"));

            }
            if (g.Contains(activity))
            {
                SeleniumHelper.OnClick(By.XPath("//*[@class = 'div-container activity-container']//*[@class= 'mat-form-field-flex']"));
                SeleniumHelper.OnClick(By.XPath("//*[@class = 'ng-tns-c5-9 ng-trigger ng-trigger-transformPanel mat-select-panel mat-primary']//*[contains(text(), '"+activity+"')]"));
            }

            return Status.Info;
        }

        public static Status AttachFile()
        {
            DriverManager.DriverManager.Driver.FindElement(By.XPath("//div[@class = 'div-container input-attach-new-report']//*[@id = 'file']")).SendKeys("C:/Users/User/Downloads/Screenshot (1).png");

            return Status.Info;

        }
    }
}

