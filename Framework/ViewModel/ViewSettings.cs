namespace Framework.ViewModel
{
    public class ViewSettings
    {
        public ViewSettings(string pageTitle,string submitAction,string submitTitle)
        {
            PageTitle = pageTitle;
            SubmitAction = submitAction;
            SubmitTitle = submitTitle;
        }

        public ViewSettings(string pageTitle, string gridTitle)
        {
            PageTitle = pageTitle;
            GridTitle = gridTitle;
        }

        public ViewSettings(string pageTitle)
        {
            PageTitle = pageTitle;
        }

        public string PageTitle { get; set; }
        public string SubmitAction { get; set; }
        public string SubmitTitle { get; set; }
        public string GridTitle { get; set; }
    }
}
