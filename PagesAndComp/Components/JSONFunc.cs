using AventStack.ExtentReports;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TikTak.Helpers;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Specialized;
using OpenQA.Selenium;



//using JObject = TikTak.Processes.JObject;



namespace TikTak.PagesAndComp.Components
{
    public static class JSONFunc
    {
        public static Status GetKeyFromJ(string num)
        {
            SeleniumHelper.OnClick(By.XPath("//*[@id = '0223']"));
            SeleniumHelper.OnClick(By.XPath("//input[@class = 'form-control networkinput ng-untouched ng-pristine ng-invalid']"));
            string json = @"C:\Users\User\Desktop\source\repos\TikTak\Preferred.json";
             JObject giveKey = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(json).ToString());
            string x = giveKey.Children().FirstOrDefault().ToString();
           string[] z =  x.Split(new Char[] { ' ', '"', '\r', '\n', '[', ']', '"' });
            foreach(string c in z)
            {
                if (c == num)
                {
                    IList<string> keys = giveKey.Properties().Select(p => p.Name).ToList();
                    string k = keys[0];
                    SeleniumHelper.InsertText(k, By.XPath("//input[@placeholder= 'הזן רשת לחיפוש']"));
                    SeleniumHelper.WaitDocumentLoading();
                    SeleniumHelper.OnClick(By.XPath("//*[@class = 'resultitem ng-star-inserted']/div[contains(text(), '" + k + "')]"));
                    SeleniumHelper.WaitDocumentLoading();
                    SeleniumHelper.OnClick(By.XPath("//div[@class = 'mat-select-arrow']"));
                    return SeleniumHelper.OnClick(By.XPath("//span[contains(text(), '" + num + "')]"));
                }
                else
                {
                    string json1 = @"C:\Users\User\Desktop\source\repos\TikTak\NetWorksAndActions.json";
                    JObject giveKey1 = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(json1).ToString());
                    string y = giveKey1.Children().FirstOrDefault().ToString();
                    string[] f = y.Split(new Char[] { ' ', '"', '\r', '\n', '[', ']'});
                    foreach (string t in f)
                    {
                        if (t == num)
                        {
                            IList<string> keys = giveKey1.Properties().Select(p => p.Name).ToList();
                            string k = keys[0];
                            SeleniumHelper.InsertText(k, By.XPath("//input[@placeholder= 'הזן רשת לחיפוש']"));
                            SeleniumHelper.WaitDocumentLoading();
                            SeleniumHelper.OnClick(By.XPath("//*[@class = 'resultitem ng-star-inserted']/div[contains(text(), '"+k+"')]"));
                            SeleniumHelper.WaitDocumentLoading();
                            SeleniumHelper.OnClick(By.XPath("//div[@class = 'mat-select-arrow']"));
                            return SeleniumHelper.OnClick(By.XPath("//span[contains(text(), '"+num+"')]"));

                        }


                    }

                }
            }
            return Status.Info;





        }
    }
}






    




