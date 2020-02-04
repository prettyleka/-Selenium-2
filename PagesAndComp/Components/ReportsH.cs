using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTak.Processes;

namespace TikTak.PagesAndComp.Components
{
    public class ReportsH
    {
        public Status Reports2()
        {
            ObjectHoursReport hours = new ObjectHoursReport();

            hours.dateD = SeleniumHelper.GetTextFromElement(By.XPath("//*[@id = 'releaselist']//tr[@class = 'ng-star-inserted']/td[2]/span"));
            hours.day = SeleniumHelper.GetTextFromElement(By.XPath("//*[@id = 'releaselist']//tr[@class = 'ng-star-inserted']/td[3]/span"));
            hours.reshet = SeleniumHelper.GetTextFromElement(By.XPath("//*[@id = 'releaselist']//tr[@class = 'ng-star-inserted']/td[5]"));
            hours.activity = SeleniumHelper.GetTextFromElement(By.XPath("//*[@id = 'releaselist']//tr[@class = 'ng-star-inserted']/td[6]"));
            hours.starting = SeleniumHelper.GetTextFromElement(By.XPath("//*[@id = 'releaselist']//tr[@class = 'ng-star-inserted']/td[7]/span"));
            hours.ending = SeleniumHelper.GetTextFromElement(By.XPath("//*[@id = 'releaselist']//tr[@class = 'ng-star-inserted']/td[8]/span"));
            hours.wholeTime = SeleniumHelper.GetTextFromElement(By.XPath("//*[@id = 'releaselist']//tr[@class = 'ng-star-inserted']/td[9]/span"));
            if (SeleniumHelper.ValidDateShowing(hours.dateD))
            {
                Console.WriteLine("dateD");
            }
            else
            {
                Console.WriteLine("dateD not true");
            }
            if (SeleniumHelper.ValidHebrewDay(hours.day))
            {
                Console.WriteLine("day");
            }
            else
            {
                Console.WriteLine("day not true");
            }

            if (SeleniumHelper.ValidClock(hours.starting))
            {
                Console.WriteLine("starting");
            }
            else
            {
                Console.WriteLine("starting not true");
            }
            if(SeleniumHelper.ValidClock(hours.ending))
            {
                Console.WriteLine("ending");
            }
            else
            {
                Console.WriteLine("ending not true");
            }
            if(SeleniumHelper.ValidTimeShowing(hours.wholeTime))
            {
                Console.WriteLine("wholeTime");
            }
            else
            {
                Console.WriteLine("wholeTime not true");
            }

            return Status.Info;
        }
    }
}
