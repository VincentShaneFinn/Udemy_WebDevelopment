//using Autofac;
//using System;

//namespace Dependency_Injection
//{

//    public interface ILog
//    {
//        void Write(string message);
//    }

//    public class ConsoleLog : ILog
//    {
//        public void Write(string message)
//        {
//            Console.WriteLine(message);
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
//            //Whenver someone asks for a ILog, give them a ConsoleLog
//            builder.RegisterType<ConsoleLog>().As<ILog>().AsSelf();
//            builder.RegisterType<Engine>();
//            builder.RegisterType<Car>();

//            IContainer container = builder.Build();

//            //This does not work because console log is only fulfilng requests for Ilog
//            //You need to add .AsSelf() to its registration
//            var log = container.Resolve<ConsoleLog>();

//            //Resolves all dependencies
//            var car = container.Resolve<Car>();
//            car.Go();
//        }
//    }
//}
