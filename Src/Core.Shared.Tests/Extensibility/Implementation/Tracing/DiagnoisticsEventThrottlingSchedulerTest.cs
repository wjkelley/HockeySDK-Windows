﻿namespace Microsoft.HockeyApp.Extensibility.Implementation.Tracing
{
    using System;
    using System.Threading.Tasks;
#if WINDOWS_PHONE || WINDOWS_STORE || WINDOWS_UWP
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
    using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif
#if WINRT || WINDOWS_UWP
    using TaskEx = System.Threading.Tasks.Task;
#endif

    [TestClass]
    public sealed class DiagnoisticsEventThrottlingSchedulerTest : IDisposable
    {
        private const int SchedulingRoutineRunInterval = 10;
        private const int ExecuteTimes = 3;

        private readonly DiagnoisticsEventThrottlingScheduler scheduler = new DiagnoisticsEventThrottlingScheduler();

        public void Dispose()
        {
            this.scheduler.Dispose();
        }

        [TestMethod]
        public void TestStateAfterInitialization()
        {
            Assert.AreEqual(
                0, 
                this.scheduler.Tokens.Count, 
                "Unexpected number of timer tokens");
        }

        [TestMethod]
        public void TestScheduingIntervalIsZeroOrLessException()
        {
            bool failedWithExpectedException = false;
            try
            {
                this.scheduler.ScheduleToRunEveryTimeIntervalInMilliseconds(0, () => { });
            }
            catch (ArgumentOutOfRangeException)
            {
                failedWithExpectedException = true;
            }

            Assert.IsTrue(failedWithExpectedException);
        }

        [TestMethod]
        public void TestScheduingActionIsNullException()
        {
            bool failedWithExpectedException = false;
            try
            {
                this.scheduler.ScheduleToRunEveryTimeIntervalInMilliseconds(1, null);
            }
            catch (ArgumentNullException)
            {
                failedWithExpectedException = true;
            }

            Assert.IsTrue(failedWithExpectedException);
        }
        
        [TestMethod]
        public void TestRemovingScheduledActionsIsNullException()
        {
            bool failedWithExpectedException = false;
            try
            {
                this.scheduler.RemoveScheduledRoutine(null);
            }
            catch (ArgumentNullException)
            {
                failedWithExpectedException = true;
            }

            Assert.IsTrue(failedWithExpectedException);
        }

        [TestMethod]
        public void TestRemovingScheduledActionsIsNotOfExpectedType()
        {
            bool failedWithExpectedException = false;
            try
            {
                this.scheduler.RemoveScheduledRoutine(new object());
            }
            catch (ArgumentException)
            {
                failedWithExpectedException = true;
            }

            Assert.IsTrue(failedWithExpectedException);
        }
        
        private class RoutineCounter
        {
            public int ExecutedTimes { get; private set; }

            public void Execute()
            {
                this.ExecutedTimes += 1;
            }
        }
    }
}