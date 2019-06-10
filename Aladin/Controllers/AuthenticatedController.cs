using Aladin.Core.Filter;
using Framework.Model.Authentication.Enum;

namespace Aladin.Controllers
{
    [CustomAuthentication(AuthenticationType.Secure), ValidateModel]
    public class AuthenticatedController : BaseController
    {

    }
}