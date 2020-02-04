
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using TikTak.PagesAndComp;
using TikTak.Helpers;
using TikTak.PagesAndComp.Pages;

namespace TikTak.PagesAndComp.Components
{
    class HomePage : BasicPage
    {


        public Status GoToTikTak()
        {
            return SeleniumHelper.OnClick(By.XPath("//*[contains(@class, 'col-md-full-right')]//span[text() = 'TIK TAK']"));
        }


    }
}