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
    }
}
