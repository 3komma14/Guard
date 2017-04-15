using BarsGroup.CodeGuard.Exceptions;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.Tests.Validators
{
    
    public class IntegerValidatorTests : BaseTests
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

        [Fact]
        public void IsOdd_ArgumentIsOdd_DoesNotThrow()
        {
            // Arrange
            var arg = 3;

            // Act/Assert
            Guard.That(arg).IsOdd();
        }

        [Fact]
        public void IsOdd_ArgumentIsEven_Throws()
        {
            // Arrange
            var arg = 2;

            // Act/Assert
            Assert.Throws<OddValueExpectedException<int>>(() => Guard.That(arg).IsOdd());
        }


        [Fact]
        public void IsOdd_Long_ArgumentIsOdd_DoesNotThrow()
        {
            // Arrange
            var arg = 3L;

            // Act/Assert
            Guard.That(arg).IsOdd();
        }

        [Fact]
        public void IsOdd_Long_ArgumentIsEven_Throws()
        {
            // Arrange
            var arg = 2L;

            // Act/Assert
            Assert.Throws<OddValueExpectedException<long>>(() => Guard.That(arg).IsOdd());
        }


        [Fact]
        public void IsEven_ArgumentIsEven_DoesNotThrow()
        {
            // Arrange
            var arg = 4;

            // Act/Assert
            Guard.That(arg).IsEven();
        }

        [Fact]
        public void IsEven_ArgumentIsOdd_Throws()
        {
            // Arrange
            var arg = 5L;

            // Act/Assert
            Assert.Throws<EvenValueExpectedException<long>>(() => Guard.That(arg).IsEven());
        }

        [Fact]
        public void IsEven_Long_ArgumentIsEven_DoesNotThrow()
        {
            // Arrange
            var arg = 4L;

            // Act/Assert
            Guard.That(arg).IsEven();
        }

        [Fact]
        public void IsEven_Long_ArgumentIsOdd_Throws()
        {
            // Arrange
            var arg = 5;

            // Act/Assert
            Assert.Throws<EvenValueExpectedException<int>>(() => Guard.That(arg).IsEven());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void IsPrime_ArgumentIsPrime_DoesNotThrow(int arg)
        {
            // Act/Assert
             Guard.That(arg).IsPrime();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        public void IsPrime_ArgumentIsNotPrime_Throws(int arg)
        {
            // Act/Assert
            Assert.Throws<PrimeValueExpectedException<int>>(() => Guard.That(arg).IsPrime());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void IsPrime_Long_ArgumentIsPrime_DoesNotThrow(long arg)
        {
            // Act/Assert
            Guard.That(arg).IsPrime();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        public void IsPrime_Long_ArgumentIsNotPrime_Throws(long arg)
        {
            // Act/Assert
            Assert.Throws<PrimeValueExpectedException<long>>(() => Guard.That(arg).IsPrime());
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        public void IsPositive_ArgumentIsNotPositive_Throws(int arg)
        {
            // Act/Assert
            Assert.Throws<PositiveValueExpectedException<int>>(() => Guard.That(arg).IsPositive());
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        public void IsPositive_ArgumentIsNotPositive_Throws(long arg)
        {
            // Act/Assert
            Assert.Throws<PositiveValueExpectedException<long>>(() => Guard.That(arg).IsPositive());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(20)]
        public void IsPositive_ArgumentIsPositive_DoesNotThrow(int arg)
        {
            // Act/Assert
            Guard.That(arg).IsPositive();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(20)]
        public void IsPositive_ArgumentIsPositive_DoesNotThrow(long arg)
        {
            // Act/Assert
           Guard.That(arg).IsPositive();
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        public void IsPositive_ArgumentIsNotNegative_Throws(int arg)
        {
            // Act/Assert
            Assert.Throws<NegativeValueExpectedException<int>>(() => Guard.That(arg).IsNegative());
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        public void IsPositive_ArgumentIsNotNegative_Throws(long arg)
        {
            // Act/Assert
            Assert.Throws<NegativeValueExpectedException<long>>(() => Guard.That(arg).IsNegative());
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-20)]
        public void IsPositive_ArgumentIsNegative_DoesNotThrow(int arg)
        {
            // Act/Assert
            Guard.That(arg).IsNegative();
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-20)]
        public void IsPositive_ArgumentIsNegative_DoesNotThrow(long arg)
        {
            // Act/Assert
            Guard.That(arg).IsNegative();
        }
    }
}
