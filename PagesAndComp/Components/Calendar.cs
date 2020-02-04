using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTak.PagesAndComp.Components
{
    public class Calendar
    {
        public Status MonthAndYear(string year, string month)
        {
            if (SeleniumHelper.ValidYear(year))
            {
                SeleniumHelper.OnClick(By.XPath("//*[@class = 'btn btn-default btn-secondary btn-sm']"));
                SeleniumHelper.OnClick(By.XPath("//*[@class = 'btn btn-default btn-sm']"));
                SeleniumHelper.OnClick(By.XPath("//table[@role = 'grid']/tbody//span[contains(. ," + year + ")]"));
                string[] monthName = { "ינואר", "פברואר", "מרץ", "אפריל", "מאי", "יוני", "יולי", "אוגוסט", "ספטמבר", "אוקטובר", "נובמבר", "דצמבר" };
                foreach (string Name in monthName)
                {
                    if (month == Name)
                    {
                        SeleniumHelper.OnClick(By.XPath("//table[@role= 'grid']//span[contains(text()," + month + ")]"));

                    }
                    else
                    {
                        Console.WriteLine("your month name is wrong");
                    }
                }
            }
            else
            {
                Console.WriteLine("Year number must be in range from 2000 to 2029");
                return Status.Fail;
            }

            return Status.Info;
        }

        public Status PickAndClickDay(string day)
        {
            if (SeleniumHelper.ValidDay(day))
            {
              
                SeleniumHelper.OnClick(By.XPath("//*[@role = 'grid']/tbody//span[contains(. ," + day + ")]"));
                return Status.Pass;
            }
            else
            {
                Console.WriteLine("Your number is wrong");
                return Status.Fail;
            }

        }

        public Status RandomMonthYear()
        {
            Random rand = new Random();
            //Month
               int m = rand.Next(1, 12);
                Console.WriteLine(m);
            //Year
                int y = rand.Next(2020, 2039);
                Console.WriteLine(y);
            return Status.Info;

        }
    }
}

