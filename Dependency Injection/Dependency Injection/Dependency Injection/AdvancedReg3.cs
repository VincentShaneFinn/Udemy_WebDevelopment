//using Autofac;
//using Autofac.Core;
//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using Module = Autofac.Module;

//namespace Dependency_Injection
//{

//    public interface ILog
//    {
//        void Write(string message);
//    }

//    public interface IConsole
//    {

//    }

//    public class ConsoleLog : ILog
//    {
//        public void Write(string message)
//        {
//            Console.WriteLine(message);
//        }
//    }

//    public class EmailLog : ILog, IConsole
//    {
//        private const string adminEmail = "admin@foo.com";

//        public void Write(string message)
//        {
//            Console.WriteLine($"Email sent to {adminEmail} : {message}");
//        }

//    }
//    public class Engine
//    {
//        private ILog log;
//        private int id;

//        public Engine(ILog log, int id)
//        {
//            this.log = log;
//            this.id = id;
//        }

//        public void Ahead(int power)
//        {
//            log.Write($"Engine [{id}] ahead {power}");
//        }
//    }

//    public class Car
//    {
//        private Engine engine;
//        private ILog log;

//        public Car(Engine engine)
//        {
//            this.engine = engine;
//            this.log = new EmailLog();
//        }

//        public Car(Engine engine, ILog log)
//        {
//            this.engine = engine;
//            this.log = log;
//        }

//        public void Go()
//        {
//            engine.Ahead(100);
//            log.Write("Car going forward");
//        }
//    }

//    public class SMSLog : ILog
//    {
//        string phoneNumber;

//        public SMSLog(string phoneNumber)
//        {
//            this.phoneNumber = phoneNumber;
//        }

//        public void Write(string message)
//        {
//            Console.WriteLine($"SMS to {phoneNumber} : {message}");
//        }
//    }

//    public class Parent
//    {
//        public override string ToString()
//        {
//            return "I am your father";
//        }
//    }

//    public class Child
//    {
//        public string Name { get; set; }
//        public Parent Parent { get; set; }

//        public void SetParent(Parent parent)
//        {
//            this.Parent = parent;
//        }
//    }

//    public class ParentChildModule : Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            builder.RegisterType<Parent>();
//            builder.Register(c => new Child() { Parent = c.Resolve<Parent>() });
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //var assembly = Assembly.GetExecutingAssembly();
//            //var builder = new ContainerBuilder();
//            ////register all logs exept sms log, and if Console log, make it a singleton instance
//            //builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Log"))
//            //    .Except<SMSLog>()
//            //    .Except<ConsoleLog>(c => c.As<ILog>().SingleInstance())
//            //    .AsSelf();

//            ////get register to the first interface they implement
//            //builder.RegisterAssemblyTypes(assembly).Except<SMSLog>().Where(t => t.Name.EndsWith("Log")).As(t => t.GetInterfaces()[0]);

//            var builder = new ContainerBuilder();
//            builder.RegisterAssemblyModules(typeof(Program).Assembly);
//            builder.RegisterAssemblyModules<ParentChildModule>(typeof(Program).Assembly);

//            var container = builder.Build();

//            Console.WriteLine(container.Resolve<Child>().Parent);
//        }
//    }
//}
