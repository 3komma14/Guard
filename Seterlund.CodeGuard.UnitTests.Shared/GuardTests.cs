using System;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class GuardTests : BaseTests
    {
        #region ----- Fixture setup -----

        /// <summary>
        /// Called once before first test is executed
        /// </summary>
        [TestFixtureSetUp]
        public void Init()
        {
            // Init tests
        }

        /// <summary>
        /// Called once after last test is executed
        /// </summary>
        [TestFixtureTearDown]
        public void Cleanup()
        {
            // Cleanup tests
        }

        #endregion

        #region ------ Test setup -----

        /// <summary>
        /// Called before each test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Setup test
        }

        /// <summary>
        /// Called before each test
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            // Cleanup after test       
        }

        #endregion

        [Test]
        public void That_CalledWithFunc_MessageHandlerISet()
        {
            // Arrange
            int arg1 = 0;

            // Act
            var actual = Guard.That(() => arg1);

            // Assert
            Assert.IsNotNull(actual.Message);
        }

        [Test]
        public void That_CalledWithValue_MessageHandlerISet()
        {
            // Arrange
            int arg1 = 0;

            // Act
            var actual = Guard.That(arg1);

            // Assert
            Assert.IsNotNull(actual.Message);
        }

        [Test]
        public void That_CalledWithValueAndName_MessageHandlerISet()
        {
            // Arrange
            int arg1 = 0;

            // Act
            var actual = Guard.That(arg1, "MyName");

            // Assert
            Assert.IsNotNull(actual.Message);
        }


        [Test]
        public void Is_WhenArgumentIsSameType_DoesNotThrow()
        {
            // Arrange
            int arg1 = 0;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).Is(typeof(int));
            });
        }

        [Test]
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

        [Test]
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


        [Test]
        public void Is_WhenArgumentImplementsType_DoesNotThrow()
        {
            // Arrange
            var arg1 = new ImplementationOfITest();

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).Is(typeof(ITest));
            });
        }

        [Test]
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

        [Test]
        public void IsEqual_WhenArgumentIsProperty_Throws()
        {
            // Arrange
            var obj = new PropertyTest();

            // Act/Assert
            ArgumentException exception =
                GetException<ArgumentException>(() => obj.RunGuard());

            // Assert
            AssertArgumentException(exception, "Prop", "Specified argument was out of the range of valid values.\r\nParameter name: Prop");
        }


        public class PropertyTest
        {
            public int Prop { get; set; }

            public void RunGuard()
            {
                Guard.That(() => Prop).IsEqual(1);
            }
        }

        public interface ITest 
        {
            int Prop { get; set; }
            void Ping();
        }

        public class ImplementationOfITest : ITest
        {
            public int Prop { get; set; }

            public void Ping()
            {
                throw new NotImplementedException();
            }
        }

        public class NotImplementationOfITest
        {
            public void Echo()
            {
                throw new NotImplementedException();
            }
        }


    }
}
