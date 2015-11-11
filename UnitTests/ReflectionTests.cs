using System;
using NUnit.Framework;
using Seterlund.CodeGuard.Validators;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class ReflectionTests : BaseTests
    {
        [Test]
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

        [Test]
        public void FuncOfT_Used_DoesNotThrow()
        {
            string myArg = "s";
            Guard.That(() => myArg).IsNotNull();
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
            Guard.That(() => dbContext).IsNotNull();
            DbContext = dbContext;
        }
    }
}