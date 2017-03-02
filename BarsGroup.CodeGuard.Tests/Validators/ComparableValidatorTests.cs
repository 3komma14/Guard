using System;
using BarsGroup.CodeGuard.Exceptions;
using BarsGroup.CodeGuard.Validators;
using Xunit;
using Xunit.Sdk;

namespace BarsGroup.CodeGuard.Tests.Validators
{
    
    public class ComparableValidatorTests : BaseTests
    {
        #region ----- Fixture setup -----

        /// <summary>
        /// Called once before first test is executed
        /// </summary>
        public void Init()
        {
            // Init tests
        }

        /// <summary>
        /// Called once after last test is executed
        /// </summary>
        public void Cleanup()
        {
            // Cleanup tests
        }

        #endregion

        #region ------ Test setup -----

        /// <summary>
        /// Called before each test
        /// </summary>
        public void Setup()
        {
            // Setup test
        }

        /// <summary>
        /// Called before each test
        /// </summary>
        public void TearDown()
        {
            // Cleanup after test       
        }

        #endregion

        #region IsGreaterThan

        [Fact]
        public void IsGreaterThan_WhenArgumentIsLessThan_Throws()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 1;

            // Act
            var exception =
                GetException<GreaterThenExpectedException<int>>(() => Guard.That(arg1, nameof(arg1)).IsGreaterThan(arg2));

            // Assert
            AssertGreaterThenExpectedException(exception, arg1, arg2, "arg1");
        }

        [Fact]
        public void IsGreaterThan_WhenArgumentIsEqual_Throws()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 0;

            // Act
            var exception =
                GetException<GreaterThenExpectedException<int>>(() => Guard.That(arg1, nameof(arg1)).IsGreaterThan(arg2));

            // Assert
            AssertGreaterThenExpectedException(exception, arg1, arg2, "arg1");
        }

        [Fact]
        public void IsGreaterThan_WhenArgumentIsGreather_Func_DoesNotThrow()
        {
            // Arrange
            double arg1 = 1;
            double arg2 = 0;

            // Act/Assert
            Guard.That(arg1).IsGreaterThan(() => arg2);
        }

        [Fact]
        public void IsGreaterThan_WhenArgumentIsGreather_DoesNotThrow()
        {
            // Arrange
            double arg1 = 1;
            double arg2 = 0;

            // Act/Assert
                Guard.That(arg1).IsGreaterThan(arg2);
        }

        #endregion

        #region IsGreaterThanOrEqual

        [Fact]
        public void IsGreaterThanOrEqual_WhenArgumentIsLessThan_Throws()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 1;

            // Act
            var exception = GetException<GreaterThenExpectedException<int>>(() => Guard.That(arg1, nameof(arg1)).IsGreaterThanOrEqualTo(arg2));

            // Assert
            AssertGreaterThenExpectedException(exception, arg1, arg2, "arg1");
        }

        [Fact]
        public void IsGreaterThanOrEqual_WhenArgumentIsEqual_Func_DoesNotThrow()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 0;

            // Act
            // Assert
            Guard.That(arg1).IsGreaterThanOrEqualTo(() => arg2);
        }

        [Fact]
        public void IsGreaterThanOrEqual_WhenArgumentIsEqual_DoesNotThrow()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 0;

            // Act
            // Assert
            Guard.That(arg1).IsGreaterThanOrEqualTo(arg2);
        }

        [Fact]
        public void IsGreaterThanOrEqual_WhenArgumentIsGreather_DoesNotThrow()
        {
            // Arrange
            double arg1 = 1;
            double arg2 = 0;

            Guard.That(arg1).IsGreaterThanOrEqualTo(arg2);
        }

        #endregion

        #region IsLessThan

        [Fact]
        public void IsLessThan_WhenArgumentIsGreaterThan_Throws()
        {
            // Arrange
            var arg1 = 1;
            var arg2 = 0;

            // Act
            var exception =
                GetException<LessThenExpectedException<int>>(() => Guard.That(arg1, nameof(arg1)).IsLessThan(arg2));

            // Assert
            AssertLessThenExpectedException(exception, "arg1", arg1, arg2);
        }

        [Fact]
        public void IsLessThan_WhenArgumentIsEqual_Throws()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 0;

            // Act
            var exception =
                GetException<LessThenExpectedException<int>>(() => Guard.That(arg1, nameof(arg1)).IsLessThan(arg2));

            // Assert
            AssertLessThenExpectedException(exception, "arg1", arg1, arg2);
        }

        [Fact]
        public void IsLessThan_WhenArgumentIsLess_Func_DoesNotThrow()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 1;

            Guard.That(arg1).IsLessThan(() => arg2);
        }

        [Fact]
        public void IsLessThan_WhenArgumentIsLess_DoesNotThrow()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 1;

            Guard.That(arg1).IsLessThan(arg2);
        }

        #endregion

        #region IsLessThanOrEqualTo

        [Fact]
        public void IsLessThanOrEqual_WhenArgumentIsGreaterThan_Throws()
        {
            // Arrange
            var arg1 = 1;
            var arg2 = 0;

            // Act
            var exception =
                GetException<LessThenExpectedException<int>>(() => Guard.That(arg1, nameof(arg1)).IsLessThanOrEqualTo(arg2));

            // Assert
            AssertLessThenExpectedException(exception, "arg1", arg1, arg2);
        }

        [Fact]
        public void IsLessThanOrEqual_WhenArgumentIsEqual_DoesNotThrow()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 0;

            // Act
            // Assert
            Guard.That(arg1).IsLessThanOrEqualTo(arg2);
        }

        [Fact]
        public void IsLessThanOrEqual_WhenArgumentIsEqual_Func_DoesNotThrow()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 0;

            // Act
            // Assert
            Guard.That(arg1).IsLessThanOrEqualTo(() => arg2);
        }

        [Fact]
        public void IsLessThanOrEqual_WhenArgumentIsLess_DoesNotThrow()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 1;

            Guard.That(arg1).IsLessThanOrEqualTo(arg2);
        }

        #endregion

        #region IsEqual

        [Fact]
        public void IsEqual_WhenArgumentIsNotEqual_Throws()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 1;

            // Act
            var exception =
                GetException<NotExpectedException<int>>(() => Guard.That(arg1, nameof(arg1)).IsEqual(arg2));

            // Assert
            AssertNotExpectedException(exception, "arg1", arg1, arg2);
        }

        [Fact]
        public void IsEqual_WhenArgumentIsEqual_Func_DoesNotThrow()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 0;

            // Act/Assert
            Guard.That(arg1).IsEqual(() => arg2);
        }

        [Fact]
        public void IsEqual_WhenArgumentIsEqual_DoesNotThrow()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 0;

            // Act/Assert
            Guard.That(arg1).IsEqual(arg2);
        }

        [Fact]
        public void IsEqual2_WhenArgumentIsNotEqual_Throws()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 1;

            // Act
            var exception =
                GetException<NotExpectedException<int>>(() => Guard.That(arg1, nameof(arg1)).IsEqual(arg2));

            // Assert
            AssertNotExpectedException(exception, "arg1", arg1, arg2);
        }

        [Fact]
        public void IsEqual2_WhenArgumentIsEqual_DoesNotThrow()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 0;

            // Act/Assert
            Guard.That(arg1).IsEqual(arg2);
        }

        #endregion

        #region IsNotEqual

        [Fact]
        public void IsNotEqual_WhenFuncArgumentIsEqual_Throws()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 0;

            // Act/Assert
           Assert.Throws<NotExpectedException<int>>(() => Guard.That(arg1, nameof(arg1)).IsNotEqual(arg2));
        }

        [Fact]
        public void IsNotEqual_WhenFuncArgumentIsNotEqual_NotThrows()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 1;

            // Act/Assert
           Guard.That(arg1, nameof(arg1)).IsNotEqual(arg2);
        }

        [Fact]
        public void IsNotEqual_WhenFuncArgumentIsNotEqual_Func_NotThrows()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 1;

            // Act/Assert
            Guard.That(arg1, nameof(arg1)).IsNotEqual(() => arg2);
        }

        [Fact]
        public void IsNotEqual_WhenArgumentIsEqual_Throws()
        {
            // Arrange
            var arg1 = 0;
            var arg2 = 0;

            // Act/Assert
            Assert.Throws<NotExpectedException<int>>(() =>
            {
                Guard.That(arg1).IsNotEqual(arg2);
            });
        }

        #endregion

        [Fact]
        public void IsInRange_WhenArgumentBetweenStartAndStop_DoesNotThrow()
        {
            // Arrange
            var arg = DateTime.Now;
            var start = DateTime.Now.AddDays(-1);
            var stop = DateTime.Now.AddDays(1);

            // Act/Assert
            Guard.That(arg).IsInRange(start, stop);
        }

        [Fact]
        public void IsInRange_WhenArgumentEqualsStart_DoesNotThrow()
        {
            // Arrange
            var arg = DateTime.Now;
            var start = arg;
            var stop = DateTime.Now.AddDays(1);

            // Act/Assert
            Guard.That(arg).IsInRange(start, stop);
        }

        [Fact]
        public void IsInRange_WhenArgumentOutOfRange_Throws()
        {
            // Arrange
            var arg = DateTime.Now.AddDays(-1);
            var start = DateTime.Now;
            var stop = DateTime.Now.AddDays(1);

            //// Act/Assert
            //Assert.Throws<OutOfRangeException>(() =>
            //{
            //    Guard.That(arg).IsInRange(start, stop);
            //});


            // Act
            var exception =
                GetException<OutOfRangeException<DateTime>>(() => Guard.That(arg, nameof(arg)).IsInRange(start, stop));

            // Assert
            AssertOutOfRangeException(exception, "arg", arg, start, stop);

        }
    }
}
