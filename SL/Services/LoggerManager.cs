using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;


namespace SL.Services
{
    public sealed class LoggerManager
    {

        ///PARAMETRIZADO DE LOGGERS CON SINGLETON THREAD SAFE

        private string filePath;

        private readonly static LoggerManager loggerManager = new LoggerManager();

        private LoggerManager()
        {
            //PARAMETRIZACION
            filePath = ConfigurationManager.AppSettings["filePathLogger"];
        }

        public static LoggerManager Current
        {
            get
            {
                return loggerManager;
            }
        }




        ///PUEDE REALIZARSE TAMBIEN USANDO MUTEX

        /*

            private string filePath;

            private static LoggerManager loggerManager = null;

            private static object mutex = new object();

            private LoggerManager()
            {
                //PARAMETRIZACION
                filePath = ConfigurationManager.AppSettings["filePathLogger"];
            }

            public static LoggerManager GetInstance()

            {


                if (loggerManager == null)
                {


                    lock (mutex)
                    {
                        if (loggerManager == null)
                        {
                            loggerManager = new LoggerManager();
                        }

                    }

                }

                return loggerManager;

        */



        /* 

            /// PARAMETRIZADO DE LOGGERS CON SINGLETON 



            private string filePath;

            private static LoggerManager loggerManager = null;

            private LoggerManager()
            {
                //PARAMETRIZACION
                filePath = ConfigurationManager.AppSettings["filePathLogger"];
            }

           public static LoggerManager GetInstance()

            {
                if (loggerManager==null)
                {
                    loggerManager = new LoggerManager();
                }

                return loggerManager;
            }





        /// PARAMETRIZADO DE LOGGERS SIN SINGLETON 


        private string filePath;

        public LoggerManager()
        {
            filePath = ConfigurationManager.AppSettings["filePathLogger"];
        }


    */
        public void Write(string message, EventLevel eventLevel)
        {


            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {

                streamWriter.WriteLine($"{DateTime.Now.ToString("dd.MM.yy hh:mm:ss")} [Severity {eventLevel.ToString()}]:{message}");


            }
        }

    }

}
