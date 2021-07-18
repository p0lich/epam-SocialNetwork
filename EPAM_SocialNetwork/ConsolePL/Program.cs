using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependencies;
using Entities;
using EPAM.SocialNetwork.BLL.Interfaces;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace ConsolePL
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            try
            {
                ILogic logic = DependencyResolver.GetInstance().UserLogic;

                logic.GetUser(-1);
            }
            catch (Exception e)
            {
                log.Error(string.Format("{0}", e.Message));
            }
        }
    }
}
