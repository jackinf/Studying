using NUnit.Framework;
using Study.Algo.AlgoChallenge;

namespace Study.Algo.Tests.AlgoChallenge
{
    public class MaximumProductSubarrayTests
    {
        [Test]
        public void Test1()
        {
            int[] arr = { 6, -3, -10, 0, 2 };
            var result = MaximumProductSubarray.RunImplementationA(arr);
            Assert.That(result, Is.EqualTo(180));
        }

        [Test]
        public void Test2()
        {
            int[] arr = {-1, -3, -10, 0, 60};
            var result = MaximumProductSubarray.RunImplementationA(arr);
            Assert.That(result, Is.EqualTo(60));
        }

        [Test]
        public void Test3()
        {
            int[] arr = { -2, -3, 0, -2, -40 };
            var result = MaximumProductSubarray.RunImplementationA(arr);
            Assert.That(result, Is.EqualTo(80));
        }

        [Test]
        public void Test4()
        {
            int[] arr = { -1, 0, 0, 1, -1, 1 };
            var result = MaximumProductSubarray.RunImplementationA(arr);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Test5()
        {
            int[] arr = { 0 };
            var result = MaximumProductSubarray.RunImplementationA(arr);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Test6()
        {
            int[] arr = { 1, -3, -5, -2, 0, 4, 9, 0, 3, -8, 7, -6 };
            var result = MaximumProductSubarray.RunImplementationA(arr);
            Assert.That(result, Is.EqualTo(1008));
        }

        [Test]
        public void Test7()
        {
            int[] arr = { -1 };
            var result = MaximumProductSubarray.RunImplementationA(arr);
            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void Test8()
        {
            int[] arr = {  };
            var result = MaximumProductSubarray.RunImplementationA(arr);
            Assert.That(result, Is.EqualTo(null));
        }
    }
}