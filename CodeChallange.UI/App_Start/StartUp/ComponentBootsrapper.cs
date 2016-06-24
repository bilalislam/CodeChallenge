using System.Data.Entity;
using System.Web.Mvc;
using CaptchaMvc.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CodeChallange.Core.UoW;
using CodeChallange.Entity;
using CodeChallange.Service.UserService;
using CodeChallenge.Data.CoreRepository;
using CodeChallenge.Data.UoW;
using CodeChallenge.Data.UserRepository;

namespace CodeChallange.UI.StartUp
{
    public class ComponentBootsrapper
    {
        private IWindsorContainer _container;

        public IWindsorContainer Intialize()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());

            return _container;
        }
    }

    public class BusinessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserService>().ImplementedBy<UserService>().Interceptors<UnitOfWorkInterceptor>().LifeStyle.Transient);
        }
    }

    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(BaseRepository<>)).LifeStyle.Transient);
            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifeStyle.Transient);
        }
    }

    public class DataComponenentsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifeStyle.PerWebRequest);
            container.Register(Component.For(typeof(DbContext)).ImplementedBy(typeof(CodeKataEntities)).LifeStyle.Transient);
        }
    }

    public class HttpController : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
        }
    }

    public class InterceptorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<UnitOfWorkInterceptor>().LifeStyle.Transient);
        }
    }
}