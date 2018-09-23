using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotelJsonWeb.Models
{
    public class LogSingleton
    {
        private static LogSingleton singletonInstance;

        private LogSingleton()
        {
        }

        public static LogSingleton getSingletonInstance()
        {
            if (null == singletonInstance)
            {
                Console.WriteLine("singleton created");
                singletonInstance = new LogSingleton();
            }
            return singletonInstance;
        }
        public void logger(Log log)
        {
            LogRepository logger = new LogRepository();
            logger.RegisterLog(log);
        }
    }
}
