using JetBrains.dotMemoryUnit;
using JetBrains.dotMemoryUnit.Kernel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
    public class QuadraticTest
    {
        public Tuple<double, double> Quadratic(double a, double b, double c)
        {
            var disc = b * b - 4 * a * c;
            if (disc < 0)
            {
                throw new Exception("Cannot solve with complex roots");
            }
            else
            {
                var root = Math.Sqrt(disc);
                return Tuple.Create(
                    (-b + root) / 2 / a,
                    (-b - root) / 2 / a);
            }
        }
    }

    [TestFixture]
    public class EquationTest
    {
        [Test]
        public void Test()
        {
            var result = new QuadraticTest().Quadratic(1, 10, 16);
        }

        [Test]
        public void MemoryTest()
        {
            if (dotMemoryApi.IsEnabled)
            {
                var checkpoint1 = dotMemory.Check();

                // ... manipulations

                var checkpoint2 = dotMemory.Check(memory =>
                {
                    Assert.That(memory.GetTrafficFrom(checkpoint1)
                        .Where(obj => obj.Interface.Is<IEnumerable<int>>())
                        .AllocatedMemory.SizeInBytes, Is.LessThan(1000));
                });

                dotMemory.Check(memory =>
                {
                    Assert.That(memory.GetObjects(
                        where => where.Type.Is<QuadraticTest>()
                        ).ObjectsCount, Is.EqualTo(0));
                });
            }
        }
    }
}
