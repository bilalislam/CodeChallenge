using System.Web.Mvc;
using Castle.Windsor;

namespace CodeChallange.UI.StartUp
{
    public class HttpContextBase
    {
        private static IWindsorContainer CurrentContainer { get; set; }

        public static void Initialize()
        {
            var bs = new ComponentBootsrapper();
            CurrentContainer = bs.Intialize();            

            var controllerFactory = new WindsorControllerFactory(CurrentContainer.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }    
}