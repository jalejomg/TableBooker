using Moq;
using System;
using TableBooker.Repositories;
using Xunit;

namespace TableBooker.Tests.Processor
{
    public class TableBookerProcessorTest
    {
        private readonly TableBookerProcessor _processor;
        private Mock<ITableBookerRepository> _tableBookerRepository;

        public TableBookerProcessorTest()
        {
            _tableBookerRepository = new Mock<ITableBookerRepository>();

            _processor = new TableBookerProcessor(_tableBookerRepository.Object);
        }

        [Fact]
        public void ShouldReturnTheSameDataEntered()
        {
            //Arrange
            var _request = new TableBooking
            {
                Name = "Pedro",
                LastName = "Díaz",
                BookerDate = new DateTime(2021, 10, 15),
                Email = "tekuzeros@tekus.co"
            };

            //Act
            var result = _processor.BookTable(_request);

            //Asserts
            Assert.NotNull(result);
            Assert.Equal(_request.Name, result.Name);
            Assert.Equal(_request.LastName, result.LastName);
            Assert.Equal(_request.BookerDate, result.BookerDate);
            Assert.Equal(_request.Email, result.Email);
        }

        [Fact]
        public void ShouldThorwArgumentNullExceptionIfRequestArgumentIsNull()
        {
            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookTable(null));

            //Asserts
            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveTableBookerOnDataBase()
        {
            //Arrange
            var _request = new TableBooking
            {
                Name = "Pedro",
                LastName = "Díaz",
                BookerDate = new DateTime(2021, 10, 15),
                Email = "tekuzeros@tekus.co"
            };

            TableBooking savedTableBooker = null;

            _tableBookerRepository.Setup(repository => repository.Save(It.IsAny<TableBooking>()))
                .Callback<TableBooking>(tableBooker =>
                    savedTableBooker = tableBooker
                );

            //Act
            var result = _processor.BookTable(_request);

            //Asserts
            _tableBookerRepository.Verify(repository => repository.Save(It.IsAny<TableBooking>()), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(savedTableBooker.Name, result.Name);
            Assert.Equal(savedTableBooker.LastName, result.LastName);
            Assert.Equal(savedTableBooker.BookerDate, result.BookerDate);
            Assert.Equal(savedTableBooker.Email, result.Email);
        }
    }
}
