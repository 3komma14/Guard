using CodeGuard.dotNetCore.Validators;
using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests.Validators
{
    public class IntegerValidatorTests : BaseTests
    {
        #region Public Methods

        [Fact]
        public void IsEven_ArgumentIsEven_DoesNotThrow()
        {
            // Arrange
            int arg = 4;

            // Act/Assert
            Guard.That(() => arg).IsEven();
        }

        [Fact]
        public void IsEven_ArgumentIsOdd_Throws()
        {
            // Arrange
            int arg = 5;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsEven());
        }

        [Fact]
        public void IsOdd_ArgumentIsEven_Throws()
        {
            // Arrange
            int arg = 2;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsOdd());
        }

        [Fact]
        public void IsOdd_ArgumentIsOdd_DoesNotThrow()
        {
            // Arrange
            int arg = 3;

            // Act/Assert
            Guard.That(() => arg).IsOdd();
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-20)]
        public void IsPositive_ArgumentIsNegative_DoesNotThrow_int(int arg)
        {
            // Act/Assert
            Guard.That(() => arg).IsNegative();
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-20)]
        public void IsPositive_ArgumentIsNegative_DoesNotThrow_long(long arg)
        {
            // Act/Assert
            Guard.That(() => arg).IsNegative();
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        public void IsPositive_ArgumentIsNotNegative_Throws_int(int arg)
        {
            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsNegative());
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        public void IsPositive_ArgumentIsNotNegative_Throws_long(long arg)
        {
            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsNegative());
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        public void IsPositive_ArgumentIsNotPositive_Throws_int(int arg)
        {
            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsPositive());
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        public void IsPositive_ArgumentIsNotPositive_Throws_long(long arg)
        {
            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsPositive());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(20)]
        public void IsPositive_ArgumentIsPositive_DoesNotThrow_int(int arg)
        {
            // Act/Assert
            Guard.That(() => arg).IsPositive();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(20)]
        public void IsPositive_ArgumentIsPositive_DoesNotThrow_long(long arg)
        {
            // Act/Assert
            Guard.That(() => arg).IsPositive();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        public void IsPrime_ArgumentIsNotPrime_Throws_int(int arg)
        {
            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsPrime());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void IsPrime_ArgumentIsPrime_DoesNotThrow_int(int arg)
        {
            // Act/Assert
            Guard.That(() => arg).IsPrime();
        }

        #endregion Public Methods
    }
}
