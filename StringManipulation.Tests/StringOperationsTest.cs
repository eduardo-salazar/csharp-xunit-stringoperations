using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace StringManipulation.Tests
{
	public class StringOperationsTest
	{
        //[Theory(Skip = "This is a demo of how to skip a test")]
        [Theory]
        [InlineData("Hola", "world", "Hola world")]
        public void ConcatenateStrings(string str1, string str2, string expected)
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.ConcatenateStrings(str1, str2);

            //Asserts
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("ama",true)]
        [InlineData("notPalindrome", false)]
        public void IsPalindrome(string word, bool expected)
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome(word);

            // Asserts
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Hola World","HolaWorld")]
        public void RemoveWhitespace(string word, string expected)
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.RemoveWhitespace(word);

            // Asserts
            Assert.NotEmpty(result);
            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.QuantintyInWords("cat", 10);

            // Asserts
            Assert.StartsWith("ten", result);
            Assert.Contains("cat", result);
        }

        [Fact]
        public void GetStringLength_Exception()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act

            // Asserts
            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }

        [Fact]
        public void GetStringLength()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.GetStringLength("helloworld");

            // Asserts
            Assert.Equal(10, result);
        }

        [Fact]
        public void TruncateString_Exception()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act

            // Asserts
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strOperations.TruncateString("mesgagmedia",-1));
        }

        [Theory]
        [InlineData("hello world",5,"hello")]
        [InlineData("", 1, "")]
        public void TruncateString(string input, int maxLength, string expected)
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.TruncateString(input, maxLength);

            // Asserts
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("V",5)]
        [InlineData("I",1)]
        [InlineData("X", 10)]
        public void FromRomanToNumber(string romanString, int expected)
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.FromRomanToNumber(romanString);

            // Asserts
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountOccurrences()
        {
            // Arrange
            var fakeLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(fakeLogger.Object);
           

            // Act
            var result = strOperations.CountOccurrences("Mesgage Media", 'M');

            // Asserts
            Assert.Equal(2, result);

        }

        [Fact]
        public void ReadFile()
        {
            // Arrange
            var strOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(reader => reader.ReadString(It.IsAny<string>())).Returns("Mocked File");

            // Act 
            var result = strOperations.ReadFile(mockFileReader.Object, "anyfileName.txt");

            // Asserts
            Assert.Equal("Mocked File", result);
        }

        [Theory]
        [InlineData("cat", "cats")]
        [InlineData("apple", "apples")]
        [InlineData("city", "cities")]
        public void Pluralize(string input, string expected)
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.Pluralize(input);

            // Asserts
            Assert.Equal(expected, result);
        }
    }
}

