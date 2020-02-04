using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTak.PagesAndComp.Components;

namespace TikTak.Processes
{
    class LogInProcess
    {
        public static Dictionary<string, Status> LoginToNess()
        {
            Dictionary<string, Status> result = new Dictionary<string, Status>();
            LogIn LI = new LogIn();
            result.Add("Navigate To Home Page", LI.NavigateToHomePage());
            result.Add("Insert User", LI.InsertUser(Configuration.Configuration.UserName));
            result.Add("Insert Password", LI.InsertPassword(Configuration.Configuration.Password));
            result.Add("Click Enter", LI.ClickEnter());
            return result;
        }

    }
}
    