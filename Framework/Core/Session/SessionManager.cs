using Framework.Model.Authentication;
using Framework.ViewModel;
using System;

namespace Framework.Core.Session
{
    public class SessionManager
    {
        public static CurrentUser User
        {
            get
            {
                return SessionHelper.Get("CurrentUser", new CurrentUser());
            }
            set
            {
                SessionHelper.Save("CurrentUser", value, TimeSpan.FromMinutes(300));
            }
        }
    }
}
