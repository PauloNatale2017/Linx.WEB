using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Linx.Domain.Core.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {

        private IKernel ninjectKernnel;

        public NinjectControllerFactory()
        {
            ninjectKernnel = new StandardKernel();
            AdBinding();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernnel.Get(controllerType);
        }


        private void AdBinding()
        {
            ninjectKernnel.Bind<Linx.Domain.Core.IRepository.IRepository<Linx.Domain.Mapping.Entities.Users>>().To<Linx.Domain.Core.Repository.UsersRepository>();
            ninjectKernnel.Bind<Linx.Domain.Core.IRepository.IRepository<Linx.Domain.Mapping.Entities.UserClaimsConseg>>().To<Linx.Domain.Core.Repository.UserClaimsConsegRepository>();
            ninjectKernnel.Bind<Linx.Domain.Core.IRepository.IRepository<Linx.Domain.Mapping.Entities.Client>>().To<Linx.Domain.Core.Repository.ClientRepository>();
            ninjectKernnel.Bind<Linx.Domain.Core.IRepository.IRepository<Linx.Domain.Mapping.Entities.Token>>().To<Linx.Domain.Core.Repository.TokenRepository>();
            ninjectKernnel.Bind<Linx.Domain.Core.IRepository.IRepository<Linx.Domain.Mapping.Entities.ClientSecret>>().To<Linx.Domain.Core.Repository.ClientSecretRepository>();
        }



    }
}
