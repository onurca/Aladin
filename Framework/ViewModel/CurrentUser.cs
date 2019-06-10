using Framework.Core.Session;
using Framework.Model;
using System;
using System.Linq;

namespace Framework.ViewModel
{
    public class CurrentUser : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string IdentificationNumber { get; set; }
        public string Phone { get; set; }
        public Guid[] Roles { get; set; } = new Guid[] { };

        public bool IsInRole(Guid[] role)
        {
            return Roles.Any(x => role.Contains(x));
        }

        public bool IsAuthenticated
        {
            get
            {
                return !IsNew;
            }
        }

        public void Clear()
        {
            SessionHelper.Remove("CurrentUser");
        }
    }
}
