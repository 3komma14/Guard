using BarsGroup.CodeGuard.Validators;
using System;
using Xunit;

namespace BarsGroup.CodeGuard.Tests
{
    
    public class ReflectionTests : BaseTests
    {
        [Fact]
        public void GenericBaseClass_Called_DoesNotCauseBadImageFormatException()
        {
            // Arrange
            // Act
            var exception = GetException<ArgumentNullException>(() =>
                                                              {
                                                                  var t = new TestBadImageFormat(null);
                                                              });

            // Assert
            AssertArgumentNullException(exception, "dbContext", "Value cannot be null.\r\nParameter name: dbContext");
        }

        [Fact]
        public void FuncOfT_Used_DoesNotThrow()
        {
            var myArg = "s";
            Guard.That(myArg).IsNotNull();
        }
    }

    public class MyContext
    {
        // Dummy context
    }

    public class TestBadImageFormat : GenericBaseClass<MyContext>
    {
        public TestBadImageFormat(MyContext dbContext)
            : base(dbContext)
        {
        }
    }

    public abstract class GenericBaseClass<TContext> where TContext : class
    {
        protected TContext DbContext { get; private set; }

        protected GenericBaseClass(TContext dbContext)
        {
            Guard.That(dbContext, nameof(dbContext)).IsNotNull();
            DbContext = dbContext;
        }
    }
}