using System;
using Xunit;

namespace TableBooker.Tests.Processor
{
    public class TableBookerProcessorTest
    {
        [Fact]
        public void ShouldReturnTheSameDataEntered()
        {
            //Arrange
            var _request = new TableBooker
            {
                Name = "Pedro",
                LastName = "Díaz",
                BookerDate = new DateTime(2021, 10, 15),
                Email = "tekuzeros@tekus.co"
            };

            var _processor = new TableBookerProcessor();

            //Act
            var result = _processor.BookTable(_request);

            //Asserts
            Assert.NotNull(result);
            Assert.Equal(_request.Name, result.Name);
            Assert.Equal(_request.LastName, result.LastName);
            Assert.Equal(_request.BookerDate, result.BookerDate);
            Assert.Equal(_request.Email, result.Email);
        }
    }
}
