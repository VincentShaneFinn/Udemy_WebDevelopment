using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{

    //Remember you would use mocks to verify that the dependencies are used the number of times that you expect
    //Using mock.Verify, which lets you specify a lambda and a Times.XXX to check that it ran a specific number of times

    public class Foo : IFoo
    {
        public string Name { get; set ; }

        public IBaz SomeBaz => throw new NotImplementedException();

        public int SomeOtherProperty { get; set; }

        public bool Add(int amount)
        {
            throw new NotImplementedException();
        }

        public bool DoSomething(string value)
        {
            return true;
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public string ProcessString(string value)
        {
            throw new NotImplementedException();
        }

        public bool Submit(ref Bar bar)
        {
            throw new NotImplementedException();
        }

        public bool TryParse(string value, out string outputValue)
        {
            throw new NotImplementedException();
        }
    }

    public class VerifyTest
    {
        IFoo foo;

        public VerifyTest(IFoo foo)
        {
            this.foo = foo;
        }

        public void Hello()
        {

            foo.DoSomething("ping");
            var name = foo.Name;
            foo.SomeOtherProperty = 123;
        }
    }

    [TestFixture]
    public class VerificationSamples
    {
        [Test]
        public void MyTest()
        {
            var mock = new Mock<IFoo>();
            var consumer = new VerifyTest(mock.Object);

            consumer.Hello();

            mock.Verify(foo => foo.DoSomething("ping"), Times.AtLeastOnce);
            mock.Verify(foo => foo.DoSomething("pong"), Times.Never);

            mock.VerifyGet(foo => foo.Name);

            mock.VerifySet(foo => foo.SomeOtherProperty = It.IsInRange(100, 200, Range.Inclusive));
        }
    }
}
