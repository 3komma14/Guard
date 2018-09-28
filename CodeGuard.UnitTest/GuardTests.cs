using CodeGuard.dotNetCore.Validators;
using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests
{
    public class GuardTests : BaseTests
    {
        #region Public Interfaces

        public interface ITest
        {
            #region Public Properties
            int Prop { get; set; }
            #endregion Public Properties

            #region Public Methods

            void Ping();

            #endregion Public Methods
        }

        #endregion Public Interfaces

        #region Public Methods

        [Fact]
        public void Is_WhenArgumentDoesNotImplementType_Throws()
        {
            // Arrange
            var someArg = new NotImplementationOfITest();

            // Act/Assert
            ArgumentException exception =
                GetException<ArgumentException>(() => Guard.That(() => someArg).Is(typeof(ITest)));

            // Assert
            AssertArgumentException(exception, "someArg", "Value is not <ITest>\r\nParameter name: someArg");
        }

        [Fact]
        public void Is_WhenArgumentImplementsType_DoesNotThrow()
        {
            // Arrange
            var arg1 = new ImplementationOfITest();

            // Act/Assert
            //Assert.DoesNotThrow(() =>
            Guard.That(() => arg1).Is(typeof(ITest));
        }

        [Fact]
        public void Is_WhenArgumentIsSameType_DoesNotThrow()
        {
            // Arrange
            int arg1 = 0;

            // Act/Assert
            //Assert.DoesNotThrow(() =>
            Guard.That(() => arg1).Is(typeof(int));
        }

        [Fact]
        public void Is_WhenArgumentIsWrongType_Throws()
        {
            // Arrange
            int myArg = 0;

            // Act
            ArgumentException exception =
                GetException<ArgumentException>(() => Guard.That(() => myArg).Is(typeof(string)));

            // Assert
            AssertArgumentException(exception, "myArg", "Value is not <String>\r\nParameter name: myArg");
        }

        [Fact]
        public void IsEqual_WhenArgumentIsProperty_Throws()
        {
            // Arrange
            var obj = new PropertyTest();

            // Act/Assert
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => obj.RunGuard());

            // Assert
            AssertArgumentNotEqualException(exception, "Prop", obj.Prop, 1);
        }

        [Fact]
        public void That_ArgumentNameSuppliedAndError_ThrowsAndUsedArgumentName()
        {
            // Arrange
            int arg1 = 0;

            // Act
            ArgumentException exception =
                GetException<ArgumentException>(() => Guard.That(arg1, "MyName").Is(typeof(string)));

            // Assert
            AssertArgumentException(exception, "MyName", "Value is not <String>\r\nParameter name: MyName");
        }

        [Fact]
        public void That_CalledWithFunc_MessageHandlerISet()
        {
            // Arrange
            int arg1 = 0;

            // Act
            var actual = Guard.That(() => arg1);

            // Assert
            Assert.NotNull(actual.Message);
        }

        [Fact]
        public void That_CalledWithValue_MessageHandlerISet()
        {
            // Arrange
            int arg1 = 0;

            // Act
            var actual = Guard.That(arg1);

            // Assert
            Assert.NotNull(actual.Message);
        }

        [Fact]
        public void That_CalledWithValueAndName_MessageHandlerISet()
        {
            // Arrange
            int arg1 = 0;

            // Act
            var actual = Guard.That(arg1, "MyName");

            // Assert
            Assert.NotNull(actual.Message);
        }

        #endregion Public Methods

        #region Public Classes

        public class ImplementationOfITest : ITest
        {
            #region Public Properties
            public int Prop { get; set; }
            #endregion Public Properties

            #region Public Methods

            public void Ping()
            {
                throw new NotImplementedException();
            }

            #endregion Public Methods
        }

        public class NotImplementationOfITest
        {
            #region Public Methods

            public void Echo()
            {
                throw new NotImplementedException();
            }

            #endregion Public Methods
        }

        public class PropertyTest
        {
            #region Public Properties
            public int Prop { get; set; }
            #endregion Public Properties

            #region Public Methods

            public void RunGuard()
            {
                Guard.That(() => Prop).IsEqual(1);
            }

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}
