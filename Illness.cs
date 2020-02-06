using AventStack.ExtentReports;
using OpenQA.Selenium;
using System.ComponentModel;
using TikTak.Helpers;

namespace TikTak.PagesAndComp.Pages
{
    public class Illness
    {
        public enum E_Illness
        {
            [Description("דיווח מחלה חדש")]
            NewDiseaseReport,
            [Description("הוספת מסמך")]
            AddADocument,
            [Description("כל הדיווחים")]
            AllReports,
            [Description("חסר מסמך")]
            DeleteReport,
            [Description("מצורף מסמך")]
            AttachedDocument,
            [Description("לדיווח שעות")]
            ForReportingHours
            

,
        }

        public Status IllnessUpperTool(E_Illness e_Illness)
        {
            string a = string.Format("//header//div[@class ='top-header actions']//*[contains(text(), '{0}')]", EnumsHelper.GetDescription(e_Illness));
            return SeleniumHelper.OnClick(By.XPath(a));

        }

        public Status EnterToTheIllnessPage()
        {
            SeleniumHelper.OnClick(By.XPath("//button[@id = 'leftmenubtn']"));
            SeleniumHelper.OnClick(By.XPath("//*[@role = 'menuitem']/a[contains(., 'אישורי מחלה')]"));
            return Status.Info;
        }
    }
}
