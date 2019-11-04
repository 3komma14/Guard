using CodeGuard.dotNetCore.Validators;
using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests
{
    public abstract class GenericBaseClass<TContext> where TContext : class
    {
        #region Protected Constructors

        protected GenericBaseClass(TContext dbContext)
        {
            Guard.That(() => dbContext).NotNull();
            DbContext = dbContext;
        }

        #endregion Protected Constructors

        #region Protected Properties
        protected TContext DbContext { get; private set; }
        #endregion Protected Properties
    }

    public class MyContext
    {
        // Dummy context
    }

    public class ReflectionTests : BaseTests
    {
        #region Public Methods

        [Fact]
        public void FuncOfT_Used_DoesNotThrow()
        {
            string myArg = "s";
            Guard.That(() => myArg).NotNull();
        }

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
            AssertArgumentNullException(exception, "dbContext", "Value cannot be null. (Parameter 'dbContext')");
        }

        #endregion Public Methods
    }

    public class TestBadImageFormat : GenericBaseClass<MyContext>
    {
        #region Public Constructors

        public TestBadImageFormat(MyContext dbContext)
            : base(dbContext)
        {
        }

        #endregion Public Constructors
    }
}
