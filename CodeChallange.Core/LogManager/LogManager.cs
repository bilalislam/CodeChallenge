using System.Configuration;
using System.IO;
using System.Linq;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace CodeChallange.Core.LogManager
{
    public sealed class LogManager
    {
        public readonly ILog DBlog;
        public readonly ILog FileLog;

        private static LogManager instance;

        public static LogManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogManager();
                }

                return instance;
            }
        }

        public void Clear()
        {
            GlobalContext.Properties.Clear();
        }

        private LogManager()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Log.config")));

            var hiear = log4net.LogManager.GetRepository() as Hierarchy;

            if (hiear != null)
            {
                var appender = hiear.GetAppenders()
                                 .OfType<AdoNetAppender>()
                                 .SingleOrDefault();

                if (appender != null)
                {
                    appender.ConnectionString = ConfigurationManager.ConnectionStrings["Log4netConnectionString"].ConnectionString;
                    appender.ActivateOptions();
                }
            }

            DBlog = log4net.LogManager.GetLogger("DBLog");

            FileLog = log4net.LogManager.GetLogger("FileLog");
        }
    }
}
