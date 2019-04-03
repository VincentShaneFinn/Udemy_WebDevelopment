//using Autofac;
//using Autofac.Core;
//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using Module = Autofac.Module;

//namespace Dependency_Injection
//{

//    public interface ILog : IDisposable
//    {
//        void Write(string message);
//    }

//    public class ConsoleLog : ILog
//    {
//        public ConsoleLog()
//        {
//            Console.WriteLine($"Console log created at {DateTime.Now.Ticks}");
//        }

//        public void Write(string message)
//        {
//            Console.WriteLine(message);
//        }

//        public void Dispose()
//        {
//            Console.WriteLine("Console logger no longer required");
//        }
//    }

//    public class SMSLog : ILog
//    {
//        private readonly string phoneNumber;

//        public SMSLog(string phoneNumber)
//        {
//            this.phoneNumber = phoneNumber;
//        }

//        public void Write(string message)
//        {
//            Console.WriteLine($"SMS to {phoneNumber} : {message}");
//        }

//        public void Dispose()
//        {

//        }
//    }

//    public class Reporting
//    {
//        Lazy<ConsoleLog> log;

//        public Reporting(Lazy<ConsoleLog> log)
//        {
//            this.log = log ?? throw new ArgumentNullException(paramName: nameof(log));
//            Console.WriteLine("Reporting component created");
//        }

//        public void Report()
//        {
//            log.Value.Write("Log started");
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //Replaced by dependancy injection
//            //new Lazy<ConsoleLog>(() => new ConsoleLog());

//            var builder = new ContainerBuilder();
//            builder.RegisterType<ConsoleLog>();
//            builder.RegisterType<Reporting>();

//            using (var c = builder.Build())
//            {
//                c.Resolve<Reporting>().Report();
//            }
//        }
//    }
//}
