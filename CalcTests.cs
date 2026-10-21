using System;
using Xunit;

namespace FlakyDemo.Tests
{
    public class CalcTests
    {
        private static readonly Random Rng = new Random();

        [Fact]
        public void AddsNumbers()
        {
            Assert.Equal(5, Calc.Add(2, 3));
        }

        [Fact]
        public void MultipliesNumbers()
        {
            Assert.Equal(20, Calc.Mul(4, 5));
        }

        [Fact]
        public void DetectsEven()
        {
            Assert.True(Calc.IsEven(6));
            Assert.False(Calc.IsEven(7));
        }

        [Fact]
        public void FlakyAddsUnderLoad()
        {
            if (Rng.NextDouble() < 0.4)
            {
                Assert.Fail("flaky: simulated timeout while adding");
            }
            Assert.Equal(2, Calc.Add(1, 1));
        }

        [Fact]
        public void FlakyFailsOnFirstAttemptOnly()
        {
            if (Environment.GetEnvironmentVariable("GITHUB_RUN_ATTEMPT") == "1")
            {
                Assert.Fail("flaky: simulated first-attempt failure (GITHUB_RUN_ATTEMPT=1)");
            }
            Assert.Equal(2, Calc.Add(1, 1));
        }

        [Fact]
        public void FlakyMultipliesUnderContention()
        {
            if (Rng.NextDouble() < 0.4)
            {
                Assert.Fail("flaky: simulated contention in multiplier");
            }
            Assert.Equal(9, Calc.Mul(3, 3));
        }
    }
}
