using TikTak.PagesAndComp.Components;
using TikTak.Processes;

namespace TikTak.PagesAndComp.Pages
{

    public class BasicPage
    {

        private MoreThings moreThings = null;
        private CheckIt checkIt = null;
        private Calendar calendar = null;
        private ReportsH reportsH = null;
       // private JSONFunc jsonRead = null;
        #region Properties
        public MoreThings MoreThings
        {
            get
            {
                if (moreThings == null)
                {
                    moreThings = new MoreThings();
                }

                return new MoreThings();
            }
        }

        public CheckIt CheckIt
        {
            get
            {
                if (checkIt == null)
                {
                    checkIt = new CheckIt();
                }

                return new CheckIt();
            }
        }

        public Calendar Calendar
        {
            get
            {
                if (calendar == null)
                {
                    calendar = new Calendar();
                }
                return new Calendar();
            }
        }

        public ReportsH ReportsH
        {
            get
            {
                if (reportsH == null)
                {
                    reportsH = new ReportsH();
                }
                return new ReportsH();
            }
        }
    }
}


    #endregion
