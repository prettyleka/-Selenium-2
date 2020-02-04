using AventStack.ExtentReports;

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTak.Helpers;

namespace TikTak.PagesAndComp.Components
{
    public class MoreThings
    {
        public enum E_Tik

        {

            [Description("דיווחים חסרים לרבעון")]
            MissingQuarterlyReports,
            [Description("סגירת רבעון - סרטון הדרכה")]
            TutorialVideo,
            [Description("דו\"ח מצב מפורט")]
            DetailedReport,
            [Description("סיכום דיווחים חודשי")]
            MonthlyReports,
            [Description("ייבוא דיווחים מאקסל")]
            ImportReportsFromExcel,
            [Description("ייבוא דיווחים משעון נוכחות")]
            ImportReportsFromClock,
            [Description("אישורי מחלה")]
            IllnessReport,
            [Description("אישור שעות")]
            HoursApproval
        }

        public Status DropMenu(E_Tik e_Tik)
        {
            string a = string.Format("//a[@class='dropdown-item' and contains(.,'{0}')]", EnumsHelper.GetDescription(e_Tik));
            return SeleniumHelper.OnClick(By.XPath(a));
        }

        public Status ClickMoreThings()
        {
            return SeleniumHelper.OnClick(By.XPath("//button[@id='leftmenubtn']"));
        }

     
    }
}
