using BarsGroup.CodeGuard.Exceptions;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.Tests
{
    public class GuardTests : BaseTests
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
        public void Is_WhenArgumentIsSameType_DoesNotThrow()
        {
            // Arrange
            var arg1 = 0;

            // Act/Assert
            Guard.That(arg1).Is(typeof(int));
        }

        [Fact]
        public void That_ArgumentNameSuppliedAndError_ThrowsAndUsedArgumentName()
        {
            // Arrange
            var arg1 = 0;

            // Act
            var exception = 
                GetException<ArgumentException>(() => Guard.That(arg1, "MyName").Is(typeof(string)));

            // Assert
            AssertArgumentException(exception, "Value is not <String>", "MyName");
        }


        [Fact]
        public void Is_WhenArgumentImplementsType_DoesNotThrow()
        {
            // Arrange
            var arg1 = new ImplementationOfITest();

            // Act/Assert
            Guard.That(arg1).Is(typeof(ITest));
        }

        [Fact]
        public void Is_WhenArgumentDoesNotImplementType_Throws()
        {
            // Arrange
            var someArg = new NotImplementationOfITest();

            // Act/Assert
            var exception = GetException<ArgumentException>(() => Guard.That(someArg, nameof(someArg)).Is(typeof(ITest)));
        
            // Assert
            AssertArgumentException(exception, "Value is not <ITest>", "someArg");
        }

        [Fact]
        public void IsEqual_WhenArgumentIsProperty_Throws()
        {
            // Arrange
            var obj = new PropertyTest();

            // Act/Assert
            var exception = GetException<NotExpectedException<int>>(() => obj.RunGuard());

            // Assert
            AssertNotExpectedException(exception, "Prop", obj.Prop, 1);
        }


        public class PropertyTest
        {
            public int Prop { get; set; }

            public void RunGuard()
            {
                Guard.That(Prop, nameof(Prop)).IsEqual(1);
            }
        }

        public interface ITest 
        {
        }

        public class ImplementationOfITest : ITest
        {
        }

        public class NotImplementationOfITest
        {
        }


    }
}
