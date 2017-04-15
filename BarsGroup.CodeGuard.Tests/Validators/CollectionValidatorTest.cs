using System.Collections;
using System.Collections.Generic;
using BarsGroup.CodeGuard.Exceptions;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.Tests.Validators
{
    public class CollectionValidatorTest
    {
        [Fact]
        public void IsNotEmpty_EmptyCollection_Throws()
        {
            var list = new List<string>() ;

            Assert.Throws<ArgumentException>(() => { Guard.That<ICollection>(list).IsNotEmpty(); });
        }

        [Fact]
        public void IsNotEmpty_NotEmptyCollection_NotThrows()
        {
            var list = new List<string> {string.Empty};

            Guard.That<ICollection>(list).IsNotEmpty();
        }
    }
}