using Framework.Model.Authentication;
using Framework.ViewModel;
using System.Linq;

namespace Framework.Service.Authentication
{
    public interface IUserService
    {
        CurrentUser Get(string identificationNumber, string password);
    }

    public class UserService : Service, IUserService
    {
        public CurrentUser Get(string identificationNumber, string password)
        {
            var user = UnitOfWork.GetRepository<User>().GetAll(x => x.IdentificationNumber == identificationNumber && x.Password == password)
              .Select(x => new CurrentUser()
              {
                  ID = x.ID,
                  Email = x.Email,
                  FirstName = x.FirstName,
                  LastName = x.LastName,
                  IdentificationNumber = x.IdentificationNumber,
                  UserName = x.UserName,
                  Password = x.Password,
                  Phone = x.Phone
              }).FirstOrDefault();

            return user;
        }
    }
}
