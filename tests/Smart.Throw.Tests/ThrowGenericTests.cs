using System;
using System.Collections.Generic;
using Smart.Throw.Generic;
using Xunit;

namespace Smart.Throw.Tests
{
    public class ThrowGenericTests
    {
        #region correct input

        [Fact]
        [Trait("Throw", "CorrectInput")]
        public void If_CorrectInput_ShouldNotThrowAnything()
        {
            var record = Record.Exception(() => Throw<Exception>.If(false));
            Assert.Null(record);
        }

        [Fact]
        [Trait("Throw", "CorrectInput")]
        public void IfNull_CorrectInput_ShouldNotThrowAnything()
        {
            var record = Record.Exception(() => Throw<ArgumentNullException>.IfNull(""));
            Assert.Null(record);
        }

        [Fact]
        [Trait("Throw", "CorrectInput")]
        public void IfAnyNull_CorrectInput_ShouldNotThrowAnything()
        {
            var record = Record.Exception(() => Throw<ArgumentNullException>.IfAnyNull("", "", ""));
            Assert.Null(record);
        }

        [Fact]
        [Trait("Throw", "CorrectInput")]
        public void IfNullOrEmpty_CorrectInput_ShouldNotThrowAnything()
        {
            var record = Record.Exception(() => Throw<Exception>.IfNullOrEmpty("test"));
            Assert.Null(record);
        }

        [Fact]
        [Trait("Throw", "CorrectInput")]
        public void IfNullOrEmpty_Collection_CorrectInput_ShouldNotThrowAnything()
        {
            var record = Record.Exception(() => Throw<ArgumentNullException>.IfNullOrEmpty("test"));
            Assert.Null(record);
        }

        [Fact]
        [Trait("Throw", "CorrectInput")]
        public void IfNullOrWhiteSpace_CorrectInput_ShouldNotThrowAnything()
        {
            var record = Record.Exception(() => Throw<ArgumentException>.IfNullOrWhiteSpace("test"));
            Assert.Null(record);
        }

        #endregion

        #region wrong input

        [Fact]
        [Trait("Throw", "WrongInput")]
        public void If_CorrectInput_ShouldThrowException()
        {
            Assert.Throws<Exception>(() => Throw<Exception>.If(true));
            Assert.Throws<ArgumentException>(() => Throw<ArgumentException>.If(true));
            Assert.Throws<ArgumentNullException>(() => Throw<ArgumentNullException>.If(true));
            Assert.Throws<InvalidCastException>(() => Throw<InvalidCastException>.If(true));
            Assert.Throws<ArithmeticException>(() => Throw<ArithmeticException>.If(true));
            Assert.Throws<BadImageFormatException>(() => Throw<BadImageFormatException>.If(true));
        }

        [Fact]
        [Trait("Throw", "WrongInput")]
        public void IfNull_CorrectInput_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => Throw<ArgumentNullException>.IfNull(null));
        }

        [Theory]
        [Trait("Throw", "WrongInput")]
        [InlineData(null, "", "")]
        [InlineData("", null, "")]
        [InlineData("", "", null)]
        public void IfAnyNull_WrongInput_ShouldThrowException(string param1, string param2, string param3)
        {
            Assert.Throws<ArgumentNullException>(() => Throw<ArgumentNullException>.IfAnyNull(param1, param2, param3));
        }

        [Theory]
        [Trait("Throw", "WrongInput")]
        [InlineData(null)]
        [InlineData("")]
        public void IfNullOrEmpty_WrongInput_ShouldThrowException(string param)
        {
            Assert.Throws<Exception>(() => Throw<Exception>.IfNullOrEmpty(param));
        }

        [Fact]
        [Trait("Throw", "WrongInput")]
        public void IfNullOrEmpty_Collection_WrongInput_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => Throw<ArgumentNullException>.IfNullOrEmpty(null));
            Assert.Throws<ArgumentException>(() => Throw<ArgumentException>.IfNullOrEmpty(new List<string>()));
        }

        [Theory]
        [Trait("Throw", "WrongInput")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void IfNullOrWhiteSpace_WrongInput_ShouldThrowException(string param)
        {
            Assert.Throws<ArgumentException>(() => Throw<ArgumentException>.IfNullOrWhiteSpace(param));
        }

        #endregion
    }
}
