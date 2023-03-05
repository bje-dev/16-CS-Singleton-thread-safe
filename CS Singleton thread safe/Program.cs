using SL.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Singleton_thread_safe
{
    class Program
    {
        static void Main(string[] args)
        {

            //USO DE LOGGERS: EXCEPCIONES - REGLAS DE NEGOCIO - LOGIN/LOGOUT ETC.

            ////////////////CON SINGLETON THREAD SAFE

            LoggerManager instancia1 = LoggerManager.Current;
            LoggerManager instancia2 = LoggerManager.Current;

            if (instancia1 == instancia2)
            {
                Console.WriteLine("Esto es un singleton con thread safe");
            }
            LoggerManager.Current.Write("Logger por consola...con singleton thread safe", EventLevel.Informational);
            Console.ReadLine();


            /*

            //////////////CON SINGLETON
            
            LoggerManager instancia1 = LoggerManager.GetInstance();
            LoggerManager instancia2 = LoggerManager.GetInstance();

            if (instancia1 == instancia2)
            {
                Console.WriteLine("Esto es un singleton");
            }
            Console.ReadLine();


            //////////////SIN SINGLETON
            
            LoggerManager loggerManager = new LoggerManager();

            loggerManager.Write("Logger por consola...", EventLevel.Informational);

            Console.WriteLine("Terminado");

            */


        }
    }
}
