using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTak.PagesAndComp.Components
{
    public class CheckIt
    {
        public Status TitleCheck()
        {
            return SeleniumHelper.TextIsCorrect(By.XPath("//div[@class ='modal-title']/div[contains( . ,'ייבוא דיווחים משעון נוכחות' )]"), "ייבוא דיווחים משעון נוכחות");

        }

        public Status AscendingOrder()
        {
            var dates = SeleniumHelper.FindElements(By.XPath("//table[@id='releaselist']//tr[@class='ng-star-inserted']//td[2]//span"));
            var d = dates.Select(t => DateTime.Parse(t.Text)).ToList();
            foreach (var day in d)
            {
                Console.WriteLine(day.ToString());
            };
            var Ordered = dates.Select(t => DateTime.Parse(t.Text)).OrderBy(y => y.DayOfYear).ToList();
            foreach (var newDay in Ordered)
            {
                Console.WriteLine(newDay.ToString());
            };
            if (d.Equals(Ordered))
            {
                Console.WriteLine(true);
                return Status.Pass;
            }
            else
            {
                Console.WriteLine(false);
                return Status.Fail;
            }
        }

        public Status HoursRelease()
        {
            SeleniumHelper.OnClick(By.XPath("//*[@id = 'releasehoursbtn']"));
            return SeleniumHelper.TextIsCorrect(By.XPath("//h4/text()[contains(. , 'שחרור דיווחים עבור חודש דצמבר 2020')]"), "שחרור דיווחים עבור חודש דצמבר 2020");
        }


        public Status IWillCheckYouAll()
        {
            //Hebrew letter
            string x = SeleniumHelper.GetTextFromElement(By.XPath("//*[@class = 'subcon longTitle']/table[@id = 'releaselist']/tbody/tr/td[3]"));
            if (SeleniumHelper.ValidHebrewDay(x))
            {
                Console.WriteLine("Hebrew - yes");
            }
            //HH:mm 
            string y = SeleniumHelper.GetTextFromElement(By.XPath("//*[@class = 'subcon longTitle']/table[@id = 'releaselist']/tbody/tr/td[7]"));
            if (SeleniumHelper.ValidClock(y))
            {
                Console.WriteLine("HH:MM - yes");
            }
            //Time Show
            string z = SeleniumHelper.GetTextFromElement(By.XPath("//*[@class = 'subcon longTitle']/table[@id = 'releaselist']/tbody/tr/td[9]"));
            if (SeleniumHelper.ValidTimeShowing(z))
            {
                Console.WriteLine("TimeShow - yes");
            }
            //Date Show
            string d = SeleniumHelper.GetTextFromElement(By.XPath("//*[@class = 'subcon longTitle']/table[@id = 'releaselist']/tbody/tr/td[2]"));
            if (SeleniumHelper.ValidDateShowing(d))
            {
                Console.WriteLine("DateShow - yes");
            }
            return Status.Info;
        }

        public Status setFreeHours()
        {
            SeleniumHelper.OnClick(By.XPath("//button[@id = 'releasehoursbtn']"));
            return Status.Info;
        }

        public Status CheckTheFebruarTitle()
        {
            string x = SeleniumHelper.GetTextFromElement(By.XPath("//*[@id = 'releaselist']//tr[@class = 'ng-star-inserted']/td[2]/span"));
            if (x == "שחרור דיווחים עבור חודש פברואר 2020")
            {
                Console.WriteLine("Its true");
            }
            else
            {
                Console.WriteLine("Try and Check smth else");
            }
            return Status.Info;
        }
        public Status CheckBoxInFreeHours(string date)
        {
            SeleniumHelper.OnClick(By.XPath("//tbody/tr[@class = 'ng-star-inserted']//*[contains(., '" + date + "')]/preceding-sibling::td"));
            return Status.Info;
        }

        public Status BitulInFreeHours()
        {
            SeleniumHelper.OnClick(By.XPath("//*[@class = 'col-md-12 text-center']/button[contains(text(), 'ביטול')]"));
            SeleniumHelper.ElementIsExists(By.XPath("//div[@class = 'modal fade in']/div[@class = 'modal-dialog modal-lg']"));
            return Status.Info;
        }

        public Status CleenInFreeHours()
        {
            SeleniumHelper.OnClick(By.XPath("//*[@class = 'col-md-12 text-center']/button[contains(text(), 'נקה')]"));
            SeleniumHelper.ElementIsExists(By.XPath("//input[@class = 'mat-checkbox-input cdk-visually-hidden' and @aria-checked = 'false']"));
            return Status.Info;
        }
    }
}
