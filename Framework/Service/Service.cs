using System.Web.Mvc;

namespace Framework.Service
{
    public abstract class Service 
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return DependencyResolver.Current.GetService<IUnitOfWork>();
            }
        }
    }
}
