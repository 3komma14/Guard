using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    class ArrayValidatorTests
    {
        [Test]
        public void IsEmpty_ArgumentIsNotEmptyArray_DoesNotThrow()
        {
            // Arrange
            var arg = new string[] { "item1" };

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).IsNotEmpty());
        }

        [Test]
        public void IsEmpty_ArgumentIsEmptyArray_Throws()
        {
            // Arrange
            var arg = new string[0];

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).IsNotEmpty());
        }

        [Test]
        public void CountIs_ArgumentHasMoreItems_Throws()
        {
            // Arrange
            var arg = new string[] { "item1", "item2" };

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).CountIs(1));
        }

        [Test]
        public void CountIs_ArgumentHasCorrectCount_DoesNotThrow()
        {
            // Arrange
            var arg = new string[] { "item1", "item2" };

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).CountIs(2));
        }
    }
}
