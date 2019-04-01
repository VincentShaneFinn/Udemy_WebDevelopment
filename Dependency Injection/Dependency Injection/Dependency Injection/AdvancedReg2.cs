﻿//using Autofac;
//using Autofac.Core;
//using System;
//using System.Collections.Generic;

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

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var builder = new ContainerBuilder();

//            builder.RegisterType<Parent>();

//            //Property Injection

//            //builder.RegisterType<Child>().PropertiesAutowired();
//            //builder.RegisterType<Child>().WithProperty("Parent", new Parent());


//            //Method Injection

//            //builder.Register((c =>
//            //{
//            //    var child = new Child();
//            //    child.SetParent(c.Resolve<Parent>());
//            //    return child;
//            //}));

//            builder.RegisterType<Child>().OnActivated(e =>
//            {
//                var p = e.Context.Resolve<Parent>();
//                e.Instance.SetParent(p);
//            });

//            var container = builder.Build();

//            var parent = container.Resolve<Child>().Parent;

//            Console.WriteLine(parent);
//        }
//    }
//}
