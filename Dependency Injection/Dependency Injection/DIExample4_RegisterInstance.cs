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

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var builder = new ContainerBuilder();

//            //builder.RegisterType<ConsoleLog>().As<ILog>();

//            var log = new ConsoleLog();
//            builder.RegisterInstance(log).As<ILog>(); //When something asks for an ILog, give them this instance instead of createing a new one

//            builder.RegisterType<Engine>();
//            //Please use a constructor with one parameter of type engine
//            builder.RegisterType<Car>().UsingConstructor(typeof(Engine));

//            IContainer container = builder.Build();

//            //Resolves all dependencies
//            var car = container.Resolve<Car>();
//            car.Go();
//        }
//    }
//}
