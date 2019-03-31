using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
    public interface IBaz
    {
        string Name { get; }
    }

    public class Bar
    {
    }

    public interface IFoo
    {
        bool DoSomething(string value);
        string ProcessString(string value);
        bool TryParse(string value, out string outputValue);
        bool Submit(ref Bar bar);
        int GetCount();
        bool Add(int amount);

        string Name { get; set; }
        IBaz SomeBaz { get; }
        int SomeOtherProperty { get; set; }

    }

    [TestFixture]
    public class MethodSamples
    {

        [Test]
        public void OrdinaryMethodCalls()
        {
            var mock = new Mock<IFoo>();

            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            mock.Setup(foo => foo.DoSomething("pong")).Returns(false);
            mock.Setup(foo => foo.DoSomething(It.IsIn("pingpong", "foo"))).Returns(false);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(mock.Object.DoSomething("ping"));
                Assert.IsFalse(mock.Object.DoSomething("pong"));
                Assert.IsFalse(mock.Object.DoSomething("pingpong"));
                Assert.IsFalse(mock.Object.DoSomething("foo"));
            });
        }

        [Test]
        public void ArgumentDependentMatching()
        {
            var mock = new Mock<IFoo>();

            //setup to always return false no mater what it gets
            mock.Setup(foo => foo.DoSomething(It.IsAny<String>())).Returns(false);

            //is true when the parameter is even
            mock.Setup(foo => foo.Add(It.Is<int>(x => x % 2 == 0))).Returns(true);

            //false if the object is 1-10
            mock.Setup(foo => foo.Add(It.IsInRange<int>(1, 10, Range.Inclusive))).Returns(false);

            //false if the object is included in this regex, i.e. must be alphabetical
            mock.Setup(foo => foo.DoSomething(It.IsRegex("[a-z]+"))).Returns(false);
        }

        [Test]
        public void OutAndRefArguments()
        {
            //Out
            var mock = new Mock<IFoo>();
            var requiredOutput = "ok";

            //smart enough to realize out here is the desired result
            mock.Setup(foo => foo.TryParse("ping", out requiredOutput)).Returns(true);

            string result;

            Assert.Multiple(() =>
            {
                Assert.IsTrue(mock.Object.TryParse("ping", out result));
                Assert.That(result, Is.EqualTo(requiredOutput));

                //This is not proper, since pong  has not been setup
                var thisShouldBeFalse = mock.Object.TryParse("pong", out result);
                Console.WriteLine(thisShouldBeFalse);
                Console.WriteLine(result);
            });

            //Ref
            var bar = new Bar();
            mock.Setup(foo => foo.Submit(ref bar)).Returns(true);

            Assert.That(mock.Object.Submit(ref bar), Is.EqualTo(true));

            //Mock does referencial equatables, not that they are kinda the same object
            var someOtherBar = new Bar();
            Assert.IsFalse(mock.Object.Submit(ref someOtherBar));
        }

        [Test]
        public void MyTest()
        {
            var mock = new Mock<IFoo>();

            mock.Setup(foo => foo.ProcessString(It.IsAny<String>())).Returns((string s) => s.ToLowerInvariant());

            Assert.That(mock.Object.ProcessString("ABC"), Is.EqualTo("abc"));


            var calls = 0;
            mock.Setup(foo => foo.GetCount()).Returns(() => calls).Callback(() => calls++);

            mock.Object.GetCount();
            mock.Object.GetCount();

            Assert.That(mock.Object.GetCount(), Is.EqualTo(2));

            mock.Setup(foo => foo.DoSomething("Kill")).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.DoSomething(null)).Throws(new ArgumentException("cmd"));

            Assert.Throws<InvalidOperationException>(() =>
                mock.Object.DoSomething("Kill")
            );
            //or
            Assert.Throws<ArgumentException>(() =>
                 mock.Object.DoSomething(null), "cmd");

        }

        [Test]
        public void PropertyMockingBasics()
        {
            var mock = new Mock<IFoo>();

            mock.Setup(foo => foo.Name).Returns("bar");
            mock.Object.Name = "Will not be assigned";
            Assert.That(mock.Object.Name, Is.EqualTo("bar"));

            mock.Setup(foo => foo.SomeBaz.Name).Returns("hello");
            Assert.That(mock.Object.SomeBaz.Name, Is.EqualTo("hello"));

            //Mock a setter
            bool setterCalled = false;

            mock.SetupSet(foo =>
            {
                foo.Name = It.IsAny<string>();
            }).Callback<string>(value =>
            {
                setterCalled = true;
            });

            mock.Object.Name = "anotherBar";

            mock.VerifySet(foo =>
            {
                foo.Name = "anotherBar";
            }, Times.AtLeastOnce);

            Assert.IsTrue(setterCalled);
        }

        [Test]
        public void PropertyMockingAdvanced()
        {
            var mock = new Mock<IFoo>();

            //Stub all properties
            mock.SetupAllProperties();

            //A single property setup
            //mock.SetupProperty(foo => foo.Name);

            IFoo fooObj = mock.Object;

            fooObj.Name = "bar";
            Assert.That(mock.Object.Name, Is.EqualTo("bar"));
        }

        public delegate void AlienAbductionHandler(int galaxy, bool returned);


        public interface IAnimal
        {
            event EventHandler FallsIll;
            void Stumble();

            event AlienAbductionHandler AbuctedByAlient;
        }

        public class Doctor
        {
            public Doctor(IAnimal animal)
            {
                animal.FallsIll += (sender, args) =>
                {
                    Console.WriteLine("I Will Cure you");
                    TimesCured++;
                };

                animal.AbuctedByAlient += (galaxy, returned) => AbductionsObserverd++;
            }

            public int TimesCured { get; private set; }
            public int AbductionsObserverd { get; set; }
        }

        [Test]
        public void DoctorTests()
        {
            var mock = new Mock<IAnimal>();
            var doctor = new Doctor(mock.Object);

            mock.Raise(
                a => a.FallsIll += null,
                new EventArgs()
            );

            Assert.That(doctor.TimesCured, Is.EqualTo(1));
            mock.Setup(a => a.Stumble()).Raises(
                a => a.FallsIll += null,
                new EventArgs()
            );

            mock.Object.Stumble();

            Assert.That(doctor.TimesCured, Is.EqualTo(2));


            mock.Raise(
                a => a.AbuctedByAlient += null,
                42,
                true
            );

            Assert.That(doctor.AbductionsObserverd, Is.EqualTo(1));
        }


        [Test]
        public void CallbackTesting()
        {
            var mock = new Mock<IFoo>();

            int x = 0;
            mock.Setup(foo => foo.DoSomething("ping"))
                .Returns(true)
                .Callback(() => x++);

            mock.Object.DoSomething("ping");

            Assert.That(x, Is.EqualTo(1));

            mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Returns(true)
                .Callback((string s) => x += s.Length);

            //Same thing
            //mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
            //    .Returns(true)
            //    .Callback<string>(s => x += s.Length);

            mock.Setup(foo => foo.DoSomething("pong"))
                .Callback(() => Console.WriteLine("Before Return"))
                .Returns(true)
                .Callback((string s) => x += s.Length);
        }
    }

}
