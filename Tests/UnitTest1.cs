using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TikTak.PagesAndComp.Components;
using TikTak.Processes;
using OpenQA.Selenium;

namespace TikTak
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           HomePage HP = new HomePage();
            LogInProcess.LoginToNess();
            HP.GoToTikTak();
            SeleniumHelper.OnClick(By.XPath("//*[@class = 'btn btn-sm btn-default ng-star-inserted']/span[contains(text(), '30')]"));
            HP.MoreThings.ClickMoreThings();
            HP.MoreThings.DropMenu(MoreThings.E_Tik.ImportReportsFromClock);
            //HP.CheckIt.TitleCheck();*/
            //HP.checkIt.AscendingOrder();
            // HP.Calendar.MonthAndYear("2020", "ינואר");
            //  HP.Calendar.PickAndClickDay("27");
            //HP.CheckIt.HoursRelease();
            //JSONFunc.GetKeyFromJ("0900");
            // HP.CheckIt.IWillCheckYouAll();
            // HP.Calendar.RandomMonthYear();
            HP.ReportsH.Reports2();




             SeleniumHelper.QuitDriver();



        }
    }
}
