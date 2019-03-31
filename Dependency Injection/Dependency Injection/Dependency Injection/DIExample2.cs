//using Autofac;
//using System;

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

//        public Engine(ILog log)
//        {
//            this.log = log;
//            id = new Random().Next();
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

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var builder = new ContainerBuilder();
//            //Whenver someone asks for a ILog, give them an EmailLog
//            builder.RegisterType<EmailLog>().As<ILog>().As<IConsole>().AsSelf();
//            //By default, autofac simply looks at the last registration, unless you add PreserveExistingDefaults
//            builder.RegisterType<ConsoleLog>().As<ILog>().AsSelf().PreserveExistingDefaults();
//            builder.RegisterType<Engine>();
//            builder.RegisterType<Car>();

//            IContainer container = builder.Build();

//            //Resolves all dependencies
//            var car = container.Resolve<Car>();
//            car.Go();
//        }
//    }
//}
